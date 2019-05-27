#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Canvas {

/// <summary>Efl animation class</summary>
[Efl.Canvas.Animation.NativeMethods]
public class Animation : Efl.Object, Efl.Eo.IWrapper,Efl.IPlayable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Animation))
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
        efl_canvas_animation_class_get();
    /// <summary>Initializes a new instance of the <see cref="Animation"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Animation(Efl.Object parent= null
            ) : base(efl_canvas_animation_class_get(), typeof(Animation), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Animation"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Animation(System.IntPtr raw) : base(raw)
    {
            }

    /// <summary>Initializes a new instance of the <see cref="Animation"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Animation(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    /// <summary>Keep final state property</summary>
    /// <returns><c>true</c> to keep final state, <c>false</c> otherwise.</returns>
    virtual public bool GetFinalStateKeep() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_final_state_keep_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Keep final state property</summary>
    /// <param name="keep"><c>true</c> to keep final state, <c>false</c> otherwise.</param>
    virtual public void SetFinalStateKeep(bool keep) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_final_state_keep_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),keep);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Duration property</summary>
    /// <returns>Duration value.</returns>
    virtual public double GetDuration() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_duration_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Duration property</summary>
    /// <param name="sec">Duration value.</param>
    virtual public void SetDuration(double sec) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_duration_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Repeat mode property</summary>
    /// <returns>Repeat mode. EFL_ANIMATION_REPEAT_MODE_RESTART restarts animation when the animation ends and EFL_ANIMATION_REPEAT_MODE_REVERSE reverses animation when the animation ends.</returns>
    virtual public Efl.Canvas.AnimationRepeatMode GetRepeatMode() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_repeat_mode_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Repeat mode property</summary>
    /// <param name="mode">Repeat mode. EFL_ANIMATION_REPEAT_MODE_RESTART restarts animation when the animation ends and EFL_ANIMATION_REPEAT_MODE_REVERSE reverses animation when the animation ends.</param>
    virtual public void SetRepeatMode(Efl.Canvas.AnimationRepeatMode mode) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_repeat_mode_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),mode);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Repeat count property</summary>
    /// <returns>Repeat count. EFL_ANIMATION_REPEAT_INFINITE repeats animation infinitely.</returns>
    virtual public int GetRepeatCount() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_repeat_count_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Repeat count property</summary>
    /// <param name="count">Repeat count. EFL_ANIMATION_REPEAT_INFINITE repeats animation infinitely.</param>
    virtual public void SetRepeatCount(int count) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_repeat_count_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),count);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Start delay property</summary>
    /// <returns>Delay time, in seconds, from when the animation starts until the animation is animated</returns>
    virtual public double GetStartDelay() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_start_delay_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Start delay property</summary>
    /// <param name="sec">Delay time, in seconds, from when the animation starts until the animation is animated</param>
    virtual public void SetStartDelay(double sec) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_start_delay_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),sec);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Interpolator property</summary>
    /// <returns>Interpolator which indicates interpolation function. Efl_Interpolator is required.</returns>
    virtual public Efl.IInterpolator GetInterpolator() {
         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_interpolator_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Interpolator property</summary>
    /// <param name="interpolator">Interpolator which indicates interpolation function. Efl_Interpolator is required.</param>
    virtual public void SetInterpolator(Efl.IInterpolator interpolator) {
                                 Efl.Canvas.Animation.NativeMethods.efl_animation_interpolator_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),interpolator);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <returns>Final applied progress.</returns>
    virtual public double AnimationApply(double progress, Efl.Canvas.Object target) {
                                                         var _ret_var = Efl.Canvas.Animation.NativeMethods.efl_animation_apply_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),progress, target);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Get the length of play for the media file.</summary>
    /// <returns>The length of the stream in seconds.</returns>
    virtual public double GetLength() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_length_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    virtual public bool GetPlayable() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Get whether the media file is seekable.</summary>
    /// <returns><c>true</c> if seekable.</returns>
    virtual public bool GetSeekable() {
         var _ret_var = Efl.IPlayableConcrete.NativeMethods.efl_playable_seekable_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Keep final state property</summary>
/// <value><c>true</c> to keep final state, <c>false</c> otherwise.</value>
    public bool FinalStateKeep {
        get { return GetFinalStateKeep(); }
        set { SetFinalStateKeep(value); }
    }
    /// <summary>Duration property</summary>
/// <value>Duration value.</value>
    public double Duration {
        get { return GetDuration(); }
        set { SetDuration(value); }
    }
    /// <summary>Repeat mode property</summary>
/// <value>Repeat mode. EFL_ANIMATION_REPEAT_MODE_RESTART restarts animation when the animation ends and EFL_ANIMATION_REPEAT_MODE_REVERSE reverses animation when the animation ends.</value>
    public Efl.Canvas.AnimationRepeatMode RepeatMode {
        get { return GetRepeatMode(); }
        set { SetRepeatMode(value); }
    }
    /// <summary>Repeat count property</summary>
/// <value>Repeat count. EFL_ANIMATION_REPEAT_INFINITE repeats animation infinitely.</value>
    public int RepeatCount {
        get { return GetRepeatCount(); }
        set { SetRepeatCount(value); }
    }
    /// <summary>Start delay property</summary>
/// <value>Delay time, in seconds, from when the animation starts until the animation is animated</value>
    public double StartDelay {
        get { return GetStartDelay(); }
        set { SetStartDelay(value); }
    }
    /// <summary>Interpolator property</summary>
/// <value>Interpolator which indicates interpolation function. Efl_Interpolator is required.</value>
    public Efl.IInterpolator Interpolator {
        get { return GetInterpolator(); }
        set { SetInterpolator(value); }
    }
    /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
    public double Length {
        get { return GetLength(); }
    }
        public bool Playable {
        get { return GetPlayable(); }
    }
    /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
    public bool Seekable {
        get { return GetSeekable(); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Canvas.Animation.efl_canvas_animation_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Evas);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_animation_final_state_keep_get_static_delegate == null)
            {
                efl_animation_final_state_keep_get_static_delegate = new efl_animation_final_state_keep_get_delegate(final_state_keep_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetFinalStateKeep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_final_state_keep_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_get_static_delegate) });
            }

            if (efl_animation_final_state_keep_set_static_delegate == null)
            {
                efl_animation_final_state_keep_set_static_delegate = new efl_animation_final_state_keep_set_delegate(final_state_keep_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetFinalStateKeep") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_final_state_keep_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_set_static_delegate) });
            }

            if (efl_animation_duration_get_static_delegate == null)
            {
                efl_animation_duration_get_static_delegate = new efl_animation_duration_get_delegate(duration_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetDuration") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_get_static_delegate) });
            }

            if (efl_animation_duration_set_static_delegate == null)
            {
                efl_animation_duration_set_static_delegate = new efl_animation_duration_set_delegate(duration_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDuration") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_duration_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_set_static_delegate) });
            }

            if (efl_animation_repeat_mode_get_static_delegate == null)
            {
                efl_animation_repeat_mode_get_static_delegate = new efl_animation_repeat_mode_get_delegate(repeat_mode_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRepeatMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_get_static_delegate) });
            }

            if (efl_animation_repeat_mode_set_static_delegate == null)
            {
                efl_animation_repeat_mode_set_static_delegate = new efl_animation_repeat_mode_set_delegate(repeat_mode_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRepeatMode") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_set_static_delegate) });
            }

            if (efl_animation_repeat_count_get_static_delegate == null)
            {
                efl_animation_repeat_count_get_static_delegate = new efl_animation_repeat_count_get_delegate(repeat_count_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetRepeatCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_count_get_static_delegate) });
            }

            if (efl_animation_repeat_count_set_static_delegate == null)
            {
                efl_animation_repeat_count_set_static_delegate = new efl_animation_repeat_count_set_delegate(repeat_count_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetRepeatCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_count_set_static_delegate) });
            }

            if (efl_animation_start_delay_get_static_delegate == null)
            {
                efl_animation_start_delay_get_static_delegate = new efl_animation_start_delay_get_delegate(start_delay_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetStartDelay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_start_delay_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_get_static_delegate) });
            }

            if (efl_animation_start_delay_set_static_delegate == null)
            {
                efl_animation_start_delay_set_static_delegate = new efl_animation_start_delay_set_delegate(start_delay_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetStartDelay") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_start_delay_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_set_static_delegate) });
            }

            if (efl_animation_interpolator_get_static_delegate == null)
            {
                efl_animation_interpolator_get_static_delegate = new efl_animation_interpolator_get_delegate(interpolator_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetInterpolator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_interpolator_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_get_static_delegate) });
            }

            if (efl_animation_interpolator_set_static_delegate == null)
            {
                efl_animation_interpolator_set_static_delegate = new efl_animation_interpolator_set_delegate(interpolator_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetInterpolator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_interpolator_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_set_static_delegate) });
            }

            if (efl_animation_apply_static_delegate == null)
            {
                efl_animation_apply_static_delegate = new efl_animation_apply_delegate(animation_apply);
            }

            if (methods.FirstOrDefault(m => m.Name == "AnimationApply") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_apply_static_delegate) });
            }

            if (efl_playable_length_get_static_delegate == null)
            {
                efl_playable_length_get_static_delegate = new efl_playable_length_get_delegate(length_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetLength") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_length_get_static_delegate) });
            }

            if (efl_playable_get_static_delegate == null)
            {
                efl_playable_get_static_delegate = new efl_playable_get_delegate(playable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetPlayable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_get_static_delegate) });
            }

            if (efl_playable_seekable_get_static_delegate == null)
            {
                efl_playable_seekable_get_static_delegate = new efl_playable_seekable_get_delegate(seekable_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetSeekable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_playable_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_seekable_get_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Canvas.Animation.efl_canvas_animation_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_animation_final_state_keep_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_animation_final_state_keep_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_final_state_keep_get_api_delegate> efl_animation_final_state_keep_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_final_state_keep_get_api_delegate>(Module, "efl_animation_final_state_keep_get");

        private static bool final_state_keep_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_final_state_keep_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Animation)wrapper).GetFinalStateKeep();
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
                return efl_animation_final_state_keep_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_final_state_keep_get_delegate efl_animation_final_state_keep_get_static_delegate;

        
        private delegate void efl_animation_final_state_keep_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool keep);

        
        public delegate void efl_animation_final_state_keep_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool keep);

        public static Efl.Eo.FunctionWrapper<efl_animation_final_state_keep_set_api_delegate> efl_animation_final_state_keep_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_final_state_keep_set_api_delegate>(Module, "efl_animation_final_state_keep_set");

        private static void final_state_keep_set(System.IntPtr obj, System.IntPtr pd, bool keep)
        {
            Eina.Log.Debug("function efl_animation_final_state_keep_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetFinalStateKeep(keep);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_final_state_keep_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), keep);
            }
        }

        private static efl_animation_final_state_keep_set_delegate efl_animation_final_state_keep_set_static_delegate;

        
        private delegate double efl_animation_duration_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_animation_duration_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_duration_get_api_delegate> efl_animation_duration_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_duration_get_api_delegate>(Module, "efl_animation_duration_get");

        private static double duration_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_duration_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Animation)wrapper).GetDuration();
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
                return efl_animation_duration_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_duration_get_delegate efl_animation_duration_get_static_delegate;

        
        private delegate void efl_animation_duration_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        public delegate void efl_animation_duration_set_api_delegate(System.IntPtr obj,  double sec);

        public static Efl.Eo.FunctionWrapper<efl_animation_duration_set_api_delegate> efl_animation_duration_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_duration_set_api_delegate>(Module, "efl_animation_duration_set");

        private static void duration_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            Eina.Log.Debug("function efl_animation_duration_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetDuration(sec);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_duration_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sec);
            }
        }

        private static efl_animation_duration_set_delegate efl_animation_duration_set_static_delegate;

        
        private delegate Efl.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_repeat_mode_get_api_delegate> efl_animation_repeat_mode_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_repeat_mode_get_api_delegate>(Module, "efl_animation_repeat_mode_get");

        private static Efl.Canvas.AnimationRepeatMode repeat_mode_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_repeat_mode_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.Canvas.AnimationRepeatMode _ret_var = default(Efl.Canvas.AnimationRepeatMode);
                try
                {
                    _ret_var = ((Animation)wrapper).GetRepeatMode();
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
                return efl_animation_repeat_mode_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_repeat_mode_get_delegate efl_animation_repeat_mode_get_static_delegate;

        
        private delegate void efl_animation_repeat_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.AnimationRepeatMode mode);

        
        public delegate void efl_animation_repeat_mode_set_api_delegate(System.IntPtr obj,  Efl.Canvas.AnimationRepeatMode mode);

        public static Efl.Eo.FunctionWrapper<efl_animation_repeat_mode_set_api_delegate> efl_animation_repeat_mode_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_repeat_mode_set_api_delegate>(Module, "efl_animation_repeat_mode_set");

        private static void repeat_mode_set(System.IntPtr obj, System.IntPtr pd, Efl.Canvas.AnimationRepeatMode mode)
        {
            Eina.Log.Debug("function efl_animation_repeat_mode_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetRepeatMode(mode);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_repeat_mode_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), mode);
            }
        }

        private static efl_animation_repeat_mode_set_delegate efl_animation_repeat_mode_set_static_delegate;

        
        private delegate int efl_animation_repeat_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_animation_repeat_count_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_repeat_count_get_api_delegate> efl_animation_repeat_count_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_repeat_count_get_api_delegate>(Module, "efl_animation_repeat_count_get");

        private static int repeat_count_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_repeat_count_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Animation)wrapper).GetRepeatCount();
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
                return efl_animation_repeat_count_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_repeat_count_get_delegate efl_animation_repeat_count_get_static_delegate;

        
        private delegate void efl_animation_repeat_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int count);

        
        public delegate void efl_animation_repeat_count_set_api_delegate(System.IntPtr obj,  int count);

        public static Efl.Eo.FunctionWrapper<efl_animation_repeat_count_set_api_delegate> efl_animation_repeat_count_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_repeat_count_set_api_delegate>(Module, "efl_animation_repeat_count_set");

        private static void repeat_count_set(System.IntPtr obj, System.IntPtr pd, int count)
        {
            Eina.Log.Debug("function efl_animation_repeat_count_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetRepeatCount(count);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_repeat_count_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), count);
            }
        }

        private static efl_animation_repeat_count_set_delegate efl_animation_repeat_count_set_static_delegate;

        
        private delegate double efl_animation_start_delay_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_animation_start_delay_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_start_delay_get_api_delegate> efl_animation_start_delay_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_start_delay_get_api_delegate>(Module, "efl_animation_start_delay_get");

        private static double start_delay_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_start_delay_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Animation)wrapper).GetStartDelay();
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
                return efl_animation_start_delay_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_start_delay_get_delegate efl_animation_start_delay_get_static_delegate;

        
        private delegate void efl_animation_start_delay_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        public delegate void efl_animation_start_delay_set_api_delegate(System.IntPtr obj,  double sec);

        public static Efl.Eo.FunctionWrapper<efl_animation_start_delay_set_api_delegate> efl_animation_start_delay_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_start_delay_set_api_delegate>(Module, "efl_animation_start_delay_set");

        private static void start_delay_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            Eina.Log.Debug("function efl_animation_start_delay_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetStartDelay(sec);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_start_delay_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), sec);
            }
        }

        private static efl_animation_start_delay_set_delegate efl_animation_start_delay_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.IInterpolator efl_animation_interpolator_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.IInterpolator efl_animation_interpolator_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_animation_interpolator_get_api_delegate> efl_animation_interpolator_get_ptr = new Efl.Eo.FunctionWrapper<efl_animation_interpolator_get_api_delegate>(Module, "efl_animation_interpolator_get");

        private static Efl.IInterpolator interpolator_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_animation_interpolator_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            Efl.IInterpolator _ret_var = default(Efl.IInterpolator);
                try
                {
                    _ret_var = ((Animation)wrapper).GetInterpolator();
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
                return efl_animation_interpolator_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_animation_interpolator_get_delegate efl_animation_interpolator_get_static_delegate;

        
        private delegate void efl_animation_interpolator_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IInterpolator interpolator);

        
        public delegate void efl_animation_interpolator_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IInterpolator interpolator);

        public static Efl.Eo.FunctionWrapper<efl_animation_interpolator_set_api_delegate> efl_animation_interpolator_set_ptr = new Efl.Eo.FunctionWrapper<efl_animation_interpolator_set_api_delegate>(Module, "efl_animation_interpolator_set");

        private static void interpolator_set(System.IntPtr obj, System.IntPtr pd, Efl.IInterpolator interpolator)
        {
            Eina.Log.Debug("function efl_animation_interpolator_set was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                    
                try
                {
                    ((Animation)wrapper).SetInterpolator(interpolator);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_animation_interpolator_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), interpolator);
            }
        }

        private static efl_animation_interpolator_set_delegate efl_animation_interpolator_set_static_delegate;

        
        private delegate double efl_animation_apply_delegate(System.IntPtr obj, System.IntPtr pd,  double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object target);

        
        public delegate double efl_animation_apply_api_delegate(System.IntPtr obj,  double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Canvas.Object target);

        public static Efl.Eo.FunctionWrapper<efl_animation_apply_api_delegate> efl_animation_apply_ptr = new Efl.Eo.FunctionWrapper<efl_animation_apply_api_delegate>(Module, "efl_animation_apply");

        private static double animation_apply(System.IntPtr obj, System.IntPtr pd, double progress, Efl.Canvas.Object target)
        {
            Eina.Log.Debug("function efl_animation_apply was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
                                                            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Animation)wrapper).AnimationApply(progress, target);
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
                return efl_animation_apply_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), progress, target);
            }
        }

        private static efl_animation_apply_delegate efl_animation_apply_static_delegate;

        
        private delegate double efl_playable_length_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate double efl_playable_length_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate> efl_playable_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate>(Module, "efl_playable_length_get");

        private static double length_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_length_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            double _ret_var = default(double);
                try
                {
                    _ret_var = ((Animation)wrapper).GetLength();
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
                return efl_playable_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_length_get_delegate efl_playable_length_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_playable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate> efl_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate>(Module, "efl_playable_get");

        private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Animation)wrapper).GetPlayable();
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
                return efl_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_get_delegate efl_playable_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_playable_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_playable_seekable_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate> efl_playable_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate>(Module, "efl_playable_seekable_get");

        private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_playable_seekable_get was called");
            Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
            if (wrapper != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((Animation)wrapper).GetSeekable();
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
                return efl_playable_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_playable_seekable_get_delegate efl_playable_seekable_get_static_delegate;

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

}

