/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
    /// A two-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [TypeConverter(typeof(Vector2TypeConverter))]
    public class Vector2 : global::System.IDisposable
    {
        /// <summary>
        /// swigCMemOwn.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool swigCMemOwn;

        /// <summary>
        /// A Flat to check if it is already disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected bool disposed = false;
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;

        /// <summary>
        /// The default constructor initializes the vector to 0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2() : this(Interop.Vector2.new_Vector2__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x or width component.</param>
        /// <param name="y">The y or height component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(float x, float y) : this(Interop.Vector2.new_Vector2__SWIG_1(x, y), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The conversion constructor from an array of two floats.
        /// </summary>
        /// <param name="array">The array of xy.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(float[] array) : this(Interop.Vector2.new_Vector2__SWIG_2(array), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec3">Vector3 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(Vector3 vec3) : this(Interop.Vector2.new_Vector2__SWIG_3(Vector3.getCPtr(vec3)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="vec4">Vector4 to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Vector2(Vector4 vec4) : this(Interop.Vector2.new_Vector2__SWIG_4(Vector4.getCPtr(vec4)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal Vector2(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~Vector2()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// (1.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 One
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_ONE_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 XAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_XAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 YAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_YAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative x-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_NEGATIVE_XAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The vector representing the negative y-axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_NEGATIVE_YAXIS_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// (0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector2.Vector2_ZERO_get();
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The x component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            set
            {
                Interop.Vector2.Vector2_X_set(swigCPtr, value);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_X_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Width
        {
            set
            {
                Interop.Vector2.Vector2_Width_set(swigCPtr, value);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Width_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
                Interop.Vector2.Vector2_Y_set(swigCPtr, value);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Y_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Height
        {
            set
            {
                Interop.Vector2.Vector2_Height_set(swigCPtr, value);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Height_get(swigCPtr);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
        public static Vector2 operator +(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator -(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The target value.</param>
        /// <returns>The vector containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator -(Vector2 arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator *(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator *(Vector2 arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator /(Vector2 arg1, Vector2 arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector2 operator /(Vector2 arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Vector2 vector2 = obj as Vector2;
            bool equal = false;
            if (X == vector2?.X && Y == vector2?.Y)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this Vector2.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Returns the length of the vector.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float Length()
        {
            float ret = Interop.Vector2.Vector2_Length(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the vector squared.<br />
        /// This is more efficient than Length() for threshold
        /// testing as it avoids the use of a square root.<br />
        /// </summary>
        /// <returns>The length of the vector squared</returns>
        /// <since_tizen> 3 </since_tizen>
        public float LengthSquared()
        {
            float ret = Interop.Vector2.Vector2_LengthSquared(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the vector to be the unit length, whilst maintaining its direction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Vector2.Vector2_Normalize(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clamps the vector between minimum and maximum vectors.
        /// </summary>
        /// <param name="min">The minimum vector.</param>
        /// <param name="max">The maximum vector.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Clamp(Vector2 min, Vector2 max)
        {
            Interop.Vector2.Vector2_Clamp(swigCPtr, Vector2.getCPtr(min), Vector2.getCPtr(max));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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

        internal static Vector2 GetVector2FromPtr(global::System.IntPtr cPtr)
        {
            Vector2 ret = new Vector2(cPtr, false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Vector2 obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal SWIGTYPE_p_float AsFloat()
        {
            global::System.IntPtr cPtr = Interop.Vector2.Vector2_AsFloat__SWIG_0(swigCPtr);
            SWIGTYPE_p_float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
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
                    Interop.Vector2.delete_Vector2(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        private Vector2 Add(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Add(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 AddAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_AddAssign(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Subtract__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 SubtractAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_SubtractAssign(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Multiply__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Multiply(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_MultiplyAssign__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 MultiplyAssign(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_MultiplyAssign__SWIG_1(swigCPtr, rhs), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Divide__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Divide(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Divide__SWIG_1(swigCPtr, rhs), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(Vector2 rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_DivideAssign__SWIG_0(swigCPtr, Vector2.getCPtr(rhs)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 DivideAssign(float rhs)
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_DivideAssign__SWIG_1(swigCPtr, rhs), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector2 Subtract()
        {
            Vector2 ret = new Vector2(Interop.Vector2.Vector2_Subtract__SWIG_1(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Vector2 rhs)
        {
            bool ret = Interop.Vector2.Vector2_EqualTo(swigCPtr, Vector2.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Vector2 rhs)
        {
            bool ret = Interop.Vector2.Vector2_NotEqualTo(swigCPtr, Vector2.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector2.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

    }

}