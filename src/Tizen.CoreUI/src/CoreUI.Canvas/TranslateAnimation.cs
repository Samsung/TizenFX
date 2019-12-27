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
    /// <summary>Animated translation effect.
    /// 
    /// The <see cref="CoreUI.Canvas.Object"/> will move from one point to another. Coordinates for the origin and destination points can be relative to the object or absolute (relative to the containing canvas).
    /// 
    /// <b>NOTE: </b>Changing an object&apos;s position using <see cref="CoreUI.Gfx.IEntity.Position"/> while this animation is running might lead to unexpected results.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.TranslateAnimation.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class TranslateAnimation : CoreUI.Canvas.Animation
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(TranslateAnimation))
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
            efl_canvas_translate_animation_class_get();

        /// <summary>Initializes a new instance of the <see cref="TranslateAnimation"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public TranslateAnimation(CoreUI.Object parent= null) : base(efl_canvas_translate_animation_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected TranslateAnimation(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TranslateAnimation"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal TranslateAnimation(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="TranslateAnimation"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected TranslateAnimation(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Translation vector, relative to the starting position of the object. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will move from its current position to <c>to</c>.</summary>
        /// <param name="from">Relative initial position.</param>
        /// <param name="to">Relative ending position.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetTranslate(out CoreUI.DataTypes.Position2D from, out CoreUI.DataTypes.Position2D to) {
            var _out_from = new CoreUI.DataTypes.Position2D();
var _out_to = new CoreUI.DataTypes.Position2D();
CoreUI.Canvas.TranslateAnimation.NativeMethods.efl_animation_translate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_from, out _out_to);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
from = _out_from;
to = _out_to;
            
        }

        /// <summary>Translation vector, relative to the starting position of the object. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will move from its current position to <c>to</c>.</summary>
        /// <param name="from">Relative initial position.</param>
        /// <param name="to">Relative ending position.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTranslate(CoreUI.DataTypes.Position2D from, CoreUI.DataTypes.Position2D to) {
            CoreUI.DataTypes.Position2D _in_from = from;
CoreUI.DataTypes.Position2D _in_to = to;
CoreUI.Canvas.TranslateAnimation.NativeMethods.efl_animation_translate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_from, _in_to);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Translation vector, relative to the canvas. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will always start from the origin of the canvas, regardless of the current object position.</summary>
        /// <param name="from">Absolute initial position.</param>
        /// <param name="to">Absolute ending position.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetTranslateAbsolute(out CoreUI.DataTypes.Position2D from, out CoreUI.DataTypes.Position2D to) {
            var _out_from = new CoreUI.DataTypes.Position2D();
var _out_to = new CoreUI.DataTypes.Position2D();
CoreUI.Canvas.TranslateAnimation.NativeMethods.efl_animation_translate_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_from, out _out_to);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
from = _out_from;
to = _out_to;
            
        }

        /// <summary>Translation vector, relative to the canvas. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will always start from the origin of the canvas, regardless of the current object position.</summary>
        /// <param name="from">Absolute initial position.</param>
        /// <param name="to">Absolute ending position.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetTranslateAbsolute(CoreUI.DataTypes.Position2D from, CoreUI.DataTypes.Position2D to) {
            CoreUI.DataTypes.Position2D _in_from = from;
