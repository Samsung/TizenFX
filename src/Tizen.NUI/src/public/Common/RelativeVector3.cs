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
    /// RelativeVector3 is a three-dimensional vector.
    /// All values (x, y, z and w) should be between [0, 1].
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(RelativeVector3TypeConverter))]
    public class RelativeVector3 : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3() : this(Interop.Vector3.NewVector3(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3(float x, float y, float z) : this(Interop.Vector3.NewVector3(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector2">The RelativeVector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3(RelativeVector2 relativeVector2) : this(Interop.Vector3.NewVector3WithVector2(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector4">The RelativeVector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3(RelativeVector4 relativeVector4) : this(Interop.Vector3.NewVector3WithVector4(RelativeVector4.getCPtr(relativeVector4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector3 relativeVector3 = new RelativeVector3();
        /// relativeVector3.X = 0.1f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// RelativeVector3 relativeVector3 = new RelativeVector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector3(...) constructor")]
            set
            {
                Interop.Vector3.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector3.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector3 relativeVector3 = new RelativeVector3();
        /// relativeVector3.Y = 0.5f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// RelativeVector3 relativeVector3 = new RelativeVector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector3(...) constructor")]
            set
            {
                Interop.Vector3.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector3.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new RelativeVector3(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// RelativeVector3 relativeVector3 = new RelativeVector3();
        /// relativeVector3.Z = 0.9f; 
        /// // Please USE like this
        /// float x = 0.1f, y = 0.5f, z = 0.9f;
        /// RelativeVector3 relativeVector3 = new RelativeVector3(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new RelativeVector3(...) constructor")]
            set
            {
                Interop.Vector3.ZSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector3.ZGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">Th vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator +(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1?.Add(arg2);
            return result;
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The vector to subtract.</param>
        /// <param name="arg2">The vector to subtract.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator -(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1?.Subtract(arg2);
            return result;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator *(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1?.Multiply(arg2);
            return result;
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator *(RelativeVector3 arg1, float arg2)
        {
            RelativeVector3 result = arg1?.Multiply(arg2);
            return result;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The vector to divide.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator /(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1?.Divide(arg2);
            return result;
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector3 operator /(RelativeVector3 arg1, float arg2)
        {
            RelativeVector3 result = arg1?.Divide(arg2);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector3(RelativeVector3 relativeVector3)
        {
            return new Vector3(relativeVector3.X, relativeVector3.Y, relativeVector3.Z);
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator RelativeVector3(Vector3 vec)
        {
            return new RelativeVector3(vec.X, vec.Y, vec.Z);
        }

        /// <summary>
        /// The const array subscript operator overload. Should be 0, 1 or 2.
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
            RelativeVector3 relativeVector3 = obj as RelativeVector3;
            bool equal = false;
            if (X == relativeVector3?.X && Y == relativeVector3?.Y && Z == relativeVector3?.Z)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this RelativeVector3.
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
        public bool EqualTo(RelativeVector3 rhs)
        {
            bool ret = Interop.Vector3.EqualTo(SwigCPtr, RelativeVector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if the rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(RelativeVector3 rhs)
        {
            bool ret = Interop.Vector3.NotEqualTo(SwigCPtr, RelativeVector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// </summary>
        internal static RelativeVector3 GetRelativeVector3FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector3 ret = new RelativeVector3(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector3 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal RelativeVector3(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.DeleteVector3(swigCPtr);
        }

        private RelativeVector3 Add(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Add(SwigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Subtract(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Subtract(SwigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Multiply(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Multiply(SwigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Multiply(float rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Divide(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Divide(SwigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Divide(float rhs)
        {
            RelativeVector3 ret = new RelativeVector3(Interop.Vector3.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }

}
