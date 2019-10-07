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

namespace Vg {

/// <summary>Efl vector graphics class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.Vg.Object.NativeMethods]
[Efl.Eo.BindingEntity]
public class Object : Efl.Canvas.Object, Efl.IFile, Efl.IFileSave, Efl.Gfx.IFrameController
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Object))
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
        efl_canvas_vg_object_class_get();

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Object(Efl.Object parent= null
            ) : base(efl_canvas_vg_object_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Object(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Object(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Object"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Object(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Control how the viewbox is mapped to the vg canvas&apos;s viewport.</summary>
    /// <returns>Fill mode type</returns>
    public virtual Efl.Canvas.Vg.FillMode GetFillMode() {
        var _ret_var = Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_fill_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control how the viewbox is mapped to the vg canvas&apos;s viewport.</summary>
    /// <param name="fill_mode">Fill mode type</param>
    public virtual void SetFillMode(Efl.Canvas.Vg.FillMode fill_mode) {
        Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_fill_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),fill_mode);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The viewbox for the evas vg canvas. viewbox if set should be mapped to the canvas geometry when rendering the vg tree.</summary>
    /// <returns>viewbox for the vg canvas</returns>
    public virtual Eina.Rect GetViewbox() {
        var _ret_var = Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_viewbox_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The viewbox for the evas vg canvas. viewbox if set should be mapped to the canvas geometry when rendering the vg tree.</summary>
    /// <param name="viewbox">viewbox for the vg canvas</param>
    public virtual void SetViewbox(Eina.Rect viewbox) {
        Eina.Rect.NativeStruct _in_viewbox = viewbox;
Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_viewbox_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewbox);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control how the viewbox is positioned inside the viewport.</summary>
    /// <param name="align_x">Alignment in the horizontal axis (0 &lt;= align_x &lt;= 1).<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="align_y">Alignment in the vertical axis (0 &lt;= align_y &lt;= 1).<br/>The default value is <c>0.000000</c>.</param>
    public virtual void GetViewboxAlign(out double align_x, out double align_y) {
        Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_viewbox_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out align_x, out align_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Control how the viewbox is positioned inside the viewport.</summary>
    /// <param name="align_x">Alignment in the horizontal axis (0 &lt;= align_x &lt;= 1).<br/>The default value is <c>0.000000</c>.</param>
    /// <param name="align_y">Alignment in the vertical axis (0 &lt;= align_y &lt;= 1).<br/>The default value is <c>0.000000</c>.</param>
    public virtual void SetViewboxAlign(double align_x, double align_y) {
        Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_viewbox_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),align_x, align_y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The root node of the evas_object_vg.
    /// Note: To manually create the shape object and show in the Vg object canvas you must create the hierarchy and set as root node.
    /// 
    /// It takes the ownership of the root node.</summary>
    /// <returns>Root node of the VG canvas.</returns>
    public virtual Efl.Canvas.Vg.Node GetRootNode() {
        var _ret_var = Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_root_node_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The root node of the evas_object_vg.
    /// Note: To manually create the shape object and show in the Vg object canvas you must create the hierarchy and set as root node.
    /// 
    /// It takes the ownership of the root node.</summary>
    /// <param name="root">Root node of the VG canvas.</param>
    public virtual void SetRootNode(Efl.Canvas.Vg.Node root) {
        Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_root_node_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),root);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The default vector size that specified from vector resource.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual Eina.Size2D GetDefaultSize() {
        var _ret_var = Efl.Canvas.Vg.Object.NativeMethods.efl_canvas_vg_object_default_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    public virtual Eina.File GetMmap() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The file path.</returns>
    public virtual System.String GetFile() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
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
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
    public virtual System.String GetKey() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    public virtual void SetKey(System.String key) {
        Efl.FileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The load state of the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    public virtual bool GetLoaded() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.IFile.File"/> (or <see cref="Efl.IFile.Mmap"/>) and <see cref="Efl.IFile.Key"/> properties.
    /// In the case where <see cref="Efl.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.IFile.SetMmap"/> on the object using the opened file handle.
    /// 
    /// Calling <see cref="Efl.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>0 on success, error code otherwise</returns>
    public virtual Eina.Error Load() {
        var _ret_var = Efl.FileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
    /// <since_tizen> 6 </since_tizen>
    public virtual void Unload() {
        Efl.FileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Save the given image object&apos;s contents to an (image) file.
    /// The extension suffix on <c>file</c> will determine which saver module Evas is to use when saving, thus the final file&apos;s format. If the file supports multiple data stored in it (Eet ones), you can specify the key to be used as the index of the image in it.
    /// 
    /// You can specify some flags when saving the image.  Currently acceptable flags are <c>quality</c> and <c>compress</c>. Eg.: &quot;quality=100 compress=9&quot;.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="file">The filename to be used to save the image (extension obligatory).</param>
    /// <param name="key">The image key in the file (if an Eet one), or <c>null</c>, otherwise.</param>
    /// <param name="info">The flags to be used (<c>null</c> for defaults).</param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool Save(System.String file, System.String key, ref Efl.FileSaveInfo info) {
        Efl.FileSaveInfo.NativeStruct _in_info = info;
var _ret_var = Efl.FileSaveConcrete.NativeMethods.efl_file_save_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file, key, ref _in_info);
        Eina.Error.RaiseIfUnhandledException();
info = _in_info;
        return _ret_var;
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

    /// <summary>Control how the viewbox is mapped to the vg canvas&apos;s viewport.</summary>
    /// <value>Fill mode type</value>
    public Efl.Canvas.Vg.FillMode FillMode {
        get { return GetFillMode(); }
        set { SetFillMode(value); }
    }

    /// <summary>The viewbox for the evas vg canvas. viewbox if set should be mapped to the canvas geometry when rendering the vg tree.</summary>
    /// <value>viewbox for the vg canvas</value>
    public Eina.Rect Viewbox {
        get { return GetViewbox(); }
        set { SetViewbox(value); }
    }

    /// <summary>Control how the viewbox is positioned inside the viewport.</summary>
    /// <value>Alignment in the horizontal axis (0 &lt;= align_x &lt;= 1).</value>
    public (double, double) ViewboxAlign {
        get {
            double _out_align_x = default(double);
            double _out_align_y = default(double);
            GetViewboxAlign(out _out_align_x,out _out_align_y);
            return (_out_align_x,_out_align_y);
        }
        set { SetViewboxAlign( value.Item1,  value.Item2); }
    }

    /// <summary>The root node of the evas_object_vg.
    /// Note: To manually create the shape object and show in the Vg object canvas you must create the hierarchy and set as root node.
    /// 
    /// It takes the ownership of the root node.</summary>
    /// <value>Root node of the VG canvas.</value>
    public Efl.Canvas.Vg.Node RootNode {
        get { return GetRootNode(); }
        set { SetRootNode(value); }
    }

    /// <summary>The default vector size that specified from vector resource.</summary>
    /// <since_tizen> 6 </since_tizen>
    public Eina.Size2D DefaultSize {
        get { return GetDefaultSize(); }
    }

    /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }

    /// <summary>The file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }

    /// <summary>The key which corresponds to the target data within a file.
    /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }

    /// <summary>The load state of the object.</summary>
    /// <since_tizen> 6 </since_tizen>
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

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Vg.Object.efl_canvas_vg_object_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Canvas.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_canvas_vg_object_fill_mode_get_static_delegate == null)
            {
                efl_canvas_vg_object_fill_mode_get_static_delegate = new efl_canvas_vg_object_fill_mode_get_delegate(fill_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFillMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_fill_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_fill_mode_get_static_delegate) });
            }

            if (efl_canvas_vg_object_fill_mode_set_static_delegate == null)
            {
                efl_canvas_vg_object_fill_mode_set_static_delegate = new efl_canvas_vg_object_fill_mode_set_delegate(fill_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFillMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_fill_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_fill_mode_set_static_delegate) });
            }

            if (efl_canvas_vg_object_viewbox_get_static_delegate == null)
            {
                efl_canvas_vg_object_viewbox_get_static_delegate = new efl_canvas_vg_object_viewbox_get_delegate(viewbox_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewbox") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_viewbox_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_viewbox_get_static_delegate) });
            }

            if (efl_canvas_vg_object_viewbox_set_static_delegate == null)
            {
                efl_canvas_vg_object_viewbox_set_static_delegate = new efl_canvas_vg_object_viewbox_set_delegate(viewbox_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetViewbox") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_viewbox_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_viewbox_set_static_delegate) });
            }

            if (efl_canvas_vg_object_viewbox_align_get_static_delegate == null)
            {
                efl_canvas_vg_object_viewbox_align_get_static_delegate = new efl_canvas_vg_object_viewbox_align_get_delegate(viewbox_align_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewboxAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_viewbox_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_viewbox_align_get_static_delegate) });
            }

            if (efl_canvas_vg_object_viewbox_align_set_static_delegate == null)
            {
                efl_canvas_vg_object_viewbox_align_set_static_delegate = new efl_canvas_vg_object_viewbox_align_set_delegate(viewbox_align_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetViewboxAlign") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_viewbox_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_viewbox_align_set_static_delegate) });
            }

            if (efl_canvas_vg_object_root_node_get_static_delegate == null)
            {
                efl_canvas_vg_object_root_node_get_static_delegate = new efl_canvas_vg_object_root_node_get_delegate(root_node_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRootNode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_root_node_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_root_node_get_static_delegate) });
            }

            if (efl_canvas_vg_object_root_node_set_static_delegate == null)
            {
                efl_canvas_vg_object_root_node_set_static_delegate = new efl_canvas_vg_object_root_node_set_delegate(root_node_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRootNode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_root_node_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_root_node_set_static_delegate) });
            }

            if (efl_canvas_vg_object_default_size_get_static_delegate == null)
            {
                efl_canvas_vg_object_default_size_get_static_delegate = new efl_canvas_vg_object_default_size_get_delegate(default_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDefaultSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_vg_object_default_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_vg_object_default_size_get_static_delegate) });
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
            return Efl.Canvas.Vg.Object.efl_canvas_vg_object_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Canvas.Vg.FillMode efl_canvas_vg_object_fill_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Canvas.Vg.FillMode efl_canvas_vg_object_fill_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_fill_mode_get_api_delegate> efl_canvas_vg_object_fill_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_fill_mode_get_api_delegate>(Module, "efl_canvas_vg_object_fill_mode_get");

        private static Efl.Canvas.Vg.FillMode fill_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_fill_mode_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Canvas.Vg.FillMode _ret_var = default(Efl.Canvas.Vg.FillMode);
                try
                {
                    _ret_var = ((Object)ws.Target).GetFillMode();
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
                return efl_canvas_vg_object_fill_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_object_fill_mode_get_delegate efl_canvas_vg_object_fill_mode_get_static_delegate;

        
        private delegate void efl_canvas_vg_object_fill_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Vg.FillMode fill_mode);

        
        public delegate void efl_canvas_vg_object_fill_mode_set_api_delegate(System.IntPtr obj,  Efl.Canvas.Vg.FillMode fill_mode);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_fill_mode_set_api_delegate> efl_canvas_vg_object_fill_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_fill_mode_set_api_delegate>(Module, "efl_canvas_vg_object_fill_mode_set");

        private static void fill_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.FillMode fill_mode)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_fill_mode_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetFillMode(fill_mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_vg_object_fill_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), fill_mode);
            }
        }

        private static efl_canvas_vg_object_fill_mode_set_delegate efl_canvas_vg_object_fill_mode_set_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_canvas_vg_object_viewbox_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Rect.NativeStruct efl_canvas_vg_object_viewbox_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_get_api_delegate> efl_canvas_vg_object_viewbox_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_get_api_delegate>(Module, "efl_canvas_vg_object_viewbox_get");

        private static Eina.Rect.NativeStruct viewbox_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_viewbox_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Object)ws.Target).GetViewbox();
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
                return efl_canvas_vg_object_viewbox_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_object_viewbox_get_delegate efl_canvas_vg_object_viewbox_get_static_delegate;

        
        private delegate void efl_canvas_vg_object_viewbox_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct viewbox);

        
        public delegate void efl_canvas_vg_object_viewbox_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct viewbox);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_set_api_delegate> efl_canvas_vg_object_viewbox_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_set_api_delegate>(Module, "efl_canvas_vg_object_viewbox_set");

        private static void viewbox_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct viewbox)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_viewbox_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Rect _in_viewbox = viewbox;

                try
                {
                    ((Object)ws.Target).SetViewbox(_in_viewbox);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_vg_object_viewbox_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), viewbox);
            }
        }

        private static efl_canvas_vg_object_viewbox_set_delegate efl_canvas_vg_object_viewbox_set_static_delegate;

        
        private delegate void efl_canvas_vg_object_viewbox_align_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double align_x,  out double align_y);

        
        public delegate void efl_canvas_vg_object_viewbox_align_get_api_delegate(System.IntPtr obj,  out double align_x,  out double align_y);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_align_get_api_delegate> efl_canvas_vg_object_viewbox_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_align_get_api_delegate>(Module, "efl_canvas_vg_object_viewbox_align_get");

        private static void viewbox_align_get(System.IntPtr obj, System.IntPtr pd, out double align_x, out double align_y)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_viewbox_align_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                align_x = default(double);align_y = default(double);
                try
                {
                    ((Object)ws.Target).GetViewboxAlign(out align_x, out align_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_vg_object_viewbox_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out align_x, out align_y);
            }
        }

        private static efl_canvas_vg_object_viewbox_align_get_delegate efl_canvas_vg_object_viewbox_align_get_static_delegate;

        
        private delegate void efl_canvas_vg_object_viewbox_align_set_delegate(System.IntPtr obj, System.IntPtr pd,  double align_x,  double align_y);

        
        public delegate void efl_canvas_vg_object_viewbox_align_set_api_delegate(System.IntPtr obj,  double align_x,  double align_y);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_align_set_api_delegate> efl_canvas_vg_object_viewbox_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_viewbox_align_set_api_delegate>(Module, "efl_canvas_vg_object_viewbox_align_set");

        private static void viewbox_align_set(System.IntPtr obj, System.IntPtr pd, double align_x, double align_y)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_viewbox_align_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetViewboxAlign(align_x, align_y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_vg_object_viewbox_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), align_x, align_y);
            }
        }

        private static efl_canvas_vg_object_viewbox_align_set_delegate efl_canvas_vg_object_viewbox_align_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Vg.Node efl_canvas_vg_object_root_node_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Vg.Node efl_canvas_vg_object_root_node_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_root_node_get_api_delegate> efl_canvas_vg_object_root_node_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_root_node_get_api_delegate>(Module, "efl_canvas_vg_object_root_node_get");

        private static Efl.Canvas.Vg.Node root_node_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_root_node_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Canvas.Vg.Node _ret_var = default(Efl.Canvas.Vg.Node);
                try
                {
                    _ret_var = ((Object)ws.Target).GetRootNode();
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
                return efl_canvas_vg_object_root_node_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_object_root_node_get_delegate efl_canvas_vg_object_root_node_get_static_delegate;

        
        private delegate void efl_canvas_vg_object_root_node_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node root);

        
        public delegate void efl_canvas_vg_object_root_node_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Vg.Node root);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_root_node_set_api_delegate> efl_canvas_vg_object_root_node_set_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_root_node_set_api_delegate>(Module, "efl_canvas_vg_object_root_node_set");

        private static void root_node_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Vg.Node root)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_root_node_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Object)ws.Target).SetRootNode(root);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_vg_object_root_node_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), root);
            }
        }

        private static efl_canvas_vg_object_root_node_set_delegate efl_canvas_vg_object_root_node_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_canvas_vg_object_default_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_canvas_vg_object_default_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_canvas_vg_object_default_size_get_api_delegate> efl_canvas_vg_object_default_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_canvas_vg_object_default_size_get_api_delegate>(Module, "efl_canvas_vg_object_default_size_get");

        private static Eina.Size2D.NativeStruct default_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_canvas_vg_object_default_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((Object)ws.Target).GetDefaultSize();
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
                return efl_canvas_vg_object_default_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_canvas_vg_object_default_size_get_delegate efl_canvas_vg_object_default_size_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Canvas_VgObject_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Canvas.Vg.FillMode> FillMode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<Efl.Canvas.Vg.FillMode>("fill_mode", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Viewbox<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<Eina.Rect>("viewbox", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Vg.Node> RootNode<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<Efl.Canvas.Vg.Node>("root_node", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    public static Efl.BindableProperty<int> Frame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.Vg.Object, T>magic = null) where T : Efl.Canvas.Vg.Object {
        return new Efl.BindableProperty<int>("frame", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Canvas {

namespace Vg {

/// <summary>Enumeration that defines how viewbox will be filled int the vg canvs&apos;s viewport. default Fill_Mode is <c>none</c></summary>
[Efl.Eo.BindingEntity]
public enum FillMode
{
/// <summary>Don&apos;t scale the viewbox. Placed it inside viewport taking align property into account</summary>
None = 0,
/// <summary>Scale the viewbox so that it matches the canvas viewport. Aaspect ratio might be changed.</summary>
Stretch = 1,
/// <summary>Scale the viewbox so that it fits inside canvas viewport while maintaining the aspect ratio. At least one of the dimensions of the viewbox should be equal to the corresponding dimension of the viewport.</summary>
Meet = 2,
/// <summary>Scale the viewbox so that it covers the entire canvas viewport while maintaining the aspect ratio. At least one of the dimensions of the viewbox should be equal to the corresponding dimension of the viewport.</summary>
Slice = 3,
}
}
}
}

