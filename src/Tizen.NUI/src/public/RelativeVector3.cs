/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
namespace Tizen.NUI
{

    /// <summary>
    /// RelativeVector3 is a three dimensional vector.
    /// All values(x, y, z and w) should be between [0, 1].
    /// </summary>
    public class RelativeVector3 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal RelativeVector3(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector3 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~RelativeVector3()
        {
            DisposeQueue.Instance.Add(this);
        }

        public virtual void Dispose()
        {
            if (!Stage.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_Vector3(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }


        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">Vector to add</param>
        /// <param name="arg2">Vector to add</param>
        /// <returns>A vector containing the result of the addition</returns>
        public static RelativeVector3 operator +(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1.Add(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">Vector to subtract</param>
        /// <param name="arg2">Vector to subtract</param>
        /// <returns>A vector containing the result of the subtraction</returns>
        public static RelativeVector3 operator -(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1.Subtract(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The vector to multiply</param>
        /// <returns>A vector containing the result of the multiplication</returns>
        public static RelativeVector3 operator *(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector3 operator *(RelativeVector3 arg1, float arg2)
        {
            RelativeVector3 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The vector to divide</param>
        /// <returns>A vector containing the result of the division</returns>
        public static RelativeVector3 operator /(RelativeVector3 arg1, RelativeVector3 arg2)
        {
            RelativeVector3 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The float value to scale the vector by</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector3 operator /(RelativeVector3 arg1, float arg2)
        {
            RelativeVector3 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }


        /// <summary>
        /// Const array subscript operator overload. Should be 0, 1 or 2.
        /// </summary>
        /// <param name="index">Subscript index</param>
        /// <returns>The float at the given index</returns>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// </summary>
        internal static RelativeVector3 GetRelativeVector3FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector3 ret = new RelativeVector3(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public RelativeVector3() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x component</param>
        /// <param name="y">y component</param>
        /// <param name="z">z component</param>
        public RelativeVector3(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true)
        {
            ValueCheck(x);
            ValueCheck(y);
            ValueCheck(z);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector2">RelativeVector2 to create this vector from</param>
        public RelativeVector3(RelativeVector2 relativeVector2) : this(NDalicPINVOKE.new_Vector3__SWIG_3(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector4">RelativeVector4 to create this vector from</param>
        public RelativeVector3(RelativeVector4 relativeVector4) : this(NDalicPINVOKE.new_Vector3__SWIG_4(RelativeVector4.getCPtr(relativeVector4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        private RelativeVector3 Add(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Add(swigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Subtract(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Subtract__SWIG_0(swigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Multiply(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Multiply__SWIG_0(swigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Multiply(float rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Divide(RelativeVector3 rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Divide__SWIG_0(swigCPtr, RelativeVector3.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector3 Divide(float rhs)
        {
            RelativeVector3 ret = new RelativeVector3(NDalicPINVOKE.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = NDalicPINVOKE.Vector3_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false</returns>
        public bool EqualTo(RelativeVector3 rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, RelativeVector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false</returns>
        public bool NotEqualTo(RelativeVector3 rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, RelativeVector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// x component
        /// </summary>
        public float X
        {
            set
            {
                ValueCheck(value);
                NDalicPINVOKE.Vector3_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_X_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// y component
        /// </summary>
        public float Y
        {
            set
            {
                ValueCheck(value);
                NDalicPINVOKE.Vector3_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// z component
        /// </summary>
        public float Z
        {
            set
            {
                 ValueCheck(value);
                NDalicPINVOKE.Vector3_Z_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Z_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// </summary>
        public static implicit operator Vector3(RelativeVector3 relativeVector3)
        {
            return new Vector3(relativeVector3.X, relativeVector3.Y, relativeVector3.Z);
        }

        /// <summary>
        /// </summary>
        public static implicit operator RelativeVector3(Vector3 vec)
        {
            ValueCheck(vec.X);
            ValueCheck(vec.Y);
            ValueCheck(vec.Z);
            return new RelativeVector3(vec.X, vec.Y, vec.Z);
        }

        internal static void ValueCheck(RelativeVector3 relativeVector3)
        {
            if(relativeVector3.X < 0.0f)
            {
                relativeVector3.X = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.X > 1.0f)
            {
                relativeVector3.X = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector3.Y < 0.0f)
            {
                relativeVector3.Y = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.Y > 1.0f)
            {
                relativeVector3.Y = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector3.Z < 0.0f)
            {
                relativeVector3.Z = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.Z > 1.0f)
            {
                relativeVector3.Z = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
        }

        internal static void ValueCheck(float value)
        {
            if(value < 0.0f)
            {
                value = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Parameters is invalid! Should be between [0, 1].");
            }
            else if(value > 1.0f)
            {
                value = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Parameters is invalid! Should be between [0, 1].");
            }
        }
    }

}


