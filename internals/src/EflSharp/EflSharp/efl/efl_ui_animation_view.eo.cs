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

/// <summary>Elementary Animation view class. Animation view is designed to show and play animation of vector graphics based content. It hides all efl_canvas_vg details but just open an API to read vector data from file. Also, it implements details of animation control methods of Vector.
/// Vector data could contain static or animatable vector elements including animation infomation. Currently approved vector data file format is svg, json and eet. Only json(known for Lottie file as well) and eet could contains animation infomation, currently Animation_View is supporting.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.AnimationView.NativeMethods]
[Efl.Eo.BindingEntity]
public class AnimationView : Efl.Ui.Widget, Efl.IFile, Efl.Gfx.IView
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(AnimationView))
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
        efl_ui_animation_view_class_get();
    /// <summary>Initializes a new instance of the <see cref="AnimationView"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public AnimationView(Efl.Object parent
            , System.String style = null) : base(efl_ui_animation_view_class_get(), parent)
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
    protected AnimationView(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationView"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected AnimationView(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="AnimationView"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected AnimationView(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Called when animation is just started</summary>
    public event EventHandler PlayStartEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_START";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_START";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayStartEvt.</summary>
    public void OnPlayStartEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_START";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just repeated</summary>
    public event EventHandler PlayRepeatEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_REPEAT";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_REPEAT";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayRepeatEvt.</summary>
    public void OnPlayRepeatEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_REPEAT";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just finished</summary>
    public event EventHandler PlayDoneEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_DONE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_DONE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayDoneEvt.</summary>
    public void OnPlayDoneEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_DONE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just paused</summary>
    public event EventHandler PlayPauseEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_PAUSE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_PAUSE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayPauseEvt.</summary>
    public void OnPlayPauseEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_PAUSE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just resumed</summary>
    public event EventHandler PlayResumeEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_RESUME";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_RESUME";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayResumeEvt.</summary>
    public void OnPlayResumeEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_RESUME";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just stopped</summary>
    public event EventHandler PlayStopEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_STOP";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_STOP";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayStopEvt.</summary>
    public void OnPlayStopEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_STOP";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Called when animation is just updated</summary>
    public event EventHandler PlayUpdateEvt
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

                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_UPDATE";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_UPDATE";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event PlayUpdateEvt.</summary>
    public void OnPlayUpdateEvt(EventArgs e)
    {
        var key = "_EFL_UI_ANIMATION_VIEW_EVENT_PLAY_UPDATE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Animation will be started automatically when it&apos;s possible.
    /// If <see cref="Efl.Ui.AnimationView.AutoPlay"/> is <c>true</c>, animation will be started when it&apos;s readied. The condition of <c>auto</c> play is when animation view opened file successfully, yet to play it plus when the object is visible. If animation view is disabled, invisible, it turns to pause state then resume animation when it&apos;s visible again.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.
    /// 
    /// Warning: This auto play will be only affected to the next animation source. So must be called before setting animation file.</summary>
    /// <returns>Auto play mode, Default value is <c>false</c></returns>
    virtual public bool GetAutoPlay() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_auto_play_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Animation will be started automatically when it&apos;s possible.
    /// If <see cref="Efl.Ui.AnimationView.AutoPlay"/> is <c>true</c>, animation will be started when it&apos;s readied. The condition of <c>auto</c> play is when animation view opened file successfully, yet to play it plus when the object is visible. If animation view is disabled, invisible, it turns to pause state then resume animation when it&apos;s visible again.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.
    /// 
    /// Warning: This auto play will be only affected to the next animation source. So must be called before setting animation file.</summary>
    /// <param name="auto_play">Auto play mode, Default value is <c>false</c></param>
    virtual public void SetAutoPlay(bool auto_play) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_auto_play_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),auto_play);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Turn on/off animation looping.
    /// If <see cref="Efl.Ui.AnimationView.AutoRepeat"/> is <c>true</c>, it repeats animation when animation frame is reached to end. This auto repeat mode is valid to both play and play_back cases.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.</summary>
    /// <returns>Loop mode, Defalut is <c>false</c>.</returns>
    virtual public bool GetAutoRepeat() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_auto_repeat_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Turn on/off animation looping.
    /// If <see cref="Efl.Ui.AnimationView.AutoRepeat"/> is <c>true</c>, it repeats animation when animation frame is reached to end. This auto repeat mode is valid to both play and play_back cases.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.</summary>
    /// <param name="auto_repeat">Loop mode, Defalut is <c>false</c>.</param>
    virtual public void SetAutoRepeat(bool auto_repeat) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_auto_repeat_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),auto_repeat);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control animation speed.
    /// Control animation speed by multiplying <c>speed</c> value. If you want to play animation double-time faster, you can give <c>speed</c> 2. If you want to play animation double-time slower, you can give <c>speed</c> 0.5.
    /// 
    /// <c>true</c> when it&apos;s successful. <c>false</c> otherwise.
    /// 
    /// Warning: speed must be greater than zero.</summary>
    /// <returns>Speed factor. Default value is 1.0</returns>
    virtual public double GetSpeed() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control animation speed.
    /// Control animation speed by multiplying <c>speed</c> value. If you want to play animation double-time faster, you can give <c>speed</c> 2. If you want to play animation double-time slower, you can give <c>speed</c> 0.5.
    /// 
    /// <c>true</c> when it&apos;s successful. <c>false</c> otherwise.
    /// 
    /// Warning: speed must be greater than zero.</summary>
    /// <param name="speed">Speed factor. Default value is 1.0</param>
    virtual public bool SetSpeed(double speed) {
                                 var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),speed);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the duration of animation in seconds.
    /// This API returns total duration time of current animation in the seconds. If current animation source isn&apos;t animatable, it returns zero.</summary>
    /// <returns>duration time in the seconds</returns>
    virtual public double GetDurationTime() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_duration_time_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set current progress position of animation view object.
    /// When you required to jump on a certain frame instantly, you can change current position by using this API.
    /// 
    /// Warning: The range of progress is 0 ~ 1.</summary>
    /// <returns>Progress position. Value must be 0 ~ 1.</returns>
    virtual public double GetProgress() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set current progress position of animation view object.
    /// When you required to jump on a certain frame instantly, you can change current position by using this API.
    /// 
    /// Warning: The range of progress is 0 ~ 1.</summary>
    /// <param name="progress">Progress position. Value must be 0 ~ 1.</param>
    virtual public void SetProgress(double progress) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_progress_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),progress);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Number of current frame.
    /// Ranges from 0 to <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1.</summary>
    /// <returns>Current frame number.</returns>
    virtual public int GetFrame() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_frame_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Number of current frame.
    /// Ranges from 0 to <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1.</summary>
    /// <param name="frame_num">Current frame number.</param>
    virtual public void SetFrame(int frame_num) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_frame_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),frame_num);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The default view size that specified from vector resource.</summary>
    virtual public Eina.Size2D GetDefaultViewSize() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_default_view_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Current animation view state. see <see cref="Efl.Ui.AnimationViewState"/></summary>
    /// <returns>Current animation view state</returns>
    virtual public Efl.Ui.AnimationViewState GetState() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_state_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The index of end frame of the animation view, if it&apos;s animated. note : frame number starts with 0.</summary>
    /// <returns>The number of frames. 0, if it&apos;s not animated.</returns>
    virtual public int GetFrameCount() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_frame_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The start progress of the play. Default value is 0.</summary>
    /// <returns>The minimum progress. Value must be 0 ~ 1.</returns>
    virtual public double GetMinProgress() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_min_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The start progress of the play. Default value is 0.</summary>
    /// <param name="min_progress">The minimum progress. Value must be 0 ~ 1.</param>
    virtual public void SetMinProgress(double min_progress) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_min_progress_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),min_progress);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The last progress of the play. Default value is 1.</summary>
    /// <returns>The maximum progress. Value must be 0 ~ 1.</returns>
    virtual public double GetMaxProgress() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_max_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The last progress of the play. Default value is 1.</summary>
    /// <param name="max_progress">The maximum progress. Value must be 0 ~ 1.</param>
    virtual public void SetMaxProgress(double max_progress) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_max_progress_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),max_progress);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The start frame of the play. Default value is 0.</summary>
    /// <returns>The minimum frame for play. Value must be 0 ~ <see cref="Efl.Ui.AnimationView.MaxFrame"/></returns>
    virtual public int GetMinFrame() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_min_frame_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The start frame of the play. Default value is 0.</summary>
    /// <param name="min_frame">The minimum frame for play. Value must be 0 ~ <see cref="Efl.Ui.AnimationView.MaxFrame"/></param>
    virtual public void SetMinFrame(int min_frame) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_min_frame_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),min_frame);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>The last frame of the play. Default value is <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1</summary>
    /// <returns>The maximum frame for play. Value must be <see cref="Efl.Ui.AnimationView.MinFrame"/> ~ (<see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1)</returns>
    virtual public int GetMaxFrame() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_max_frame_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The last frame of the play. Default value is <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1</summary>
    /// <param name="max_frame">The maximum frame for play. Value must be <see cref="Efl.Ui.AnimationView.MinFrame"/> ~ (<see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1)</param>
    virtual public void SetMaxFrame(int max_frame) {
                                 Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_max_frame_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),max_frame);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Play animation one time instantly when it&apos;s available.
    /// If current keyframe is on a certain position by playing back, this will play forward from there.
    /// 
    /// Warning: Play request will be ignored if animation source is not set yet or animation is paused state or it&apos;s already on playing.</summary>
    /// <returns><c>true</c> when it&apos;s successful. <c>false</c> otherwise.</returns>
    virtual public bool Play() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_play_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Play back animation one time instantly when it&apos;s available.
    /// If current keyframe is on a certain position by playing, this will play backward from there.
    /// 
    /// Warning: Play back request will be ignored if animation source is not set yet or animation is paused state or it&apos;s already on playing back.</summary>
    /// <returns><c>true</c> when it&apos;s successful. <c>false</c> otherwise.</returns>
    virtual public bool PlayBack() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_play_back_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Pause current animation instantly.
    /// Once animation is paused, animation view must get resume to play continue again.
    /// 
    /// Warning: Animation must be on playing or playing back status.</summary>
    /// <returns><c>true</c> when it&apos;s successful. <c>false</c> otherwise.</returns>
    virtual public bool Pause() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_pause_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Resume paused animation to continue animation.
    /// Warning: This resume must be called on animation paused status.</summary>
    /// <returns><c>true</c> when it&apos;s successful. <c>false</c> otherwise.</returns>
    virtual public bool Resume() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_resume_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Stop playing animation.
    /// Stop animation instatly regardless of it&apos;s status and reset to show first frame of animation. Even though current animation is paused, the animation status will be stopped.</summary>
    /// <returns><c>true</c> when it&apos;s successful. <c>false</c> otherwise.</returns>
    virtual public bool Stop() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Returns the status whether current animation is on playing forward or backward. warning: If animation view is not on playing, it will return <c>false</c>.</summary>
    /// <returns><c>true</c>, if animation on playing back, <c>false</c> otherwise.</returns>
    virtual public bool IsPlayingBack() {
         var _ret_var = Efl.Ui.AnimationView.NativeMethods.efl_ui_animation_view_is_playing_back_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <returns>The handle to the <see cref="Eina.File"/> that will be used</returns>
    virtual public Eina.File GetMmap() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// If mmap is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="f">The handle to the <see cref="Eina.File"/> that will be used</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetMmap(Eina.File f) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),f);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <returns>The file path.</returns>
    virtual public System.String GetFile() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the file path from where an object will fetch the data.
    /// If file is set during object construction, the object will automatically call <see cref="Efl.IFile.Load"/> during the finalize phase of construction.
    /// (Since EFL 1.22)</summary>
    /// <param name="file">The file path.</param>
    /// <returns>0 on success, error code otherwise</returns>
    virtual public Eina.Error SetFile(System.String file) {
                                 var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),file);
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
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Set the key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
    /// (Since EFL 1.22)</summary>
    /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
    virtual public void SetKey(System.String key) {
                                 Efl.IFileConcrete.NativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
    virtual public bool GetLoaded() {
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
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
         var _ret_var = Efl.IFileConcrete.NativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Perform all necessary operations to unload file data from the object.
    /// In the case where <see cref="Efl.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
    /// 
    /// Calling <see cref="Efl.IFile.Unload"/> on an object which is not currently loaded will have no effect.
    /// (Since EFL 1.22)</summary>
    virtual public void Unload() {
         Efl.IFileConcrete.NativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>The dimensions of this object&apos;s viewport.
    /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
    /// 
    /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
    /// 
    /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
    /// 
    /// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
    /// 
    /// Refer to each implementing class specific documentation for more details.</summary>
    /// <returns>Size of the view.</returns>
    virtual public Eina.Size2D GetViewSize() {
         var _ret_var = Efl.Gfx.IViewConcrete.NativeMethods.efl_gfx_view_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>The dimensions of this object&apos;s viewport.
    /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
    /// 
    /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
    /// 
    /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
    /// 
    /// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
    /// 
    /// Refer to each implementing class specific documentation for more details.</summary>
    /// <param name="size">Size of the view.</param>
    virtual public void SetViewSize(Eina.Size2D size) {
         Eina.Size2D.NativeStruct _in_size = size;
                        Efl.Gfx.IViewConcrete.NativeMethods.efl_gfx_view_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_size);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Animation will be started automatically when it&apos;s possible.
    /// If <see cref="Efl.Ui.AnimationView.AutoPlay"/> is <c>true</c>, animation will be started when it&apos;s readied. The condition of <c>auto</c> play is when animation view opened file successfully, yet to play it plus when the object is visible. If animation view is disabled, invisible, it turns to pause state then resume animation when it&apos;s visible again.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.
    /// 
    /// Warning: This auto play will be only affected to the next animation source. So must be called before setting animation file.</summary>
    /// <value>Auto play mode, Default value is <c>false</c></value>
    public bool AutoPlay {
        get { return GetAutoPlay(); }
        set { SetAutoPlay(value); }
    }
    /// <summary>Turn on/off animation looping.
    /// If <see cref="Efl.Ui.AnimationView.AutoRepeat"/> is <c>true</c>, it repeats animation when animation frame is reached to end. This auto repeat mode is valid to both play and play_back cases.
    /// 
    /// <c>true</c> Enable auto play mode, disable otherwise.</summary>
    /// <value>Loop mode, Defalut is <c>false</c>.</value>
    public bool AutoRepeat {
        get { return GetAutoRepeat(); }
        set { SetAutoRepeat(value); }
    }
    /// <summary>Control animation speed.
    /// Control animation speed by multiplying <c>speed</c> value. If you want to play animation double-time faster, you can give <c>speed</c> 2. If you want to play animation double-time slower, you can give <c>speed</c> 0.5.
    /// 
    /// <c>true</c> when it&apos;s successful. <c>false</c> otherwise.
    /// 
    /// Warning: speed must be greater than zero.</summary>
    /// <value>Speed factor. Default value is 1.0</value>
    public double Speed {
        get { return GetSpeed(); }
        set { SetSpeed(value); }
    }
    /// <summary>Get the duration of animation in seconds.
    /// This API returns total duration time of current animation in the seconds. If current animation source isn&apos;t animatable, it returns zero.</summary>
    /// <value>duration time in the seconds</value>
    public double DurationTime {
        get { return GetDurationTime(); }
    }
    /// <summary>Set current progress position of animation view object.
    /// When you required to jump on a certain frame instantly, you can change current position by using this API.
    /// 
    /// Warning: The range of progress is 0 ~ 1.</summary>
    /// <value>Progress position. Value must be 0 ~ 1.</value>
    public double Progress {
        get { return GetProgress(); }
        set { SetProgress(value); }
    }
    /// <summary>Number of current frame.
    /// Ranges from 0 to <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1.</summary>
    /// <value>Current frame number.</value>
    public int Frame {
        get { return GetFrame(); }
        set { SetFrame(value); }
    }
    /// <summary>The default view size that specified from vector resource.</summary>
    public Eina.Size2D DefaultViewSize {
        get { return GetDefaultViewSize(); }
    }
    /// <summary>Current animation view state. see <see cref="Efl.Ui.AnimationViewState"/></summary>
    /// <value>Current animation view state</value>
    public Efl.Ui.AnimationViewState State {
        get { return GetState(); }
    }
    /// <summary>The index of end frame of the animation view, if it&apos;s animated. note : frame number starts with 0.</summary>
    /// <value>The number of frames. 0, if it&apos;s not animated.</value>
    public int FrameCount {
        get { return GetFrameCount(); }
    }
    /// <summary>The start progress of the play. Default value is 0.</summary>
    /// <value>The minimum progress. Value must be 0 ~ 1.</value>
    public double MinProgress {
        get { return GetMinProgress(); }
        set { SetMinProgress(value); }
    }
    /// <summary>The last progress of the play. Default value is 1.</summary>
    /// <value>The maximum progress. Value must be 0 ~ 1.</value>
    public double MaxProgress {
        get { return GetMaxProgress(); }
        set { SetMaxProgress(value); }
    }
    /// <summary>The start frame of the play. Default value is 0.</summary>
    /// <value>The minimum frame for play. Value must be 0 ~ <see cref="Efl.Ui.AnimationView.MaxFrame"/></value>
    public int MinFrame {
        get { return GetMinFrame(); }
        set { SetMinFrame(value); }
    }
    /// <summary>The last frame of the play. Default value is <see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1</summary>
    /// <value>The maximum frame for play. Value must be <see cref="Efl.Ui.AnimationView.MinFrame"/> ~ (<see cref="Efl.Ui.AnimationView.GetFrameCount"/> - 1)</value>
    public int MaxFrame {
        get { return GetMaxFrame(); }
        set { SetMaxFrame(value); }
    }
    /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an <see cref="Eina.File"/>).
    /// (Since EFL 1.22)</summary>
    /// <value>The handle to the <see cref="Eina.File"/> that will be used</value>
    public Eina.File Mmap {
        get { return GetMmap(); }
        set { SetMmap(value); }
    }
    /// <summary>Retrieve the file path from where an object is to fetch the data.
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The file path.</value>
    public System.String File {
        get { return GetFile(); }
        set { SetFile(value); }
    }
    /// <summary>Get the previously-set key which corresponds to the target data within a file.
    /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="Efl.Ui.Image"/> or <see cref="Efl.Ui.Layout"/>).
    /// 
    /// You must not modify the strings on the returned pointers.
    /// (Since EFL 1.22)</summary>
    /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
    public System.String Key {
        get { return GetKey(); }
        set { SetKey(value); }
    }
    /// <summary>Get the load state of the object.
    /// (Since EFL 1.22)</summary>
    /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
    public bool Loaded {
        get { return GetLoaded(); }
    }
    /// <summary>The dimensions of this object&apos;s viewport.
    /// This property represents the size of an image (file on disk, vector graphics, GL or 3D scene, ...) view: this is the logical size of a view, not the number of pixels in the buffer, nor its visible size on the window.
    /// 
    /// For scalable scenes (vector graphics, 3D or GL), this means scaling the contents of the scene and drawing more pixels as a result; For pixmaps this means zooming and stretching up or down the backing buffer to fit this view.
    /// 
    /// In most cases the view should have the same dimensions as the object on the canvas, for best quality.
    /// 
    /// <see cref="Efl.Gfx.IView.SetViewSize"/> may not be implemented. If it is, it might trigger a complete recalculation of the scene, or reload of the pixel data.
    /// 
    /// Refer to each implementing class specific documentation for more details.</summary>
    /// <value>Size of the view.</value>
    public Eina.Size2D ViewSize {
        get { return GetViewSize(); }
        set { SetViewSize(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.AnimationView.efl_ui_animation_view_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_animation_view_auto_play_get_static_delegate == null)
            {
                efl_ui_animation_view_auto_play_get_static_delegate = new efl_ui_animation_view_auto_play_get_delegate(auto_play_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutoPlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_auto_play_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_auto_play_get_static_delegate) });
            }

            if (efl_ui_animation_view_auto_play_set_static_delegate == null)
            {
                efl_ui_animation_view_auto_play_set_static_delegate = new efl_ui_animation_view_auto_play_set_delegate(auto_play_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutoPlay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_auto_play_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_auto_play_set_static_delegate) });
            }

            if (efl_ui_animation_view_auto_repeat_get_static_delegate == null)
            {
                efl_ui_animation_view_auto_repeat_get_static_delegate = new efl_ui_animation_view_auto_repeat_get_delegate(auto_repeat_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetAutoRepeat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_auto_repeat_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_auto_repeat_get_static_delegate) });
            }

            if (efl_ui_animation_view_auto_repeat_set_static_delegate == null)
            {
                efl_ui_animation_view_auto_repeat_set_static_delegate = new efl_ui_animation_view_auto_repeat_set_delegate(auto_repeat_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetAutoRepeat") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_auto_repeat_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_auto_repeat_set_static_delegate) });
            }

            if (efl_ui_animation_view_speed_get_static_delegate == null)
            {
                efl_ui_animation_view_speed_get_static_delegate = new efl_ui_animation_view_speed_get_delegate(speed_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_speed_get_static_delegate) });
            }

            if (efl_ui_animation_view_speed_set_static_delegate == null)
            {
                efl_ui_animation_view_speed_set_static_delegate = new efl_ui_animation_view_speed_set_delegate(speed_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetSpeed") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_speed_set_static_delegate) });
            }

            if (efl_ui_animation_view_duration_time_get_static_delegate == null)
            {
                efl_ui_animation_view_duration_time_get_static_delegate = new efl_ui_animation_view_duration_time_get_delegate(duration_time_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDurationTime") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_duration_time_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_duration_time_get_static_delegate) });
            }

            if (efl_ui_animation_view_progress_get_static_delegate == null)
            {
                efl_ui_animation_view_progress_get_static_delegate = new efl_ui_animation_view_progress_get_delegate(progress_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_progress_get_static_delegate) });
            }

            if (efl_ui_animation_view_progress_set_static_delegate == null)
            {
                efl_ui_animation_view_progress_set_static_delegate = new efl_ui_animation_view_progress_set_delegate(progress_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_progress_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_progress_set_static_delegate) });
            }

            if (efl_ui_animation_view_frame_get_static_delegate == null)
            {
                efl_ui_animation_view_frame_get_static_delegate = new efl_ui_animation_view_frame_get_delegate(frame_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_frame_get_static_delegate) });
            }

            if (efl_ui_animation_view_frame_set_static_delegate == null)
            {
                efl_ui_animation_view_frame_set_static_delegate = new efl_ui_animation_view_frame_set_delegate(frame_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_frame_set_static_delegate) });
            }

            if (efl_ui_animation_view_default_view_size_get_static_delegate == null)
            {
                efl_ui_animation_view_default_view_size_get_static_delegate = new efl_ui_animation_view_default_view_size_get_delegate(default_view_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDefaultViewSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_default_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_default_view_size_get_static_delegate) });
            }

            if (efl_ui_animation_view_state_get_static_delegate == null)
            {
                efl_ui_animation_view_state_get_static_delegate = new efl_ui_animation_view_state_get_delegate(state_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetState") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_state_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_state_get_static_delegate) });
            }

            if (efl_ui_animation_view_frame_count_get_static_delegate == null)
            {
                efl_ui_animation_view_frame_count_get_static_delegate = new efl_ui_animation_view_frame_count_get_delegate(frame_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFrameCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_frame_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_frame_count_get_static_delegate) });
            }

            if (efl_ui_animation_view_min_progress_get_static_delegate == null)
            {
                efl_ui_animation_view_min_progress_get_static_delegate = new efl_ui_animation_view_min_progress_get_delegate(min_progress_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMinProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_min_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_min_progress_get_static_delegate) });
            }

            if (efl_ui_animation_view_min_progress_set_static_delegate == null)
            {
                efl_ui_animation_view_min_progress_set_static_delegate = new efl_ui_animation_view_min_progress_set_delegate(min_progress_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMinProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_min_progress_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_min_progress_set_static_delegate) });
            }

            if (efl_ui_animation_view_max_progress_get_static_delegate == null)
            {
                efl_ui_animation_view_max_progress_get_static_delegate = new efl_ui_animation_view_max_progress_get_delegate(max_progress_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMaxProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_max_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_max_progress_get_static_delegate) });
            }

            if (efl_ui_animation_view_max_progress_set_static_delegate == null)
            {
                efl_ui_animation_view_max_progress_set_static_delegate = new efl_ui_animation_view_max_progress_set_delegate(max_progress_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMaxProgress") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_max_progress_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_max_progress_set_static_delegate) });
            }

            if (efl_ui_animation_view_min_frame_get_static_delegate == null)
            {
                efl_ui_animation_view_min_frame_get_static_delegate = new efl_ui_animation_view_min_frame_get_delegate(min_frame_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMinFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_min_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_min_frame_get_static_delegate) });
            }

            if (efl_ui_animation_view_min_frame_set_static_delegate == null)
            {
                efl_ui_animation_view_min_frame_set_static_delegate = new efl_ui_animation_view_min_frame_set_delegate(min_frame_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMinFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_min_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_min_frame_set_static_delegate) });
            }

            if (efl_ui_animation_view_max_frame_get_static_delegate == null)
            {
                efl_ui_animation_view_max_frame_get_static_delegate = new efl_ui_animation_view_max_frame_get_delegate(max_frame_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMaxFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_max_frame_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_max_frame_get_static_delegate) });
            }

            if (efl_ui_animation_view_max_frame_set_static_delegate == null)
            {
                efl_ui_animation_view_max_frame_set_static_delegate = new efl_ui_animation_view_max_frame_set_delegate(max_frame_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMaxFrame") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_max_frame_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_max_frame_set_static_delegate) });
            }

            if (efl_ui_animation_view_play_static_delegate == null)
            {
                efl_ui_animation_view_play_static_delegate = new efl_ui_animation_view_play_delegate(play);
            }

            if (methods.FirstOrDefault(m => m.Name == "Play") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_play"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_play_static_delegate) });
            }

            if (efl_ui_animation_view_play_back_static_delegate == null)
            {
                efl_ui_animation_view_play_back_static_delegate = new efl_ui_animation_view_play_back_delegate(play_back);
            }

            if (methods.FirstOrDefault(m => m.Name == "PlayBack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_play_back"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_play_back_static_delegate) });
            }

            if (efl_ui_animation_view_pause_static_delegate == null)
            {
                efl_ui_animation_view_pause_static_delegate = new efl_ui_animation_view_pause_delegate(pause);
            }

            if (methods.FirstOrDefault(m => m.Name == "Pause") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_pause"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_pause_static_delegate) });
            }

            if (efl_ui_animation_view_resume_static_delegate == null)
            {
                efl_ui_animation_view_resume_static_delegate = new efl_ui_animation_view_resume_delegate(resume);
            }

            if (methods.FirstOrDefault(m => m.Name == "Resume") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_resume"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_resume_static_delegate) });
            }

            if (efl_ui_animation_view_stop_static_delegate == null)
            {
                efl_ui_animation_view_stop_static_delegate = new efl_ui_animation_view_stop_delegate(stop);
            }

            if (methods.FirstOrDefault(m => m.Name == "Stop") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_stop_static_delegate) });
            }

            if (efl_ui_animation_view_is_playing_back_static_delegate == null)
            {
                efl_ui_animation_view_is_playing_back_static_delegate = new efl_ui_animation_view_is_playing_back_delegate(is_playing_back);
            }

            if (methods.FirstOrDefault(m => m.Name == "IsPlayingBack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_animation_view_is_playing_back"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_animation_view_is_playing_back_static_delegate) });
            }

            if (efl_file_mmap_get_static_delegate == null)
            {
                efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate) });
            }

            if (efl_file_mmap_set_static_delegate == null)
            {
                efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetMmap") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate) });
            }

            if (efl_file_get_static_delegate == null)
            {
                efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate) });
            }

            if (efl_file_set_static_delegate == null)
            {
                efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFile") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate) });
            }

            if (efl_file_key_get_static_delegate == null)
            {
                efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate) });
            }

            if (efl_file_key_set_static_delegate == null)
            {
                efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetKey") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate) });
            }

            if (efl_file_loaded_get_static_delegate == null)
            {
                efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLoaded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate) });
            }

            if (efl_file_load_static_delegate == null)
            {
                efl_file_load_static_delegate = new efl_file_load_delegate(load);
            }

            if (methods.FirstOrDefault(m => m.Name == "Load") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate) });
            }

            if (efl_file_unload_static_delegate == null)
            {
                efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unload") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate) });
            }

            if (efl_gfx_view_size_get_static_delegate == null)
            {
                efl_gfx_view_size_get_static_delegate = new efl_gfx_view_size_get_delegate(view_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetViewSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_view_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_get_static_delegate) });
            }

            if (efl_gfx_view_size_set_static_delegate == null)
            {
                efl_gfx_view_size_set_static_delegate = new efl_gfx_view_size_set_delegate(view_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetViewSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_view_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_view_size_set_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.AnimationView.efl_ui_animation_view_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_auto_play_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_auto_play_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_play_get_api_delegate> efl_ui_animation_view_auto_play_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_play_get_api_delegate>(Module, "efl_ui_animation_view_auto_play_get");

        private static bool auto_play_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_auto_play_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetAutoPlay();
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
                return efl_ui_animation_view_auto_play_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_auto_play_get_delegate efl_ui_animation_view_auto_play_get_static_delegate;

        
        private delegate void efl_ui_animation_view_auto_play_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool auto_play);

        
        public delegate void efl_ui_animation_view_auto_play_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool auto_play);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_play_set_api_delegate> efl_ui_animation_view_auto_play_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_play_set_api_delegate>(Module, "efl_ui_animation_view_auto_play_set");

        private static void auto_play_set(System.IntPtr obj, System.IntPtr pd, bool auto_play)
        {
            Eina.Log.Debug("function efl_ui_animation_view_auto_play_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetAutoPlay(auto_play);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_auto_play_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), auto_play);
            }
        }

        private static efl_ui_animation_view_auto_play_set_delegate efl_ui_animation_view_auto_play_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_auto_repeat_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_auto_repeat_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_repeat_get_api_delegate> efl_ui_animation_view_auto_repeat_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_repeat_get_api_delegate>(Module, "efl_ui_animation_view_auto_repeat_get");

        private static bool auto_repeat_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_auto_repeat_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetAutoRepeat();
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
                return efl_ui_animation_view_auto_repeat_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_auto_repeat_get_delegate efl_ui_animation_view_auto_repeat_get_static_delegate;

        
        private delegate void efl_ui_animation_view_auto_repeat_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool auto_repeat);

        
        public delegate void efl_ui_animation_view_auto_repeat_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool auto_repeat);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_repeat_set_api_delegate> efl_ui_animation_view_auto_repeat_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_auto_repeat_set_api_delegate>(Module, "efl_ui_animation_view_auto_repeat_set");

        private static void auto_repeat_set(System.IntPtr obj, System.IntPtr pd, bool auto_repeat)
        {
            Eina.Log.Debug("function efl_ui_animation_view_auto_repeat_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetAutoRepeat(auto_repeat);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_auto_repeat_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), auto_repeat);
            }
        }

        private static efl_ui_animation_view_auto_repeat_set_delegate efl_ui_animation_view_auto_repeat_set_static_delegate;

        
        private delegate double efl_ui_animation_view_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_animation_view_speed_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_speed_get_api_delegate> efl_ui_animation_view_speed_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_speed_get_api_delegate>(Module, "efl_ui_animation_view_speed_get");

        private static double speed_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_speed_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetSpeed();
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
                return efl_ui_animation_view_speed_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_speed_get_delegate efl_ui_animation_view_speed_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  double speed);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_speed_set_api_delegate(System.IntPtr obj,  double speed);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_speed_set_api_delegate> efl_ui_animation_view_speed_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_speed_set_api_delegate>(Module, "efl_ui_animation_view_speed_set");

        private static bool speed_set(System.IntPtr obj, System.IntPtr pd, double speed)
        {
            Eina.Log.Debug("function efl_ui_animation_view_speed_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).SetSpeed(speed);
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
                return efl_ui_animation_view_speed_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), speed);
            }
        }

        private static efl_ui_animation_view_speed_set_delegate efl_ui_animation_view_speed_set_static_delegate;

        
        private delegate double efl_ui_animation_view_duration_time_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_animation_view_duration_time_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_duration_time_get_api_delegate> efl_ui_animation_view_duration_time_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_duration_time_get_api_delegate>(Module, "efl_ui_animation_view_duration_time_get");

        private static double duration_time_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_duration_time_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetDurationTime();
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
                return efl_ui_animation_view_duration_time_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_duration_time_get_delegate efl_ui_animation_view_duration_time_get_static_delegate;

        
        private delegate double efl_ui_animation_view_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_animation_view_progress_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_progress_get_api_delegate> efl_ui_animation_view_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_progress_get_api_delegate>(Module, "efl_ui_animation_view_progress_get");

        private static double progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_progress_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetProgress();
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
                return efl_ui_animation_view_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_progress_get_delegate efl_ui_animation_view_progress_get_static_delegate;

        
        private delegate void efl_ui_animation_view_progress_set_delegate(System.IntPtr obj, System.IntPtr pd,  double progress);

        
        public delegate void efl_ui_animation_view_progress_set_api_delegate(System.IntPtr obj,  double progress);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_progress_set_api_delegate> efl_ui_animation_view_progress_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_progress_set_api_delegate>(Module, "efl_ui_animation_view_progress_set");

        private static void progress_set(System.IntPtr obj, System.IntPtr pd, double progress)
        {
            Eina.Log.Debug("function efl_ui_animation_view_progress_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetProgress(progress);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_progress_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), progress);
            }
        }

        private static efl_ui_animation_view_progress_set_delegate efl_ui_animation_view_progress_set_static_delegate;

        
        private delegate int efl_ui_animation_view_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_animation_view_frame_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_get_api_delegate> efl_ui_animation_view_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_get_api_delegate>(Module, "efl_ui_animation_view_frame_get");

        private static int frame_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_frame_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetFrame();
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
                return efl_ui_animation_view_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_frame_get_delegate efl_ui_animation_view_frame_get_static_delegate;

        
        private delegate void efl_ui_animation_view_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,  int frame_num);

        
        public delegate void efl_ui_animation_view_frame_set_api_delegate(System.IntPtr obj,  int frame_num);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_set_api_delegate> efl_ui_animation_view_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_set_api_delegate>(Module, "efl_ui_animation_view_frame_set");

        private static void frame_set(System.IntPtr obj, System.IntPtr pd, int frame_num)
        {
            Eina.Log.Debug("function efl_ui_animation_view_frame_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetFrame(frame_num);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), frame_num);
            }
        }

        private static efl_ui_animation_view_frame_set_delegate efl_ui_animation_view_frame_set_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_ui_animation_view_default_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_ui_animation_view_default_view_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_default_view_size_get_api_delegate> efl_ui_animation_view_default_view_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_default_view_size_get_api_delegate>(Module, "efl_ui_animation_view_default_view_size_get");

        private static Eina.Size2D.NativeStruct default_view_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_default_view_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetDefaultViewSize();
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
                return efl_ui_animation_view_default_view_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_default_view_size_get_delegate efl_ui_animation_view_default_view_size_get_static_delegate;

        
        private delegate Efl.Ui.AnimationViewState efl_ui_animation_view_state_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.AnimationViewState efl_ui_animation_view_state_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_state_get_api_delegate> efl_ui_animation_view_state_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_state_get_api_delegate>(Module, "efl_ui_animation_view_state_get");

        private static Efl.Ui.AnimationViewState state_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_state_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.AnimationViewState _ret_var = default(Efl.Ui.AnimationViewState);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetState();
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
                return efl_ui_animation_view_state_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_state_get_delegate efl_ui_animation_view_state_get_static_delegate;

        
        private delegate int efl_ui_animation_view_frame_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_animation_view_frame_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_count_get_api_delegate> efl_ui_animation_view_frame_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_frame_count_get_api_delegate>(Module, "efl_ui_animation_view_frame_count_get");

        private static int frame_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_frame_count_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetFrameCount();
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
                return efl_ui_animation_view_frame_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_frame_count_get_delegate efl_ui_animation_view_frame_count_get_static_delegate;

        
        private delegate double efl_ui_animation_view_min_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_animation_view_min_progress_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_progress_get_api_delegate> efl_ui_animation_view_min_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_progress_get_api_delegate>(Module, "efl_ui_animation_view_min_progress_get");

        private static double min_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_min_progress_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetMinProgress();
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
                return efl_ui_animation_view_min_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_min_progress_get_delegate efl_ui_animation_view_min_progress_get_static_delegate;

        
        private delegate void efl_ui_animation_view_min_progress_set_delegate(System.IntPtr obj, System.IntPtr pd,  double min_progress);

        
        public delegate void efl_ui_animation_view_min_progress_set_api_delegate(System.IntPtr obj,  double min_progress);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_progress_set_api_delegate> efl_ui_animation_view_min_progress_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_progress_set_api_delegate>(Module, "efl_ui_animation_view_min_progress_set");

        private static void min_progress_set(System.IntPtr obj, System.IntPtr pd, double min_progress)
        {
            Eina.Log.Debug("function efl_ui_animation_view_min_progress_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetMinProgress(min_progress);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_min_progress_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min_progress);
            }
        }

        private static efl_ui_animation_view_min_progress_set_delegate efl_ui_animation_view_min_progress_set_static_delegate;

        
        private delegate double efl_ui_animation_view_max_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_ui_animation_view_max_progress_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_progress_get_api_delegate> efl_ui_animation_view_max_progress_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_progress_get_api_delegate>(Module, "efl_ui_animation_view_max_progress_get");

        private static double max_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_max_progress_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetMaxProgress();
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
                return efl_ui_animation_view_max_progress_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_max_progress_get_delegate efl_ui_animation_view_max_progress_get_static_delegate;

        
        private delegate void efl_ui_animation_view_max_progress_set_delegate(System.IntPtr obj, System.IntPtr pd,  double max_progress);

        
        public delegate void efl_ui_animation_view_max_progress_set_api_delegate(System.IntPtr obj,  double max_progress);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_progress_set_api_delegate> efl_ui_animation_view_max_progress_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_progress_set_api_delegate>(Module, "efl_ui_animation_view_max_progress_set");

        private static void max_progress_set(System.IntPtr obj, System.IntPtr pd, double max_progress)
        {
            Eina.Log.Debug("function efl_ui_animation_view_max_progress_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetMaxProgress(max_progress);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_max_progress_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), max_progress);
            }
        }

        private static efl_ui_animation_view_max_progress_set_delegate efl_ui_animation_view_max_progress_set_static_delegate;

        
        private delegate int efl_ui_animation_view_min_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_animation_view_min_frame_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_frame_get_api_delegate> efl_ui_animation_view_min_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_frame_get_api_delegate>(Module, "efl_ui_animation_view_min_frame_get");

        private static int min_frame_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_min_frame_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetMinFrame();
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
                return efl_ui_animation_view_min_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_min_frame_get_delegate efl_ui_animation_view_min_frame_get_static_delegate;

        
        private delegate void efl_ui_animation_view_min_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,  int min_frame);

        
        public delegate void efl_ui_animation_view_min_frame_set_api_delegate(System.IntPtr obj,  int min_frame);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_frame_set_api_delegate> efl_ui_animation_view_min_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_min_frame_set_api_delegate>(Module, "efl_ui_animation_view_min_frame_set");

        private static void min_frame_set(System.IntPtr obj, System.IntPtr pd, int min_frame)
        {
            Eina.Log.Debug("function efl_ui_animation_view_min_frame_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetMinFrame(min_frame);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_min_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), min_frame);
            }
        }

        private static efl_ui_animation_view_min_frame_set_delegate efl_ui_animation_view_min_frame_set_static_delegate;

        
        private delegate int efl_ui_animation_view_max_frame_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_ui_animation_view_max_frame_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_frame_get_api_delegate> efl_ui_animation_view_max_frame_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_frame_get_api_delegate>(Module, "efl_ui_animation_view_max_frame_get");

        private static int max_frame_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_max_frame_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetMaxFrame();
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
                return efl_ui_animation_view_max_frame_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_max_frame_get_delegate efl_ui_animation_view_max_frame_get_static_delegate;

        
        private delegate void efl_ui_animation_view_max_frame_set_delegate(System.IntPtr obj, System.IntPtr pd,  int max_frame);

        
        public delegate void efl_ui_animation_view_max_frame_set_api_delegate(System.IntPtr obj,  int max_frame);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_frame_set_api_delegate> efl_ui_animation_view_max_frame_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_max_frame_set_api_delegate>(Module, "efl_ui_animation_view_max_frame_set");

        private static void max_frame_set(System.IntPtr obj, System.IntPtr pd, int max_frame)
        {
            Eina.Log.Debug("function efl_ui_animation_view_max_frame_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetMaxFrame(max_frame);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_animation_view_max_frame_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), max_frame);
            }
        }

        private static efl_ui_animation_view_max_frame_set_delegate efl_ui_animation_view_max_frame_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_play_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_play_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_play_api_delegate> efl_ui_animation_view_play_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_play_api_delegate>(Module, "efl_ui_animation_view_play");

        private static bool play(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_play was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).Play();
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
                return efl_ui_animation_view_play_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_play_delegate efl_ui_animation_view_play_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_play_back_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_play_back_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_play_back_api_delegate> efl_ui_animation_view_play_back_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_play_back_api_delegate>(Module, "efl_ui_animation_view_play_back");

        private static bool play_back(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_play_back was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).PlayBack();
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
                return efl_ui_animation_view_play_back_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_play_back_delegate efl_ui_animation_view_play_back_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_pause_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_pause_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_pause_api_delegate> efl_ui_animation_view_pause_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_pause_api_delegate>(Module, "efl_ui_animation_view_pause");

        private static bool pause(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_pause was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).Pause();
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
                return efl_ui_animation_view_pause_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_pause_delegate efl_ui_animation_view_pause_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_resume_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_resume_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_resume_api_delegate> efl_ui_animation_view_resume_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_resume_api_delegate>(Module, "efl_ui_animation_view_resume");

        private static bool resume(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_resume was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).Resume();
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
                return efl_ui_animation_view_resume_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_resume_delegate efl_ui_animation_view_resume_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_stop_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_stop_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_stop_api_delegate> efl_ui_animation_view_stop_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_stop_api_delegate>(Module, "efl_ui_animation_view_stop");

        private static bool stop(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_stop was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).Stop();
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
                return efl_ui_animation_view_stop_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_stop_delegate efl_ui_animation_view_stop_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_animation_view_is_playing_back_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_ui_animation_view_is_playing_back_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_animation_view_is_playing_back_api_delegate> efl_ui_animation_view_is_playing_back_ptr = new Efl.Eo.FunctionWrapper<efl_ui_animation_view_is_playing_back_api_delegate>(Module, "efl_ui_animation_view_is_playing_back");

        private static bool is_playing_back(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_animation_view_is_playing_back was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).IsPlayingBack();
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
                return efl_ui_animation_view_is_playing_back_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_animation_view_is_playing_back_delegate efl_ui_animation_view_is_playing_back_static_delegate;

        
        private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(Module, "efl_file_mmap_get");

        private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_mmap_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.File _ret_var = default(Eina.File);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetMmap();
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
                return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;

        
        private delegate Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.File f);

        
        public delegate Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,  Eina.File f);

        public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(Module, "efl_file_mmap_set");

        private static Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd, Eina.File f)
        {
            Eina.Log.Debug("function efl_file_mmap_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).SetMmap(f);
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
                return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), f);
            }
        }

        private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(Module, "efl_file_get");

        private static System.String file_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetFile();
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
                return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_get_delegate efl_file_get_static_delegate;

        
        private delegate Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        
        public delegate Eina.Error efl_file_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String file);

        public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(Module, "efl_file_set");

        private static Eina.Error file_set(System.IntPtr obj, System.IntPtr pd, System.String file)
        {
            Eina.Log.Debug("function efl_file_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).SetFile(file);
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
                return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), file);
            }
        }

        private static efl_file_set_delegate efl_file_set_static_delegate;

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        private delegate System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]
        public delegate System.String efl_file_key_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(Module, "efl_file_key_get");

        private static System.String key_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_key_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            System.String _ret_var = default(System.String);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetKey();
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
                return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_key_get_delegate efl_file_key_get_static_delegate;

        
        private delegate void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate void efl_file_key_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(Module, "efl_file_key_set");

        private static void key_set(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_file_key_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((AnimationView)ws.Target).SetKey(key);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_file_key_set_delegate efl_file_key_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(Module, "efl_file_loaded_get");

        private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_loaded_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetLoaded();
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
                return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;

        
        private delegate Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Error efl_file_load_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(Module, "efl_file_load");

        private static Eina.Error load(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_load was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Error _ret_var = default(Eina.Error);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).Load();
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
                return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_load_delegate efl_file_load_static_delegate;

        
        private delegate void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_file_unload_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(Module, "efl_file_unload");

        private static void unload(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_file_unload was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((AnimationView)ws.Target).Unload();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_file_unload_delegate efl_file_unload_static_delegate;

        
        private delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Eina.Size2D.NativeStruct efl_gfx_view_size_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate> efl_gfx_view_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_get_api_delegate>(Module, "efl_gfx_view_size_get");

        private static Eina.Size2D.NativeStruct view_size_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_gfx_view_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Size2D _ret_var = default(Eina.Size2D);
                try
                {
                    _ret_var = ((AnimationView)ws.Target).GetViewSize();
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
                return efl_gfx_view_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_gfx_view_size_get_delegate efl_gfx_view_size_get_static_delegate;

        
        private delegate void efl_gfx_view_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Size2D.NativeStruct size);

        
        public delegate void efl_gfx_view_size_set_api_delegate(System.IntPtr obj,  Eina.Size2D.NativeStruct size);

        public static Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate> efl_gfx_view_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_view_size_set_api_delegate>(Module, "efl_gfx_view_size_set");

        private static void view_size_set(System.IntPtr obj, System.IntPtr pd, Eina.Size2D.NativeStruct size)
        {
            Eina.Log.Debug("function efl_gfx_view_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Size2D _in_size = size;
                            
                try
                {
                    ((AnimationView)ws.Target).SetViewSize(_in_size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_gfx_view_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), size);
            }
        }

        private static efl_gfx_view_size_set_delegate efl_gfx_view_size_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiAnimationView_ExtensionMethods {
    public static Efl.BindableProperty<bool> AutoPlay<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<bool>("auto_play", fac);
    }

    public static Efl.BindableProperty<bool> AutoRepeat<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<bool>("auto_repeat", fac);
    }

    public static Efl.BindableProperty<double> Speed<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<double>("speed", fac);
    }

    
    public static Efl.BindableProperty<double> Progress<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<double>("progress", fac);
    }

    public static Efl.BindableProperty<int> Frame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<int>("frame", fac);
    }

    
    
    
    public static Efl.BindableProperty<double> MinProgress<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<double>("min_progress", fac);
    }

    public static Efl.BindableProperty<double> MaxProgress<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<double>("max_progress", fac);
    }

    public static Efl.BindableProperty<int> MinFrame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<int>("min_frame", fac);
    }

    public static Efl.BindableProperty<int> MaxFrame<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<int>("max_frame", fac);
    }

    public static Efl.BindableProperty<Eina.File> Mmap<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<Eina.File>("mmap", fac);
    }

    public static Efl.BindableProperty<System.String> File<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<System.String>("file", fac);
    }

    public static Efl.BindableProperty<System.String> Key<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<System.String>("key", fac);
    }

    
    public static Efl.BindableProperty<Eina.Size2D> ViewSize<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.AnimationView, T>magic = null) where T : Efl.Ui.AnimationView {
        return new Efl.BindableProperty<Eina.Size2D>("view_size", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

/// <summary>State of animation view</summary>
[Efl.Eo.BindingEntity]
public enum AnimationViewState
{
/// <summary>Animation is not ready to play. (Probably, it didn&apos;t file set yet or failed to read file.</summary>
NotReady = 0,
/// <summary>Animation is on playing. see <see cref="Efl.Ui.AnimationView.Play"/></summary>
Play = 1,
/// <summary>Animation is on playing back (rewinding). see <see cref="Efl.Ui.AnimationView.PlayBack"/></summary>
PlayBack = 2,
/// <summary>Animation has been paused. To continue animation, call <see cref="Efl.Ui.AnimationView.Resume"/>. see <see cref="Efl.Ui.AnimationView.Pause"/></summary>
Pause = 3,
/// <summary>Animation view successfully loaded a file then readied for playing. Otherwise after finished animation or stopped forcely by request. see <see cref="Efl.Ui.AnimationView.Stop"/></summary>
Stop = 4,
}

}

}

