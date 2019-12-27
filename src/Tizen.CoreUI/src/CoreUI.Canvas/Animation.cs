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
namespace CoreUI.Canvas {
    /// <summary>Base class to be used by classes implementing specific canvas animations.
    /// 
    /// A canvas animation modifies the properties of a <see cref="CoreUI.Canvas.Object"/> like <see cref="CoreUI.Gfx.IEntity.Position"/>, <see cref="CoreUI.Gfx.IEntity.Scale"/> or <see cref="CoreUI.Gfx.IMapping.Rotate"/>, for example. The value of the changed properties moves smoothly as the provided progress value evolves from <c>0</c> to <c>1</c>.
    /// 
    /// For example implementations see <see cref="CoreUI.Canvas.TranslateAnimation"/> or <see cref="CoreUI.Canvas.ScaleAnimation"/>.
    /// 
    /// <b>NOTE: </b>Unless <see cref="CoreUI.Canvas.Animation.FinalStateKeep"/> is used, when an animation finishes any effect it introduced on the object is removed. This means that if the animation does not end in the object&apos;s initial state there will be a noticeable sudden jump. To avoid this, animations must finish in the same state as they begin, or the object&apos;s state must be matched to the animation&apos;s ending state once the animation finishes (using the <see cref="CoreUI.Canvas.IObjectAnimation.AnimationChanged"/> event).</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.Animation.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Animation : CoreUI.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Animation))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_animation_class_get();

