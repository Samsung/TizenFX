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
    /// <summary>Cubic Bezier interpolator. It starts slow, then moves quickly and then slows down again before stopping.
    /// 
    /// The exact shape of the mapping curve can be modified through the <see cref="CoreUI.CubicBezierInterpolator.ControlPoints"/> property.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.CubicBezierInterpolator.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class CubicBezierInterpolator : CoreUI.Object, CoreUI.IInterpolator
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(CubicBezierInterpolator))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_cubic_bezier_interpolator_class_get();

        /// <summary>Initializes a new instance of the <see cref="CubicBezierInterpolator"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public CubicBezierInterpolator(CoreUI.Object parent= null) : base(efl_cubic_bezier_interpolator_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected CubicBezierInterpolator(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CubicBezierInterpolator"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal CubicBezierInterpolator(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CubicBezierInterpolator"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected CubicBezierInterpolator(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Cubic Bezier curves are described by 4 2D control points (https://en.wikipedia.org/wiki/B%C3%A9zier_curve). For each control point, the X coordinate is an input value and the Y coordinate is the corresponding output value. The first one, P0, is set to <c>(0,0)</c>: The input <c>0.0</c> is mapped to the <c>0.0</c> output. The last one, P3, is set to <c>(1,1)</c>: The input <c>1.0</c> is mapped to the <c>1.0</c> output. The other two control points can be set through this property and control the shape of the curve. Note that the control points do not need to be in the <c>0...1</c> range, and neither do the output values of the curve.</summary>
        /// <param name="p1">P1 control point.</param>
        /// <param name="p2">P2 control point.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetControlPoints(out CoreUI.DataTypes.Vector2 p1, out CoreUI.DataTypes.Vector2 p2) {
            var _out_p1 = new CoreUI.DataTypes.Vector2();
var _out_p2 = new CoreUI.DataTypes.Vector2();
CoreUI.CubicBezierInterpolator.NativeMethods.efl_cubic_bezier_interpolator_control_points_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_p1, out _out_p2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
p1 = _out_p1;
p2 = _out_p2;
            
        }

        /// <summary>Cubic Bezier curves are described by 4 2D control points (https://en.wikipedia.org/wiki/B%C3%A9zier_curve). For each control point, the X coordinate is an input value and the Y coordinate is the corresponding output value. The first one, P0, is set to <c>(0,0)</c>: The input <c>0.0</c> is mapped to the <c>0.0</c> output. The last one, P3, is set to <c>(1,1)</c>: The input <c>1.0</c> is mapped to the <c>1.0</c> output. The other two control points can be set through this property and control the shape of the curve. Note that the control points do not need to be in the <c>0...1</c> range, and neither do the output values of the curve.</summary>
        /// <param name="p1">P1 control point.</param>
        /// <param name="p2">P2 control point.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetControlPoints(CoreUI.DataTypes.Vector2 p1, CoreUI.DataTypes.Vector2 p2) {
            CoreUI.DataTypes.Vector2 _in_p1 = p1;
