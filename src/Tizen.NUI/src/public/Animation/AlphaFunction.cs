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

using System.ComponentModel;

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

        /// <summary>
        /// The constructor.<br />
        /// Creates an alpha function object with the user-defined alpha function.<br />
        /// </summary>
        /// <param name="func">User defined function. It must be a method formatted as float alphafunction(float progress)</param>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction(global::System.Delegate func) : this(Interop.AlphaFunction.NewAlphaFunction(SWIGTYPE_p_f_float__float.getCPtr(new SWIGTYPE_p_f_float__float(System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func)))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The default constructor.<br />
        /// Creates an alpha function object with the default built-in alpha function.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction() : this(Interop.AlphaFunction.NewAlphaFunction(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.<br />
        /// Creates an alpha function object with the built-in alpha function passed as a parameter to the constructor.<br />
        /// </summary>
        /// <param name="function">One of the built-in alpha functions.</param>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction(AlphaFunction.BuiltinFunctions function) : this(Interop.AlphaFunction.NewAlphaFunction((int)function), true)
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
        public AlphaFunction(Vector2 controlPoint0, Vector2 controlPoint1) : this(Interop.AlphaFunction.NewAlphaFunction(Vector2.getCPtr(controlPoint0), Vector2.getCPtr(controlPoint1)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal AlphaFunction(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        // Not used : This will be remained by 2021-05-30 to check side effect. After 2021-05-30 this will be removed cleanly
        // internal AlphaFunction(SWIGTYPE_p_f_float__float function) : this(Interop.AlphaFunction.NewAlphaFunction(SWIGTYPE_p_f_float__float.getCPtr(function)), true)
        // {
        //     if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        // }

        /// <summary>
        /// This specifies the various types of BuiltinFunctions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum BuiltinFunctions
        {
            /// <summary>
            /// Linear.
            /// </summary>
            [Description("DEFAULT")]
            Default,
            /// <summary>
            /// No transformation.
            /// </summary>
            [Description("LINEAR")]
            Linear,
            /// <summary>
            /// Reverse linear.
            /// </summary>
            [Description("REVERSE")]
            Reverse,
            /// <summary>
            /// Speeds up and comes to a sudden stop (square).
            /// </summary>
            [Description("EASE_IN_SQUARE")]
            EaseInSquare,
            /// <summary>
            /// Sudden start and slows to a gradual stop (square).
            /// </summary>
            [Description("EASE_OUT_SQUARE")]
            EaseOutSquare,
            /// <summary>
            /// Speeds up and comes to a sudden stop (cubic).
            /// </summary>
            [Description("EASE_IN")]
            EaseIn,
            /// <summary>
            /// Sudden start and slows to a gradual stop (cubic).
            /// </summary>
            [Description("EASE_OUT")]
            EaseOut,
            /// <summary>
            /// Speeds up and slows to a gradual stop (cubic).
            /// </summary>
            [Description("EASE_IN_OUT")]
            EaseInOut,
            /// <summary>
            /// Speeds up and comes to a sudden stop (sinusoidal).
            /// </summary>
            [Description("EASE_IN_SINE")]
            EaseInSine,
            /// <summary>
            /// Sudden start and slows to a gradual stop (sinusoidal).
            /// </summary>
            [Description("EASE_OUT_SINE")]
            EaseOutSine,
            /// <summary>
            /// Speeds up and slows to a gradual stop (sinusoidal).
            /// </summary>
            [Description("EASE_IN_OUT_SINE")]
            EaseInOutSine,
            /// <summary>
            /// Sudden start, loses momentum and returns to start position.
            /// </summary>
            [Description("BOUNCE")]
            Bounce,
            /// <summary>
            /// Single revolution.
            /// </summary>
            [Description("SIN")]
            Sin,
            /// <summary>
            /// Sudden start, exceed end position and return to a gradual stop.
            /// </summary>
            [Description("EASE_OUT_BACK")]
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
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
        /// Retrieves the control points of the alpha function.<br />
        /// </summary>
        /// <param name="controlPoint0">A Vector2 which will be used as the first control point of the curve.</param>
        /// <param name="controlPoint1">A Vector2 which will be used as the second control point of the curve.</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetBezierControlPoints(out Vector2 controlPoint0, out Vector2 controlPoint1)
        {
            Vector4 ret = new Vector4(Interop.AlphaFunction.GetBezierControlPoints(SwigCPtr), true);
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
            AlphaFunction.BuiltinFunctions ret = (AlphaFunction.BuiltinFunctions)Interop.AlphaFunction.GetBuiltinFunction(SwigCPtr);
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
            AlphaFunction.Modes ret = (AlphaFunction.Modes)Interop.AlphaFunction.GetMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AlphaFunction obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
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

        // Not used : This will be remained by 2021-05-30 to check side effect. After 2021-05-30 this will be removed cleanly
        // internal SWIGTYPE_p_f_float__float GetCustomFunction()
        // {
        //     global::System.IntPtr cPtr = Interop.AlphaFunction.GetCustomFunction(SwigCPtr);
        //     SWIGTYPE_p_f_float__float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_float__float(cPtr);
        //     if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        //     return ret;
        // }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AlphaFunction.DeleteAlphaFunction(swigCPtr);
        }
    }
}
