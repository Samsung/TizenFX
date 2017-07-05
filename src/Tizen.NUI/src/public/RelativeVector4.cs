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
    /// RelativeVector4 is a four dimensional vector.
    /// All values(x, y, and z) should be between [0, 1].
    /// </summary>
    public class RelativeVector4 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal RelativeVector4(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RelativeVector4 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~RelativeVector4()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        public void Dispose()
        {
            //Throw excpetion if Dispose() is called in separate thread.
            if (!Window.IsInstalled())
            {
                throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
            }

            if (isDisposeQueued)
            {
                Dispose(DisposeTypes.Implicit);
            }
            else
            {
                Dispose(DisposeTypes.Explicit);
                System.GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Vector4(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }


        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">Vector to add</param>
        /// <param name="arg2">Vector to add</param>
        /// <returns>A vector containing the result of the addition</returns>
        public static RelativeVector4 operator +(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1.Add(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">Vector to subtract</param>
        /// <param name="arg2">Vector to subtract</param>
        /// <returns>A vector containing the result of the subtraction</returns>
        public static RelativeVector4 operator -(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1.Subtract(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The vector to multiply</param>
        /// <returns>A vector containing the result of the multiplication</returns>
        public static RelativeVector4 operator *(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector4 operator *(RelativeVector4 arg1, float arg2)
        {
            RelativeVector4 result = arg1.Multiply(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The vector to divide</param>
        /// <returns>A vector containing the result of the division</returns>
        public static RelativeVector4 operator /(RelativeVector4 arg1, RelativeVector4 arg2)
        {
            RelativeVector4 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The float value to scale the vector by</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static RelativeVector4 operator /(RelativeVector4 arg1, float arg2)
        {
            RelativeVector4 result = arg1.Divide(arg2);
            ValueCheck(result);
            return result;
        }


        /// <summary>
        /// Const array subscript operator overload. Should be 0, 1 3 or 3.
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
        internal static RelativeVector4 GetRelativeVector4FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector4 ret = new RelativeVector4(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public RelativeVector4() : this(NDalicPINVOKE.new_Vector4__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x component</param>
        /// <param name="y">y component</param>
        /// <param name="z">z component</param>
        /// <param name="w">w component</param>
        public RelativeVector4(float x, float y, float z, float w) : this(NDalicPINVOKE.new_Vector4__SWIG_1(x, y, z, w), true)
        {
            ValueCheck(x);
            ValueCheck(y);
            ValueCheck(z);
            ValueCheck(W);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector2">RelativeVector2 to create this vector from</param>
        public RelativeVector4(RelativeVector2 relativeVector2) : this(NDalicPINVOKE.new_Vector4__SWIG_3(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="relativeVector3">RelativeVector3 to create this vector from</param>
        public RelativeVector4(RelativeVector3 relativeVector3) : this(NDalicPINVOKE.new_Vector4__SWIG_4(RelativeVector3.getCPtr(relativeVector3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private RelativeVector4 Add(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Add(swigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Subtract(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Subtract__SWIG_0(swigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Multiply(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Multiply__SWIG_0(swigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Multiply(float rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Divide(RelativeVector4 rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Divide__SWIG_0(swigCPtr, RelativeVector4.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private RelativeVector4 Divide(float rhs)
        {
            RelativeVector4 ret = new RelativeVector4(NDalicPINVOKE.Vector4_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = NDalicPINVOKE.Vector4_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false</returns>
        public bool EqualTo(RelativeVector4 rhs)
        {
            bool ret = NDalicPINVOKE.Vector4_EqualTo(swigCPtr, RelativeVector4.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false</returns>
        public bool NotEqualTo(RelativeVector4 rhs)
        {
            bool ret = NDalicPINVOKE.Vector4_NotEqualTo(swigCPtr, RelativeVector4.getCPtr(rhs));
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
                NDalicPINVOKE.Vector4_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_X_get(swigCPtr);
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
                NDalicPINVOKE.Vector4_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_Y_get(swigCPtr);
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
                NDalicPINVOKE.Vector4_Z_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_Z_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// w component
        /// </summary>
        public float W
        {
            set
            {
                ValueCheck(value);
                NDalicPINVOKE.Vector4_W_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector4_W_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// </summary>
        public static implicit operator Vector4(RelativeVector4 relativeVector4)
        {
            return new Vector4(relativeVector4.X, relativeVector4.Y, relativeVector4.Z, relativeVector4.W);
        }

        /// <summary>
        /// </summary>
        public static implicit operator RelativeVector4(Vector4 vec)
        {
            ValueCheck(vec.X);
            ValueCheck(vec.Y);
            ValueCheck(vec.Z);
            ValueCheck(vec.W);
            return new RelativeVector4(vec.X, vec.Y, vec.Z, vec.W);
        }

        internal static void ValueCheck(RelativeVector4 relativeVector4)
        {
            if(relativeVector4.X < 0.0f)
            {
                relativeVector4.X = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.X > 1.0f)
            {
                relativeVector4.X = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.Y < 0.0f)
            {
                relativeVector4.Y = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.Y > 1.0f)
            {
                relativeVector4.Y = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.Z < 0.0f)
            {
                relativeVector4.Z = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.Z > 1.0f)
            {
                relativeVector4.Z = 1.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.W < 0.0f)
            {
                relativeVector4.W = 0.0f;
                Tizen.Log.Fatal("NUI", "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.W > 1.0f)
            {
                relativeVector4.W = 1.0f;
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


