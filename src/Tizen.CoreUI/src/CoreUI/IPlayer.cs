/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI {
    /// <summary>CoreUI media player interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IPlayerNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IPlayer : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetPlaying();

        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
        /// <returns>If <c>true</c>, the property change has succeeded.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool SetPlaying(bool playing);

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetPaused();

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
        /// <returns>If <c>true</c>, the property change has succeeded.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool SetPaused(bool paused);

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <returns>The position (in seconds).</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetPlaybackPosition();

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <param name="sec">The position (in seconds).</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPlaybackPosition(double sec);

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <returns>The progress within the [0, 1] range.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetPlaybackProgress();

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <param name="progress">The progress within the [0, 1] range.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPlaybackProgress(double progress);

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <returns>The play speed in the [0, infinity) range.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetPlaybackSpeed();

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <param name="speed">The play speed in the [0, infinity) range.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPlaybackSpeed(double speed);

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <returns>Auto play mode, Default is <c>false</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetAutoplay();

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <param name="autoplay">Auto play mode, Default is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAutoplay(bool autoplay);

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <returns>Loop mode, Default is <c>false</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetPlaybackLoop();

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <param name="looping">Loop mode, Default is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPlaybackLoop(bool looping);

        /// <summary>Called when the playing state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlayingChangedEventArgs"/></value>
        event EventHandler<CoreUI.PlayerPlayingChangedEventArgs> PlayingChanged;
        /// <summary>Called when the paused state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPausedChangedEventArgs"/></value>
        event EventHandler<CoreUI.PlayerPausedChangedEventArgs> PausedChanged;
        /// <summary>Called when the playback_progress state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackProgressChangedEventArgs"/></value>
        event EventHandler<CoreUI.PlayerPlaybackProgressChangedEventArgs> PlaybackProgressChanged;
        /// <summary>Called when the playback_position state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackPositionChangedEventArgs"/></value>
        event EventHandler<CoreUI.PlayerPlaybackPositionChangedEventArgs> PlaybackPositionChanged;
        /// <summary>Called when the player has begun to repeat its data stream. The event value is the current number of repeats.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackRepeatedEventArgs"/></value>
        event EventHandler<CoreUI.PlayerPlaybackRepeatedEventArgs> PlaybackRepeated;
        /// <summary>Called when the player has completed playing its data stream.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler PlaybackFinished;
        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Playing {
            get;
            set;
        }

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Paused {
            get;
            set;
        }

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <value>The position (in seconds).</value>
        /// <since_tizen> 6 </since_tizen>
        double PlaybackPosition {
            get;
            set;
        }

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <value>The progress within the [0, 1] range.</value>
        /// <since_tizen> 6 </since_tizen>
        double PlaybackProgress {
            get;
            set;
        }

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <value>The play speed in the [0, infinity) range.</value>
        /// <since_tizen> 6 </since_tizen>
        double PlaybackSpeed {
            get;
            set;
        }

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <value>Auto play mode, Default is <c>false</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        bool Autoplay {
            get;
            set;
        }

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <value>Loop mode, Default is <c>false</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        bool PlaybackLoop {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IPlayer.PlayingChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PlayerPlayingChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the playing state has changed. The event value reflects the current state.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IPlayer.PausedChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PlayerPausedChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the paused state has changed. The event value reflects the current state.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IPlayer.PlaybackProgressChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PlayerPlaybackProgressChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the playback_progress state has changed. The event value reflects the current state.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IPlayer.PlaybackPositionChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PlayerPlaybackPositionChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the playback_position state has changed. The event value reflects the current state.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.IPlayer.PlaybackRepeated"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class PlayerPlaybackRepeatedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the player has begun to repeat its data stream. The event value is the current number of repeats.</value>
        /// <since_tizen> 6 </since_tizen>
        public int Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IPlayerNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_player_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_player_playing_get_static_delegate == null)
            {
                efl_player_playing_get_static_delegate = new efl_player_playing_get_delegate(playing_get);
            }

            if (methods.Contains("GetPlaying"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_get_static_delegate) });
            }

            if (efl_player_playing_set_static_delegate == null)
            {
                efl_player_playing_set_static_delegate = new efl_player_playing_set_delegate(playing_set);
            }

            if (methods.Contains("SetPlaying"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_set_static_delegate) });
            }

            if (efl_player_paused_get_static_delegate == null)
            {
                efl_player_paused_get_static_delegate = new efl_player_paused_get_delegate(paused_get);
            }

            if (methods.Contains("GetPaused"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_get_static_delegate) });
            }

            if (efl_player_paused_set_static_delegate == null)
            {
                efl_player_paused_set_static_delegate = new efl_player_paused_set_delegate(paused_set);
            }

            if (methods.Contains("SetPaused"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_set_static_delegate) });
            }

            if (efl_player_playback_position_get_static_delegate == null)
            {
                efl_player_playback_position_get_static_delegate = new efl_player_playback_position_get_delegate(playback_position_get);
            }

            if (methods.Contains("GetPlaybackPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_position_get_static_delegate) });
            }

            if (efl_player_playback_position_set_static_delegate == null)
            {
                efl_player_playback_position_set_static_delegate = new efl_player_playback_position_set_delegate(playback_position_set);
            }

            if (methods.Contains("SetPlaybackPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_position_set_static_delegate) });
            }

            if (efl_player_playback_progress_get_static_delegate == null)
            {
                efl_player_playback_progress_get_static_delegate = new efl_player_playback_progress_get_delegate(playback_progress_get);
            }

            if (methods.Contains("GetPlaybackProgress"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_progress_get_static_delegate) });
            }

            if (efl_player_playback_progress_set_static_delegate == null)
            {
                efl_player_playback_progress_set_static_delegate = new efl_player_playback_progress_set_delegate(playback_progress_set);
            }

            if (methods.Contains("SetPlaybackProgress"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_progress_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_progress_set_static_delegate) });
            }

            if (efl_player_playback_speed_get_static_delegate == null)
            {
                efl_player_playback_speed_get_static_delegate = new efl_player_playback_speed_get_delegate(playback_speed_get);
            }

            if (methods.Contains("GetPlaybackSpeed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_get_static_delegate) });
            }

            if (efl_player_playback_speed_set_static_delegate == null)
            {
                efl_player_playback_speed_set_static_delegate = new efl_player_playback_speed_set_delegate(playback_speed_set);
            }

            if (methods.Contains("SetPlaybackSpeed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_set_static_delegate) });
            }

            if (efl_player_autoplay_get_static_delegate == null)
            {
                efl_player_autoplay_get_static_delegate = new efl_player_autoplay_get_delegate(autoplay_get);
            }

            if (methods.Contains("GetAutoplay"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_autoplay_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_autoplay_get_static_delegate) });
            }

            if (efl_player_autoplay_set_static_delegate == null)
            {
                efl_player_autoplay_set_static_delegate = new efl_player_autoplay_set_delegate(autoplay_set);
            }

            if (methods.Contains("SetAutoplay"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_autoplay_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_autoplay_set_static_delegate) });
            }

            if (efl_player_playback_loop_get_static_delegate == null)
            {
                efl_player_playback_loop_get_static_delegate = new efl_player_playback_loop_get_delegate(playback_loop_get);
            }

            if (methods.Contains("GetPlaybackLoop"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_loop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_loop_get_static_delegate) });
            }

            if (efl_player_playback_loop_set_static_delegate == null)
            {
                efl_player_playback_loop_set_static_delegate = new efl_player_playback_loop_set_delegate(playback_loop_set);
            }

            if (methods.Contains("SetPlaybackLoop"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_loop_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_loop_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_player_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_playing_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playing_get_api_delegate> efl_player_playing_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playing_get_api_delegate>(Module, "efl_player_playing_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool playing_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playing_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaying();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playing_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playing_get_delegate efl_player_playing_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool playing);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_playing_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool playing);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playing_set_api_delegate> efl_player_playing_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playing_set_api_delegate>(Module, "efl_player_playing_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool playing_set(System.IntPtr obj, System.IntPtr pd, bool playing)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playing_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPlaying(playing);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playing_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), playing);
            }
        }

        private static efl_player_playing_set_delegate efl_player_playing_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_paused_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_paused_get_api_delegate> efl_player_paused_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_paused_get_api_delegate>(Module, "efl_player_paused_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool paused_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_paused_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPaused();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_paused_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_paused_get_delegate efl_player_paused_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool paused);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_paused_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool paused);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_paused_set_api_delegate> efl_player_paused_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_paused_set_api_delegate>(Module, "efl_player_paused_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool paused_set(System.IntPtr obj, System.IntPtr pd, bool paused)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_paused_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPaused(paused);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_paused_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), paused);
            }
        }

        private static efl_player_paused_set_delegate efl_player_paused_set_static_delegate;

        
        private delegate double efl_player_playback_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_player_playback_position_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_get_api_delegate> efl_player_playback_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_get_api_delegate>(Module, "efl_player_playback_position_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double playback_position_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_position_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackPosition();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_position_get_delegate efl_player_playback_position_get_static_delegate;

        
        private delegate void efl_player_playback_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        internal delegate void efl_player_playback_position_set_api_delegate(System.IntPtr obj,  double sec);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_set_api_delegate> efl_player_playback_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_set_api_delegate>(Module, "efl_player_playback_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_position_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackPosition(sec);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sec);
            }
        }

        private static efl_player_playback_position_set_delegate efl_player_playback_position_set_static_delegate;

        
        private delegate double efl_player_playback_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_player_playback_progress_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_get_api_delegate> efl_player_playback_progress_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_get_api_delegate>(Module, "efl_player_playback_progress_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double playback_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_progress_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackProgress();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_progress_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_progress_get_delegate efl_player_playback_progress_get_static_delegate;

        
        private delegate void efl_player_playback_progress_set_delegate(System.IntPtr obj, System.IntPtr pd,  double progress);

        
        internal delegate void efl_player_playback_progress_set_api_delegate(System.IntPtr obj,  double progress);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_set_api_delegate> efl_player_playback_progress_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_set_api_delegate>(Module, "efl_player_playback_progress_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_progress_set(System.IntPtr obj, System.IntPtr pd, double progress)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_progress_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackProgress(progress);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_progress_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), progress);
            }
        }

        private static efl_player_playback_progress_set_delegate efl_player_playback_progress_set_static_delegate;

        
        private delegate double efl_player_playback_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_player_playback_speed_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_get_api_delegate> efl_player_playback_speed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_get_api_delegate>(Module, "efl_player_playback_speed_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double playback_speed_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_speed_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackSpeed();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_speed_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_speed_get_delegate efl_player_playback_speed_get_static_delegate;

        
        private delegate void efl_player_playback_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  double speed);

        
        internal delegate void efl_player_playback_speed_set_api_delegate(System.IntPtr obj,  double speed);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_set_api_delegate> efl_player_playback_speed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_set_api_delegate>(Module, "efl_player_playback_speed_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_speed_set(System.IntPtr obj, System.IntPtr pd, double speed)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_speed_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackSpeed(speed);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_speed_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), speed);
            }
        }

        private static efl_player_playback_speed_set_delegate efl_player_playback_speed_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_autoplay_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_autoplay_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_autoplay_get_api_delegate> efl_player_autoplay_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_autoplay_get_api_delegate>(Module, "efl_player_autoplay_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool autoplay_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_autoplay_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetAutoplay();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_autoplay_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_autoplay_get_delegate efl_player_autoplay_get_static_delegate;

        
        private delegate void efl_player_autoplay_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool autoplay);

        
        internal delegate void efl_player_autoplay_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool autoplay);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_autoplay_set_api_delegate> efl_player_autoplay_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_autoplay_set_api_delegate>(Module, "efl_player_autoplay_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void autoplay_set(System.IntPtr obj, System.IntPtr pd, bool autoplay)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_autoplay_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetAutoplay(autoplay);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_autoplay_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), autoplay);
            }
        }

        private static efl_player_autoplay_set_delegate efl_player_autoplay_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playback_loop_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_playback_loop_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_loop_get_api_delegate> efl_player_playback_loop_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_loop_get_api_delegate>(Module, "efl_player_playback_loop_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool playback_loop_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_loop_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackLoop();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_loop_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_loop_get_delegate efl_player_playback_loop_get_static_delegate;

        
        private delegate void efl_player_playback_loop_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool looping);

        
        internal delegate void efl_player_playback_loop_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool looping);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_loop_set_api_delegate> efl_player_playback_loop_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_loop_set_api_delegate>(Module, "efl_player_playback_loop_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_loop_set(System.IntPtr obj, System.IntPtr pd, bool looping)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_loop_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackLoop(looping);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_loop_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), looping);
            }
        }

        private static efl_player_playback_loop_set_delegate efl_player_playback_loop_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class PlayerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Playing<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<bool>("playing", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Paused<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<bool>("paused", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackPosition<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<double>("playback_position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackProgress<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<double>("playback_progress", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackSpeed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<double>("playback_speed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Autoplay<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<bool>("autoplay", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> PlaybackLoop<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
            return new CoreUI.BindableProperty<bool>("playback_loop", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

