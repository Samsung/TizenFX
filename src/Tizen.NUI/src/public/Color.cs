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

using System;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// The Color class.
    /// </summary>
    [Tizen.NUI.Binding.TypeConverter(typeof(ColorTypeConverter))]
    public class Color : Disposable
    {
        /// <summary>
        /// Gets the black colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Black = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the white colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color White = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the red colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Red = new Color(1.0f, 0.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the green colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Green = new Color(0.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the blue colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Blue = new Color(0.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the yellow colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Yellow = new Color(1.0f, 1.0f, 0.0f, 1.0f);

        /// <summary>
        /// Gets the magenta colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Magenta = new Color(1.0f, 0.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the cyan colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Cyan = new Color(0.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Gets the  transparent colored Color class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly Color Transparent = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        private readonly bool hashDummy;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color() : this(Interop.Vector4.new_Vector4__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float r, float g, float b, float a) : this(Interop.Vector4.new_Vector4__SWIG_1(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of four floats.
        /// </summary>
        /// <param name="array">array Array of R,G,B,A.</param>
        /// <since_tizen> 3 </since_tizen>
        public Color(float[] array) : this(Interop.Vector4.new_Vector4__SWIG_2(ValueCheck(array)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Color(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
			hashDummy = false;
        }

        internal Color(ColorChangedCallback cb, float r, float g, float b, float a) : this(Interop.Vector4.new_Vector4__SWIG_1(ValueCheck(r), ValueCheck(g), ValueCheck(b), ValueCheck(a)), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Color(ColorChangedCallback cb, Color other) : this(cb, other.R, other.G, other.B, other.A)
        {
        }

        internal delegate void ColorChangedCallback(float r, float g, float b, float a);
        private ColorChangedCallback callback = null;

        /// <summary>
        /// The red component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            set
            {
                Interop.Vector4.Vector4_r_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.Vector4_r_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            set
            {
                Interop.Vector4.Vector4_g_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.Vector4_g_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            set
            {
                Interop.Vector4.Vector4_b_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.Vector4_b_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The alpha component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            set
            {
                Interop.Vector4.Vector4_a_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(R, G, B, A);
            }
            get
            {
                float ret = Interop.Vector4.Vector4_a_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The array subscript operator overload.
        /// </summary>
        /// <param name="index">The subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// Converts the Color class to Vector4 class implicitly.
        /// </summary>
        /// <param name="color">A color to be converted to Vector4</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector4(Color color)
        {
            return new Vector4(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Converts Vector4 class to Color class implicitly.
        /// </summary>
        /// <param name="vec">A Vector4 to be converted to color.</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Color(Vector4 vec)
        {
            return new Color(vec.R, vec.G, vec.B, vec.A);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator +(Color arg1, Color arg2)
        {
            Color result = arg1.Add(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1, Color arg2)
        {
            Color result = arg1.Subtract(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The color containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator -(Color arg1)
        {
            Color result = arg1.Subtract();
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, Color arg2)
        {
            Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator *(Color arg1, float arg2)
        {
            Color result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, Color arg2)
        {
            Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The color containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Color operator /(Color arg1, float arg2)
        {
            Color result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// Checks if two color classes are same.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are same, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.Vector4_EqualTo(swigCPtr, Color.getCPtr(rhs));

            if (rhs == null) return false;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks if two color classes are different.
        /// </summary>
        /// <param name="rhs">A color to be compared.</param>
        /// <returns>If two colors are are different, then true.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Color rhs)
        {
            bool ret = Interop.Vector4.Vector4_NotEqualTo(swigCPtr, Color.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Color obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Color GetColorFromPtr(global::System.IntPtr cPtr)
        {
            Color ret = new Color(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static Color ValueCheck(Color color)
        {
            if (color.R < 0.0f)
            {
                color.R = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (color.R > 1.0f)
            {
                color.R = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            if (color.G < 0.0f)
            {
                color.G = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (color.G > 1.0f)
            {
                color.G = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            if (color.B < 0.0f)
            {
                color.B = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (color.B > 1.0f)
            {
                color.B = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            if (color.A < 0.0f)
            {
                color.A = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (color.A > 1.0f)
            {
                color.A = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            return color;
        }

        internal static float ValueCheck(float value)
        {
            if (value < 0.0f)
            {
                value = 0.0f;
                NUILog.Error("The value of Parameters is invalid! Should be between [0, 1].");
            }
            else if (value > 1.0f)
            {
                value = 1.0f;
                NUILog.Error("The value of Parameters is invalid! Should be between [0, 1].");
            }
            return value;
        }

        internal static float[] ValueCheck(float[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0.0f)
                {
                    arr[i] = 0.0f;
                    NUILog.Error("The value of Parameters is invalid! Should be between [0, 1].");
                }
                else if (arr[i] > 1.0f)
                {
                    arr[i] = 1.0f;
                    NUILog.Error("The value of Parameters is invalid! Should be between [0, 1].");
                }
            }
            return arr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.delete_Vector4(swigCPtr);
        }

        private Color Add(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Add(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color AddAssign(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_AddAssign(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Subtract__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color SubtractAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_SubtractAssign(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Multiply__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Multiply(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_MultiplyAssign__SWIG_0(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color MultiplyAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_MultiplyAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(Vector4 rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Divide__SWIG_0(swigCPtr, Color.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Divide(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(Color rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_DivideAssign__SWIG_0(swigCPtr, Color.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color DivideAssign(float rhs)
        {
            Color ret = new Color(Interop.Vector4.Vector4_DivideAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Color Subtract()
        {
            Color ret = new Color(Interop.Vector4.Vector4_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static bool EqualsColorValue(float f1, float f2)
        {
            float EPS = (float)Math.Abs(f1 * .00001);
            if(Math.Abs(f1 - f2) <= EPS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool EqualsColor(Color c1, Color c2)
        {
            return EqualsColorValue(c1.R, c2.R) && EqualsColorValue(c1.G, c2.G)
                && EqualsColorValue(c1.B, c2.B) && EqualsColorValue(c1.A, c2.A);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(System.Object obj)
        {
            Color color = obj as Color;
            bool equal = false;
            if (color == null)
            {
                return equal;
            }

            if (EqualsColor(this, color))
            {
                equal = true;
            }
            return equal;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return hashDummy.GetHashCode();
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector4.Vector4_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}


