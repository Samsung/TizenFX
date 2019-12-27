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
    /// <summary>Animated rotation effect.
    /// 
    /// The <see cref="CoreUI.Canvas.Object"/> will rotate around a pivot point from one degree to another. Coordinates for the pivot point can be relative to another object or absolute (relative to the containing canvas).
    /// 
    /// <b>NOTE: </b>Changing an object&apos;s position using <see cref="CoreUI.Gfx.IEntity.Position"/> while this animation is running might lead to unexpected results.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.RotateAnimation.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class RotateAnimation : CoreUI.Canvas.Animation
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(RotateAnimation))
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
            efl_canvas_rotate_animation_class_get();

        /// <summary>Initializes a new instance of the <see cref="RotateAnimation"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public RotateAnimation(CoreUI.Object parent= null) : base(efl_canvas_rotate_animation_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected RotateAnimation(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RotateAnimation"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal RotateAnimation(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RotateAnimation"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected RotateAnimation(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Degree range to animate and pivot object. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to the pivot point inside the pivot object. The pivot point is another object <c>pivot</c> plus an additional offset <c>center_point</c>.</summary>
        /// <param name="from_degree">Initial rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="to_degree">Ending rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="pivot">Object to use as pivot. <c>NULL</c> means the animated object itself.</param>
        /// <param name="center_point">Position in pixels of the pivot point inside the pivot object. <c>(0,0)</c> means the upper-left corner.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRotate(out double from_degree, out double to_degree, out CoreUI.Canvas.Object pivot, out CoreUI.DataTypes.Vector2 center_point) {
            var _out_center_point = new CoreUI.DataTypes.Vector2();
CoreUI.Canvas.RotateAnimation.NativeMethods.efl_animation_rotate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out from_degree, out to_degree, out pivot, out _out_center_point);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
center_point = _out_center_point;
            
        }

        /// <summary>Degree range to animate and pivot object. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to the pivot point inside the pivot object. The pivot point is another object <c>pivot</c> plus an additional offset <c>center_point</c>.</summary>
        /// <param name="from_degree">Initial rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="to_degree">Ending rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="pivot">Object to use as pivot. <c>NULL</c> means the animated object itself.</param>
        /// <param name="center_point">Position in pixels of the pivot point inside the pivot object. <c>(0,0)</c> means the upper-left corner.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRotate(double from_degree, double to_degree, CoreUI.Canvas.Object pivot, CoreUI.DataTypes.Vector2 center_point) {
            CoreUI.DataTypes.Vector2 _in_center_point = center_point;
CoreUI.Canvas.RotateAnimation.NativeMethods.efl_animation_rotate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), from_degree, to_degree, pivot, _in_center_point);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Degree range to animate and absolute pivot point. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to an absolute pivot point. The pivot point is relative to the canvas.</summary>
        /// <param name="from_degree">Initial rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="to_degree">Ending rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="pivot_point">Position of the pivot point relative to the canvas.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetRotateAbsolute(out double from_degree, out double to_degree, out CoreUI.DataTypes.Position2D pivot_point) {
            var _out_pivot_point = new CoreUI.DataTypes.Position2D();
CoreUI.Canvas.RotateAnimation.NativeMethods.efl_animation_rotate_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out from_degree, out to_degree, out _out_pivot_point);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
pivot_point = _out_pivot_point;
            
        }

        /// <summary>Degree range to animate and absolute pivot point. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to an absolute pivot point. The pivot point is relative to the canvas.</summary>
        /// <param name="from_degree">Initial rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="to_degree">Ending rotation (from 0 to 360). 0 means no rotation.</param>
        /// <param name="pivot_point">Position of the pivot point relative to the canvas.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRotateAbsolute(double from_degree, double to_degree, CoreUI.DataTypes.Position2D pivot_point) {
            CoreUI.DataTypes.Position2D _in_pivot_point = pivot_point;
