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

/// <summary>Event argument wrapper for event <see cref="Efl.Canvas.AnimationPlayer.RunningEvent"/>.</summary>
[Efl.Eo.BindingEntity]
public class AnimationPlayerRunningEventArgs : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Animation is running.</value>
    public Efl.Canvas.ObjectAnimationEvent arg { get; set; }
}
/// <summary>Efl animation object class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Canvas.AnimationPlayer.NativeMethods]
[Efl.Eo.BindingEntity]
public class AnimationPlayer : Efl.Object, Efl.IPlayer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AnimationPlayer))
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
        efl_canvas_animation_player_class_get();
    /// <summary>Initializes a new instance of the <see cref="AnimationPlayer"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public AnimationPlayer(Efl.Object parent= null
            ) : base(efl_canvas_animation_player_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected AnimationPlayer(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationPlayer"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AnimationPlayer(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationPlayer"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AnimationPlayer(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Animation is started.</summary>
    public event EventHandler StartedEvent
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

                string key = "_EFL_ANIMATION_PLAYER_EVENT_STARTED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ANIMATION_PLAYER_EVENT_STARTED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event StartedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnStartedEvent(EventArgs e)
    {
        var key = "_EFL_ANIMATION_PLAYER_EVENT_STARTED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Animation is running.</summary>
    /// <value><see cref="Efl.Canvas.AnimationPlayerRunningEventArgs"/></value>
    public event EventHandler<Efl.Canvas.AnimationPlayerRunningEventArgs> RunningEvent
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
                        Efl.Canvas.AnimationPlayerRunningEventArgs args = new Efl.Canvas.AnimationPlayerRunningEventArgs();
                        args.arg =  (Efl.Canvas.ObjectAnimationEvent)evt.Info;
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

                string key = "_EFL_ANIMATION_PLAYER_EVENT_RUNNING";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ANIMATION_PLAYER_EVENT_RUNNING";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event RunningEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnRunningEvent(Efl.Canvas.AnimationPlayerRunningEventArgs e)
    {
        var key = "_EFL_ANIMATION_PLAYER_EVENT_RUNNING";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Eina.PrimitiveConversion.ManagedToPointerAlloc(e.arg);
        try
        {
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Animation is ended.</summary>
    public event EventHandler EndedEvent
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

                string key = "_EFL_ANIMATION_PLAYER_EVENT_ENDED";
                AddNativeEventHandler(efl.Libs.Evas, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_ANIMATION_PLAYER_EVENT_ENDED";
                RemoveNativeEventHandler(efl.Libs.Evas, key, value);
            }
        }
    }
    /// <summary>Method to raise event EndedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnEndedEvent(EventArgs e)
    {
        var key = "_EFL_ANIMATION_PLAYER_EVENT_ENDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Evas, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    public virtual Efl.Canvas.Animation GetAnimation() {
         var _ret_var = Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_animation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    public virtual void SetAnimation(Efl.Canvas.Animation animation) {
                                 Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_animation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),animation);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Auto delete property</summary>
    /// <returns><c>true</c> to delete animation object automatically when animation is finished or animation is cancelled, <c>false</c> otherwise.</returns>
    public virtual bool GetAutoDel() {
         var _ret_var = Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_auto_del_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Auto delete property</summary>
    /// <param name="auto_del"><c>true</c> to delete animation object automatically when animation is finished or animation is cancelled, <c>false</c> otherwise.</param>
    public virtual void SetAutoDel(bool auto_del) {
                                 Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_auto_del_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),auto_del);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Target object property</summary>
    /// <returns>Target object which is applied animation.</returns>
    public virtual Efl.Canvas.Object GetTarget() {
         var _ret_var = Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_target_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Target object property</summary>
    /// <param name="target">Target object which is applied animation.</param>
    public virtual void SetTarget(Efl.Canvas.Object target) {
                                 Efl.Canvas.AnimationPlayer.NativeMethods.efl_animation_player_target_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),target);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Whether or not the playable can be played.</summary>
    /// <returns><c>true</c> if the object have playable data, <c>false</c> otherwise</returns>
    public virtual bool GetPlayable() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    public virtual bool GetPlay() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_play_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <param name="play"><c>true</c> if playing, <c>false</c> otherwise.</param>
    public virtual void SetPlay(bool play) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_play_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <returns>The position (in seconds).</returns>
    public virtual double GetPos() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    public virtual void SetPos(double sec) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    public virtual double GetProgress() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    public virtual double GetPlaySpeed() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_play_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the play speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    public virtual void SetPlaySpeed(double speed) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_play_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),speed);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <returns>The volume level</returns>
    public virtual double GetVolume() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_volume_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <param name="volume">The volume level</param>
    public virtual void SetVolume(double volume) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_volume_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),volume);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This property controls the audio mute state.</summary>
    /// <returns>The mute state. <c>true</c> or <c>false</c>.</returns>
    public virtual bool GetMute() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_mute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>This property controls the audio mute state.</summary>
    /// <param name="mute">The mute state. <c>true</c> or <c>false</c>.</param>
    public virtual void SetMute(bool mute) {
                                 Efl.PlayerConcrete.NativeMethods.efl_player_mute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),mute);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    public virtual double GetLength() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_length_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    public virtual bool GetSeekable() {
         var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_seekable_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start a playing playable object.</summary>
    public virtual void Start() {
         Efl.PlayerConcrete.NativeMethods.efl_player_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Stop playable object.</summary>
    public virtual void Stop() {
         Efl.PlayerConcrete.NativeMethods.efl_player_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    public Efl.Canvas.Animation Animation {
        get { return GetAnimation(); }
        set { SetAnimation(value); }
    }
    /// <summary>Auto delete property</summary>
    /// <value><c>true</c> to delete animation object automatically when animation is finished or animation is cancelled, <c>false</c> otherwise.</value>
    public bool AutoDel {
        get { return GetAutoDel(); }
        set { SetAutoDel(value); }
    }
    /// <summary>Target object property</summary>
    /// <value>Target object which is applied animation.</value>
    public Efl.Canvas.Object Target {
        get { return GetTarget(); }
        set { SetTarget(value); }
    }
    /// <summary>Whether or not the playable can be played.</summary>
    /// <value><c>true</c> if the object have playable data, <c>false</c> otherwise</value>
    public bool Playable {
        get { return GetPlayable(); }
    }
    /// <summary>Playback state of the media file.
    /// This property sets the currently playback state of the video. Using this function to play or pause the video doesn&apos;t alter it&apos;s current position.</summary>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    public bool Play {
        get { return GetPlay(); }
        set { SetPlay(value); }
    }
    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the playing state of the media file.</summary>
    /// <value>The position (in seconds).</value>
    public double Pos {
        get { return GetPos(); }
        set { SetPos(value); }
    }
    /// <summary>How much of the file has been played.
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
        set { SetPlaySpeed(value); }
    }
    /// <summary>Control the audio volume.
    /// Controls the audio volume of the stream being played. This has nothing to do with the system volume. This volume will be multiplied by the system volume. e.g.: if the current volume level is 0.5, and the system volume is 50%, it will be 0.5 * 0.5 = 0.25.</summary>
    /// <value>The volume level</value>
    public double Volume {
        get { return GetVolume(); }
        set { SetVolume(value); }
    }
    /// <summary>This property controls the audio mute state.</summary>
    /// <value>The mute state. <c>true</c> or <c>false</c>.</value>
    public bool Mute {
        get { return GetMute(); }
        set { SetMute(value); }
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
        return Efl.Canvas.AnimationPlayer.efl_canvas_animation_player_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_animation_player_animation_get_static_delegate == null)
            {
                efl_animation_player_animation_get_static_delegate = new efl_animation_player_animation_get_delegate(animation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_animation_get_static_delegate) });
            }

            if (efl_animation_player_animation_set_static_delegate == null)
            {
                efl_animation_player_animation_set_static_delegate = new efl_animation_player_animation_set_delegate(animation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAnimation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_animation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_animation_set_static_delegate) });
            }

            if (efl_animation_player_auto_del_get_static_delegate == null)
            {
                efl_animation_player_auto_del_get_static_delegate = new efl_animation_player_auto_del_get_delegate(auto_del_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutoDel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_auto_del_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_auto_del_get_static_delegate) });
            }

            if (efl_animation_player_auto_del_set_static_delegate == null)
            {
                efl_animation_player_auto_del_set_static_delegate = new efl_animation_player_auto_del_set_delegate(auto_del_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutoDel") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_auto_del_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_auto_del_set_static_delegate) });
            }

            if (efl_animation_player_target_get_static_delegate == null)
            {
                efl_animation_player_target_get_static_delegate = new efl_animation_player_target_get_delegate(target_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_target_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_target_get_static_delegate) });
            }

            if (efl_animation_player_target_set_static_delegate == null)
            {
                efl_animation_player_target_set_static_delegate = new efl_animation_player_target_set_delegate(target_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTarget") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_player_target_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_player_target_set_static_delegate) });
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
            return Efl.Canvas.AnimationPlayer.efl_canvas_animation_player_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Animation efl_animation_player_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Animation efl_animation_player_animation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_animation_get_api_delegate> efl_animation_player_animation_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_animation_get_api_delegate>(Module, "efl_animation_player_animation_get");

        private static Efl.Canvas.Animation animation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_player_animation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Animation _ret_var = default(Efl.Canvas.Animation);
                try
                {
                    _ret_var = ((AnimationPlayer)ws.Target).GetAnimation();
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
                return efl_animation_player_animation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_player_animation_get_delegate efl_animation_player_animation_get_static_delegate;

        
        private delegate void efl_animation_player_animation_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        
        public delegate void efl_animation_player_animation_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Animation animation);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_animation_set_api_delegate> efl_animation_player_animation_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_animation_set_api_delegate>(Module, "efl_animation_player_animation_set");

        private static void animation_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Animation animation)
        {
            Eina.Log.Debug("function efl_animation_player_animation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationPlayer)ws.Target).SetAnimation(animation);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_player_animation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), animation);
            }
        }

        private static efl_animation_player_animation_set_delegate efl_animation_player_animation_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_animation_player_auto_del_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_animation_player_auto_del_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_auto_del_get_api_delegate> efl_animation_player_auto_del_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_auto_del_get_api_delegate>(Module, "efl_animation_player_auto_del_get");

        private static bool auto_del_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_player_auto_del_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationPlayer)ws.Target).GetAutoDel();
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
                return efl_animation_player_auto_del_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_player_auto_del_get_delegate efl_animation_player_auto_del_get_static_delegate;

        
        private delegate void efl_animation_player_auto_del_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool auto_del);

        
        public delegate void efl_animation_player_auto_del_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool auto_del);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_auto_del_set_api_delegate> efl_animation_player_auto_del_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_auto_del_set_api_delegate>(Module, "efl_animation_player_auto_del_set");

        private static void auto_del_set(System.IntPtr obj, System.IntPtr pd, bool auto_del)
        {
            Eina.Log.Debug("function efl_animation_player_auto_del_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationPlayer)ws.Target).SetAutoDel(auto_del);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_player_auto_del_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), auto_del);
            }
        }

        private static efl_animation_player_auto_del_set_delegate efl_animation_player_auto_del_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Canvas.Object efl_animation_player_target_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Canvas.Object efl_animation_player_target_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_target_get_api_delegate> efl_animation_player_target_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_target_get_api_delegate>(Module, "efl_animation_player_target_get");

        private static Efl.Canvas.Object target_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_player_target_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
                try
                {
                    _ret_var = ((AnimationPlayer)ws.Target).GetTarget();
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
                return efl_animation_player_target_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_player_target_get_delegate efl_animation_player_target_get_static_delegate;

        
        private delegate void efl_animation_player_target_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object target);

        
        public delegate void efl_animation_player_target_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object target);

        public static Efl.Eo.FunctionWrapper<efl_animation_player_target_set_api_delegate> efl_animation_player_target_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_player_target_set_api_delegate>(Module, "efl_animation_player_target_set");

        private static void target_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.Object target)
        {
            Eina.Log.Debug("function efl_animation_player_target_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationPlayer)ws.Target).SetTarget(target);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_player_target_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), target);
            }
        }

        private static efl_animation_player_target_set_delegate efl_animation_player_target_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_CanvasAnimationPlayer_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Canvas.Animation> Animation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<Efl.Canvas.Animation>("animation", fac);
    }

    public static Efl.BindableProperty<bool> AutoDel<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<bool>("auto_del", fac);
    }

    public static Efl.BindableProperty<Efl.Canvas.Object> Target<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<Efl.Canvas.Object>("target", fac);
    }

    
    public static Efl.BindableProperty<bool> Play<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<bool>("play", fac);
    }

    public static Efl.BindableProperty<double> Pos<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<double>("pos", fac);
    }

    
    public static Efl.BindableProperty<double> PlaySpeed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<double>("play_speed", fac);
    }

    public static Efl.BindableProperty<double> Volume<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<double>("volume", fac);
    }

    public static Efl.BindableProperty<bool> Mute<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Canvas.AnimationPlayer, T>magic = null) where T : Efl.Canvas.AnimationPlayer {
        return new Efl.BindableProperty<bool>("mute", fac);
    }

    
    
}
#pragma warning restore CS1591
#endif
