#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
///<summary>Event argument wrapper for event <see cref="Efl.Canvas.AnimationPlayer.RunningEvt"/>.</summary>
public class AnimationPlayerRunningEvt_Args : EventArgs {
   ///<summary>Actual event payload.</summary>
   public Efl.Canvas.ObjectAnimationEvent arg { get; set; }
}
/// <summary>Efl animation object class</summary>
[AnimationPlayerNativeInherit]
public class AnimationPlayer : Efl.Object, Efl.Eo.IWrapper,Efl.Player
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Canvas.AnimationPlayerNativeInherit nativeInherit = new Efl.Canvas.AnimationPlayerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (AnimationPlayer))
            return Efl.Canvas.AnimationPlayerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(AnimationPlayer obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_animation_player_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public AnimationPlayer(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("AnimationPlayer", efl_canvas_animation_player_class_get(), typeof(AnimationPlayer), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected AnimationPlayer(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public AnimationPlayer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static AnimationPlayer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new AnimationPlayer(obj.NativeHandle);
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
private static object StartedEvtKey = new object();
   /// <summary>Animation is started.</summary>
   public event EventHandler StartedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_STARTED";
            if (add_cpp_event_handler(key, this.evt_StartedEvt_delegate)) {
               eventHandlers.AddHandler(StartedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_STARTED";
            if (remove_cpp_event_handler(key, this.evt_StartedEvt_delegate)) { 
               eventHandlers.RemoveHandler(StartedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event StartedEvt.</summary>
   public void On_StartedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[StartedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_StartedEvt_delegate;
   private void on_StartedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_StartedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object RunningEvtKey = new object();
   /// <summary>Animation is running.</summary>
   public event EventHandler<Efl.Canvas.AnimationPlayerRunningEvt_Args> RunningEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_RUNNING";
            if (add_cpp_event_handler(key, this.evt_RunningEvt_delegate)) {
               eventHandlers.AddHandler(RunningEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_RUNNING";
            if (remove_cpp_event_handler(key, this.evt_RunningEvt_delegate)) { 
               eventHandlers.RemoveHandler(RunningEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event RunningEvt.</summary>
   public void On_RunningEvt(Efl.Canvas.AnimationPlayerRunningEvt_Args e)
   {
      EventHandler<Efl.Canvas.AnimationPlayerRunningEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.Canvas.AnimationPlayerRunningEvt_Args>)eventHandlers[RunningEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_RunningEvt_delegate;
   private void on_RunningEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.Canvas.AnimationPlayerRunningEvt_Args args = new Efl.Canvas.AnimationPlayerRunningEvt_Args();
      args.arg = default(Efl.Canvas.ObjectAnimationEvent);
      try {
         On_RunningEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

private static object EndedEvtKey = new object();
   /// <summary>Animation is ended.</summary>
   public event EventHandler EndedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_ENDED";
            if (add_cpp_event_handler(key, this.evt_EndedEvt_delegate)) {
               eventHandlers.AddHandler(EndedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_ANIMATION_PLAYER_EVENT_ENDED";
            if (remove_cpp_event_handler(key, this.evt_EndedEvt_delegate)) { 
               eventHandlers.RemoveHandler(EndedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event EndedEvt.</summary>
   public void On_EndedEvt(EventArgs e)
   {
      EventHandler evt;
      lock (eventLock) {
      evt = (EventHandler)eventHandlers[EndedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_EndedEvt_delegate;
   private void on_EndedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      EventArgs args = EventArgs.Empty;
      try {
         On_EndedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_StartedEvt_delegate = new Efl.EventCb(on_StartedEvt_NativeCallback);
      evt_RunningEvt_delegate = new Efl.EventCb(on_RunningEvt_NativeCallback);
      evt_EndedEvt_delegate = new Efl.EventCb(on_EndedEvt_NativeCallback);
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Animation efl_animation_player_animation_get(System.IntPtr obj);
   /// <summary></summary>
   /// <returns></returns>
   virtual public Efl.Canvas.Animation GetAnimation() {
       var _ret_var = efl_animation_player_animation_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_player_animation_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
   /// <summary></summary>
   /// <param name="animation"></param>
   /// <returns></returns>
   virtual public  void SetAnimation( Efl.Canvas.Animation animation) {
                         efl_animation_player_animation_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  animation);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_animation_player_auto_del_get(System.IntPtr obj);
   /// <summary>Auto delete property</summary>
   /// <returns><c>true</c> to delete animation object automatically when animation is finished or animation is cancelled, <c>false</c> otherwise.</returns>
   virtual public bool GetAutoDel() {
       var _ret_var = efl_animation_player_auto_del_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_player_auto_del_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool auto_del);
   /// <summary>Auto delete property</summary>
   /// <param name="auto_del"><c>true</c> to delete animation object automatically when animation is finished or animation is cancelled, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetAutoDel( bool auto_del) {
                         efl_animation_player_auto_del_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  auto_del);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] protected static extern Efl.Canvas.Object efl_animation_player_target_get(System.IntPtr obj);
   /// <summary>Target object property</summary>
   /// <returns>Target object which is applied animation.</returns>
   virtual public Efl.Canvas.Object GetTarget() {
       var _ret_var = efl_animation_player_target_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
    protected static extern  void efl_animation_player_target_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
   /// <summary>Target object property</summary>
   /// <param name="target">Target object which is applied animation.</param>
   /// <returns></returns>
   virtual public  void SetTarget( Efl.Canvas.Object target) {
                         efl_animation_player_target_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  target);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_player_playable_get(System.IntPtr obj);
   /// <summary>Whether or not the playable can be played.</summary>
   /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
   virtual public bool GetPlayable() {
       var _ret_var = efl_player_playable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_player_play_get(System.IntPtr obj);
   /// <summary>Get play/pause state of the media file.</summary>
   /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
   virtual public bool GetPlay() {
       var _ret_var = efl_player_play_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_play_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool play);
   /// <summary>Set play/pause state of the media file.
   /// This functions sets the currently playing status of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
   /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
   /// <returns></returns>
   virtual public  void SetPlay( bool play) {
                         efl_player_play_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  play);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_player_pos_get(System.IntPtr obj);
   /// <summary>Get the position in the media file.
   /// The position is returned as the number of seconds since the beginning of the media file.</summary>
   /// <returns>The position (in seconds).</returns>
   virtual public double GetPos() {
       var _ret_var = efl_player_pos_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_pos_set(System.IntPtr obj,   double sec);
   /// <summary>Set the position in the media file.
   /// This functions sets the current position of the media file to &quot;sec&quot;, this only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
   /// <param name="sec">The position (in seconds).</param>
   /// <returns></returns>
   virtual public  void SetPos( double sec) {
                         efl_player_pos_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  sec);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_player_progress_get(System.IntPtr obj);
   /// <summary>Get how much of the file has been played.
   /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
   /// <returns>The progress within the [0, 1] range.</returns>
   virtual public double GetProgress() {
       var _ret_var = efl_player_progress_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_player_play_speed_get(System.IntPtr obj);
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <returns>The play speed in the [0, infinity) range.</returns>
   virtual public double GetPlaySpeed() {
       var _ret_var = efl_player_play_speed_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_play_speed_set(System.IntPtr obj,   double speed);
   /// <summary>Control the play speed of the media file.
   /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
   /// <param name="speed">The play speed in the [0, infinity) range.</param>
   /// <returns></returns>
   virtual public  void SetPlaySpeed( double speed) {
                         efl_player_play_speed_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  speed);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_player_volume_get(System.IntPtr obj);
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <returns>The volume level</returns>
   virtual public double GetVolume() {
       var _ret_var = efl_player_volume_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_volume_set(System.IntPtr obj,   double volume);
   /// <summary>Control the audio volume.
   /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
   /// <param name="volume">The volume level</param>
   /// <returns></returns>
   virtual public  void SetVolume( double volume) {
                         efl_player_volume_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  volume);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_player_mute_get(System.IntPtr obj);
   /// <summary>This property controls the audio mute state.</summary>
   /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
   virtual public bool GetMute() {
       var _ret_var = efl_player_mute_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_mute_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool mute);
   /// <summary>This property controls the audio mute state.</summary>
   /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
   /// <returns></returns>
   virtual public  void SetMute( bool mute) {
                         efl_player_mute_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  mute);
      Eina.Error.RaiseIfUnhandledException();
                   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern double efl_player_length_get(System.IntPtr obj);
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   virtual public double GetLength() {
       var _ret_var = efl_player_length_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_player_seekable_get(System.IntPtr obj);
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   virtual public bool GetSeekable() {
       var _ret_var = efl_player_seekable_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_start(System.IntPtr obj);
   /// <summary>Start a playing playable object.</summary>
   /// <returns></returns>
   virtual public  void Start() {
       efl_player_start((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
    protected static extern  void efl_player_stop(System.IntPtr obj);
   /// <summary>Stop playable object.</summary>
   /// <returns></returns>
   virtual public  void Stop() {
       efl_player_stop((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary></summary>
   public Efl.Canvas.Animation Animation {
      get { return GetAnimation(); }
      set { SetAnimation( value); }
   }
   /// <summary>Auto delete property</summary>
   public bool AutoDel {
      get { return GetAutoDel(); }
      set { SetAutoDel( value); }
   }
   /// <summary>Target object property</summary>
   public Efl.Canvas.Object Target {
      get { return GetTarget(); }
      set { SetTarget( value); }
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
public class AnimationPlayerNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_animation_player_animation_get_static_delegate = new efl_animation_player_animation_get_delegate(animation_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_animation_get_static_delegate)});
      efl_animation_player_animation_set_static_delegate = new efl_animation_player_animation_set_delegate(animation_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_animation_set_static_delegate)});
      efl_animation_player_auto_del_get_static_delegate = new efl_animation_player_auto_del_get_delegate(auto_del_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_auto_del_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_auto_del_get_static_delegate)});
      efl_animation_player_auto_del_set_static_delegate = new efl_animation_player_auto_del_set_delegate(auto_del_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_auto_del_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_auto_del_set_static_delegate)});
      efl_animation_player_target_get_static_delegate = new efl_animation_player_target_get_delegate(target_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_target_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_target_get_static_delegate)});
      efl_animation_player_target_set_static_delegate = new efl_animation_player_target_set_delegate(target_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_animation_player_target_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_target_set_static_delegate)});
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
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.AnimationPlayer.efl_canvas_animation_player_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.AnimationPlayer.efl_canvas_animation_player_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Animation efl_animation_player_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Animation efl_animation_player_animation_get(System.IntPtr obj);
    private static Efl.Canvas.Animation animation_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_player_animation_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Animation _ret_var = default(Efl.Canvas.Animation);
         try {
            _ret_var = ((AnimationPlayer)wrapper).GetAnimation();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_player_animation_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_player_animation_get_delegate efl_animation_player_animation_get_static_delegate;


    private delegate  void efl_animation_player_animation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_player_animation_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Animation, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Animation animation);
    private static  void animation_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Animation animation)
   {
      Eina.Log.Debug("function efl_animation_player_animation_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnimationPlayer)wrapper).SetAnimation( animation);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_player_animation_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  animation);
      }
   }
   private efl_animation_player_animation_set_delegate efl_animation_player_animation_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_animation_player_auto_del_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_animation_player_auto_del_get(System.IntPtr obj);
    private static bool auto_del_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_player_auto_del_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((AnimationPlayer)wrapper).GetAutoDel();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_player_auto_del_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_player_auto_del_get_delegate efl_animation_player_auto_del_get_static_delegate;


    private delegate  void efl_animation_player_auto_del_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.U1)]  bool auto_del);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_player_auto_del_set(System.IntPtr obj,  [MarshalAs(UnmanagedType.U1)]  bool auto_del);
    private static  void auto_del_set(System.IntPtr obj, System.IntPtr pd,  bool auto_del)
   {
      Eina.Log.Debug("function efl_animation_player_auto_del_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnimationPlayer)wrapper).SetAutoDel( auto_del);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_player_auto_del_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  auto_del);
      }
   }
   private efl_animation_player_auto_del_set_delegate efl_animation_player_auto_del_set_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private delegate Efl.Canvas.Object efl_animation_player_target_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))] private static extern Efl.Canvas.Object efl_animation_player_target_get(System.IntPtr obj);
    private static Efl.Canvas.Object target_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_animation_player_target_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((AnimationPlayer)wrapper).GetTarget();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_animation_player_target_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_animation_player_target_get_delegate efl_animation_player_target_get_static_delegate;


    private delegate  void efl_animation_player_target_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]  private static extern  void efl_animation_player_target_set(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object target);
    private static  void target_set(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object target)
   {
      Eina.Log.Debug("function efl_animation_player_target_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((AnimationPlayer)wrapper).SetTarget( target);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_animation_player_target_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  target);
      }
   }
   private efl_animation_player_target_set_delegate efl_animation_player_target_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_player_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_player_playable_get(System.IntPtr obj);
    private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_player_playable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((AnimationPlayer)wrapper).GetPlayable();
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
            _ret_var = ((AnimationPlayer)wrapper).GetPlay();
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
            ((AnimationPlayer)wrapper).SetPlay( play);
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
            _ret_var = ((AnimationPlayer)wrapper).GetPos();
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
            ((AnimationPlayer)wrapper).SetPos( sec);
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
            _ret_var = ((AnimationPlayer)wrapper).GetProgress();
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
            _ret_var = ((AnimationPlayer)wrapper).GetPlaySpeed();
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
            ((AnimationPlayer)wrapper).SetPlaySpeed( speed);
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
            _ret_var = ((AnimationPlayer)wrapper).GetVolume();
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
            ((AnimationPlayer)wrapper).SetVolume( volume);
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
            _ret_var = ((AnimationPlayer)wrapper).GetMute();
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
            ((AnimationPlayer)wrapper).SetMute( mute);
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
            _ret_var = ((AnimationPlayer)wrapper).GetLength();
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
            _ret_var = ((AnimationPlayer)wrapper).GetSeekable();
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
            ((AnimationPlayer)wrapper).Start();
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
            ((AnimationPlayer)wrapper).Stop();
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
} } 
