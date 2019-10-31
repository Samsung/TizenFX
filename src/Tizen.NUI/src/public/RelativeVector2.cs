/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// RelativeVector2 is a two-dimensional vector.
    /// Both values (x and y) should be between [0, 1].
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [TypeConverter(typeof(RelativeVector2TypeConverter))]
    public class RelativeVector2 : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2() : this(Interop.Vector2.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2(float x, float y) : this(Interop.Vector2.new_Vector2__SWIG_1(ValueCheck(x), ValueCheck(y)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector3">The RelativeVector3 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2(RelativeVector3 relativeVector3) : this(Interop.Vector2.new_Vector2__SWIG_3(RelativeVector3.getCPtr(relativeVector3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector4">The RelativeVector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector2(RelativeVector4 relativeVector4) : this(Interop.Vector2.new_Vector2__SWIG_4(RelativeVector4.getCPtr(relativeVector4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RelativeVector2(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            set
            {
                Interop.Vector2.Vector2_X_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_X_get(swigCPtr);
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
                Interop.Vector2.Vector2_Y_set(swigCPtr, ValueCheck(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector2 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator +(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Add(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The vector to subtract.</param>
        /// <param name="arg2">The vector to subtract.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator -(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Subtract(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator *(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator *(RelativeVector2 arg1, float arg2)
        {
            RelativeVector2 result = arg1.Multiply(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The vector to divide.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator /(RelativeVector2 arg1, RelativeVector2 arg2)
        {
            RelativeVector2 result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static RelativeVector2 operator /(RelativeVector2 arg1, float arg2)
        {
            RelativeVector2 result = arg1.Divide(arg2);
            return ValueCheck(result);
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector2(RelativeVector2 relativeVector2)
        {
            return new Vector2(relativeVector2.X, relativeVector2.Y);
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator RelativeVector2(Vector2 vec)
        {
            return new RelativeVector2(ValueCheck(vec.X), ValueCheck(vec.Y));
        }

        /// <summary>
        /// The const array subscript operator overload. Should be 0, 1.
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
            RelativeVector2 relativeRector2 = obj as RelativeVector2;
            bool equal = false;
            if (X == relativeRector2?.X && Y == relativeRector2?.Y)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this RelativeVector2.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if the rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(RelativeVector2 rhs)
        {
            bool ret = Interop.Vector2.Vector2_EqualTo(swigCPtr, RelativeVector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if the rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(RelativeVector2 rhs)
        {
            bool ret = Interop.Vector2.Vector2_NotEqualTo(swigCPtr, RelativeVector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// </summary>
        internal static RelativeVector2 GetRelativeVector2FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector2 ret = new RelativeVector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static RelativeVector2 ValueCheck(RelativeVector2 relativeVector2)
        {
            if (relativeVector2.X < 0.0f)
            {
                relativeVector2.X = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (relativeVector2.X > 1.0f)
            {
                relativeVector2.X = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            if (relativeVector2.Y < 0.0f)
            {
                relativeVector2.Y = 0.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            else if (relativeVector2.Y > 1.0f)
            {
                relativeVector2.Y = 1.0f;
                NUILog.Error("The value of Result is invalid! Should be between [0, 1].");
            }
            return relativeVector2;
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

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector2.delete_Vector2(swigCPtr);
        }

        private RelativeVector2 Add(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Add(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Subtract(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Subtract__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Multiply(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Multiply__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Multiply(float rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Divide(RelativeVector2 rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Divide__SWIG_0(swigCPtr, RelativeVector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector2 Divide(float rhs)
        {
            RelativeVector2 ret = new RelativeVector2(Interop.Vector2.Vector2_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector2.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}


