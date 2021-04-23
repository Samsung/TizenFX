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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{

    /// <summary>
    /// A three-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(Vector3TypeConverter))]
    public class Vector3 : Disposable, ICloneable
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3() : this(Interop.Vector3.NewVector3(), true)
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
        public Vector3(float x, float y, float z) : this(Interop.Vector3.NewVector3(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Conversion constructor from an array of three floats.
        /// </summary>
        /// <param name="array">An array of xyz.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(float[] array) : this(Interop.Vector3.NewVector3(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec2">Vector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(Vector2 vec2) : this(Interop.Vector3.NewVector3WithVector2(Vector2.getCPtr(vec2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec4">Vector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector3(Vector4 vec4) : this(Interop.Vector3.NewVector3WithVector4(Vector4.getCPtr(vec4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Vector3(Vector3ChangedCallback cb, float x, float y, float z) : this(Interop.Vector3.NewVector3(x, y, z), true)
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
                global::System.IntPtr cPtr = Interop.Vector3.OneGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.XaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.YaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.ZaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.NegativeXaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.NegativeYaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.NegativeZaxisGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
                global::System.IntPtr cPtr = Interop.Vector3.ZeroGet();
                Vector3 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector3(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.X = 0.1f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// Vector3 vector3 = new Vector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The width component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.Width = 1.0f; 
        /// // Please USE like this
        /// float width = 1.0f, height = 2.0f, depth = 3.0f;
        /// Vector3 vector3 = new Vector3(width, height, depth);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Width
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.WidthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.WidthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.R = 0.1f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f;
        /// Vector3 vector3 = new Vector3(r, g, b);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.RSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.RGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.Y = 0.5f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// Vector3 vector3 = new Vector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The height component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.Height = 2.0f; 
        /// // Please USE like this
        /// float width = 1.0f, height = 2.0f, depth = 3.0f;
        /// Vector3 vector3 = new Vector3(width, height, depth);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Height
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.HeightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.HeightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.G = 0.5f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f;
        /// Vector3 vector3 = new Vector3(r, g, b);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.GSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.GGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.Z = 0.9f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// Vector3 vector3 = new Vector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.ZSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.ZGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The depth component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.Depth = 3.0f; 
        /// // Please USE like this
        /// float width = 1.0f, height = 2.0f, depth = 3.0f;
        /// Vector3 vector3 = new Vector3(width, height, depth);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Depth
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.DepthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.DepthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector3 vector3 = new Vector3();
        /// vector3.B = 0.9f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f;
        /// Vector3 vector3 = new Vector3(r, g, b);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector3(...) constructor")]
            set
            {
                Interop.Vector3.BSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.BGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
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
            return arg1?.Add(arg2);
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
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator -(Vector3 arg1)
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
        public static Vector3 operator *(Vector3 arg1, Vector3 arg2)
        {
            return arg1?.Multiply(arg2);
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Divide(arg2);
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
            return arg1?.Divide(arg2);
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
        /// Gets the hash code of this Vector3.
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
            float ret = Interop.Vector3.Length(SwigCPtr);
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
            float ret = Interop.Vector3.LengthSquared(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the vector to be unit length, whilst maintaining its direction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Vector3.Normalize(SwigCPtr);
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
            Interop.Vector3.Clamp(SwigCPtr, Vector3.getCPtr(min), Vector3.getCPtr(max));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the x and y components (or width and height, or r and g) as a Vector2.
        /// </summary>
        /// <returns>The partial vector contents as Vector2 (x,y).</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetVectorXY()
        {
            Vector2 ret = new Vector2(Interop.Vector3.GetVectorXY(SwigCPtr), false);
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
            Vector2 ret = new Vector2(Interop.Vector3.GetVectorYZ(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Vector3(X, Y, Z);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector3 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Vector3 GetVector3FromPtr(global::System.IntPtr cPtr)
        {
            Vector3 ret = new Vector3(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Vector3.AsFloat(SwigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.DeleteVector3(swigCPtr);
        }

        private Vector3 Add(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Add(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 AddAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.AddAssign(SwigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Subtract(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Subtract(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 SubtractAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.SubtractAssign(SwigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Multiply(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.MultiplyAssign(SwigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.MultiplyAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 MultiplyAssign(Rotation rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.MultiplyAssignQuaternion(SwigCPtr, Rotation.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Divide(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Divide(SwigCPtr, Vector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Divide(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 DivideAssign(Vector3 rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.DivideAssign(SwigCPtr, Vector3.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 DivideAssign(float rhs)
        {
            Vector3 ret = new Vector3(Interop.Vector3.DivideAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Subtract()
        {
            Vector3 ret = new Vector3(Interop.Vector3.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector3 rhs)
        {
            bool ret = Interop.Vector3.EqualTo(SwigCPtr, Vector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector3 rhs)
        {
            bool ret = Interop.Vector3.NotEqualTo(SwigCPtr, Vector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Dot(Vector3 other)
        {
            float ret = Interop.Vector3.Dot(SwigCPtr, Vector3.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 Cross(Vector3 other)
        {
            Vector3 ret = new Vector3(Interop.Vector3.Cross(SwigCPtr, Vector3.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
