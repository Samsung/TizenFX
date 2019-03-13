#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl media player interface</summary>
[PlayerNativeInherit]
public interface Player : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Whether or not the playable can be played.</summary>
/// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
bool GetPlayable();
   /// <summary>Get play/pause state of the media file.</summary>
/// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
bool GetPlay();
   /// <summary>Set play/pause state of the media file.
/// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
/// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
/// <returns></returns>
 void SetPlay( bool play);
   /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
/// <returns>The position (in seconds).</returns>
double GetPos();
   /// <summary>Set the position in the media file.
/// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
/// <param name="sec">The position (in seconds).</param>
/// <returns></returns>
 void SetPos( double sec);
   /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
/// <returns>The progress within the [0, 1] range.</returns>
double GetProgress();
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
/// <returns>The play speed in the [0, infinity) range.</returns>
double GetPlaySpeed();
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
/// <param name="speed">The play speed in the [0, infinity) range.</param>
/// <returns></returns>
 void SetPlaySpeed( double speed);
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <returns>The volume level</returns>
double GetVolume();
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <param name="volume">The volume level</param>
/// <returns></returns>
 void SetVolume( double volume);
   /// <summary>This property controls the audio mute state.</summary>
/// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
bool GetMute();
   /// <summary>This property controls the audio mute state.</summary>
/// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
/// <returns></returns>
 void SetMute( bool mute);
   /// <summary>Get the length of play for the media file.</summary>
/// <returns>The length of the stream in seconds.</returns>
double GetLength();
   /// <summary>Get whether the media file is seekable.</summary>
/// <returns><c>true</c> if seekable.</returns>
bool GetSeekable();
   /// <summary>Start a playing playable object.</summary>
/// <returns></returns>
 void Start();
   /// <summary>Stop playable object.</summary>
/// <returns></returns>
 void Stop();
                                                   /// <summary>Whether or not the playable can be played.</summary>
/// <value><c>true</c> if the object have playable data, <c>false</c> otherwise</value>
   bool Playable {
      get ;
   }
   /// <summary>Get play/pause state of the media file.</summary>
/// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
   bool Play {
      get ;
      set ;
   }
   /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
/// <value>The position (in seconds).</value>
   double Pos {
      get ;
      set ;
   }
   /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
/// <value>The progress within the [0, 1] range.</value>
   double Progress {
      get ;
   }
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
/// <value>The play speed in the [0, infinity) range.</value>
   double PlaySpeed {
      get ;
      set ;
   }
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
/// <value>The volume level</value>
   double Volume {
      get ;
      set ;
   }
   /// <summary>This property controls the audio mute state.</summary>
/// <value>The mute state. <c>true</c> or <c>false</c>.</value>
   bool Mute {
      get ;
      set ;
   }
   /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
   double Length {
      get ;
   }
   /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
   bool Seekable {
      get ;
   }
}
/// <summary>Efl media player interface</summary>
sealed public class PlayerConcrete : 