CoreUI.DataTypes.Position2D _in_to = to;
CoreUI.Canvas.TranslateAnimation.NativeMethods.efl_animation_translate_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_from, _in_to);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Translation vector, relative to the starting position of the object. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will move from its current position to <c>to</c>.</summary>
        /// <value>Relative initial position.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.DataTypes.Position2D, CoreUI.DataTypes.Position2D) Translate {
            get {
                CoreUI.DataTypes.Position2D _out_from = default(CoreUI.DataTypes.Position2D);
                CoreUI.DataTypes.Position2D _out_to = default(CoreUI.DataTypes.Position2D);
                GetTranslate(out _out_from, out _out_to);
                return (_out_from, _out_to);
            }
            set { SetTranslate( value.Item1,  value.Item2); }
        }

        /// <summary>Translation vector, relative to the canvas. So, for example, if <c>from</c> is <c>(0,0)</c>, the object will always start from the origin of the canvas, regardless of the current object position.</summary>
        /// <value>Absolute initial position.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.DataTypes.Position2D, CoreUI.DataTypes.Position2D) TranslateAbsolute {
            get {
                CoreUI.DataTypes.Position2D _out_from = default(CoreUI.DataTypes.Position2D);
                CoreUI.DataTypes.Position2D _out_to = default(CoreUI.DataTypes.Position2D);
                GetTranslateAbsolute(out _out_from, out _out_to);
                return (_out_from, _out_to);
            }
            set { SetTranslateAbsolute( value.Item1,  value.Item2); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.TranslateAnimation.efl_canvas_translate_animation_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Canvas.Animation.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_animation_translate_get_static_delegate == null)
                {
                    efl_animation_translate_get_static_delegate = new efl_animation_translate_get_delegate(translate_get);
                }

                if (methods.Contains("GetTranslate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_translate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_get_static_delegate) });
                }

                if (efl_animation_translate_set_static_delegate == null)
                {
                    efl_animation_translate_set_static_delegate = new efl_animation_translate_set_delegate(translate_set);
                }

                if (methods.Contains("SetTranslate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_translate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_set_static_delegate) });
                }

                if (efl_animation_translate_absolute_get_static_delegate == null)
                {
                    efl_animation_translate_absolute_get_static_delegate = new efl_animation_translate_absolute_get_delegate(translate_absolute_get);
                }

                if (methods.Contains("GetTranslateAbsolute"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_translate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_absolute_get_static_delegate) });
                }

                if (efl_animation_translate_absolute_set_static_delegate == null)
                {
                    efl_animation_translate_absolute_set_static_delegate = new efl_animation_translate_absolute_set_delegate(translate_absolute_set);
                }

                if (methods.Contains("SetTranslateAbsolute"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_translate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_translate_absolute_set_static_delegate) });
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
                return CoreUI.Canvas.TranslateAnimation.efl_canvas_translate_animation_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_animation_translate_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.DataTypes.Position2D from,  out CoreUI.DataTypes.Position2D to);

            
            internal delegate void efl_animation_translate_get_api_delegate(System.IntPtr obj,  out CoreUI.DataTypes.Position2D from,  out CoreUI.DataTypes.Position2D to);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_get_api_delegate> efl_animation_translate_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_get_api_delegate>(Module, "efl_animation_translate_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void translate_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.DataTypes.Position2D from, out CoreUI.DataTypes.Position2D to)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_translate_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _out_from = default(CoreUI.DataTypes.Position2D);
CoreUI.DataTypes.Position2D _out_to = default(CoreUI.DataTypes.Position2D);

                    try
                    {
                        ((TranslateAnimation)ws.Target).GetTranslate(out _out_from, out _out_to);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            from = _out_from;
to = _out_to;
        
                }
                else
                {
                    efl_animation_translate_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out from, out to);
                }
            }

            private static efl_animation_translate_get_delegate efl_animation_translate_get_static_delegate;

            
            private delegate void efl_animation_translate_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D from,  CoreUI.DataTypes.Position2D to);

            
            internal delegate void efl_animation_translate_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D from,  CoreUI.DataTypes.Position2D to);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_set_api_delegate> efl_animation_translate_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_set_api_delegate>(Module, "efl_animation_translate_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void translate_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D from, CoreUI.DataTypes.Position2D to)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_translate_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_from = from;
CoreUI.DataTypes.Position2D _in_to = to;

                    try
                    {
                        ((TranslateAnimation)ws.Target).SetTranslate(_in_from, _in_to);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_translate_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), from, to);
                }
            }

            private static efl_animation_translate_set_delegate efl_animation_translate_set_static_delegate;

            
            private delegate void efl_animation_translate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.DataTypes.Position2D from,  out CoreUI.DataTypes.Position2D to);

            
            internal delegate void efl_animation_translate_absolute_get_api_delegate(System.IntPtr obj,  out CoreUI.DataTypes.Position2D from,  out CoreUI.DataTypes.Position2D to);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_absolute_get_api_delegate> efl_animation_translate_absolute_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_absolute_get_api_delegate>(Module, "efl_animation_translate_absolute_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void translate_absolute_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.DataTypes.Position2D from, out CoreUI.DataTypes.Position2D to)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_translate_absolute_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _out_from = default(CoreUI.DataTypes.Position2D);
CoreUI.DataTypes.Position2D _out_to = default(CoreUI.DataTypes.Position2D);

                    try
                    {
                        ((TranslateAnimation)ws.Target).GetTranslateAbsolute(out _out_from, out _out_to);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            from = _out_from;
to = _out_to;
        
                }
                else
                {
                    efl_animation_translate_absolute_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out from, out to);
                }
            }

            private static efl_animation_translate_absolute_get_delegate efl_animation_translate_absolute_get_static_delegate;

            
            private delegate void efl_animation_translate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D from,  CoreUI.DataTypes.Position2D to);

            
            internal delegate void efl_animation_translate_absolute_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D from,  CoreUI.DataTypes.Position2D to);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_absolute_set_api_delegate> efl_animation_translate_absolute_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_translate_absolute_set_api_delegate>(Module, "efl_animation_translate_absolute_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void translate_absolute_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D from, CoreUI.DataTypes.Position2D to)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_translate_absolute_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_from = from;
CoreUI.DataTypes.Position2D _in_to = to;

                    try
                    {
                        ((TranslateAnimation)ws.Target).SetTranslateAbsolute(_in_from, _in_to);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_translate_absolute_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), from, to);
                }
            }

            private static efl_animation_translate_absolute_set_delegate efl_animation_translate_absolute_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