CoreUI.Canvas.RotateAnimation.NativeMethods.efl_animation_rotate_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), from_degree, to_degree, _in_pivot_point);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Degree range to animate and pivot object. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to the pivot point inside the pivot object. The pivot point is another object <c>pivot</c> plus an additional offset <c>center_point</c>.</summary>
        /// <value>Initial rotation (from 0 to 360). 0 means no rotation.</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double, CoreUI.Canvas.Object, CoreUI.DataTypes.Vector2) Rotate {
            get {
                double _out_from_degree = default(double);
                double _out_to_degree = default(double);
                CoreUI.Canvas.Object _out_pivot = default(CoreUI.Canvas.Object);
                CoreUI.DataTypes.Vector2 _out_center_point = default(CoreUI.DataTypes.Vector2);
                GetRotate(out _out_from_degree, out _out_to_degree, out _out_pivot, out _out_center_point);
                return (_out_from_degree, _out_to_degree, _out_pivot, _out_center_point);
            }
            set { SetRotate( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Degree range to animate and absolute pivot point. The object will rotate from <c>from_degree</c> to <c>to_degree</c> around the pivot point. All of the object&apos;s vertices (i.e. the corners, if it&apos;s a rectangular object) will be rotated by these degrees, relative to an absolute pivot point. The pivot point is relative to the canvas.</summary>
        /// <value>Initial rotation (from 0 to 360). 0 means no rotation.</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double, CoreUI.DataTypes.Position2D) RotateAbsolute {
            get {
                double _out_from_degree = default(double);
                double _out_to_degree = default(double);
                CoreUI.DataTypes.Position2D _out_pivot_point = default(CoreUI.DataTypes.Position2D);
                GetRotateAbsolute(out _out_from_degree, out _out_to_degree, out _out_pivot_point);
                return (_out_from_degree, _out_to_degree, _out_pivot_point);
            }
            set { SetRotateAbsolute( value.Item1,  value.Item2,  value.Item3); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.RotateAnimation.efl_canvas_rotate_animation_class_get();
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

                if (efl_animation_rotate_get_static_delegate == null)
                {
                    efl_animation_rotate_get_static_delegate = new efl_animation_rotate_get_delegate(rotate_get);
                }

                if (methods.Contains("GetRotate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_get_static_delegate) });
                }

                if (efl_animation_rotate_set_static_delegate == null)
                {
                    efl_animation_rotate_set_static_delegate = new efl_animation_rotate_set_delegate(rotate_set);
                }

                if (methods.Contains("SetRotate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_set_static_delegate) });
                }

                if (efl_animation_rotate_absolute_get_static_delegate == null)
                {
                    efl_animation_rotate_absolute_get_static_delegate = new efl_animation_rotate_absolute_get_delegate(rotate_absolute_get);
                }

                if (methods.Contains("GetRotateAbsolute"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_absolute_get"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_get_static_delegate) });
                }

                if (efl_animation_rotate_absolute_set_static_delegate == null)
                {
                    efl_animation_rotate_absolute_set_static_delegate = new efl_animation_rotate_absolute_set_delegate(rotate_absolute_set);
                }

                if (methods.Contains("SetRotateAbsolute"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_animation_rotate_absolute_set"), func = Marshal.GetFunctionPointerForDelegate(efl_animation_rotate_absolute_set_static_delegate) });
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
                return CoreUI.Canvas.RotateAnimation.efl_canvas_rotate_animation_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_animation_rotate_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Canvas.Object pivot,  out CoreUI.DataTypes.Vector2 center_point);

            
            internal delegate void efl_animation_rotate_get_api_delegate(System.IntPtr obj,  out double from_degree,  out double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] out CoreUI.Canvas.Object pivot,  out CoreUI.DataTypes.Vector2 center_point);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_get_api_delegate> efl_animation_rotate_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_get_api_delegate>(Module, "efl_animation_rotate_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void rotate_get(System.IntPtr obj, System.IntPtr pd, out double from_degree, out double to_degree, out CoreUI.Canvas.Object pivot, out CoreUI.DataTypes.Vector2 center_point)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_rotate_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    from_degree = default(double);to_degree = default(double);pivot = default(CoreUI.Canvas.Object);CoreUI.DataTypes.Vector2 _out_center_point = default(CoreUI.DataTypes.Vector2);

                    try
                    {
                        ((RotateAnimation)ws.Target).GetRotate(out from_degree, out to_degree, out pivot, out _out_center_point);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            center_point = _out_center_point;
        
                }
                else
                {
                    efl_animation_rotate_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out from_degree, out to_degree, out pivot, out center_point);
                }
            }

            private static efl_animation_rotate_get_delegate efl_animation_rotate_get_static_delegate;

            
            private delegate void efl_animation_rotate_set_delegate(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object pivot,  CoreUI.DataTypes.Vector2 center_point);

            
            internal delegate void efl_animation_rotate_set_api_delegate(System.IntPtr obj,  double from_degree,  double to_degree, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object pivot,  CoreUI.DataTypes.Vector2 center_point);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_set_api_delegate> efl_animation_rotate_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_set_api_delegate>(Module, "efl_animation_rotate_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void rotate_set(System.IntPtr obj, System.IntPtr pd, double from_degree, double to_degree, CoreUI.Canvas.Object pivot, CoreUI.DataTypes.Vector2 center_point)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_rotate_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Vector2 _in_center_point = center_point;

                    try
                    {
                        ((RotateAnimation)ws.Target).SetRotate(from_degree, to_degree, pivot, _in_center_point);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_rotate_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), from_degree, to_degree, pivot, center_point);
                }
            }

            private static efl_animation_rotate_set_delegate efl_animation_rotate_set_static_delegate;

            
            private delegate void efl_animation_rotate_absolute_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double from_degree,  out double to_degree,  out CoreUI.DataTypes.Position2D pivot_point);

            
            internal delegate void efl_animation_rotate_absolute_get_api_delegate(System.IntPtr obj,  out double from_degree,  out double to_degree,  out CoreUI.DataTypes.Position2D pivot_point);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate> efl_animation_rotate_absolute_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_absolute_get_api_delegate>(Module, "efl_animation_rotate_absolute_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void rotate_absolute_get(System.IntPtr obj, System.IntPtr pd, out double from_degree, out double to_degree, out CoreUI.DataTypes.Position2D pivot_point)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_rotate_absolute_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    from_degree = default(double);to_degree = default(double);CoreUI.DataTypes.Position2D _out_pivot_point = default(CoreUI.DataTypes.Position2D);

                    try
                    {
                        ((RotateAnimation)ws.Target).GetRotateAbsolute(out from_degree, out to_degree, out _out_pivot_point);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            pivot_point = _out_pivot_point;
        
                }
                else
                {
                    efl_animation_rotate_absolute_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out from_degree, out to_degree, out pivot_point);
                }
            }

            private static efl_animation_rotate_absolute_get_delegate efl_animation_rotate_absolute_get_static_delegate;

            
            private delegate void efl_animation_rotate_absolute_set_delegate(System.IntPtr obj, System.IntPtr pd,  double from_degree,  double to_degree,  CoreUI.DataTypes.Position2D pivot_point);

            
            internal delegate void efl_animation_rotate_absolute_set_api_delegate(System.IntPtr obj,  double from_degree,  double to_degree,  CoreUI.DataTypes.Position2D pivot_point);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate> efl_animation_rotate_absolute_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_animation_rotate_absolute_set_api_delegate>(Module, "efl_animation_rotate_absolute_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void rotate_absolute_set(System.IntPtr obj, System.IntPtr pd, double from_degree, double to_degree, CoreUI.DataTypes.Position2D pivot_point)
            {
                CoreUI.DataTypes.Log.Debug("function efl_animation_rotate_absolute_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_pivot_point = pivot_point;

                    try
                    {
                        ((RotateAnimation)ws.Target).SetRotateAbsolute(from_degree, to_degree, _in_pivot_point);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_animation_rotate_absolute_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), from_degree, to_degree, pivot_point);
                }
            }

            private static efl_animation_rotate_absolute_set_delegate efl_animation_rotate_absolute_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