        /// <summary>Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Animation(CoreUI.Object parent= null) : base(efl_canvas_animation_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Animation(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Animation"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Animation(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Animation"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Animation(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>If <c>true</c> the last mapping state the animation applies will be kept. Otherwise all the <see cref="CoreUI.Gfx.IMapping"/> properties will be reset when the animation ends.
        /// 
        /// Be careful, though. Object properties like <see cref="CoreUI.Gfx.IEntity.Position"/> do not take animations into account so they might not match the actual rendered values. It is usually better to remove the effects of the animation as soon as it finishes and set the final values on the object&apos;s properties.</summary>
        /// <returns><c>true</c> to keep the final state.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetFinalStateKeep() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_final_state_keep_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c> the last mapping state the animation applies will be kept. Otherwise all the <see cref="CoreUI.Gfx.IMapping"/> properties will be reset when the animation ends.
        /// 
        /// Be careful, though. Object properties like <see cref="CoreUI.Gfx.IEntity.Position"/> do not take animations into account so they might not match the actual rendered values. It is usually better to remove the effects of the animation as soon as it finishes and set the final values on the object&apos;s properties.</summary>
        /// <param name="keep"><c>true</c> to keep the final state.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFinalStateKeep(bool keep) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_final_state_keep_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), keep);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The duration of a single animation &quot;run&quot;. The <span class="text-muted">CoreUI.IPlayable.GetLength (object still in beta stage)</span> implementation will return this duration adjusted by <see cref="CoreUI.Canvas.Animation.RepeatMode"/> and <see cref="CoreUI.Canvas.Animation.PlayCount"/>.</summary>
        /// <returns>Duration in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetDuration() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_duration_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The duration of a single animation &quot;run&quot;. The <span class="text-muted">CoreUI.IPlayable.GetLength (object still in beta stage)</span> implementation will return this duration adjusted by <see cref="CoreUI.Canvas.Animation.RepeatMode"/> and <see cref="CoreUI.Canvas.Animation.PlayCount"/>.</summary>
        /// <param name="sec">Duration in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDuration(double sec) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_duration_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sec);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>What to do when the animation finishes.</summary>
        /// <returns>Repeat mode.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.AnimationRepeatMode GetRepeatMode() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_repeat_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>What to do when the animation finishes.</summary>
        /// <param name="mode">Repeat mode.<br/>The default value is <see cref="CoreUI.Canvas.AnimationRepeatMode.Restart"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRepeatMode(CoreUI.Canvas.AnimationRepeatMode mode) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_repeat_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), mode);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>How many times to play an animation. <c>1</c> means that the animation only plays once (it is not repeated), whereas <c>2</c> will play it again once it finishes the first time and then stop. <c>0</c> means that the animation is repeated forever. <see cref="CoreUI.Canvas.Animation.RepeatMode"/> controls the direction in which subsequent playbacks will run.</summary>
        /// <returns>Play count.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetPlayCount() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_play_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>How many times to play an animation. <c>1</c> means that the animation only plays once (it is not repeated), whereas <c>2</c> will play it again once it finishes the first time and then stop. <c>0</c> means that the animation is repeated forever. <see cref="CoreUI.Canvas.Animation.RepeatMode"/> controls the direction in which subsequent playbacks will run.</summary>
        /// <param name="count">Play count.<br/>The default value is <c>1</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPlayCount(int count) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_play_count_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), count);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The time that passes since the animation is started and the first real change to the object is applied.</summary>
        /// <returns>Delay time in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetStartDelay() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_start_delay_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The time that passes since the animation is started and the first real change to the object is applied.</summary>
        /// <param name="sec">Delay time in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetStartDelay(double sec) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_start_delay_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sec);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Optional mapping function.
        /// 
        /// Animations are based on a timer that moves linearly from 0 to 1. This <c>interpolator</c> method is applied before the timer is passed to the animation, to achieve effects like acceleration or deceleration, for example.</summary>
        /// <returns>Mapping function. By default it is <c>NULL</c> (linear mapping).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.IInterpolator GetInterpolator() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_interpolator_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Optional mapping function.
        /// 
        /// Animations are based on a timer that moves linearly from 0 to 1. This <c>interpolator</c> method is applied before the timer is passed to the animation, to achieve effects like acceleration or deceleration, for example.</summary>
        /// <param name="interpolator">Mapping function. By default it is <c>NULL</c> (linear mapping).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetInterpolator(CoreUI.IInterpolator interpolator) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_interpolator_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), interpolator);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Duration that will be used by default on all animations unless another value is set per object using <see cref="CoreUI.Canvas.Animation.Duration"/>.</summary>
        /// <returns>Default animation duration, in seconds.</returns>
        /// <since_tizen> 6 </since_tizen>
        public static double GetDefaultDuration() {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_default_duration_get_ptr.Value.Delegate();
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Duration that will be used by default on all animations unless another value is set per object using <see cref="CoreUI.Canvas.Animation.Duration"/>.</summary>
        /// <param name="animation_time">Default animation duration, in seconds.</param>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDefaultDuration(double animation_time) {
            CoreUI.Canvas.Animation.NativeMethods.efl_animation_default_duration_set_ptr.Value.Delegate(animation_time);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Overwrite this method to implement your own animation subclasses.
        /// 
        /// This is used for example by <see cref="CoreUI.Canvas.TranslateAnimation"/> or <see cref="CoreUI.Canvas.ScaleAnimation"/>.
        /// 
        /// Subclasses should call their parent&apos;s <see cref="CoreUI.Canvas.Animation.ApplyAnimation"/> to get the adjusted <c>progress</c> value and then perform the animation by modifying the <c>target</c>&apos;s properties.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="progress">Animation progress from <c>0</c> to <c>1</c>.</param>
        /// <param name="target">Object to animate.</param>
        /// <returns>Final applied progress, after possible adjustments. See <see cref="CoreUI.Canvas.Animation.Interpolator"/>.</returns>
        public virtual double ApplyAnimation(double progress, CoreUI.Canvas.Object target) {
            var _ret_var = CoreUI.Canvas.Animation.NativeMethods.efl_animation_apply_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), progress, target);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c> the last mapping state the animation applies will be kept. Otherwise all the <see cref="CoreUI.Gfx.IMapping"/> properties will be reset when the animation ends.
        /// 
        /// Be careful, though. Object properties like <see cref="CoreUI.Gfx.IEntity.Position"/> do not take animations into account so they might not match the actual rendered values. It is usually better to remove the effects of the animation as soon as it finishes and set the final values on the object&apos;s properties.</summary>
        /// <value><c>true</c> to keep the final state.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool FinalStateKeep {
            get { return GetFinalStateKeep(); }
            set { SetFinalStateKeep(value); }
        }

        /// <summary>The duration of a single animation &quot;run&quot;. The <span class="text-muted">CoreUI.IPlayable.GetLength (object still in beta stage)</span> implementation will return this duration adjusted by <see cref="CoreUI.Canvas.Animation.RepeatMode"/> and <see cref="CoreUI.Canvas.Animation.PlayCount"/>.</summary>
        /// <value>Duration in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Duration {
            get { return GetDuration(); }
            set { SetDuration(value); }
        }

        /// <summary>What to do when the animation finishes.</summary>
        /// <value>Repeat mode.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.AnimationRepeatMode RepeatMode {
            get { return GetRepeatMode(); }
            set { SetRepeatMode(value); }
        }

        /// <summary>How many times to play an animation. <c>1</c> means that the animation only plays once (it is not repeated), whereas <c>2</c> will play it again once it finishes the first time and then stop. <c>0</c> means that the animation is repeated forever. <see cref="CoreUI.Canvas.Animation.RepeatMode"/> controls the direction in which subsequent playbacks will run.</summary>
        /// <value>Play count.</value>
        /// <since_tizen> 6 </since_tizen>
        public int PlayCount {
            get { return GetPlayCount(); }
            set { SetPlayCount(value); }
        }

        /// <summary>The time that passes since the animation is started and the first real change to the object is applied.</summary>
        /// <value>Delay time in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        public double StartDelay {
            get { return GetStartDelay(); }
            set { SetStartDelay(value); }
        }

        /// <summary>Optional mapping function.
        /// 
        /// Animations are based on a timer that moves linearly from 0 to 1. This <c>interpolator</c> method is applied before the timer is passed to the animation, to achieve effects like acceleration or deceleration, for example.</summary>
        /// <value>Mapping function. By default it is <c>NULL</c> (linear mapping).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IInterpolator Interpolator {
            get { return GetInterpolator(); }
            set { SetInterpolator(value); }
        }

        /// <summary>Duration that will be used by default on all animations unless another value is set per object using <see cref="CoreUI.Canvas.Animation.Duration"/>.</summary>
        /// <value>Default animation duration, in seconds.</value>
        /// <since_tizen> 6 </since_tizen>
        public static double DefaultDuration {
            get { return GetDefaultDuration(); }
            set { SetDefaultDuration(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.Animation.efl_canvas_animation_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_animation_final_state_keep_get_static_delegate == null)
                {
                    efl_animation_final_state_keep_get_static_delegate = new efl_animation_final_state_keep_get_delegate(final_state_keep_get);
                }

                if (methods.Contains("GetFinalStateKeep"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_final_state_keep_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_get_static_delegate) });
                }

                if (efl_animation_final_state_keep_set_static_delegate == null)
                {
                    efl_animation_final_state_keep_set_static_delegate = new efl_animation_final_state_keep_set_delegate(final_state_keep_set);
                }

                if (methods.Contains("SetFinalStateKeep"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_final_state_keep_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_final_state_keep_set_static_delegate) });
                }

                if (efl_animation_duration_get_static_delegate == null)
                {
                    efl_animation_duration_get_static_delegate = new efl_animation_duration_get_delegate(duration_get);
                }

                if (methods.Contains("GetDuration"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_duration_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_get_static_delegate) });
                }

                if (efl_animation_duration_set_static_delegate == null)
                {
                    efl_animation_duration_set_static_delegate = new efl_animation_duration_set_delegate(duration_set);
                }

                if (methods.Contains("SetDuration"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_duration_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_duration_set_static_delegate) });
                }

                if (efl_animation_repeat_mode_get_static_delegate == null)
                {
                    efl_animation_repeat_mode_get_static_delegate = new efl_animation_repeat_mode_get_delegate(repeat_mode_get);
                }

                if (methods.Contains("GetRepeatMode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_get_static_delegate) });
                }

                if (efl_animation_repeat_mode_set_static_delegate == null)
                {
                    efl_animation_repeat_mode_set_static_delegate = new efl_animation_repeat_mode_set_delegate(repeat_mode_set);
                }

                if (methods.Contains("SetRepeatMode"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_repeat_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_repeat_mode_set_static_delegate) });
                }

                if (efl_animation_play_count_get_static_delegate == null)
                {
                    efl_animation_play_count_get_static_delegate = new efl_animation_play_count_get_delegate(play_count_get);
                }

                if (methods.Contains("GetPlayCount"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_play_count_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_play_count_get_static_delegate) });
                }

                if (efl_animation_play_count_set_static_delegate == null)
                {
                    efl_animation_play_count_set_static_delegate = new efl_animation_play_count_set_delegate(play_count_set);
                }

                if (methods.Contains("SetPlayCount"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_play_count_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_play_count_set_static_delegate) });
                }

                if (efl_animation_start_delay_get_static_delegate == null)
                {
                    efl_animation_start_delay_get_static_delegate = new efl_animation_start_delay_get_delegate(start_delay_get);
                }

                if (methods.Contains("GetStartDelay"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_start_delay_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_get_static_delegate) });
                }

                if (efl_animation_start_delay_set_static_delegate == null)
                {
                    efl_animation_start_delay_set_static_delegate = new efl_animation_start_delay_set_delegate(start_delay_set);
                }

                if (methods.Contains("SetStartDelay"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_start_delay_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_start_delay_set_static_delegate) });
                }

                if (efl_animation_interpolator_get_static_delegate == null)
                {
                    efl_animation_interpolator_get_static_delegate = new efl_animation_interpolator_get_delegate(interpolator_get);
                }

                if (methods.Contains("GetInterpolator"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_interpolator_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_get_static_delegate) });
                }

                if (efl_animation_interpolator_set_static_delegate == null)
                {
                    efl_animation_interpolator_set_static_delegate = new efl_animation_interpolator_set_delegate(interpolator_set);
                }

                if (methods.Contains("SetInterpolator"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_interpolator_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_interpolator_set_static_delegate) });
                }

                if (efl_animation_apply_static_delegate == null)
                {
                    efl_animation_apply_static_delegate = new efl_animation_apply_delegate(animation_apply);
                }

                if (methods.Contains("ApplyAnimation"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_apply"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_apply_static_delegate) });
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
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.Canvas.Animation.efl_canvas_animation_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_animation_final_state_keep_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_animation_final_state_keep_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_final_state_keep_get_api_delegate> efl_animation_final_state_keep_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_final_state_keep_get_api_delegate>(Module, "efl_animation_final_state_keep_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool final_state_keep_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_final_state_keep_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetFinalStateKeep();
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
                    return efl_animation_final_state_keep_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_final_state_keep_get_delegate efl_animation_final_state_keep_get_static_delegate;

            
            private delegate void efl_animation_final_state_keep_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool keep);

            
            internal delegate void efl_animation_final_state_keep_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool keep);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_final_state_keep_set_api_delegate> efl_animation_final_state_keep_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_final_state_keep_set_api_delegate>(Module, "efl_animation_final_state_keep_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void final_state_keep_set(System.IntPtr obj, System.IntPtr pd, bool keep)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_final_state_keep_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetFinalStateKeep(keep);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_final_state_keep_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), keep);
                }
            }

            private static efl_animation_final_state_keep_set_delegate efl_animation_final_state_keep_set_static_delegate;

            
            private delegate double efl_animation_duration_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_animation_duration_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_duration_get_api_delegate> efl_animation_duration_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_duration_get_api_delegate>(Module, "efl_animation_duration_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double duration_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_duration_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetDuration();
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
                    return efl_animation_duration_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_duration_get_delegate efl_animation_duration_get_static_delegate;

            
            private delegate void efl_animation_duration_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

            
            internal delegate void efl_animation_duration_set_api_delegate(System.IntPtr obj,  double sec);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_duration_set_api_delegate> efl_animation_duration_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_duration_set_api_delegate>(Module, "efl_animation_duration_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void duration_set(System.IntPtr obj, System.IntPtr pd, double sec)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_duration_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetDuration(sec);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_duration_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sec);
                }
            }

            private static efl_animation_duration_set_delegate efl_animation_duration_set_static_delegate;

            
            private delegate CoreUI.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.Canvas.AnimationRepeatMode efl_animation_repeat_mode_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_repeat_mode_get_api_delegate> efl_animation_repeat_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_repeat_mode_get_api_delegate>(Module, "efl_animation_repeat_mode_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.AnimationRepeatMode repeat_mode_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_repeat_mode_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.AnimationRepeatMode _ret_var = default(CoreUI.Canvas.AnimationRepeatMode);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetRepeatMode();
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
                    return efl_animation_repeat_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_repeat_mode_get_delegate efl_animation_repeat_mode_get_static_delegate;

            
            private delegate void efl_animation_repeat_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Canvas.AnimationRepeatMode mode);

            
            internal delegate void efl_animation_repeat_mode_set_api_delegate(System.IntPtr obj,  CoreUI.Canvas.AnimationRepeatMode mode);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_repeat_mode_set_api_delegate> efl_animation_repeat_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_repeat_mode_set_api_delegate>(Module, "efl_animation_repeat_mode_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void repeat_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.AnimationRepeatMode mode)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_repeat_mode_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetRepeatMode(mode);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_repeat_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), mode);
                }
            }

            private static efl_animation_repeat_mode_set_delegate efl_animation_repeat_mode_set_static_delegate;

            
            private delegate int efl_animation_play_count_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate int efl_animation_play_count_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_play_count_get_api_delegate> efl_animation_play_count_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_play_count_get_api_delegate>(Module, "efl_animation_play_count_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int play_count_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_play_count_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetPlayCount();
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
                    return efl_animation_play_count_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_play_count_get_delegate efl_animation_play_count_get_static_delegate;

            
            private delegate void efl_animation_play_count_set_delegate(System.IntPtr obj, System.IntPtr pd,  int count);

            
            internal delegate void efl_animation_play_count_set_api_delegate(System.IntPtr obj,  int count);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_play_count_set_api_delegate> efl_animation_play_count_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_play_count_set_api_delegate>(Module, "efl_animation_play_count_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void play_count_set(System.IntPtr obj, System.IntPtr pd, int count)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_play_count_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetPlayCount(count);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_play_count_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), count);
                }
            }

            private static efl_animation_play_count_set_delegate efl_animation_play_count_set_static_delegate;

            
            private delegate double efl_animation_start_delay_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate double efl_animation_start_delay_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_start_delay_get_api_delegate> efl_animation_start_delay_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_start_delay_get_api_delegate>(Module, "efl_animation_start_delay_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double start_delay_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_start_delay_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetStartDelay();
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
                    return efl_animation_start_delay_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_start_delay_get_delegate efl_animation_start_delay_get_static_delegate;

            
            private delegate void efl_animation_start_delay_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

            
            internal delegate void efl_animation_start_delay_set_api_delegate(System.IntPtr obj,  double sec);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_start_delay_set_api_delegate> efl_animation_start_delay_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_start_delay_set_api_delegate>(Module, "efl_animation_start_delay_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void start_delay_set(System.IntPtr obj, System.IntPtr pd, double sec)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_start_delay_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetStartDelay(sec);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_start_delay_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sec);
                }
            }

            private static efl_animation_start_delay_set_delegate efl_animation_start_delay_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.IInterpolator efl_animation_interpolator_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.IInterpolator efl_animation_interpolator_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_interpolator_get_api_delegate> efl_animation_interpolator_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_interpolator_get_api_delegate>(Module, "efl_animation_interpolator_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.IInterpolator interpolator_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_interpolator_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.IInterpolator _ret_var = default(CoreUI.IInterpolator);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).GetInterpolator();
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
                    return efl_animation_interpolator_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_animation_interpolator_get_delegate efl_animation_interpolator_get_static_delegate;

            
            private delegate void efl_animation_interpolator_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.IInterpolator interpolator);

            
            internal delegate void efl_animation_interpolator_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.IInterpolator interpolator);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_interpolator_set_api_delegate> efl_animation_interpolator_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_interpolator_set_api_delegate>(Module, "efl_animation_interpolator_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void interpolator_set(System.IntPtr obj, System.IntPtr pd, CoreUI.IInterpolator interpolator)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_interpolator_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Animation)ws.Target).SetInterpolator(interpolator);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_interpolator_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), interpolator);
                }
            }

            private static efl_animation_interpolator_set_delegate efl_animation_interpolator_set_static_delegate;

            
            private delegate double efl_animation_default_duration_get_delegate();

            
            internal delegate double efl_animation_default_duration_get_api_delegate();

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_default_duration_get_api_delegate> efl_animation_default_duration_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_default_duration_get_api_delegate>(Module, "efl_animation_default_duration_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double default_duration_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_default_duration_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = Animation.GetDefaultDuration();
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
                    return efl_animation_default_duration_get_ptr.Value.Delegate();
                }
            }

            
            private delegate void efl_animation_default_duration_set_delegate( double animation_time);

            
            internal delegate void efl_animation_default_duration_set_api_delegate( double animation_time);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_default_duration_set_api_delegate> efl_animation_default_duration_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_default_duration_set_api_delegate>(Module, "efl_animation_default_duration_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void default_duration_set(System.IntPtr obj, System.IntPtr pd, double animation_time)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_default_duration_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        Animation.SetDefaultDuration(animation_time);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_default_duration_set_ptr.Value.Delegate(animation_time);
                }
            }

            
            private delegate double efl_animation_apply_delegate(System.IntPtr obj, System.IntPtr pd,  double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object target);

            
            internal delegate double efl_animation_apply_api_delegate(System.IntPtr obj,  double progress, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object target);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_apply_api_delegate> efl_animation_apply_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_apply_api_delegate>(Module, "efl_animation_apply");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static double animation_apply(System.IntPtr obj, System.IntPtr pd, double progress, CoreUI.Canvas.Object target)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_apply was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    double _ret_var = default(double);
                    try
                    {
                        _ret_var = ((Animation)ws.Target).ApplyAnimation(progress, target);
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
                    return efl_animation_apply_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), progress, target);
                }
            }

            private static efl_animation_apply_delegate efl_animation_apply_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Canvas {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class AnimationExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> FinalStateKeep<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<bool>("final_state_keep", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Duration<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<double>("duration", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.AnimationRepeatMode> RepeatMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<CoreUI.Canvas.AnimationRepeatMode>("repeat_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> PlayCount<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<int>("play_count", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> StartDelay<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<double>("start_delay", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.IInterpolator> Interpolator<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<CoreUI.IInterpolator>("interpolator", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> DefaultDuration<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Animation, T>magic = null) where T : CoreUI.Canvas.Animation {
            return new CoreUI.BindableProperty<double>("default_duration", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

