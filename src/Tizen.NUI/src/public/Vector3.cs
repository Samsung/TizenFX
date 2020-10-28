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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{

    /// <summary>
    /// A three-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(Vector3TypeConverter))]
    public class Vector3 : Disposable
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3() : this(Interop.Vector3.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The default constructor initializes the vector to 0.
        /// </summary>
        /// <param name="x">The x (or width) component.</param>
        /// <param name="y">The y (or height) component.</param>
        /// <param name="z">The z (or depth) component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(float x, float y, float z) : this(Interop.Vector3.new_Vector3__SWIG_1(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Conversion constructor from an array of three floats.
        /// </summary>
        /// <param name="array">An array of xyz.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(float[] array) : this(Interop.Vector3.new_Vector3__SWIG_2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec2">Vector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(Vector2 vec2) : this(Interop.Vector3.new_Vector3__SWIG_3(Vector2.getCPtr(vec2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec4">Vector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(Vector4 vec4) : this(Interop.Vector3.new_Vector3__SWIG_4(Vector4.getCPtr(vec4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Vector3(Vector3ChangedCallback cb, float x, float y, float z) : this(Interop.Vector3.new_Vector3__SWIG_1(x, y, z), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal delegate void Vector3ChangedCallback(float x, float y, float z);
        private Vector3ChangedCallback callback = null;

        /// <summary>
        /// (1.0f,1.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 One
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_ONE_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 XAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_XAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 YAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_YAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the z-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 ZAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_ZAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_XAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Th vector representing the negative y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_YAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative z-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 NegativeZAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_ZAXIS_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// (0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_ZERO_get();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            set
            {
                Interop.Vector3.Vector3_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_X_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The width component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Width
        {
            set
            {
                Interop.Vector3.Vector3_Width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The red component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            set
            {
                Interop.Vector3.Vector3_r_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_r_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            set
            {
                Interop.Vector3.Vector3_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The height component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Height
        {
            set
            {
                Interop.Vector3.Vector3_Height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Height_get(swigCPtr);
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
                Interop.Vector3.Vector3_g_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_g_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            set
            {
                Interop.Vector3.Vector3_Z_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Z_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The depth component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Depth
        {
            set
            {
                Interop.Vector3.Vector3_Depth_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Depth_get(swigCPtr);
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
                Interop.Vector3.Vector3_b_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_b_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// An array subscript operator overload.
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
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator +(Vector3 arg1, Vector3 arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator -(Vector3 arg1, Vector3 arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator -(Vector3 arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator *(Vector3 arg1, Vector3 arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator *(Vector3 arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator /(Vector3 arg1, Vector3 arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator /(Vector3 arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Vector3 vector3 = obj as Vector3;
            bool equal = false;
            if (X == vector3?.X && Y == vector3?.Y && Z == vector3?.Z)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this Vector3.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float Length()
        {
            float ret = Interop.Vector3.Vector3_Length(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the vector squared.<br />
        /// This is more efficient than Length() for threshold
        /// testing as it avoids the use of a square root.<br />
        /// </summary>
        /// <returns>The length of the vector squared.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float LengthSquared()
        {
            float ret = Interop.Vector3.Vector3_LengthSquared(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the vector to be unit length, whilst maintaining its direction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Vector3.Vector3_Normalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Clamp(Vector3 min, Vector3 max)
        {
            Interop.Vector3.Vector3_Clamp(swigCPtr, Vector3.getCPtr(min), Vector3.getCPtr(max));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the x and y components (or width and height, or r and g) as a Vector2.
        /// </summary>
        /// <returns>The partial vector contents as Vector2 (x,y).</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetVectorXY()
        {
            Vector2 ret = new Vector2(Interop.Vector3.Vector3_GetVectorXY__SWIG_0(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the y and z components (or height and depth, or g and b) as a Vector2.
        /// </summary>
        /// <returns>The partial vector contents as Vector2 (y,z).</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetVectorYZ()
        {
            Vector2 ret = new Vector2(Interop.Vector3.Vector3_GetVectorYZ__SWIG_0(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector3 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Vector3 GetVector3FromPtr(global::System.IntPtr cPtr)
        {
            Vector3 ret = new Vector3(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Vector3.Vector3_AsFloat__SWIG_0(swigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.delete_Vector3(swigCPtr);
        }

        private Vector3 Add(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Add(swigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 AddAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_AddAssign(swigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Subtract(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Subtract__SWIG_0(swigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 SubtractAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_SubtractAssign(swigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Multiply__SWIG_0(swigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_MultiplyAssign__SWIG_0(swigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_MultiplyAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(Rotation rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_MultiplyAssign__SWIG_2(swigCPtr, Rotation.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Divide(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Divide__SWIG_0(swigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Divide(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 DivideAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_DivideAssign__SWIG_0(swigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 DivideAssign(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_DivideAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Subtract()
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector3 rhs)
        {
            bool ret = Interop.Vector3.Vector3_EqualTo(swigCPtr, Vector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector3 rhs)
        {
            bool ret = Interop.Vector3.Vector3_NotEqualTo(swigCPtr, Vector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.Vector3_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Dot(Vector3 other)
        {
            float ret = Interop.Vector3.Vector3_Dot(swigCPtr, Vector3.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 Cross(Vector3 other)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Vector3_Cross(swigCPtr, Vector3.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}