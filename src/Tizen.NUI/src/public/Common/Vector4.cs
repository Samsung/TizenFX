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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{

    /// <summary>
    /// A four-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(Vector4TypeConverter))]
    public class Vector4 : Disposable, ICloneable
    {
        private static readonly Vector4 one = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private static readonly Vector4 zero = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        private static readonly Vector4 xaxis = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        private static readonly Vector4 yaxis = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
        private static readonly Vector4 zaxis = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);

        private struct XYZW
        {
            public float x;
            public float y;
            public float z;
            public float w;
        }

        private struct RGBA
        {
            public float r;
            public float g;
            public float b;
            public float a;
        }

        private struct STPQ
        {
            public float s;
            public float t;
            public float p;
            public float q;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct Union
        {
            [FieldOffset(0)] public XYZW xyzw;
            [FieldOffset(0)] public RGBA rgba;
            [FieldOffset(0)] public STPQ stpq;
        }

        private Union union;

        internal static new void Preload()
        {
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// The default constructor initializes the vector to 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4() : this(Interop.Vector4.NewVector4(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// The conversion constructor from four floats.
        /// </summary>
        /// <param name="x">The x (or r/s) component.</param>
        /// <param name="y">The y (or g/t) component.</param>
        /// <param name="z">The z (or b/p) component.</param>
        /// <param name="w">The w (or a/q) component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(float x, float y, float z, float w) : this(Interop.Vector4.NewVector4(x, y, z, w), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// The conversion constructor from an array of four floats.
        /// </summary>
        /// <param name="array">The array of either xyzw/rgba/stpq.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(float[] array) : this(Interop.Vector4.NewVector4(array), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// The conversion constructor from Vector2.
        /// </summary>
        /// <param name="vec2">Vector2 to copy from, z and w are initialized to 0.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(Vector2 vec2) : this(Interop.Vector4.NewVector4WithVector2(Vector2.getCPtr(vec2)), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// The conversion constructor from Vector3.
        /// </summary>
        /// <param name="vec3">Vector3 to copy from, w is initialized to 0.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(Vector3 vec3) : this(Interop.Vector4.NewVector4WithVector3(Vector3.getCPtr(vec3)), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal Vector4(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            union.xyzw.x = Interop.Vector4.XGet(SwigCPtr);
            union.xyzw.y = Interop.Vector4.YGet(SwigCPtr);
            union.xyzw.z = Interop.Vector4.ZGet(SwigCPtr);
            union.xyzw.w = Interop.Vector4.WGet(SwigCPtr);
        }

        internal Vector4(Vector4ChangedCallback cb, float x, float y, float z, float w) : this(Interop.Vector4.NewVector4(x, y, z, w), true)
        {
            callback = cb;
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
        internal delegate void Vector4ChangedCallback(float x, float y, float z, float w);
        private Vector4ChangedCallback callback = null;

        /// <summary>
        /// Returns a Vector2 instance where both the x and y components are set to 1.0f.
        /// Actual value is (1.0f,1.0f,1.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 One => one;

        /// <summary>
        /// The vector representing the x-axis.
        /// Actual value is (1.0f,0.0f,0.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 XAxis => xaxis;

        /// <summary>
        /// The vector representing the y-axis.
        /// Actual value is (0.0f,1.0f,0.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 YAxis => yaxis;

        /// <summary>
        /// The vector representing the z-axis.
        /// Actual value is (0.0f,0.0f,1.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 ZAxis => zaxis;
        /// <summary>
        /// A Vector2 object representing the zero vector.
        /// Actual value is (0.0f, 0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 Zero => zero;

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.X = 0.1f;
        /// // USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.xyzw.x = value;
                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                return union.xyzw.x;
            }
        }

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.R = 0.1f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.rgba.r = value;
                callback?.Invoke(R, G, B, A);
            }
            get
            {
                return union.rgba.r;
            }
        }

        /// <summary>
        /// The s component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.S = 0.1f;
        /// // USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float S
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.stpq.s = value;
                callback?.Invoke(S, T, P, Q);
            }
            get
            {
                return union.stpq.s;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Y = 0.5f;
        /// // USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.xyzw.y = value;
                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                return union.xyzw.y;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.G = 0.5f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.rgba.g = value;
                callback?.Invoke(R, G, B, A);
            }
            get
            {
                return union.rgba.g;
            }
        }

        /// <summary>
        /// The t component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.T = 0.5f;
        /// // USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float T
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.stpq.t = value;
                callback?.Invoke(S, T, P, Q);
            }
            get
            {
                return union.stpq.t;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Z = 0.9f;
        /// // USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.xyzw.z = value;
                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                return union.xyzw.z;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.B = 0.9f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.rgba.b = value;
                callback?.Invoke(R, G, B, A);
            }
            get
            {
                return union.rgba.b;
            }
        }

        /// <summary>
        /// The p component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.P = 0.9f;
        /// // USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float P
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.stpq.p = value;
                callback?.Invoke(S, T, P, Q);
            }
            get
            {
                return union.stpq.p;
            }
        }

        /// <summary>
        /// The w component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.W = 1.0f;
        /// // USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float W
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.xyzw.w = value;
                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                return union.xyzw.w;
            }
        }

        /// <summary>
        /// The alpha component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.A = 1.0f;
        /// // USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.rgba.a = value;
                callback?.Invoke(R, G, B, A);
            }
            get
            {
                return union.rgba.a;
            }
        }

        /// <summary>
        /// The q component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Q = 1.0f;
        /// // USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Q
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Vector4(...) constructor")]
            set
            {
                union.stpq.q = value;
                callback?.Invoke(S, T, P, Q);
            }
            get
            {
                return union.stpq.q;
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
                switch (index)
                {
                    case 0:
                        return union.xyzw.x;
                    case 1:
                        return union.xyzw.y;
                    case 2:
                        return union.xyzw.z;
                    case 3:
                        return union.xyzw.w;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator +(Vector4 arg1, Vector4 arg2)
        {
            if (arg1 == null || arg2 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg1.union.xyzw.x + arg2.union.xyzw.x;
            v4.union.xyzw.y = arg1.union.xyzw.y + arg2.union.xyzw.y;
            v4.union.xyzw.z = arg1.union.xyzw.z + arg2.union.xyzw.z;
            v4.union.xyzw.w = arg1.union.xyzw.w + arg2.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator -(Vector4 arg1, Vector4 arg2)
        {
            if (arg1 == null || arg2 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg1.union.xyzw.x - arg2.union.xyzw.x;
            v4.union.xyzw.y = arg1.union.xyzw.y - arg2.union.xyzw.y;
            v4.union.xyzw.z = arg1.union.xyzw.z - arg2.union.xyzw.z;
            v4.union.xyzw.w = arg1.union.xyzw.w - arg2.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator -(Vector4 arg1)
        {
            if (arg1 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = -arg1.union.xyzw.x;
            v4.union.xyzw.y = -arg1.union.xyzw.y;
            v4.union.xyzw.z = -arg1.union.xyzw.z;
            v4.union.xyzw.w = -arg1.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator *(Vector4 arg1, Vector4 arg2)
        {
            if (arg1 == null || arg2 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg1.union.xyzw.x * arg2.union.xyzw.x;
            v4.union.xyzw.y = arg1.union.xyzw.y * arg2.union.xyzw.y;
            v4.union.xyzw.z = arg1.union.xyzw.z * arg2.union.xyzw.z;
            v4.union.xyzw.w = arg1.union.xyzw.w * arg2.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator *(Vector4 arg1, float arg2)
        {
            if (arg1 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg2 * arg1.union.xyzw.x;
            v4.union.xyzw.y = arg2 * arg1.union.xyzw.y;
            v4.union.xyzw.z = arg2 * arg1.union.xyzw.z;
            v4.union.xyzw.w = arg2 * arg1.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator /(Vector4 arg1, Vector4 arg2)
        {
            if ((arg1 == null) || (arg2 == null))
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg1.union.xyzw.x / arg2.union.xyzw.x;
            v4.union.xyzw.y = arg1.union.xyzw.y / arg2.union.xyzw.y;
            v4.union.xyzw.z = arg1.union.xyzw.z / arg2.union.xyzw.z;
            v4.union.xyzw.w = arg1.union.xyzw.w / arg2.union.xyzw.w;
            return v4;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator /(Vector4 arg1, float arg2)
        {
            if (arg1 == null)
                return arg1;
            Vector4 v4 = new Vector4();
            v4.union.xyzw.x = arg1.union.xyzw.x / arg2;
            v4.union.xyzw.y = arg1.union.xyzw.y / arg2;
            v4.union.xyzw.z = arg1.union.xyzw.z / arg2;
            v4.union.xyzw.w = arg1.union.xyzw.w / arg2;
            return v4;
        }

        /// <summary>
        /// Converts the float value to Vector4 class implicitly.
        /// </summary>
        /// <param name="value">A float value to be converted to Vector4</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Vector4(float value)
        {
            return new Vector4(value, value, value, value);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Vector4 vector4 = obj as Vector4;
            bool equal = false;
            if (X == vector4?.X && Y == vector4?.Y && Z == vector4?.Z && W == vector4?.W)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Vector4.
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
        /// <returns>The length.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float Length()
        {
            float x = union.xyzw.x;
            float y = union.xyzw.y;
            float z = union.xyzw.z;
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Returns the length of the vector squared.<br />
        /// This is faster than using Length() when performing
        /// threshold checks as it avoids use of the square root.<br />
        /// </summary>
        /// <returns>The length of the vector squared.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float LengthSquared()
        {
            float x = union.xyzw.x;
            float y = union.xyzw.y;
            float z = union.xyzw.z;
            return x * x + y * y + z * z;
        }

        /// <summary>
        /// Normalizes the vector.<br />
        /// Sets the vector to unit length whilst maintaining its direction.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            if (Length() != 0)
            {
                float inverseLen = 1.0f / Length();
                union.xyzw.x *= inverseLen;
                union.xyzw.y *= inverseLen;
                union.xyzw.z *= inverseLen;
            }
        }

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Clamp(Vector4 min, Vector4 max)
        {
            if (min == null || max == null)
                return;
            float upper = union.xyzw.x < max.union.xyzw.x ? union.xyzw.x : max.union.xyzw.x;
            union.xyzw.x = upper > min.union.xyzw.x ? upper : min.union.xyzw.x;

            upper = union.xyzw.y < max.union.xyzw.y ? union.xyzw.y : max.union.xyzw.y;
            union.xyzw.y = upper > min.union.xyzw.y ? upper : min.union.xyzw.y;

            upper = union.xyzw.z < max.union.xyzw.z ? union.xyzw.z : max.union.xyzw.z;
            union.xyzw.z = upper > min.union.xyzw.z ? upper : min.union.xyzw.z;

            upper = union.xyzw.w < max.union.xyzw.w ? union.xyzw.w : max.union.xyzw.w;
            union.xyzw.w = upper > min.union.xyzw.w ? upper : min.union.xyzw.w;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Vector4(X, Y, Z, W);

        internal void Reset() => Reset(0, 0, 0, 0);

        internal void Reset(UIColor color) => Reset(color.R, color.G, color.B, color.A);

        internal void Reset(UICorner corner) => Reset(corner.TopLeft, corner.TopRight, corner.BottomRight, corner.BottomLeft);

        internal void Reset(float x, float y, float z, float w)
        {
            union.xyzw.x = x;
            union.xyzw.y = y;
            union.xyzw.z = z;
            union.xyzw.w = w;
        }

        internal static Vector4 GetVector4FromPtr(global::System.IntPtr cPtr)
        {
            Vector4 ret = new Vector4(cPtr, false);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        internal float Dot(Vector3 other)
        {
            float ret = union.xyzw.x * other.X + union.xyzw.y * other.Y + union.xyzw.z * other.Z;
            return ret;
        }

        internal float Dot(Vector4 other)
        {
            float ret = union.xyzw.x * other.X + union.xyzw.y * other.Y + union.xyzw.z * other.Z;
            return ret;
        }

        internal float Dot4(Vector4 other)
        {
            float ret = union.xyzw.x * other.X + union.xyzw.y * other.Y + union.xyzw.z * other.Z + union.xyzw.w * other.W;
            return ret;
        }

        internal Vector4 Cross(Vector4 other)
        {
            Vector4 ret = new Vector4();
            ret.union.xyzw.x = union.xyzw.y * other.union.xyzw.z - union.xyzw.z * other.union.xyzw.y;
            ret.union.xyzw.y = union.xyzw.z * other.union.xyzw.x - union.xyzw.x * other.union.xyzw.z;
            ret.union.xyzw.z = union.xyzw.x * other.union.xyzw.y - union.xyzw.y * other.union.xyzw.x;
            ret.union.xyzw.w = 0.0f;
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.DeleteVector4(swigCPtr);
        }
    }
}
