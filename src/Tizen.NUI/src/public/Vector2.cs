/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{

    /// <summary>
    /// A two dimensional vector.
    /// </summary>
    public class Vector2 : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Vector2(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector2 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Vector2()
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
                    NDalicPINVOKE.delete_Vector2(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">First value</param>
        /// <param name="arg2">Second value</param>
        /// <returns>A vector containing the result of the addition</returns>
        public static Vector2 operator +(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">First value</param>
        /// <param name="arg2">Second value</param>
        /// <returns>A vector containing the result of the subtraction</returns>
        public static Vector2 operator -(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// Unary negation operator.
        /// </summary>
        /// <param name="arg1">Target Value</param>
        /// <returns>A vector containg the negation</returns>
        public static Vector2 operator -(Vector2 arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">First Value</param>
        /// <param name="arg2">Second Value</param>
        /// <returns>A vector containing the result of the multiplication</returns>
        public static Vector2 operator *(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">First Value</param>
        /// <param name="arg2">The float value to scale the vector</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static Vector2 operator *(Vector2 arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">First Value</param>
        /// <param name="arg2">Second Value</param>
        /// <returns>A vector containing the result of the division</returns>
        public static Vector2 operator /(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">First Value</param>
        /// <param name="arg2">The float value to scale the vector by</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static Vector2 operator /(Vector2 arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Array subscript operator overload.
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

        internal static Vector2 GetVector2FromPtr(global::System.IntPtr cPtr)
        {
            Vector2 ret = new Vector2(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Default constructor, initializes the vector to 0.
        /// </summary>
        public Vector2() : this(NDalicPINVOKE.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">x or width component</param>
        /// <param name="y">y or height component</param>
        public Vector2(float x, float y) : this(NDalicPINVOKE.new_Vector2__SWIG_1(x, y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Conversion constructor from an array of two floats.
        /// </summary>
        /// <param name="array">Array of xy</param>
        public Vector2(float[] array) : this(NDalicPINVOKE.new_Vector2__SWIG_2(array), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vec3">Vector3 to create this vector from</param>
        public Vector2(Vector3 vec3) : this(NDalicPINVOKE.new_Vector2__SWIG_3(Vector3.getCPtr(vec3)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vec4">Vector4 to create this vector from</param>
        public Vector2(Vector4 vec4) : this(NDalicPINVOKE.new_Vector2__SWIG_4(Vector4.getCPtr(vec4)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// (1.0f,1.0f)
        /// </summary>
        public static Vector2 One
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_ONE_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Vector representing the X axis
        /// </summary>
        public static Vector2 XAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_XAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Vector representing the Y axis
        /// </summary>
        public static Vector2 YAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_YAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Vector representing the negative X axis
        /// </summary>
        public static Vector2 NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_NEGATIVE_XAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Vector representing the negative Y axis
        /// </summary>
        public static Vector2 NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_NEGATIVE_YAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// (0.0f, 0.0f)
        /// </summary>
        public static Vector2 Zero
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_ZERO_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 Add(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Add(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 AddAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_AddAssign(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Subtract__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 SubtractAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_SubtractAssign(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Multiply__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(float rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_MultiplyAssign__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(float rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_MultiplyAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Divide__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(float rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_DivideAssign__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(float rhs)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_DivideAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Vector2_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector2 rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, Vector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector2 rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_NotEqualTo(swigCPtr, Vector2.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = NDalicPINVOKE.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <returns>The length of the vector</returns>
        public float Length()
        {
            float ret = NDalicPINVOKE.Vector2_Length(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the vector squared.<br>
        /// This is more efficient than Length() for threshold
        /// testing as it avoids the use of a square root.<br>
        /// </summary>
        /// <returns>The length of the vector squared</returns>
        public float LengthSquared()
        {
            float ret = NDalicPINVOKE.Vector2_LengthSquared(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the vector to be unit length, whilst maintaining its direction.
        /// </summary>
        public void Normalize()
        {
            NDalicPINVOKE.Vector2_Normalize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector</param>
        /// <param name="max">The maximum vector</param>
        public void Clamp(Vector2 min, Vector2 max)
        {
            NDalicPINVOKE.Vector2_Clamp(swigCPtr, Vector2.getCPtr(min), Vector2.getCPtr(max));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = NDalicPINVOKE.Vector2_AsFloat__SWIG_0(swigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
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
                NDalicPINVOKE.Vector2_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_X_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// width
        /// </summary>
        public float Width
        {
            set
            {
                NDalicPINVOKE.Vector2_Width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Width_get(swigCPtr);
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
                NDalicPINVOKE.Vector2_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// height
        /// </summary>
        public float Height
        {
            set
            {
                NDalicPINVOKE.Vector2_Height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

    }

}
