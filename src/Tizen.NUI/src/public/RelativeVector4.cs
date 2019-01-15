/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
    /// RelativeVector4 is a four-dimensional vector.
    /// All values (x, y, and z) should be between [0, 1].
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [TypeConverter(typeof(RelativeVector4TypeConverter))]
    public class RelativeVector4 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>
        /// swigCMemOwn
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <summary>
        /// A Flat to check if it is already disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool disposed = false;

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~RelativeVector4()
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
                    NDalicPINVOKE.delete_Vector4(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
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
            RelativeVector4 result = arg1.Add(arg2);
            return ValueCheck(result);
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
            RelativeVector4 result = arg1.Subtract(arg2);
            return ValueCheck(result);
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
            RelativeVector4 result = arg1.Multiply(arg2);
            return ValueCheck(result);
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
            RelativeVector4 result = arg1.Multiply(arg2);
            return ValueCheck(result);
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
            RelativeVector4 result = arg1.Divide(arg2);
            return ValueCheck(result);
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
            RelativeVector4 result = arg1.Divide(arg2);
            return ValueCheck(result);
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
        /// </summary>
        internal static RelativeVector4 GetRelativeVector4FromPtr(global::System.IntPtr cPtr)
        {
            RelativeVector4 ret = new RelativeVector4(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4() : this(NDalicPINVOKE.new_Vector4__SWIG_0(), true)
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
        public RelativeVector4(float x, float y, float z, float w) : this(NDalicPINVOKE.new_Vector4__SWIG_1(ValueCheck(x), ValueCheck(y),ValueCheck(z), ValueCheck(w)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector2">The RelativeVector2 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public RelativeVector4(RelativeVector2 relativeVector2) : this(NDalicPINVOKE.new_Vector4__SWIG_3(RelativeVector2.getCPtr(relativeVector2)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="relativeVector3">The RelativeVector3 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the the hash code of this RelativeVector4.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override int GetHashCode()
        {
            return X.GetHashCode();
        }

        /// <summary>
        /// Compares if the rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(RelativeVector4 rhs)
        {
            bool ret = NDalicPINVOKE.Vector4_EqualTo(swigCPtr, RelativeVector4.getCPtr(rhs));
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
            bool ret = NDalicPINVOKE.Vector4_NotEqualTo(swigCPtr, RelativeVector4.getCPtr(rhs));
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
                NDalicPINVOKE.Vector4_X_set(swigCPtr, ValueCheck(value));
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
        /// The y component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            set
            {
                NDalicPINVOKE.Vector4_Y_set(swigCPtr, ValueCheck(value));
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
        /// The z component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            set
            {
                NDalicPINVOKE.Vector4_Z_set(swigCPtr, ValueCheck(value));
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
        /// The w component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float W
        {
            set
            {
                NDalicPINVOKE.Vector4_W_set(swigCPtr, ValueCheck(value));
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
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector4(RelativeVector4 relativeVector4)
        {
            return new Vector4(relativeVector4.X, relativeVector4.Y, relativeVector4.Z, relativeVector4.W);
        }

        /// <summary>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator RelativeVector4(Vector4 vec)
        {
            return new RelativeVector4(ValueCheck(vec.X), ValueCheck(vec.Y), ValueCheck(vec.Z), ValueCheck(vec.W));
        }

        internal static RelativeVector4 ValueCheck(RelativeVector4 relativeVector4)
        {
            if(relativeVector4.X < 0.0f)
            {
                relativeVector4.X = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.X > 1.0f)
            {
                relativeVector4.X = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.Y < 0.0f)
            {
                relativeVector4.Y = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.Y > 1.0f)
            {
                relativeVector4.Y = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.Z < 0.0f)
            {
                relativeVector4.Z = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.Z > 1.0f)
            {
                relativeVector4.Z = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            if(relativeVector4.W < 0.0f)
            {
                relativeVector4.W = 0.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            else if(relativeVector4.W > 1.0f)
            {
                relativeVector4.W = 1.0f;
                NUILog.Error( "The value of Result is invalid! Should be between [0, 1].");
            }
            return relativeVector4;
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


