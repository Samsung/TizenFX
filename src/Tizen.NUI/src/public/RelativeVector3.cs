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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{

    /// <summary>
    /// RelativeVector3 is a three-dimensional vector.
    /// All values (x, y, z and w) should be between [0, 1].
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [TypeConverter(typeof(RelativeVector3TypeConverter))]
    public class RelativeVector3 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>
        /// swigCMemOwn
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        /// <summary>
        /// A Flat to check if it is already disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool disposed = false;

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~RelativeVector3()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    NDalicPINVOKE.delete_Vector3(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
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
            RelativeVector3 result = arg1.Add(arg2);
            return ValueCheck(result);
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
            RelativeVector3 result = arg1.Subtract(arg2);
            return ValueCheck(result);
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
            RelativeVector3 result = arg1.Multiply(arg2);
            return ValueCheck(result);
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
            RelativeVector3 result = arg1.Multiply(arg2);
            return ValueCheck(result);
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
            RelativeVector3 result = arg1.Divide(arg2);
            return ValueCheck(result);
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
            RelativeVector3 result = arg1.Divide(arg2);
            return ValueCheck(result);
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
        /// </summary>
        internal static RelativeVector3 GetRelativeVector3FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector3 ret = new RelativeVector3(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
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
        public RelativeVector3(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(ValueCheck(x), ValueCheck(y), ValueCheck(z)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector2">The RelativeVector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector3(RelativeVector2 relativeVector2) : this(NDalicPINVOKE.new_Vector3__SWIG_3(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector4">The RelativeVector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
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
        /// Compares if the rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(RelativeVector3 rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, RelativeVector3.getCPtr(rhs));
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
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, RelativeVector3.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// The x component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            set
            {
                NDalicPINVOKE.Vector3_X_set(swigCPtr, ValueCheck(value));
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
        /// The y component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            set
            {
                NDalicPINVOKE.Vector3_Y_set(swigCPtr, ValueCheck(value));
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
        /// The z component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            set
            {
                NDalicPINVOKE.Vector3_Z_set(swigCPtr, ValueCheck(value));
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
            return new RelativeVector3(ValueCheck(vec.X), ValueCheck(vec.Y), ValueCheck(vec.Z));
        }

        internal static RelativeVector3 ValueCheck(RelativeVector3 relativeVector3)
        {
            if(relativeVector3.X < 0.0f)
            {
                relativeVector3.X = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.X > 1.0f)
            {
                relativeVector3.X = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector3.Y < 0.0f)
            {
                relativeVector3.Y = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.Y > 1.0f)
            {
                relativeVector3.Y = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector3.Z < 0.0f)
            {
                relativeVector3.Z = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector3.Z > 1.0f)
            {
                relativeVector3.Z = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            return relativeVector3;
        }

        internal static float ValueCheck(float value)
        {
            if(value < 0.0f)
            {
                value = 0.0f;
                NUILog.Error( "The value of Parameters is invalid! Should be between [0, 1].");
            }
            else if(value > 1.0f)
            {
                value = 1.0f;
                NUILog.Error( "The value of Parameters is invalid! Should be between [0, 1].");
            }
            return value;
        }
    }

}


