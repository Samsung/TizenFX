/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
    /// RelativeVector4 is a four-dimensional vector.
    /// All values (x, y, and z) should be between [0, 1].
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(RelativeVector4TypeConverter))]
    public class RelativeVector4 : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4() : this(Interop.Vector4.NewVector4(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <param name="w">The w component.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4(float x, float y, float z, float w) : this(Interop.Vector4.NewVector4(x, y, z, w), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector2">The RelativeVector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4(RelativeVector2 relativeVector2) : this(Interop.Vector4.NewVector4WithVector2(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector3">The RelativeVector3 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4(RelativeVector3 relativeVector3) : this(Interop.Vector4.NewVector4WithVector3(RelativeVector3.getCPtr(relativeVector3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RelativeVector4(RelativeVector4ChangedCallback cb, float x, float y, float z, float w) : this(Interop.Vector4.NewVector4(x, y, z, w), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal delegate void RelativeVector4ChangedCallback(float x, float y, float z, float w);
        private RelativeVector4ChangedCallback callback = null;

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector4 relativeVector4 = new RelativeVector4();
        /// relativeVector4.X = 0.1f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// RelativeVector4 relativeVector4 = new RelativeVector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector4(...) constructor")]
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
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector4 relativeVector4 = new RelativeVector4();
        /// relativeVector4.Y = 0.5f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// RelativeVector4 relativeVector4 = new RelativeVector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector4(...) constructor")]
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
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector4 relativeVector4 = new RelativeVector4();
        /// relativeVector4.Z = 0.9f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// RelativeVector4 relativeVector4 = new RelativeVector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector4(...) constructor")]
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
        /// The w component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector4(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector4 relativeVector4 = new RelativeVector4();
        /// relativeVector4.W = 1.0f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f, w = 1.0f;
        /// RelativeVector4 relativeVector4 = new RelativeVector4(x, y, z, w);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float W
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector4(...) constructor")]
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
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator +(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1?.Add(arg2);
            return result;
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The vector to subtract.</param>
        /// <param name="arg2">The vector to subtract.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator -(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1?.Subtract(arg2);
            return result;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator *(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1?.Multiply(arg2);
            return result;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator *(RelativeVector4 arg1, float arg2)
        {
            RelativeVector4 result = arg1?.Multiply(arg2);
            return result;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The vector to divide.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator /(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1?.Divide(arg2);
            return result;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector4 operator /(RelativeVector4 arg1, float arg2)
        {
            RelativeVector4 result = arg1?.Divide(arg2);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector4(RelativeVector4 relativeVector4)
        {
            if (relativeVector4 == null)
            {
                return null;
            }
            return new Vector4(relativeVector4.X, relativeVector4.Y, relativeVector4.Z, relativeVector4.W);
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator RelativeVector4(Vector4 vec)
        {
            if (vec == null)
            {
                return null;
            }
            return new RelativeVector4(vec.X, vec.Y, vec.Z, vec.W);
        }

        /// <summary>
        /// The const array subscript operator overload. Should be 0, 1 3 or 3.
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
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            RelativeVector4 relativeVector4 = obj as RelativeVector4;
            bool equal = false;
            if (X == relativeVector4?.X && Y == relativeVector4?.Y && Z == relativeVector4?.Z && W == relativeVector4?.W)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this RelativeVector4.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if the rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(RelativeVector4 rhs)
        {
            bool ret = Interop.Vector4.EqualTo(SwigCPtr, RelativeVector4.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if the rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(RelativeVector4 rhs)
        {
            bool ret = Interop.Vector4.NotEqualTo(SwigCPtr, RelativeVector4.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// </summary>
        internal static RelativeVector4 GetRelativeVector4FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector4 ret = new RelativeVector4(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector4 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal RelativeVector4(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector4.DeleteVector4(swigCPtr);
        }

        private RelativeVector4 Add(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Add(SwigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Subtract(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Subtract(SwigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Multiply(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Multiply(SwigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Multiply(float rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Divide(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Divide(SwigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Divide(float rhs)
        {
            RelativeVector4 ret = new RelativeVector4(Interop.Vector4.Divide(SwigCPtr, rhs), true);
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