CoreUI.DataTypes.Vector2 _in_p2 = p2;
CoreUI.CubicBezierInterpolator.NativeMethods.efl_cubic_bezier_interpolator_control_points_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_p1, _in_p2);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Performs the mapping operation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="progress">Input value between <c>0.0</c> and <c>1.0</c>. Values outside this range might yield unpredictable results.</param>
        /// <returns>Output mapped value. Its range is unrestricted. In particular, it might be outside the input <c>0, 1</c> range.</returns>
        public virtual double Interpolate(double progress) {
            var _ret_var = CoreUI.IInterpolatorNativeMethods.efl_interpolator_interpolate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), progress);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Cubic Bezier curves are described by 4 2D control points (https://en.wikipedia.org/wiki/B%C3%A9zier_curve). For each control point, the X coordinate is an input value and the Y coordinate is the corresponding output value. The first one, P0, is set to <c>(0,0)</c>: The input <c>0.0</c> is mapped to the <c>0.0</c> output. The last one, P3, is set to <c>(1,1)</c>: The input <c>1.0</c> is mapped to the <c>1.0</c> output. The other two control points can be set through this property and control the shape of the curve. Note that the control points do not need to be in the <c>0...1</c> range, and neither do the output values of the curve.</summary>
        /// <value>P1 control point.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.DataTypes.Vector2, CoreUI.DataTypes.Vector2) ControlPoints {
            get {
                CoreUI.DataTypes.Vector2 _out_p1 = default(CoreUI.DataTypes.Vector2);
                CoreUI.DataTypes.Vector2 _out_p2 = default(CoreUI.DataTypes.Vector2);
                GetControlPoints(out _out_p1, out _out_p2);
                return (_out_p1, _out_p2);
            }
            set { SetControlPoints( value.Item1,  value.Item2); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.CubicBezierInterpolator.efl_cubic_bezier_interpolator_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_cubic_bezier_interpolator_control_points_get_static_delegate == null)
                {
                    efl_cubic_bezier_interpolator_control_points_get_static_delegate = new efl_cubic_bezier_interpolator_control_points_get_delegate(control_points_get);
                }

                if (methods.Contains("GetControlPoints"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_cubic_bezier_interpolator_control_points_get"), func = Marshal.GetFunctionPointerForDelegate(efl_cubic_bezier_interpolator_control_points_get_static_delegate) });
                }

                if (efl_cubic_bezier_interpolator_control_points_set_static_delegate == null)
                {
                    efl_cubic_bezier_interpolator_control_points_set_static_delegate = new efl_cubic_bezier_interpolator_control_points_set_delegate(control_points_set);
                }

                if (methods.Contains("SetControlPoints"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_cubic_bezier_interpolator_control_points_set"), func = Marshal.GetFunctionPointerForDelegate(efl_cubic_bezier_interpolator_control_points_set_static_delegate) });
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
                return CoreUI.CubicBezierInterpolator.efl_cubic_bezier_interpolator_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_cubic_bezier_interpolator_control_points_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.DataTypes.Vector2 p1,  out CoreUI.DataTypes.Vector2 p2);

            
            internal delegate void efl_cubic_bezier_interpolator_control_points_get_api_delegate(System.IntPtr obj,  out CoreUI.DataTypes.Vector2 p1,  out CoreUI.DataTypes.Vector2 p2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_cubic_bezier_interpolator_control_points_get_api_delegate> efl_cubic_bezier_interpolator_control_points_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_cubic_bezier_interpolator_control_points_get_api_delegate>(Module, "efl_cubic_bezier_interpolator_control_points_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void control_points_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.DataTypes.Vector2 p1, out CoreUI.DataTypes.Vector2 p2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_cubic_bezier_interpolator_control_points_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Vector2 _out_p1 = default(CoreUI.DataTypes.Vector2);
CoreUI.DataTypes.Vector2 _out_p2 = default(CoreUI.DataTypes.Vector2);

                    try
                    {
                        ((CubicBezierInterpolator)ws.Target).GetControlPoints(out _out_p1, out _out_p2);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

            p1 = _out_p1;
p2 = _out_p2;
        
                }
                else
                {
                    efl_cubic_bezier_interpolator_control_points_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out p1, out p2);
                }
            }

            private static efl_cubic_bezier_interpolator_control_points_get_delegate efl_cubic_bezier_interpolator_control_points_get_static_delegate;

            
            private delegate void efl_cubic_bezier_interpolator_control_points_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Vector2 p1,  CoreUI.DataTypes.Vector2 p2);

            
            internal delegate void efl_cubic_bezier_interpolator_control_points_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Vector2 p1,  CoreUI.DataTypes.Vector2 p2);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_cubic_bezier_interpolator_control_points_set_api_delegate> efl_cubic_bezier_interpolator_control_points_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_cubic_bezier_interpolator_control_points_set_api_delegate>(Module, "efl_cubic_bezier_interpolator_control_points_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void control_points_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Vector2 p1, CoreUI.DataTypes.Vector2 p2)
            {
                CoreUI.DataTypes.Log.Debug("function efl_cubic_bezier_interpolator_control_points_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Vector2 _in_p1 = p1;
CoreUI.DataTypes.Vector2 _in_p2 = p2;

                    try
                    {
                        ((CubicBezierInterpolator)ws.Target).SetControlPoints(_in_p1, _in_p2);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_cubic_bezier_interpolator_control_points_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), p1, p2);
                }
            }

            private static efl_cubic_bezier_interpolator_control_points_set_delegate efl_cubic_bezier_interpolator_control_points_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