Player
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PlayerConcrete))
            return Efl.PlayerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_player_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PlayerConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PlayerConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static PlayerConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PlayerConcrete(obj.NativeHandle);
   }
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
    void register_event_proxies()
   {
   }
   /// <summary>Whether or not the playable can be played.</summary>
   /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
   public bool GetPlayable() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_playable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get play/pause state of the media file.</summary>
   /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
   public bool GetPlay() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_play_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set play/pause state of the media file.
   /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
   /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
   /// <returns></returns>
   public  void SetPlay( bool play) {
                         Efl.PlayerNativeInherit.efl_player_play_set_ptr.Value.Delegate(this.NativeHandle, play);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the position in the media file.
   /// The position is returned as the number of seconds since the beginning of the media file.</summary>
   /// <returns>The position (in seconds).</returns>
   public double GetPos() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_pos_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the position in the media file.
   /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
   /// <param name="sec">The position (in seconds).</param>
   /// <returns></returns>
   public  void SetPos( double sec) {
                         Efl.PlayerNativeInherit.efl_player_pos_set_ptr.Value.Delegate(this.NativeHandle, sec);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get how much of the file has been played.
   /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   /// <returns>The progress within the [0, 1] range.</returns>
   public double GetProgress() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_progress_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <returns>The play speed in the [0, infinity) range.</returns>
   public double GetPlaySpeed() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_play_speed_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <param name="speed">The play speed in the [0, infinity) range.</param>
   /// <returns></returns>
   public  void SetPlaySpeed( double speed) {
                         Efl.PlayerNativeInherit.efl_player_play_speed_set_ptr.Value.Delegate(this.NativeHandle, speed);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <returns>The volume level</returns>
   public double GetVolume() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_volume_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <param name="volume">The volume level</param>
   /// <returns></returns>
   public  void SetVolume( double volume) {
                         Efl.PlayerNativeInherit.efl_player_volume_set_ptr.Value.Delegate(this.NativeHandle, volume);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>This property controls the audio mute state.</summary>
   /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
   public bool GetMute() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_mute_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>This property controls the audio mute state.</summary>
   /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
   /// <returns></returns>
   public  void SetMute( bool mute) {
                         Efl.PlayerNativeInherit.efl_player_mute_set_ptr.Value.Delegate(this.NativeHandle, mute);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   public double GetLength() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_length_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   public bool GetSeekable() {
       var _ret_var = Efl.PlayerNativeInherit.efl_player_seekable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Start a playing playable object.</summary>
   /// <returns></returns>
   public  void Start() {
       Efl.PlayerNativeInherit.efl_player_start_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Stop playable object.</summary>
   /// <returns></returns>
   public  void Stop() {
       Efl.PlayerNativeInherit.efl_player_stop_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
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
}
public class PlayerNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_player_playable_get_static_delegate == null)
      efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate)});
      if (efl_player_play_get_static_delegate == null)
      efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate)});
      if (efl_player_play_set_static_delegate == null)
      efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate)});
      if (efl_player_pos_get_static_delegate == null)
      efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate)});
      if (efl_player_pos_set_static_delegate == null)
      efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate)});
      if (efl_player_progress_get_static_delegate == null)
      efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate)});
      if (efl_player_play_speed_get_static_delegate == null)
      efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate)});
      if (efl_player_play_speed_set_static_delegate == null)
      efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate)});
      if (efl_player_volume_get_static_delegate == null)
      efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate)});
      if (efl_player_volume_set_static_delegate == null)
      efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate)});
      if (efl_player_mute_get_static_delegate == null)
      efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate)});
      if (efl_player_mute_set_static_delegate == null)
      efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate)});
      if (efl_player_length_get_static_delegate == null)
      efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate)});
      if (efl_player_seekable_get_static_delegate == null)
      efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate)});
      if (efl_player_start_static_delegate == null)
      efl_player_start_static_delegate = new efl_player_start_delegate(start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate)});
      if (efl_player_stop_static_delegate == null)
      efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PlayerConcrete.efl_player_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PlayerConcrete.efl_player_interface_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_player_playable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate> efl_player_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playable_get_api_delegate>(_Module, "efl_player_playable_get");
    private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_playable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Player)wrapper).GetPlayable();
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Player)wrapper).GetPlay();
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


    private delegate  void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool play);


    public delegate  void efl_player_play_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
    public static Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate> efl_player_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_set_api_delegate>(_Module, "efl_player_play_set");
    private static  void play_set(System.IntPtr obj, System.IntPtr pd,  bool play)
   {
      Eina.Log.Debug("function efl_player_play_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Player)wrapper).SetPlay( play);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Player)wrapper).GetPos();
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


    private delegate  void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);


    public delegate  void efl_player_pos_set_api_delegate(System.IntPtr obj,   double sec);
    public static Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate> efl_player_pos_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_pos_set_api_delegate>(_Module, "efl_player_pos_set");
    private static  void pos_set(System.IntPtr obj, System.IntPtr pd,  double sec)
   {
      Eina.Log.Debug("function efl_player_pos_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Player)wrapper).SetPos( sec);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Player)wrapper).GetProgress();
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Player)wrapper).GetPlaySpeed();
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


    private delegate  void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,   double speed);


    public delegate  void efl_player_play_speed_set_api_delegate(System.IntPtr obj,   double speed);
    public static Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate> efl_player_play_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_play_speed_set_api_delegate>(_Module, "efl_player_play_speed_set");
    private static  void play_speed_set(System.IntPtr obj, System.IntPtr pd,  double speed)
   {
      Eina.Log.Debug("function efl_player_play_speed_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Player)wrapper).SetPlaySpeed( speed);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Player)wrapper).GetVolume();
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


    private delegate  void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,   double volume);


    public delegate  void efl_player_volume_set_api_delegate(System.IntPtr obj,   double volume);
    public static Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate> efl_player_volume_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_volume_set_api_delegate>(_Module, "efl_player_volume_set");
    private static  void volume_set(System.IntPtr obj, System.IntPtr pd,  double volume)
   {
      Eina.Log.Debug("function efl_player_volume_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Player)wrapper).SetVolume( volume);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Player)wrapper).GetMute();
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


    private delegate  void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool mute);


    public delegate  void efl_player_mute_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
    public static Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate> efl_player_mute_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_mute_set_api_delegate>(_Module, "efl_player_mute_set");
    private static  void mute_set(System.IntPtr obj, System.IntPtr pd,  bool mute)
   {
      Eina.Log.Debug("function efl_player_mute_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((Player)wrapper).SetMute( mute);
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Player)wrapper).GetLength();
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
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Player)wrapper).GetSeekable();
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


    private delegate  void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_player_start_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_start_api_delegate> efl_player_start_ptr = new Efl.Eo.FunctionWrapper<efl_player_start_api_delegate>(_Module, "efl_player_start");
    private static  void start(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_start was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Player)wrapper).Start();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_player_start_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_player_start_delegate efl_player_start_static_delegate;


    private delegate  void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_player_stop_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate> efl_player_stop_ptr = new Efl.Eo.FunctionWrapper<efl_player_stop_api_delegate>(_Module, "efl_player_stop");
    private static  void stop(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_stop was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((Player)wrapper).Stop();
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
} 
