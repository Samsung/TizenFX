#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl media player interface</summary>
/// <since_tizen> 6 </since_tizen>
[Efl.PlayerConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IPlayer : 
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    bool GetPlaying();

    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    bool SetPlaying(bool playing);

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
    bool GetPaused();

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    bool SetPaused(bool paused);

    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="Efl.IPlayer.Playing"/> or <see cref="Efl.IPlayer.Paused"/> states of the media file.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sec">The position (in seconds).</param>
    void SetPlaybackPosition(double sec);

    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The progress within the [0, 1] range.</returns>
    double GetPlaybackProgress();

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    double GetPlaybackSpeed();

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    void SetPlaybackSpeed(double speed);

    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    bool Playing {
        get;
        set;
    }

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
    bool Paused {
        get;
        set;
    }

    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The progress within the [0, 1] range.</value>
    double PlaybackProgress {
        get;
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value>The play speed in the [0, infinity) range.</value>
    double PlaybackSpeed {
        get;
        set;
    }

}

/// <summary>Efl media player interface</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PlayerConcrete :
    Efl.Eo.EoWrapper
    , IPlayer
    
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PlayerConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private PlayerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_player_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPlayer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PlayerConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Playback state of the media file.
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="Efl.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    public bool GetPlaying() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playing_get_ptr.Value.Delegate(this.NativeHandle);
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
    public bool SetPlaying(bool playing) {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playing_set_ptr.Value.Delegate(this.NativeHandle,playing);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Pause state of the media file.
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="Efl.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="Efl.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="Efl.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
    public bool GetPaused() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_paused_get_ptr.Value.Delegate(this.NativeHandle);
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
    public bool SetPaused(bool paused) {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_paused_set_ptr.Value.Delegate(this.NativeHandle,paused);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position in the media file.
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="Efl.IPlayer.Playing"/> or <see cref="Efl.IPlayer.Paused"/> states of the media file.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="sec">The position (in seconds).</param>
    public void SetPlaybackPosition(double sec) {
        Efl.PlayerConcrete.NativeMethods.efl_player_playback_position_set_ptr.Value.Delegate(this.NativeHandle,sec);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>How much of the file has been played.
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The progress within the [0, 1] range.</returns>
    public double GetPlaybackProgress() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playback_progress_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    public double GetPlaybackSpeed() {
        var _ret_var = Efl.PlayerConcrete.NativeMethods.efl_player_playback_speed_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    public void SetPlaybackSpeed(double speed) {
        Efl.PlayerConcrete.NativeMethods.efl_player_playback_speed_set_ptr.Value.Delegate(this.NativeHandle,speed);
        Eina.Error.RaiseIfUnhandledException();
        
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

#pragma warning restore CS0628
    private static IntPtr GetEflClassStatic()
    {
        return Efl.PlayerConcrete.efl_player_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(efl.Libs.Efl);

        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_player_playing_get_static_delegate == null)
            {
                efl_player_playing_get_static_delegate = new efl_player_playing_get_delegate(playing_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlaying") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_get_static_delegate) });
            }

            if (efl_player_playing_set_static_delegate == null)
            {
                efl_player_playing_set_static_delegate = new efl_player_playing_set_delegate(playing_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPlaying") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_set_static_delegate) });
            }

            if (efl_player_paused_get_static_delegate == null)
            {
                efl_player_paused_get_static_delegate = new efl_player_paused_get_delegate(paused_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPaused") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_get_static_delegate) });
            }

            if (efl_player_paused_set_static_delegate == null)
            {
                efl_player_paused_set_static_delegate = new efl_player_paused_set_delegate(paused_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPaused") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_set_static_delegate) });
            }

            if (efl_player_playback_position_set_static_delegate == null)
            {
                efl_player_playback_position_set_static_delegate = new efl_player_playback_position_set_delegate(playback_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPlaybackPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_position_set_static_delegate) });
            }

            if (efl_player_playback_progress_get_static_delegate == null)
            {
                efl_player_playback_progress_get_static_delegate = new efl_player_playback_progress_get_delegate(playback_progress_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlaybackProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_progress_get_static_delegate) });
            }

            if (efl_player_playback_speed_get_static_delegate == null)
            {
                efl_player_playback_speed_get_static_delegate = new efl_player_playback_speed_get_delegate(playback_speed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlaybackSpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_get_static_delegate) });
            }

            if (efl_player_playback_speed_set_static_delegate == null)
            {
                efl_player_playback_speed_set_static_delegate = new efl_player_playback_speed_set_delegate(playback_speed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetPlaybackSpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_set_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.PlayerConcrete.efl_player_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_playing_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_playing_get_api_delegate> efl_player_playing_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playing_get_api_delegate>(Module, "efl_player_playing_get");

        private static bool playing_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_playing_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaying();
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
                return efl_player_playing_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_playing_get_delegate efl_player_playing_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool playing);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_playing_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool playing);

        public static Efl.Eo.FunctionWrapper<efl_player_playing_set_api_delegate> efl_player_playing_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_playing_set_api_delegate>(Module, "efl_player_playing_set");

        private static bool playing_set(System.IntPtr obj, System.IntPtr pd, bool playing)
        {
            Eina.Log.Debug("function efl_player_playing_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPlaying(playing);
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
                return efl_player_playing_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), playing);
            }
        }

        private static efl_player_playing_set_delegate efl_player_playing_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_paused_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_paused_get_api_delegate> efl_player_paused_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_paused_get_api_delegate>(Module, "efl_player_paused_get");

        private static bool paused_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_paused_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPaused();
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
                return efl_player_paused_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_paused_get_delegate efl_player_paused_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool paused);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_player_paused_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool paused);

        public static Efl.Eo.FunctionWrapper<efl_player_paused_set_api_delegate> efl_player_paused_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_paused_set_api_delegate>(Module, "efl_player_paused_set");

        private static bool paused_set(System.IntPtr obj, System.IntPtr pd, bool paused)
        {
            Eina.Log.Debug("function efl_player_paused_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPaused(paused);
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
                return efl_player_paused_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), paused);
            }
        }

        private static efl_player_paused_set_delegate efl_player_paused_set_static_delegate;

        
        private delegate void efl_player_playback_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        public delegate void efl_player_playback_position_set_api_delegate(System.IntPtr obj,  double sec);

        public static Efl.Eo.FunctionWrapper<efl_player_playback_position_set_api_delegate> efl_player_playback_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_playback_position_set_api_delegate>(Module, "efl_player_playback_position_set");

        private static void playback_position_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            Eina.Log.Debug("function efl_player_playback_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackPosition(sec);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sec);
            }
        }

        private static efl_player_playback_position_set_delegate efl_player_playback_position_set_static_delegate;

        
        private delegate double efl_player_playback_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_playback_progress_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_playback_progress_get_api_delegate> efl_player_playback_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playback_progress_get_api_delegate>(Module, "efl_player_playback_progress_get");

        private static double playback_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_playback_progress_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackProgress();
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
                return efl_player_playback_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_playback_progress_get_delegate efl_player_playback_progress_get_static_delegate;

        
        private delegate double efl_player_playback_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_player_playback_speed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_player_playback_speed_get_api_delegate> efl_player_playback_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_player_playback_speed_get_api_delegate>(Module, "efl_player_playback_speed_get");

        private static double playback_speed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_player_playback_speed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackSpeed();
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
                return efl_player_playback_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_player_playback_speed_get_delegate efl_player_playback_speed_get_static_delegate;

        
        private delegate void efl_player_playback_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  double speed);

        
        public delegate void efl_player_playback_speed_set_api_delegate(System.IntPtr obj,  double speed);

        public static Efl.Eo.FunctionWrapper<efl_player_playback_speed_set_api_delegate> efl_player_playback_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_player_playback_speed_set_api_delegate>(Module, "efl_player_playback_speed_set");

        private static void playback_speed_set(System.IntPtr obj, System.IntPtr pd, double speed)
        {
            Eina.Log.Debug("function efl_player_playback_speed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackSpeed(speed);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), speed);
            }
        }

        private static efl_player_playback_speed_set_delegate efl_player_playback_speed_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflPlayerConcrete_ExtensionMethods {
    public static Efl.BindableProperty<bool> Playing<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IPlayer, T>magic = null) where T : Efl.IPlayer {
        return new Efl.BindableProperty<bool>("playing", fac);
    }

    public static Efl.BindableProperty<bool> Paused<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IPlayer, T>magic = null) where T : Efl.IPlayer {
        return new Efl.BindableProperty<bool>("paused", fac);
    }

    public static Efl.BindableProperty<double> PlaybackSpeed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IPlayer, T>magic = null) where T : Efl.IPlayer {
        return new Efl.BindableProperty<double>("playback_speed", fac);
    }

}
#pragma warning restore CS1591
#endif
