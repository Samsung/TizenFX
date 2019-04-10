/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    /// The Rotation class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [TypeConverter(typeof(RotationTypeConverter))]
    public class Rotation : global::System.IDisposable
    {
        /// <summary>
        /// swigCMemOwn
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
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rotation() : this(Interop.Rotation.new_Rotation__SWIG_0(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor from an axis and angle.
        /// </summary>
        /// <param name="angle">The angle around the axis.</param>
        /// <param name="axis">The vector of the axis.</param>
        /// <since_tizen> 3 </since_tizen>
        public Rotation(Radian angle, Vector3 axis) : this(Interop.Rotation.new_Rotation__SWIG_1(Radian.getCPtr(angle), Vector3.getCPtr(axis)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~Rotation()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// (0.0f,0.0f,0.0f,1.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation IDENTITY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Rotation.Rotation_IDENTITY_get();
                Rotation ret = (cPtr == global::System.IntPtr.Zero) ? null : new Rotation(cPtr, false);
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first rotation.</param>
        /// <param name="arg2">The second rotation.</param>
        /// <returns>The rotation containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator +(Rotation arg1, Rotation arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first rotation.</param>
        /// <param name="arg2">The second rotation.</param>
        /// <returns>The rotation containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator -(Rotation arg1, Rotation arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The first rotation.</param>
        /// <returns>The rotation containing the negated result.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator -(Rotation arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first rotation.</param>
        /// <param name="arg2">The second rotation.</param>
        /// <returns>The rotation containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator *(Rotation arg1, Rotation arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">Rotation.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The rotation containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Vector3 operator *(Rotation arg1, Vector3 arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The scale operator.
        /// </summary>
        /// <param name="arg1">Rotation.</param>
        /// <param name="arg2">A value to scale by.</param>
        /// <returns>The rotation containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator *(Rotation arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first rotation.</param>
        /// <param name="arg2">The second rotation.</param>
        /// <returns>The rotation containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator /(Rotation arg1, Rotation arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The scale operator.
        /// </summary>
        /// <param name="arg1">Rotation.</param>
        /// <param name="arg2">A value to scale by.</param>
        /// <returns>The rotation containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation operator /(Rotation arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Returns the dot product of two rotations.
        /// </summary>
        /// <param name="q1">The first rotation.</param>
        /// <param name="q2">The second rotation.</param>
        /// <returns>The dot product of the two rotations.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static float Dot(Rotation q1, Rotation q2)
        {
            float ret = Interop.Rotation.Rotation_Dot(Rotation.getCPtr(q1), Rotation.getCPtr(q2));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The linear iterpolation (using a straight line between the two rotations).
        /// </summary>
        /// <param name="q1">The start rotation.</param>
        /// <param name="q2">The end rotation.</param>
        /// <param name="t">A progress value between 0 and 1.</param>
        /// <returns>The interpolated rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation Lerp(Rotation q1, Rotation q2, float t)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Lerp(Rotation.getCPtr(q1), Rotation.getCPtr(q2), t), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The spherical linear interpolation (using the shortest arc of a great circle between the two rotations).
        /// </summary>
        /// <param name="q1">The start rotation.</param>
        /// <param name="q2">The end rotation.</param>
        /// <param name="progress">A progress value between 0 and 1.</param>
        /// <returns>The interpolated rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation Slerp(Rotation q1, Rotation q2, float progress)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Slerp(Rotation.getCPtr(q1), Rotation.getCPtr(q2), progress), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// This version of slerp, used by squad, does not check for theta > 90.
        /// </summary>
        /// <param name="q1">The start rotation.</param>
        /// <param name="q2">The end rotation.</param>
        /// <param name="t">A progress value between 0 and 1.</param>
        /// <returns>The interpolated rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation SlerpNoInvert(Rotation q1, Rotation q2, float t)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_SlerpNoInvert(Rotation.getCPtr(q1), Rotation.getCPtr(q2), t), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The spherical cubic interpolation.
        /// </summary>
        /// <param name="start">The start rotation.</param>
        /// <param name="end">The end rotation.</param>
        /// <param name="ctrl1">The control rotation for q1.</param>
        /// <param name="ctrl2">The control rotation for q2.</param>
        /// <param name="t">A progress value between 0 and 1.</param>
        /// <returns>The interpolated rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Rotation Squad(Rotation start, Rotation end, Rotation ctrl1, Rotation ctrl2, float t)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Squad(Rotation.getCPtr(start), Rotation.getCPtr(end), Rotation.getCPtr(ctrl1), Rotation.getCPtr(ctrl2), t), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the shortest angle between two rotations in radians.
        /// </summary>
        /// <param name="q1">The first rotation.</param>
        /// <param name="q2">The second rotation.</param>
        /// <returns>The angle between the two rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static float AngleBetween(Rotation q1, Rotation q2)
        {
            float ret = Interop.Rotation.Rotation_AngleBetween(Rotation.getCPtr(q1), Rotation.getCPtr(q2));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make the Rotation instance be disposed.
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
        /// Helper to check if this is an identity quaternion.
        /// </summary>
        /// <returns>True if this is identity quaternion.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsIdentity()
        {
            bool ret = Interop.Rotation.Rotation_IsIdentity(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts the quaternion to an axis or angle pair.
        /// </summary>
        /// <param name="axis">The result of an an axis.</param>
        /// <param name="angle">The result of angle in radians.</param>
        /// <returns>True if converted correctly.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GetAxisAngle(Vector3 axis, Radian angle)
        {
            bool ret = Interop.Rotation.Rotation_GetAxisAngle(swigCPtr, Vector3.getCPtr(axis), Radian.getCPtr(angle));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the length of the rotation.
        /// </summary>
        /// <returns>The length of the rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float Length()
        {
            float ret = Interop.Rotation.Rotation_Length(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the squared length of the rotation.
        /// </summary>
        /// <returns>The squared length of the rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float LengthSquared()
        {
            float ret = Interop.Rotation.Rotation_LengthSquared(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Normalizes this to unit length.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Normalize()
        {
            Interop.Rotation.Rotation_Normalize(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Normalized.
        /// </summary>
        /// <returns>A normalized version of this rotation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Normalized()
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Normalized(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Conjugates this rotation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Conjugate()
        {
            Interop.Rotation.Rotation_Conjugate(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inverts this rotation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Invert()
        {
            Interop.Rotation.Rotation_Invert(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Performs the logarithm of a rotation.
        /// </summary>
        /// <returns>The rotation representing the logarithm.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Log()
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Log(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Performs an exponent.
        /// </summary>
        /// <returns>The rotation representing the exponent.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Exp()
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Exp(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Rotation obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Rotation(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
                    Interop.Rotation.delete_Rotation(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

        private Rotation Add(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Add(swigCPtr, Rotation.getCPtr(other)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Subtract(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Subtract__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Multiply(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Multiply__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Vector3 Multiply(Vector3 other)
        {
            Vector3 ret = new Vector3(Interop.Rotation.Rotation_Multiply__SWIG_1(swigCPtr, Vector3.getCPtr(other)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Divide(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Divide__SWIG_0(swigCPtr, Rotation.getCPtr(other)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Multiply(float scale)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Multiply__SWIG_2(swigCPtr, scale), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Divide(float scale)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Divide__SWIG_1(swigCPtr, scale), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation Subtract()
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_Subtract__SWIG_1(swigCPtr), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation AddAssign(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_AddAssign(swigCPtr, Rotation.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation SubtractAssign(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_SubtractAssign(swigCPtr, Rotation.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation MultiplyAssign(Rotation other)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_MultiplyAssign__SWIG_0(swigCPtr, Rotation.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation MultiplyAssign(float scale)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_MultiplyAssign__SWIG_1(swigCPtr, scale), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private Rotation DivideAssign(float scale)
        {
            Rotation ret = new Rotation(Interop.Rotation.Rotation_DivideAssign(swigCPtr, scale), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Rotation rhs)
        {
            bool ret = Interop.Rotation.Rotation_EqualTo(swigCPtr, Rotation.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Rotation rhs)
        {
            bool ret = Interop.Rotation.Rotation_NotEqualTo(swigCPtr, Rotation.getCPtr(rhs));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}