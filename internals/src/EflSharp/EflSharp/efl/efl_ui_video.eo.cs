#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI video class</summary>
[VideoNativeInherit]
public class Video : Efl.Ui.LayoutBase, Efl.Eo.IWrapper,Efl.IFile,Efl.IPlayer
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (Video))
                return Efl.Ui.VideoNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_video_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    ///<param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle"/></param>
    public Video(Efl.Object parent
            , System.String style = null) :
        base(efl_ui_video_class_get(), typeof(Video), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected Video(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected Video(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
    }
    /// <summary>Set whether the object can remember the last played position.
    /// Note: This API only serves as indication. System support is required.</summary>
    /// <returns><c>true</c> when the object can remember the last position, <c>false</c> otherwise</returns>
    virtual public bool GetRememberPosition() {
         var _ret_var = Efl.Ui.VideoNativeInherit.efl_ui_video_remember_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set whether the object can remember the last played position.
    /// Note: This API only serves as indication. System support is required.</summary>
    /// <param name="remember"><c>true</c> when the object can remember the last position, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetRememberPosition( bool remember) {
                                 Efl.Ui.VideoNativeInherit.efl_ui_video_remember_position_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), remember);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the underlying Emotion object.</summary>
    /// <returns>The underlying Emotion object.</returns>
    virtual public Efl.Canvas.Object GetEmotion() {
         var _ret_var = Efl.Ui.VideoNativeInherit.efl_ui_video_emotion_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the title (for instance DVD title) from this emotion object.
    /// This function is only useful when playing a DVD.
    /// 
    /// Note: Don&apos;t change or free the string returned by this function.</summary>
    /// <returns>A string containing the title.</returns>
    virtual public System.String GetTitle() {
         var _ret_var = Efl.Ui.VideoNativeInherit.efl_ui_video_title_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
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
    /// <summary>Whether or not the playable can be played.</summary>
    /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
    virtual public bool GetPlayable() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_playable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get play/pause state of the media file.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    virtual public bool GetPlay() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_play_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set play/pause state of the media file.
    /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns></returns>
    virtual public void SetPlay( bool play) {
                                 Efl.IPlayerNativeInherit.efl_player_play_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the position in the media file.
    /// The position is returned as the number of seconds since the beginning of the media file.</summary>
    /// <returns>The position (in seconds).</returns>
    virtual public double GetPos() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_pos_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the position in the media file.
    /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    /// <returns></returns>
    virtual public void SetPos( double sec) {
                                 Efl.IPlayerNativeInherit.efl_player_pos_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get how much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    virtual public double GetProgress() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_progress_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    virtual public double GetPlaySpeed() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_play_speed_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    /// <returns></returns>
    virtual public void SetPlaySpeed( double speed) {
                                 Efl.IPlayerNativeInherit.efl_player_play_speed_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), speed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    virtual public double GetVolume() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_volume_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    /// <returns></returns>
    virtual public void SetVolume( double volume) {
                                 Efl.IPlayerNativeInherit.efl_player_volume_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), volume);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    virtual public bool GetMute() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_mute_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    /// <returns></returns>
    virtual public void SetMute( bool mute) {
                                 Efl.IPlayerNativeInherit.efl_player_mute_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), mute);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    virtual public double GetLength() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_length_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    virtual public bool GetSeekable() {
         var _ret_var = Efl.IPlayerNativeInherit.efl_player_seekable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a playing playable object.</summary>
    /// <returns></returns>
    virtual public void Start() {
         Efl.IPlayerNativeInherit.efl_player_start_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop playable object.</summary>
    /// <returns></returns>
    virtual public void Stop() {
         Efl.IPlayerNativeInherit.efl_player_stop_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Set whether the object can remember the last played position.
/// Note: This API only serves as indication. System support is required.</summary>
/// <value><c>true</c> when the object can remember the last position, <c>false</c> otherwise</value>
    public bool RememberPosition {
        get { return GetRememberPosition(); }
        set { SetRememberPosition( value); }
    }
    /// <summary>Get the underlying Emotion object.</summary>
/// <value>The underlying Emotion object.</value>
    public Efl.Canvas.Object Emotion {
        get { return GetEmotion(); }
    }
    /// <summary>Get the title (for instance DVD title) from this emotion object.
/// This function is only useful when playing a DVD.
/// 
/// Note: Don&apos;t change or free the string returned by this function.</summary>
/// <value>A string containing the title.</value>
    public System.String Title {
        get { return GetTitle(); }
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
    /// <summary>Whether or not the playable can be played.</summary>
/// <value><c>true</c> if the object have playable data, <c>false</c> otherwise</value>
    public bool Playable {
        get { return GetPlayable(); }
    }
    /// <summary>Get play/pause state of the media file.</summary>
/// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    public bool Play {
        get { return GetPlay(); }
        set { SetPlay( value); }
    }
    /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
/// <value>The position (in seconds).</value>
    public double Pos {
        get { return GetPos(); }
        set { SetPos( value); }
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
        set { SetPlaySpeed( value); }
    }
    /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <value>The volume level</value>
    public double Volume {
        get { return GetVolume(); }
        set { SetVolume( value); }
    }
    /// <summary>This property controls the audio mute state.</summary>
/// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    public bool Mute {
        get { return GetMute(); }
        set { SetMute( value); }
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Video.efl_ui_video_class_get();
    }
}
public class VideoNativeInherit : Efl.Ui.LayoutBaseNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_video_remember_position_get_static_delegate == null)
            efl_ui_video_remember_position_get_static_delegate = new efl_ui_video_remember_position_get_delegate(remember_position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetRememberPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_video_remember_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_remember_position_get_static_delegate)});
        if (efl_ui_video_remember_position_set_static_delegate == null)
            efl_ui_video_remember_position_set_static_delegate = new efl_ui_video_remember_position_set_delegate(remember_position_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRememberPosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_video_remember_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_remember_position_set_static_delegate)});
        if (efl_ui_video_emotion_get_static_delegate == null)
            efl_ui_video_emotion_get_static_delegate = new efl_ui_video_emotion_get_delegate(emotion_get);
        if (methods.FirstOrDefault(m => m.Name == "GetEmotion") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_video_emotion_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_emotion_get_static_delegate)});
        if (efl_ui_video_title_get_static_delegate == null)
            efl_ui_video_title_get_static_delegate = new efl_ui_video_title_get_delegate(title_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTitle") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_video_title_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_video_title_get_static_delegate)});
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
        if (efl_player_playable_get_static_delegate == null)
            efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlayable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate)});
        if (efl_player_play_get_static_delegate == null)
            efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlay") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate)});
        if (efl_player_play_set_static_delegate == null)
            efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPlay") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate)});
        if (efl_player_pos_get_static_delegate == null)
            efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate)});
        if (efl_player_pos_set_static_delegate == null)
            efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPos") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate)});
        if (efl_player_progress_get_static_delegate == null)
            efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
        if (methods.FirstOrDefault(m => m.Name == "GetProgress") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate)});
        if (efl_player_play_speed_get_static_delegate == null)
            efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPlaySpeed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate)});
        if (efl_player_play_speed_set_static_delegate == null)
            efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPlaySpeed") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate)});
        if (efl_player_volume_get_static_delegate == null)
            efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
        if (methods.FirstOrDefault(m => m.Name == "GetVolume") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate)});
        if (efl_player_volume_set_static_delegate == null)
            efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
        if (methods.FirstOrDefault(m => m.Name == "SetVolume") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate)});
        if (efl_player_mute_get_static_delegate == null)
            efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
        if (methods.FirstOrDefault(m => m.Name == "GetMute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate)});
        if (efl_player_mute_set_static_delegate == null)
            efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
        if (methods.FirstOrDefault(m => m.Name == "SetMute") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate)});
        if (efl_player_length_get_static_delegate == null)
            efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
        if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate)});
        if (efl_player_seekable_get_static_delegate == null)
            efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
        if (methods.FirstOrDefault(m => m.Name == "GetSeekable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate)});
        if (efl_player_start_static_delegate == null)
            efl_player_start_static_delegate = new efl_player_start_delegate(start);
        if (methods.FirstOrDefault(m => m.Name == "Start") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate)});
        if (efl_player_stop_static_delegate == null)
            efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
        if (methods.FirstOrDefault(m => m.Name == "Stop") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.Video.efl_ui_video_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.Video.efl_ui_video_class_get();
    }


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_video_remember_position_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_ui_video_remember_position_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_get_api_delegate> efl_ui_video_remember_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_get_api_delegate>(_Module, "efl_ui_video_remember_position_get");
     private static bool remember_position_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_video_remember_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Video)wrapper).GetRememberPosition();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_video_remember_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_video_remember_position_get_delegate efl_ui_video_remember_position_get_static_delegate;


     private delegate void efl_ui_video_remember_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool remember);


     public delegate void efl_ui_video_remember_position_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool remember);
     public static Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_set_api_delegate> efl_ui_video_remember_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_remember_position_set_api_delegate>(_Module, "efl_ui_video_remember_position_set");
     private static void remember_position_set(System.IntPtr obj, System.IntPtr pd,  bool remember)
    {
        Eina.Log.Debug("function efl_ui_video_remember_position_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetRememberPosition( remember);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_video_remember_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  remember);
        }
    }
    private static efl_ui_video_remember_position_set_delegate efl_ui_video_remember_position_set_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_ui_video_emotion_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] public delegate Efl.Canvas.Object efl_ui_video_emotion_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_video_emotion_get_api_delegate> efl_ui_video_emotion_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_emotion_get_api_delegate>(_Module, "efl_ui_video_emotion_get");
     private static Efl.Canvas.Object emotion_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_video_emotion_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
            try {
                _ret_var = ((Video)wrapper).GetEmotion();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_video_emotion_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_video_emotion_get_delegate efl_ui_video_emotion_get_static_delegate;


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate System.String efl_ui_video_title_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate System.String efl_ui_video_title_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_video_title_get_api_delegate> efl_ui_video_title_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_video_title_get_api_delegate>(_Module, "efl_ui_video_title_get");
     private static System.String title_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_video_title_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        System.String _ret_var = default(System.String);
            try {
                _ret_var = ((Video)wrapper).GetTitle();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_video_title_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_video_title_get_delegate efl_ui_video_title_get_static_delegate;


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
                _ret_var = ((Video)wrapper).GetMmap();
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
                _ret_var = ((Video)wrapper).SetMmap( f);
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
                _ret_var = ((Video)wrapper).GetFile();
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
                _ret_var = ((Video)wrapper).SetFile( file);
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
                _ret_var = ((Video)wrapper).GetKey();
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
                ((Video)wrapper).SetKey( key);
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
                _ret_var = ((Video)wrapper).GetLoaded();
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
                _ret_var = ((Video)wrapper).Load();
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
                ((Video)wrapper).Unload();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_file_unload_delegate efl_file_unload_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_playable_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate> efl_player_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate>(_Module, "efl_player_playable_get");
     private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_playable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Video)wrapper).GetPlayable();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_playable_get_delegate efl_player_playable_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_play_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_play_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate> efl_player_play_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_get_api_delegate>(_Module, "efl_player_play_get");
     private static bool play_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_play_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Video)wrapper).GetPlay();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_play_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_play_get_delegate efl_player_play_get_static_delegate;


     private delegate void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool play);


     public delegate void efl_player_play_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
     public static Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate> efl_player_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate>(_Module, "efl_player_play_set");
     private static void play_set(System.IntPtr obj, System.IntPtr pd,  bool play)
    {
        Eina.Log.Debug("function efl_player_play_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetPlay( play);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_play_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  play);
        }
    }
    private static efl_player_play_set_delegate efl_player_play_set_static_delegate;


     private delegate double efl_player_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_pos_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate> efl_player_pos_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_get_api_delegate>(_Module, "efl_player_pos_get");
     private static double pos_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_pos_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Video)wrapper).GetPos();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_pos_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_pos_get_delegate efl_player_pos_get_static_delegate;


     private delegate void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);


     public delegate void efl_player_pos_set_api_delegate(System.IntPtr obj,   double sec);
     public static Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate> efl_player_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate>(_Module, "efl_player_pos_set");
     private static void pos_set(System.IntPtr obj, System.IntPtr pd,  double sec)
    {
        Eina.Log.Debug("function efl_player_pos_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetPos( sec);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_pos_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
        }
    }
    private static efl_player_pos_set_delegate efl_player_pos_set_static_delegate;


     private delegate double efl_player_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_progress_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate> efl_player_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_progress_get_api_delegate>(_Module, "efl_player_progress_get");
     private static double progress_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_progress_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Video)wrapper).GetProgress();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_progress_get_delegate efl_player_progress_get_static_delegate;


     private delegate double efl_player_play_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_play_speed_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate> efl_player_play_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_get_api_delegate>(_Module, "efl_player_play_speed_get");
     private static double play_speed_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_play_speed_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Video)wrapper).GetPlaySpeed();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_play_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_play_speed_get_delegate efl_player_play_speed_get_static_delegate;


     private delegate void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,   double speed);


     public delegate void efl_player_play_speed_set_api_delegate(System.IntPtr obj,   double speed);
     public static Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate> efl_player_play_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate>(_Module, "efl_player_play_speed_set");
     private static void play_speed_set(System.IntPtr obj, System.IntPtr pd,  double speed)
    {
        Eina.Log.Debug("function efl_player_play_speed_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetPlaySpeed( speed);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_play_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  speed);
        }
    }
    private static efl_player_play_speed_set_delegate efl_player_play_speed_set_static_delegate;


     private delegate double efl_player_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_volume_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate> efl_player_volume_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_get_api_delegate>(_Module, "efl_player_volume_get");
     private static double volume_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_volume_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Video)wrapper).GetVolume();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_volume_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_volume_get_delegate efl_player_volume_get_static_delegate;


     private delegate void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,   double volume);


     public delegate void efl_player_volume_set_api_delegate(System.IntPtr obj,   double volume);
     public static Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate> efl_player_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate>(_Module, "efl_player_volume_set");
     private static void volume_set(System.IntPtr obj, System.IntPtr pd,  double volume)
    {
        Eina.Log.Debug("function efl_player_volume_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetVolume( volume);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_volume_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  volume);
        }
    }
    private static efl_player_volume_set_delegate efl_player_volume_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_mute_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate> efl_player_mute_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_get_api_delegate>(_Module, "efl_player_mute_get");
     private static bool mute_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_mute_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Video)wrapper).GetMute();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_mute_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_mute_get_delegate efl_player_mute_get_static_delegate;


     private delegate void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool mute);


     public delegate void efl_player_mute_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
     public static Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate> efl_player_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate>(_Module, "efl_player_mute_set");
     private static void mute_set(System.IntPtr obj, System.IntPtr pd,  bool mute)
    {
        Eina.Log.Debug("function efl_player_mute_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((Video)wrapper).SetMute( mute);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_player_mute_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mute);
        }
    }
    private static efl_player_mute_set_delegate efl_player_mute_set_static_delegate;


     private delegate double efl_player_length_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate double efl_player_length_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate> efl_player_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_length_get_api_delegate>(_Module, "efl_player_length_get");
     private static double length_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_length_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        double _ret_var = default(double);
            try {
                _ret_var = ((Video)wrapper).GetLength();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_length_get_delegate efl_player_length_get_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_seekable_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate> efl_player_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_seekable_get_api_delegate>(_Module, "efl_player_seekable_get");
     private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_seekable_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((Video)wrapper).GetSeekable();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_player_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_seekable_get_delegate efl_player_seekable_get_static_delegate;


     private delegate void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_player_start_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_start_api_delegate> efl_player_start_ptr = new Efl.Eo.FunctionWrapper<efl_player_start_api_delegate>(_Module, "efl_player_start");
     private static void start(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_start was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Video)wrapper).Start();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_player_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_start_delegate efl_player_start_static_delegate;


     private delegate void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate void efl_player_stop_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate> efl_player_stop_ptr = new Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate>(_Module, "efl_player_stop");
     private static void stop(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_player_stop was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        
            try {
                ((Video)wrapper).Stop();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                } else {
            efl_player_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_player_stop_delegate efl_player_stop_static_delegate;
}
} } 
