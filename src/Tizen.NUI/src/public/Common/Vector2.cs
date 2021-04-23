/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{

    /// <summary>
    /// A two-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(Vector2TypeConverter))]
    public class Vector2 : Disposable, ICloneable
    {

        /// <summary>
        /// The default constructor initializes the vector to 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2() : this(Interop.Vector2.NewVector2(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x or width component.</param>
        /// <param name="y">The y or height component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(float x, float y) : this(Interop.Vector2.NewVector2(x, y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of two floats.
        /// </summary>
        /// <param name="array">The array of xy.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(float[] array) : this(Interop.Vector2.NewVector2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="other">The copy target.</param>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2(Vector2 other) : this(other == null ? throw new ArgumentNullException(nameof(other)) : other.X, other.Y)
        {
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec3">Vector3 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(Vector3 vec3) : this(Interop.Vector2.NewVector2WithVector3(Vector3.getCPtr(vec3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec4">Vector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(Vector4 vec4) : this(Interop.Vector2.NewVector2WithVector4(Vector4.getCPtr(vec4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Vector2(Vector2ChangedCallback cb, float x, float y) : this(Interop.Vector2.NewVector2(x, y), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2(Vector2ChangedCallback cb, Vector2 other) : this(cb, other.X, other.Y)
        {
        }

        internal delegate void Vector2ChangedCallback(float x, float y);
        private Vector2ChangedCallback callback = null;

        /// <summary>
        /// (1.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 One
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.OneGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 XAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.XaxisGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 YAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.YaxisGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.NegativeXaxisGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.NegativeYaxisGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// (0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.ZeroGet();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector2(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector2 vector2 = new Vector2();
        /// vector2.X = 0.1f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f;
        /// Vector2 vector2 = new Vector2(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector2(...) constructor")]
            set
            {
                Interop.Vector2.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The width.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector2(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector2 vector2 = new Vector2();
        /// vector2.Width = 1.0f; 
        /// // Please USE like this
        /// float width = 1.0f, height = 2.0f;
        /// Vector2 vector2 = new Vector2(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Width
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector2(...) constructor")]
            set
            {
                Interop.Vector2.WidthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.WidthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector2(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector2 vector2 = new Vector2();
        /// vector2.Y = 0.5f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f;
        /// Vector2 vector2 = new Vector2(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector2(...) constructor")]
            set
            {
                Interop.Vector2.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The height.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector2(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector2 vector2 = new Vector2();
        /// vector2.Height = 2.0f; 
        /// // Please USE like this
        /// float width = 1.0f, height = 2.0f;
        /// Vector2 vector2 = new Vector2(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Height
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector2(...) constructor")]
            set
            {
                Interop.Vector2.HeightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.HeightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator +(Vector2 arg1, Vector2 arg2)
        {
            return arg1?.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator -(Vector2 arg1, Vector2 arg2)
        {
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator -(Vector2 arg1)
        {
            return arg1?.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator *(Vector2 arg1, Vector2 arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator *(Vector2 arg1, float arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator /(Vector2 arg1, Vector2 arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator /(Vector2 arg1, float arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Vector2 vector2 = obj as Vector2;
            bool equal = false;
            if (X == vector2?.X && Y == vector2?.Y)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Vector2.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float Length()
        {
            float ret = Interop.Vector2.Length(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the vector squared.<br />
        /// This is more efficient than Length() for threshold
        /// testing as it avoids the use of a square root.<br />
        /// </summary>
        /// <returns>The length of the vector squared</returns>
        /// <since_tizen> 3 </since_tizen>
        public float LengthSquared()
        {
            float ret = Interop.Vector2.LengthSquared(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the vector to be the unit length, whilst maintaining its direction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Vector2.Normalize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Vector2(this);

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Clamp(Vector2 min, Vector2 max)
        {
            Interop.Vector2.Clamp(SwigCPtr, Vector2.getCPtr(min), Vector2.getCPtr(max));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static Vector2 GetVector2FromPtr(global::System.IntPtr cPtr)
        {
            Vector2 ret = new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector2 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Vector2.AsFloat(SwigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector2.DeleteVector2(swigCPtr);
        }

        private Vector2 Add(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Add(SwigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 AddAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.AddAssign(SwigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Subtract(SwigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 SubtractAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.SubtractAssign(SwigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Multiply(SwigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.MultiplyAssign(SwigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.MultiplyAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Divide(SwigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.DivideAssign(SwigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.DivideAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract()
        {
            Vector2 ret = new Vector2(Interop.Vector2.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector2 rhs)
        {
            bool ret = Interop.Vector2.EqualTo(SwigCPtr, Vector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector2 rhs)
        {
            bool ret = Interop.Vector2.NotEqualTo(SwigCPtr, Vector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector2.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
