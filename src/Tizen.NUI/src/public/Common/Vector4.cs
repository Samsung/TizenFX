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
    /// A four-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(Vector4TypeConverter))]
    public class Vector4 : Disposable, ICloneable
    {

        /// <summary>
        /// The default constructor initializes the vector to 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4() : this(Interop.Vector4.NewVector4(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of four floats.
        /// </summary>
        /// <param name="array">The array of either xyzw/rgba/stpq.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(float[] array) : this(Interop.Vector4.NewVector4(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from Vector2.
        /// </summary>
        /// <param name="vec2">Vector2 to copy from, z and w are initialized to 0.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(Vector2 vec2) : this(Interop.Vector4.NewVector4WithVector2(Vector2.getCPtr(vec2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from Vector3.
        /// </summary>
        /// <param name="vec3">Vector3 to copy from, w is initialized to 0.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector4(Vector3 vec3) : this(Interop.Vector4.NewVector4WithVector3(Vector3.getCPtr(vec3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Vector4(Vector4ChangedCallback cb, float x, float y, float z, float w) : this(Interop.Vector4.NewVector4(x, y, z, w), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal delegate void Vector4ChangedCallback(float x, float y, float z, float w);
        private Vector4ChangedCallback callback = null;

        /// <summary>
        /// (1.0f,1.0f,1.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 One
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector4.OneGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// (1.0f,0.0f,0.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 XAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector4.XaxisGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// (0.0f,1.0f,0.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 YAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector4.YaxisGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// (0.0f,0.0f,1.0f,0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 ZAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector4.ZaxisGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// (0.0f, 0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector4.ZeroGet();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.X = 0.1f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The red component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.R = 0.1f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float R
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.RSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.RGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The s component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.S = 0.1f; 
        /// // Please USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float S
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.SSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.SGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Y = 0.5f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The green component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.G = 0.5f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float G
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.GSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.GGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The t component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.T = 0.5f; 
        /// // Please USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float T
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.TSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.TGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Z = 0.9f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.ZSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.ZGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The blue component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.B = 0.9f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float B
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.BSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.BGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The p component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.P = 0.9f; 
        /// // Please USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float P
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.PSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.PGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The w component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.W = 1.0f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// Vector4 vector4 = new Vector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float W
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.WSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.WGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The alpha component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.A = 1.0f; 
        /// // Please USE like this
        /// float r = 0.1f, g = 0.5f, b = 0.9f, a = 1.0f;
        /// Vector4 vector4 = new Vector4(r, g, b, a);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float A
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.ASet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.AGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The q component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Vector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Vector4 vector4 = new Vector4();
        /// vector4.Q = 1.0f; 
        /// // Please USE like this
        /// float s = 0.1f, t = 0.5f, p = 0.9f, q = 1.0f;
        /// Vector4 vector4 = new Vector4(s, t, p, q);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Q
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Vector4(...) constructor")]
            set
            {
                Interop.Vector4.QSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, Z, W);
            }
            get
            {
                float ret = Interop.Vector4.QGet(SwigCPtr);
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
        public static Vector4 operator +(Vector4 arg1, Vector4 arg2)
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
        public static Vector4 operator -(Vector4 arg1, Vector4 arg2)
        {
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector4 operator -(Vector4 arg1)
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
        public static Vector4 operator *(Vector4 arg1, Vector4 arg2)
        {
            return arg1?.Multiply(arg2);
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Divide(arg2);
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
            return arg1?.Divide(arg2);
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
            float ret = Interop.Vector4.Length(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            float ret = Interop.Vector4.LengthSquared(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Normalizes the vector.<br />
        /// Sets the vector to unit length whilst maintaining its direction.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Vector4.Normalize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Clamp(Vector4 min, Vector4 max)
        {
            Interop.Vector4.Clamp(SwigCPtr, Vector4.getCPtr(min), Vector4.getCPtr(max));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Vector4(X, Y, Z, W);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector4 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Vector4 GetVector4FromPtr(global::System.IntPtr cPtr)
        {
            Vector4 ret = new Vector4(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Vector4.AsFloat(SwigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Dot(Vector3 other)
        {
            float ret = Interop.Vector4.DotWithVector3(SwigCPtr, Vector3.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Dot(Vector4 other)
        {
            float ret = Interop.Vector4.Dot(SwigCPtr, Vector4.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal float Dot4(Vector4 other)
        {
            float ret = Interop.Vector4.Dot4(SwigCPtr, Vector4.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 Cross(Vector4 other)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Cross(SwigCPtr, Vector4.getCPtr(other)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.DeleteVector4(swigCPtr);
        }

        private Vector4 Add(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Add(SwigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 AddAssign(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.AddAssign(SwigCPtr, Vector4.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Subtract(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Subtract(SwigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 SubtractAssign(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.SubtractAssign(SwigCPtr, Vector4.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Multiply(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Multiply(SwigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Multiply(float rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 MultiplyAssign(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.MultiplyAssign(SwigCPtr, Vector4.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 MultiplyAssign(float rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.MultiplyAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Divide(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Divide(SwigCPtr, Vector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Divide(float rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 DivideAssign(Vector4 rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.DivideAssign(SwigCPtr, Vector4.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 DivideAssign(float rhs)
        {
            Vector4 ret = new Vector4(Interop.Vector4.DivideAssign(SwigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector4 Subtract()
        {
            Vector4 ret = new Vector4(Interop.Vector4.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector4 rhs)
        {
            bool ret = Interop.Vector4.EqualTo(SwigCPtr, Vector4.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector4 rhs)
        {
            bool ret = Interop.Vector4.NotEqualTo(SwigCPtr, Vector4.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector4.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}
