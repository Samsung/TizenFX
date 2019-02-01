#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl media player interface</summary>
[PlayerConcreteNativeInherit]
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
   bool Playable {
      get ;
   }
   /// <summary>Get play/pause state of the media file.</summary>
   bool Play {
      get ;
      set ;
   }
   /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
   double Pos {
      get ;
      set ;
   }
   /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   double Progress {
      get ;
   }
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   double PlaySpeed {
      get ;
      set ;
   }
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   double Volume {
      get ;
      set ;
   }
   /// <summary>This property controls the audio mute state.</summary>
   bool Mute {
      get ;
      set ;
   }
   /// <summary>Get the length of play for the media file.</summary>
   double Length {
      get ;
   }
   /// <summary>Get whether the media file is seekable.</summary>
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
            return Efl.PlayerConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_player_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
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
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_playable_get(System.IntPtr obj);
   /// <summary>Whether or not the playable can be played.</summary>
   /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
   public bool GetPlayable() {
       var _ret_var = efl_player_playable_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_play_get(System.IntPtr obj);
   /// <summary>Get play/pause state of the media file.</summary>
   /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
   public bool GetPlay() {
       var _ret_var = efl_player_play_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_play_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
   /// <summary>Set play/pause state of the media file.
   /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
   /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
   /// <returns></returns>
   public  void SetPlay( bool play) {
                         efl_player_play_set(Efl.PlayerConcrete.efl_player_interface_get(),  play);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_player_pos_get(System.IntPtr obj);
   /// <summary>Get the position in the media file.
   /// The position is returned as the number of seconds since the beginning of the media file.</summary>
   /// <returns>The position (in seconds).</returns>
   public double GetPos() {
       var _ret_var = efl_player_pos_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_pos_set(System.IntPtr obj,   double sec);
   /// <summary>Set the position in the media file.
   /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
   /// <param name="sec">The position (in seconds).</param>
   /// <returns></returns>
   public  void SetPos( double sec) {
                         efl_player_pos_set(Efl.PlayerConcrete.efl_player_interface_get(),  sec);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_player_progress_get(System.IntPtr obj);
   /// <summary>Get how much of the file has been played.
   /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   /// <returns>The progress within the [0, 1] range.</returns>
   public double GetProgress() {
       var _ret_var = efl_player_progress_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_player_play_speed_get(System.IntPtr obj);
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <returns>The play speed in the [0, infinity) range.</returns>
   public double GetPlaySpeed() {
       var _ret_var = efl_player_play_speed_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_play_speed_set(System.IntPtr obj,   double speed);
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <param name="speed">The play speed in the [0, infinity) range.</param>
   /// <returns></returns>
   public  void SetPlaySpeed( double speed) {
                         efl_player_play_speed_set(Efl.PlayerConcrete.efl_player_interface_get(),  speed);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_player_volume_get(System.IntPtr obj);
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <returns>The volume level</returns>
   public double GetVolume() {
       var _ret_var = efl_player_volume_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_volume_set(System.IntPtr obj,   double volume);
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <param name="volume">The volume level</param>
   /// <returns></returns>
   public  void SetVolume( double volume) {
                         efl_player_volume_set(Efl.PlayerConcrete.efl_player_interface_get(),  volume);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_mute_get(System.IntPtr obj);
   /// <summary>This property controls the audio mute state.</summary>
   /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
   public bool GetMute() {
       var _ret_var = efl_player_mute_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_mute_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
   /// <summary>This property controls the audio mute state.</summary>
   /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
   /// <returns></returns>
   public  void SetMute( bool mute) {
                         efl_player_mute_set(Efl.PlayerConcrete.efl_player_interface_get(),  mute);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern double efl_player_length_get(System.IntPtr obj);
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   public double GetLength() {
       var _ret_var = efl_player_length_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_seekable_get(System.IntPtr obj);
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   public bool GetSeekable() {
       var _ret_var = efl_player_seekable_get(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_start(System.IntPtr obj);
   /// <summary>Start a playing playable object.</summary>
   /// <returns></returns>
   public  void Start() {
       efl_player_start(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    private static extern  void efl_player_stop(System.IntPtr obj);
   /// <summary>Stop playable object.</summary>
   /// <returns></returns>
   public  void Stop() {
       efl_player_stop(Efl.PlayerConcrete.efl_player_interface_get());
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Whether or not the playable can be played.</summary>
   public bool Playable {
      get { return GetPlayable(); }
   }
   /// <summary>Get play/pause state of the media file.</summary>
   public bool Play {
      get { return GetPlay(); }
      set { SetPlay( value); }
   }
   /// <summary>Get the position in the media file.
/// The position is returned as the number of seconds since the beginning of the media file.</summary>
   public double Pos {
      get { return GetPos(); }
      set { SetPos( value); }
   }
   /// <summary>Get how much of the file has been played.
/// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   public double Progress {
      get { return GetProgress(); }
   }
   /// <summary>Control the play speed of the media file.
/// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   public double PlaySpeed {
      get { return GetPlaySpeed(); }
      set { SetPlaySpeed( value); }
   }
   /// <summary>Control the audio volume.
/// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   public double Volume {
      get { return GetVolume(); }
      set { SetVolume( value); }
   }
   /// <summary>This property controls the audio mute state.</summary>
   public bool Mute {
      get { return GetMute(); }
      set { SetMute( value); }
   }
   /// <summary>Get the length of play for the media file.</summary>
   public double Length {
      get { return GetLength(); }
   }
   /// <summary>Get whether the media file is seekable.</summary>
   public bool Seekable {
      get { return GetSeekable(); }
   }
}
public class PlayerConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_player_playable_get_static_delegate = new efl_player_playable_get_delegate(playable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playable_get_static_delegate)});
      efl_player_play_get_static_delegate = new efl_player_play_get_delegate(play_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_get_static_delegate)});
      efl_player_play_set_static_delegate = new efl_player_play_set_delegate(play_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_set_static_delegate)});
      efl_player_pos_get_static_delegate = new efl_player_pos_get_delegate(pos_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_pos_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_get_static_delegate)});
      efl_player_pos_set_static_delegate = new efl_player_pos_set_delegate(pos_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_pos_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_pos_set_static_delegate)});
      efl_player_progress_get_static_delegate = new efl_player_progress_get_delegate(progress_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_progress_get_static_delegate)});
      efl_player_play_speed_get_static_delegate = new efl_player_play_speed_get_delegate(play_speed_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_play_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_get_static_delegate)});
      efl_player_play_speed_set_static_delegate = new efl_player_play_speed_set_delegate(play_speed_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_play_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_play_speed_set_static_delegate)});
      efl_player_volume_get_static_delegate = new efl_player_volume_get_delegate(volume_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_volume_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_get_static_delegate)});
      efl_player_volume_set_static_delegate = new efl_player_volume_set_delegate(volume_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_volume_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_volume_set_static_delegate)});
      efl_player_mute_get_static_delegate = new efl_player_mute_get_delegate(mute_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_mute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_get_static_delegate)});
      efl_player_mute_set_static_delegate = new efl_player_mute_set_delegate(mute_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_mute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_mute_set_static_delegate)});
      efl_player_length_get_static_delegate = new efl_player_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_length_get_static_delegate)});
      efl_player_seekable_get_static_delegate = new efl_player_seekable_get_delegate(seekable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_seekable_get_static_delegate)});
      efl_player_start_static_delegate = new efl_player_start_delegate(start);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_start"), func = Marshal.GetFunctionPointerForDelegate(efl_player_start_static_delegate)});
      efl_player_stop_static_delegate = new efl_player_stop_delegate(stop);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_player_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_player_stop_static_delegate)});
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
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_playable_get(System.IntPtr obj);
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
         return efl_player_playable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_playable_get_delegate efl_player_playable_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_play_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_play_get(System.IntPtr obj);
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
         return efl_player_play_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_play_get_delegate efl_player_play_get_static_delegate;


    private delegate  void efl_player_play_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool play);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_play_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
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
         efl_player_play_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  play);
      }
   }
   private efl_player_play_set_delegate efl_player_play_set_static_delegate;


    private delegate double efl_player_pos_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_player_pos_get(System.IntPtr obj);
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
         return efl_player_pos_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_pos_get_delegate efl_player_pos_get_static_delegate;


    private delegate  void efl_player_pos_set_delegate(System.IntPtr obj, System.IntPtr pd,   double sec);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_pos_set(System.IntPtr obj,   double sec);
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
         efl_player_pos_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  sec);
      }
   }
   private efl_player_pos_set_delegate efl_player_pos_set_static_delegate;


    private delegate double efl_player_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_player_progress_get(System.IntPtr obj);
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
         return efl_player_progress_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_progress_get_delegate efl_player_progress_get_static_delegate;


    private delegate double efl_player_play_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_player_play_speed_get(System.IntPtr obj);
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
         return efl_player_play_speed_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_play_speed_get_delegate efl_player_play_speed_get_static_delegate;


    private delegate  void efl_player_play_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,   double speed);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_play_speed_set(System.IntPtr obj,   double speed);
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
         efl_player_play_speed_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  speed);
      }
   }
   private efl_player_play_speed_set_delegate efl_player_play_speed_set_static_delegate;


    private delegate double efl_player_volume_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_player_volume_get(System.IntPtr obj);
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
         return efl_player_volume_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_volume_get_delegate efl_player_volume_get_static_delegate;


    private delegate  void efl_player_volume_set_delegate(System.IntPtr obj, System.IntPtr pd,   double volume);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_volume_set(System.IntPtr obj,   double volume);
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
         efl_player_volume_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  volume);
      }
   }
   private efl_player_volume_set_delegate efl_player_volume_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_mute_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_mute_get(System.IntPtr obj);
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
         return efl_player_mute_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_mute_get_delegate efl_player_mute_get_static_delegate;


    private delegate  void efl_player_mute_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool mute);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_mute_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
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
         efl_player_mute_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  mute);
      }
   }
   private efl_player_mute_set_delegate efl_player_mute_set_static_delegate;


    private delegate double efl_player_length_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern double efl_player_length_get(System.IntPtr obj);
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
         return efl_player_length_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_length_get_delegate efl_player_length_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_seekable_get(System.IntPtr obj);
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
         return efl_player_seekable_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_seekable_get_delegate efl_player_seekable_get_static_delegate;


    private delegate  void efl_player_start_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_start(System.IntPtr obj);
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
         efl_player_start(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_start_delegate efl_player_start_static_delegate;


    private delegate  void efl_player_stop_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  private static extern  void efl_player_stop(System.IntPtr obj);
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
         efl_player_stop(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_player_stop_delegate efl_player_stop_static_delegate;
}
} 
