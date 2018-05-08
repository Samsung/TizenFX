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

using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    public class LayoutLength : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal LayoutLength(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LayoutLength obj)
        {
            return ( obj.Equals(null) ) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~LayoutLength()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock(this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        LayoutPINVOKE.delete_LayoutLength(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        public LayoutLength(int value) : this(LayoutPINVOKE.new_LayoutLength__SWIG_0(value), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public LayoutLength(LayoutLength layoutLength) : this(LayoutPINVOKE.new_LayoutLength__SWIG_1(LayoutLength.getCPtr(layoutLength)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLength operator +(LayoutLength arg1, LayoutLength arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the addition.</returns>
        public static LayoutLength operator +(LayoutLength arg1, int arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLength operator -(LayoutLength arg1, LayoutLength arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the subtraction.</returns>
        public static LayoutLength operator -(LayoutLength arg1, int arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the multiplication.</returns>
        public static LayoutLength operator *(LayoutLength arg1, LayoutLength arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Th multiplication operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the LayoutLength.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLength operator *(LayoutLength arg1, int arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The second value.</param>
        /// <returns>The LayoutLength containing the result of the division.</returns>
        public static LayoutLength operator /(LayoutLength arg1, LayoutLength arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Th division operator.
        /// </summary>
        /// <param name="arg1">The first value.</param>
        /// <param name="arg2">The int value to scale the vector by.</param>
        /// <returns>The LayoutLength containing the result of the scaling.</returns>
        public static LayoutLength operator /(LayoutLength arg1, int arg2)
        {
            return arg1.Divide(arg2);
        }

        public static bool operator ==(LayoutLength r1, LayoutLength r2)
        {
            return r1.EqualTo(r2);
        }

        public static bool operator !=(LayoutLength r1, LayoutLength r2)
        {
            return !r1.EqualTo(r2);
        }

        private bool EqualTo(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_EqualTo__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(int rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_EqualTo__SWIG_1(swigCPtr, rhs);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_NotEqualTo(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool LessThan(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_LessThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool GreaterThan(LayoutLength rhs)
        {
            bool ret = LayoutPINVOKE.LayoutLength_GreaterThan__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Add(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Add__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Add(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Add__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Subtract(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Subtract__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Subtract(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Subtract__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength AddAssign(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength AddAssign(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_AddAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength SubtractAssign(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength SubtractAssign(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_SubtractAssign__SWIG_1(swigCPtr, rhs), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Divide(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Divide__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Divide(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Multiply(LayoutLength rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_0(swigCPtr, LayoutLength.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Multiply(int rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private LayoutLength Multiply(float rhs)
        {
            LayoutLength ret = new LayoutLength(LayoutPINVOKE.LayoutLength_Multiply__SWIG_2(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float ConvertToFloat()
        {
            float ret = LayoutPINVOKE.LayoutLength_ConvertToFloat(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int Value
        {
            set
            {
                LayoutPINVOKE.LayoutLength_mValue_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = LayoutPINVOKE.LayoutLength_mValue_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
}
