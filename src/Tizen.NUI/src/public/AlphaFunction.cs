/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

namespace Tizen.NUI
{

    /// <summary>
    /// Alpha functions are used in animations to specify the rate of change of the animation parameter over time.<br />
    /// Understanding an animation as a parametric function over time, the alpha function is applied to the parameter of
    /// the animation before computing the final animation value.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AlphaFunction : Disposable
    {
        /// <summary>swigCMemOwn.</summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool swigCMemOwn;
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// The constructor.<br />
        /// Creates an alpha function object with the user-defined alpha function.<br />
        /// </summary>
        /// <param name="func">User defined fuction. It must be a method formatted as float alphafunction(float progress)</param>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction(System.Delegate func) : this(Interop.AlphaFunction.new_AlphaFunction__SWIG_2(SWIGTYPE_p_f_float__float.getCPtr(new SWIGTYPE_p_f_float__float(System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func), true))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The default constructor.<br />
        /// Creates an alpha function object with the default built-in alpha function.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction() : this(Interop.AlphaFunction.new_AlphaFunction__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.<br />
        /// Creates an alpha function object with the built-in alpha function passed as a parameter to the constructor.<br />
        /// </summary>
        /// <param name="function">One of the built-in alpha functions.</param>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction(AlphaFunction.BuiltinFunctions function) : this(Interop.AlphaFunction.new_AlphaFunction__SWIG_1((int)function), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.<br />
        /// Creates a bezier alpha function. The bezier will have the first point at (0,0) and the end point at (1,1).<br />
        /// </summary>
        /// <remarks>The x components of the control points will be clamped to the range [0, 1] to prevent non-monotonic curves.</remarks>
        /// <param name="controlPoint0">A Vector2 which will be used as the first control point of the curve.</param>
        /// <param name="controlPoint1">A Vector2 which will be used as the second control point of the curve.</param>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction(Vector2 controlPoint0, Vector2 controlPoint1) : this(Interop.AlphaFunction.new_AlphaFunction__SWIG_3(Vector2.getCPtr(controlPoint0), Vector2.getCPtr(controlPoint1)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AlphaFunction(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal AlphaFunction(SWIGTYPE_p_f_float__float function) : this(Interop.AlphaFunction.new_AlphaFunction__SWIG_2(SWIGTYPE_p_f_float__float.getCPtr(function)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This specifies the various types of BuiltinFunctions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum BuiltinFunctions
        {
            /// <summary>
            /// Linear.
            /// </summary>
            Default,
            /// <summary>
            /// No transformation.
            /// </summary>
            Linear,
            /// <summary>
            /// Reverse linear.
            /// </summary>
            Reverse,
            /// <summary>
            /// Speeds up and comes to a sudden stop (square).
            /// </summary>
            EaseInSquare,
            /// <summary>
            /// Sudden start and slows to a gradual stop (square).
            /// </summary>
            EaseOutSquare,
            /// <summary>
            /// Speeds up and comes to a sudden stop (cubic).
            /// </summary>
            EaseIn,
            /// <summary>
            /// Sudden start and slows to a gradual stop (cubic).
            /// </summary>
            EaseOut,
            /// <summary>
            /// Speeds up and slows to a gradual stop (cubic).
            /// </summary>
            EaseInOut,
            /// <summary>
            /// Speeds up and comes to a sudden stop (sinusoidal).
            /// </summary>
            EaseInSine,
            /// <summary>
            /// Sudden start and slows to a gradual stop (sinusoidal).
            /// </summary>
            EaseOutSine,
            /// <summary>
            /// Speeds up and slows to a gradual stop (sinusoidal).
            /// </summary>
            EaseInOutSine,
            /// <summary>
            /// Sudden start, loses momentum and returns to start position.
            /// </summary>
            Bounce,
            /// <summary>
            /// Single revolution.
            /// </summary>
            Sin,
            /// <summary>
            /// Sudden start, exceed end position and return to a gradual stop.
            /// </summary>
            EaseOutBack,
            /// <summary>
            /// The count of the BuiltinFunctions enum.
            /// </summary>
            Count
        }

        /// <summary>
        /// This specifies which mode is set for AlphaFunction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Modes
        {
            /// <summary>
            /// The user has used a built-in function.
            /// </summary>
            BuiltinFunction,

            /// <summary>
            /// The user has provided a custom function.
            /// </summary>
            CustomFunction,
            /// <summary>
            /// The user has provided the control points of a bezier curve.
            /// </summary>
            Bezier
        }

        /// <summary>
        /// Retrives the control points of the alpha function.<br />
        /// </summary>
        /// <param name="controlPoint0">A Vector2 which will be used as the first control point of the curve.</param>
        /// <param name="controlPoint1">A Vector2 which will be used as the second control point of the curve.</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetBezierControlPoints(out Vector2 controlPoint0, out Vector2 controlPoint1)
        {
            Vector4 ret = new Vector4(Interop.AlphaFunction.AlphaFunction_GetBezierControlPoints(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            controlPoint0 = new Vector2(ret.X, ret.Y);
            controlPoint1 = new Vector2(ret.Z, ret.W);
        }

        /// <summary>
        /// Returns the built-in function used by the alpha function.<br />
        /// In case no built-in function has been specified, it will return AlphaFunction::DEFAULT.<br />
        /// </summary>
        /// <returns>One of the built-in alpha functions.</returns>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction.BuiltinFunctions GetBuiltinFunction()
        {
            AlphaFunction.BuiltinFunctions ret = (AlphaFunction.BuiltinFunctions)Interop.AlphaFunction.AlphaFunction_GetBuiltinFunction(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        ///  Returns the functioning mode of the alpha function.
        /// </summary>
        /// <returns>The functioning mode of the alpha function.</returns>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction.Modes GetMode()
        {
            AlphaFunction.Modes ret = (AlphaFunction.Modes)Interop.AlphaFunction.AlphaFunction_GetMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AlphaFunction obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static string BuiltinToPropertyKey(BuiltinFunctions? alphaFunction)
        {
            string propertyKey = null;
            if (alphaFunction != null)
            {
                switch (alphaFunction)
                {
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Linear:
                        {
                            propertyKey = "LINEAR";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Reverse:
                        {
                            propertyKey = "REVERSE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSquare:
                        {
                            propertyKey = "EASE_IN_SQUARE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSquare:
                        {
                            propertyKey = "EASE_OUT_SQUARE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn:
                        {
                            propertyKey = "EASE_IN";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut:
                        {
                            propertyKey = "EASE_OUT";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOut:
                        {
                            propertyKey = "EASE_IN_OUT";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInSine:
                        {
                            propertyKey = "EASE_IN_SINE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutSine:
                        {
                            propertyKey = "EASE_OUT_SINE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseInOutSine:
                        {
                            propertyKey = "EASE_IN_OUT_SINE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Bounce:
                        {
                            propertyKey = "BOUNCE";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.Sin:
                        {
                            propertyKey = "SIN";
                            break;
                        }
                    case Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOutBack:
                        {
                            propertyKey = "EASE_OUT_BACK";
                            break;
                        }
                    default:
                        {
                            propertyKey = "DEFAULT";
                            break;
                        }
                }
            }
            return propertyKey;
        }

        internal SWIGTYPE_p_f_float__float GetCustomFunction()
        {
            global::System.IntPtr cPtr = Interop.AlphaFunction.AlphaFunction_GetCustomFunction(swigCPtr);
            SWIGTYPE_p_f_float__float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_float__float(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make the AlphaFunction instance be disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.AlphaFunction.delete_AlphaFunction(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }
    }
}