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
    /// <summary>A mixin that provides animation capabilities to <see cref="CoreUI.Canvas.Object"/>.
    /// 
    /// By including this mixin canvas objects can be animated just by calling <see cref="CoreUI.Canvas.IObjectAnimation.AnimationStart"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.IObjectAnimationNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IObjectAnimation : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The animation that is currently played on the canvas object.
        /// 
        /// <c>null</c> in case that there is no animation running.</summary>
        /// <returns>The animation which is currently applied on this object.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Canvas.Animation GetAnimation();

        /// <summary>The current progress of the animation, between <c>0.0</c> and <c>1.0</c>.
        /// 
        /// Even if the animation is going backwards (speed &lt; 0.0) the progress will still go from <c>0.0</c> to <c>1.0</c>.
        /// 
        /// If there is no animation going on, this will return <c>-1.0</c>.</summary>
        /// <returns>Current progress of the animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetAnimationProgress();

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <returns>Paused state.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetAnimationPause();

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <param name="pause">Paused state.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetAnimationPause(bool pause);

        /// <summary>Start a new animation.
        /// 
        /// If there is an animation going on, it is stopped and the previous <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> object is replaced. Its lifetime is adjusted accordingly.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="animation">The animation to start. When not needed anymore, the reference that was passed is given up.</param>
        /// <param name="speed">The speed of the playback. <c>1.0</c> is normal playback. Negative values mean reverse playback.</param>
        /// <param name="starting_progress">The progress point where to start. Must be between <c>0.0</c> and <c>1.0</c>. Useful to revert an animation which has already started.</param>
        void AnimationStart(CoreUI.Canvas.Animation animation, double speed, double starting_progress);

        /// <summary>Stop the animation.
        /// 
        /// After this call, <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will return <c>null</c>. The reference that was taken during <see cref="CoreUI.Canvas.IObjectAnimation.AnimationStart"/> will be given up.</summary>
        /// <since_tizen> 6 </since_tizen>
        void AnimationStop();

        /// <summary>The animation object got changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs"/></value>
        event EventHandler<CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs> AnimationChanged;
        /// <summary>The animation progress got changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs"/></value>
        event EventHandler<CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs> AnimationProgressUpdated;
        /// <summary>The animation that is currently played on the canvas object.
        /// 
        /// <c>null</c> in case that there is no animation running.</summary>
        /// <value>The animation which is currently applied on this object.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Canvas.Animation Animation {
            get;
        }

        /// <summary>The current progress of the animation, between <c>0.0</c> and <c>1.0</c>.
        /// 
        /// Even if the animation is going backwards (speed &lt; 0.0) the progress will still go from <c>0.0</c> to <c>1.0</c>.
        /// 
        /// If there is no animation going on, this will return <c>-1.0</c>.</summary>
        /// <value>Current progress of the animation.</value>
        /// <since_tizen> 6 </since_tizen>
        double AnimationProgress {
            get;
        }

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <value>Paused state.</value>
        /// <since_tizen> 6 </since_tizen>
        bool AnimationPause {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.IObjectAnimation.AnimationChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ObjectAnimationAnimationChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>The animation object got changed.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Animation Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.IObjectAnimation.AnimationProgressUpdated"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ObjectAnimationAnimationProgressUpdatedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>The animation progress got changed.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IObjectAnimationNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_object_animation_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_canvas_object_animation_get_static_delegate == null)
            {
                efl_canvas_object_animation_get_static_delegate = new efl_canvas_object_animation_get_delegate(animation_get);
            }

            if (methods.Contains("GetAnimation"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_get_static_delegate) });
            }

            if (efl_canvas_object_animation_progress_get_static_delegate == null)
            {
                efl_canvas_object_animation_progress_get_static_delegate = new efl_canvas_object_animation_progress_get_delegate(animation_progress_get);
            }

            if (methods.Contains("GetAnimationProgress"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_progress_get_static_delegate) });
            }

            if (efl_canvas_object_animation_pause_get_static_delegate == null)
            {
                efl_canvas_object_animation_pause_get_static_delegate = new efl_canvas_object_animation_pause_get_delegate(animation_pause_get);
            }

            if (methods.Contains("GetAnimationPause"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_pause_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_pause_get_static_delegate) });
            }

            if (efl_canvas_object_animation_pause_set_static_delegate == null)
            {
                efl_canvas_object_animation_pause_set_static_delegate = new efl_canvas_object_animation_pause_set_delegate(animation_pause_set);
            }

            if (methods.Contains("SetAnimationPause"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_pause_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_pause_set_static_delegate) });
            }

            if (efl_canvas_object_animation_start_static_delegate == null)
            {
                efl_canvas_object_animation_start_static_delegate = new efl_canvas_object_animation_start_delegate(animation_start);
            }

            if (methods.Contains("AnimationStart"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_start"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_start_static_delegate) });
            }

            if (efl_canvas_object_animation_stop_static_delegate == null)
            {
                efl_canvas_object_animation_stop_static_delegate = new efl_canvas_object_animation_stop_delegate(animation_stop);
            }

            if (methods.Contains("AnimationStop"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_animation_stop"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_animation_stop_static_delegate) });
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
            return efl_canvas_object_animation_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Canvas.Animation efl_canvas_object_animation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Canvas.Animation efl_canvas_object_animation_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_get_api_delegate> efl_canvas_object_animation_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_get_api_delegate>(Module, "efl_canvas_object_animation_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Canvas.Animation animation_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Canvas.Animation _ret_var = default(CoreUI.Canvas.Animation);
                try
                {
                    _ret_var = ((IObjectAnimation)ws.Target).GetAnimation();
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
                return efl_canvas_object_animation_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_object_animation_get_delegate efl_canvas_object_animation_get_static_delegate;

        
        private delegate double efl_canvas_object_animation_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_canvas_object_animation_progress_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_progress_get_api_delegate> efl_canvas_object_animation_progress_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_progress_get_api_delegate>(Module, "efl_canvas_object_animation_progress_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double animation_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_progress_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IObjectAnimation)ws.Target).GetAnimationProgress();
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
                return efl_canvas_object_animation_progress_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_object_animation_progress_get_delegate efl_canvas_object_animation_progress_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_object_animation_pause_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_canvas_object_animation_pause_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_pause_get_api_delegate> efl_canvas_object_animation_pause_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_pause_get_api_delegate>(Module, "efl_canvas_object_animation_pause_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool animation_pause_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_pause_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IObjectAnimation)ws.Target).GetAnimationPause();
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
                return efl_canvas_object_animation_pause_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_object_animation_pause_get_delegate efl_canvas_object_animation_pause_get_static_delegate;

        
        private delegate void efl_canvas_object_animation_pause_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool pause);

        
        internal delegate void efl_canvas_object_animation_pause_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool pause);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_pause_set_api_delegate> efl_canvas_object_animation_pause_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_pause_set_api_delegate>(Module, "efl_canvas_object_animation_pause_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void animation_pause_set(System.IntPtr obj, System.IntPtr pd, bool pause)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_pause_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IObjectAnimation)ws.Target).SetAnimationPause(pause);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_animation_pause_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pause);
            }
        }

        private static efl_canvas_object_animation_pause_set_delegate efl_canvas_object_animation_pause_set_static_delegate;

        
        private delegate void efl_canvas_object_animation_start_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoMove))] CoreUI.Canvas.Animation animation,  double speed,  double starting_progress);

        
        internal delegate void efl_canvas_object_animation_start_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoMove))] CoreUI.Canvas.Animation animation,  double speed,  double starting_progress);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_start_api_delegate> efl_canvas_object_animation_start_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_start_api_delegate>(Module, "efl_canvas_object_animation_start");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void animation_start(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Animation animation, double speed, double starting_progress)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_start was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IObjectAnimation)ws.Target).AnimationStart(animation, speed, starting_progress);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_animation_start_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), animation, speed, starting_progress);
            }
        }

        private static efl_canvas_object_animation_start_delegate efl_canvas_object_animation_start_static_delegate;

        
        private delegate void efl_canvas_object_animation_stop_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_canvas_object_animation_stop_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_stop_api_delegate> efl_canvas_object_animation_stop_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_animation_stop_api_delegate>(Module, "efl_canvas_object_animation_stop");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void animation_stop(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_object_animation_stop was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IObjectAnimation)ws.Target).AnimationStop();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_object_animation_stop_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_object_animation_stop_delegate efl_canvas_object_animation_stop_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Canvas {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ObjectAnimationExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AnimationPause<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.IObjectAnimation, T>magic = null) where T : CoreUI.Canvas.IObjectAnimation {
            return new CoreUI.BindableProperty<bool>("animation_pause", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

