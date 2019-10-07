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

/// <summary>Efl UI video class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.Video.NativeMethods]
[Efl.Eo.BindingEntity]
public class Video : Efl.Ui.LayoutBase, Efl.IFile, Efl.IPlayer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Video))
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
        efl_ui_video_class_get();

    /// <summary>Initializes a new instance of the <see cref="Video"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
/// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Video(Efl.Object parent
            , System.String style = null) : base(efl_ui_video_class_get(), parent)
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
    protected Video(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Video"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Video(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Video"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Video(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Whether the object can remember the last played position.
    /// Note: This API only serves as indication. System support is required.</summary>
    /// <returns><c>true</c> when the object can remember the last position, <c>false</c> otherwise</returns>
    public virtual bool GetRememberPosition() {
        var _ret_var = Efl.Ui.Video.NativeMethods.efl_ui_video_remember_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Whether the object can remember the last played position.
    /// Note: This API only serves as indication. System support is required.</summary>
    /// <param name="remember"><c>true</c> when the object can remember the last position, <c>false</c> otherwise</param>
    public virtual void SetRememberPosition(bool remember) {
        Efl.Ui.Video.NativeMethods.efl_ui_video_remember_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),remember);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The underlying Emotion object.</summary>
    /// <returns>The underlying Emotion object.</returns>
    public virtual Efl.Canvas.Object GetEmotion() {
        var _ret_var = Efl.Ui.Video.NativeMethods.efl_ui_video_emotion_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The title (for instance DVD title) from this emotion object.
    /// This function is only useful when playing a DVD.
    /// 
    /// Note: Don&apos;t change or free the string returned by this function.</summary>
    /// <returns>A string containing the title.</returns>
    public virtual System.String GetTitle() {
        var _ret_var = Efl.Ui.Video.NativeMethods.efl_ui_video_title_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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

    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    public virtual bool GetPlaying() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playing_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    public virtual bool SetPlaying(bool playing) {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playing_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),playing);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
    public virtual bool GetPaused() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_paused_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    public virtual bool SetPaused(bool paused) {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_paused_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),paused);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="Efl.IPlayer.Playing"/> or <see cref="Efl.IPlayer.Paused"/> states of the media file.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sec">The position (in seconds).</param>
    public virtual void SetPlaybackPosition(double sec) {
        Efl.PlayerConcrete.NativeMethods.efl_player_playback_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sec);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The progress within the [0, 1] range.</returns>
    public virtual double GetPlaybackProgress() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playback_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    public virtual double GetPlaybackSpeed() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playback_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    public virtual void SetPlaybackSpeed(double speed) {
        Efl.PlayerConcrete.NativeMethods.efl_player_playback_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),speed);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Whether the object can remember the last played position.
    /// Note: This API only serves as indication. System support is required.</summary>
    /// <value><c>true</c> when the object can remember the last position, <c>false</c> otherwise</value>
    public bool RememberPosition {
        get { return GetRememberPosition(); }
        set { SetRememberPosition(value); }
    }

    /// <summary>The underlying Emotion object.</summary>
    /// <value>The underlying Emotion object.</value>
    public Efl.Canvas.Object Emotion {
        get { return GetEmotion(); }
    }

    /// <summary>The title (for instance DVD title) from this emotion object.
    /// This function is only useful when playing a DVD.
    /// 
    /// Note: Don&apos;t change or free the string returned by this function.</summary>
    /// <value>A string containing the title.</value>
    public System.String Title {
        get { return GetTitle(); }
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

    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    public bool Playing {
        get { return GetPlaying(); }
        set { SetPlaying(value); }
    }

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
    public bool Paused {
        get { return GetPaused(); }
        set { SetPaused(value); }
    }

    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The progress within the [0, 1] range.</value>
    public double PlaybackProgress {
        get { return GetPlaybackProgress(); }
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The play speed in the [0, infinity) range.</value>
    public double PlaybackSpeed {
        get { return GetPlaybackSpeed(); }
        set { SetPlaybackSpeed(value); }
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Video.efl_ui_video_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.LayoutBase.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_video_remember_position_get_static_delegate == null)
            {
                efl_ui_video_remember_position_get_static_delegate = new efl_ui_video_remember_position_get_delegate(remember_position_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRememberPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_video_remember_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_remember_position_get_static_delegate) });
            }

            if (efl_ui_video_remember_position_set_static_delegate == null)
            {
                efl_ui_video_remember_position_set_static_delegate = new efl_ui_video_remember_position_set_delegate(remember_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRememberPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_video_remember_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_remember_position_set_static_delegate) });
            }

            if (efl_ui_video_emotion_get_static_delegate == null)
            {
                efl_ui_video_emotion_get_static_delegate = new efl_ui_video_emotion_get_delegate(emotion_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetEmotion") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_video_emotion_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_emotion_get_static_delegate) });
            }

            if (efl_ui_video_title_get_static_delegate == null)
            {
                efl_ui_video_title_get_static_delegate = new efl_ui_video_title_get_delegate(title_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTitle") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_video_title_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_title_get_static_delegate) });
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
            return Efl.Ui.Video.efl_ui_video_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_video_remember_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_video_remember_position_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_get_api_delegate> efl_ui_video_remember_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_get_api_delegate>(Module, "efl_ui_video_remember_position_get");

        private static bool remember_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_video_remember_position_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Video)ws.Target).GetRememberPosition();
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
                return efl_ui_video_remember_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_video_remember_position_get_delegate efl_ui_video_remember_position_get_static_delegate;

        
        private delegate void efl_ui_video_remember_position_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool remember);

        
        public delegate void efl_ui_video_remember_position_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool remember);

        public static Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_set_api_delegate> efl_ui_video_remember_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_set_api_delegate>(Module, "efl_ui_video_remember_position_set");

        private static void remember_position_set(System.IntPtr obj, System.IntPtr pd, bool remember)
        {
            Eina.Log.Debug("function efl_ui_video_remember_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((Video)ws.Target).SetRememberPosition(remember);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_video_remember_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), remember);
            }
        }

        private static efl_ui_video_remember_position_set_delegate efl_ui_video_remember_position_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_ui_video_emotion_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_ui_video_emotion_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_video_emotion_get_api_delegate> efl_ui_video_emotion_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_emotion_get_api_delegate>(Module, "efl_ui_video_emotion_get");

        private static Efl.Canvas.Object emotion_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_video_emotion_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((Video)ws.Target).GetEmotion();
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
                return efl_ui_video_emotion_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_video_emotion_get_delegate efl_ui_video_emotion_get_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_ui_video_title_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_ui_video_title_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_video_title_get_api_delegate> efl_ui_video_title_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_title_get_api_delegate>(Module, "efl_ui_video_title_get");

        private static System.String title_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_video_title_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((Video)ws.Target).GetTitle();
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
                return efl_ui_video_title_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_video_title_get_delegate efl_ui_video_title_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiVideo_ExtensionMethods {
    public static Efl.BindableProperty<bool> RememberPosition<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<bool>("remember_position", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    public static Efl.BindableProperty<bool> Playing<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<bool>("playing", fac);
    }

    public static Efl.BindableProperty<bool> Paused<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<bool>("paused", fac);
    }

    public static Efl.BindableProperty<double> PlaybackSpeed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Video, T>magic = null) where T : Efl.Ui.Video {
        return new Efl.BindableProperty<double>("playback_speed", fac);
    }

}
#pragma warning restore CS1591
#endif
