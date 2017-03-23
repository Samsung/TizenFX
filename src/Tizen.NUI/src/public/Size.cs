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

namespace Tizen.NUI
{

    /// <summary>
    /// Three dimensional size
    /// </summary>
    public class Size : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Size(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Size obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~Size()
        {
            DisposeQueue.Instance.Add(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
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
        /// Addition operator for A+B
        /// </summary>
        /// <param name="arg1">Size, A</param>
        /// <param name="arg2">Size to assign, B</param>
        /// <returns>A Size containing the result of the addition</returns>
        public static Size operator +(Size arg1, Size arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator for A-B
        /// </summary>
        /// <param name="arg1">Size, A</param>
        /// <param name="arg2">Size to subtract, B</param>
        /// <returns>A Size containing the result of the subtraction</returns>
        public static Size operator -(Size arg1, Size arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// Unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation</param>
        /// <returns>A Size containg the negation</returns>
        public static Size operator -(Size arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication</param>
        /// <param name="arg2">The Size to multipl</param>
        /// <returns>A Size containing the result of the multiplication</returns>
        public static Size operator *(Size arg1, Size arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication</param>
        /// <param name="arg2">The float value to scale the Size</param>
        /// <returns>A Size containing the result of the scaling</returns>
        public static Size operator *(Size arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">Size for division</param>
        /// <param name="arg2">The Size to divide</param>
        /// <returns>A Size containing the result of the division></returns>
        public static Size operator /(Size arg1, Size arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">Size for division</param>
        /// <param name="arg2">The float value to scale the Size by</param>
        /// <returns>A Size containing the result of the scaling</returns>
        public static Size operator /(Size arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Array subscript operator.
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

        internal static Size GetSizeFromPtr(global::System.IntPtr cPtr)
        {
            Size ret = new Size(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Size() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">x (or width) component</param>
        /// <param name="y">y (or height) component</param>
        /// <param name="z">z (or depth) component</param>
        public Size(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size2d">Size2D with x (width) and y (height)</param>
        public Size(Size2D size2d) : this(NDalicPINVOKE.new_Vector3__SWIG_3(Size2D.getCPtr(size2d)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Zero constant, (0.0f, 0.0f, 0.0f).
        /// </summary>
        public static Size Zero
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZERO_get();
                Size ret = (cPtr == global::System.IntPtr.Zero) ? null : new Size(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Size Add(Size rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Add(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Subtract(Size rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Subtract__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Multiply(Size rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Multiply__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Multiply(float rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Divide(Size rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Divide__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Divide(float rhs)
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Subtract()
        {
            Size ret = new Size(NDalicPINVOKE.Vector3_Subtract__SWIG_1(swigCPtr), true);
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
        /// Check equality.
        /// Utilizes appropriate machine epsilon values.
        /// </summary>
        /// <param name="rhs">The Size to test against</param>
        /// <returns>True if the Sizes are equal</returns>
        public bool EqualTo(Size rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, Size.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Check inequality.
        /// Utilizes appropriate machine epsilon values.
        /// </summary>
        /// <param name="rhs">The Size to test against</param>
        /// <returns>True if the Sizes are not equal</returns>
        public bool NotEqualTo(Size rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, Size.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Width property for width component of Siz
        /// </summary>
        public float Width
        {
            set
            {
                NDalicPINVOKE.Vector3_Width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Height property for height component of Size
        /// </summary>
        public float Height
        {
            set
            {
                NDalicPINVOKE.Vector3_Height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Depth property for depth component of Size
        /// </summary>
        public float Depth
        {
            set
            {
                NDalicPINVOKE.Vector3_Depth_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Depth_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Type cast operator, Size to Vector3.
        /// </summary>
        /// <param name="size">Object of Size type</param>
        public static implicit operator Vector3(Size size)
        {
            return new Vector3(size.Width, size.Height, size.Depth);
        }

        /// <summary>
        /// Type cast operator, Vector3 to Size type.
        /// </summary>
        /// <param name="vec">Object of Vector3 type</param>
        public static implicit operator Size(Vector3 vec)
        {
            return new Size(vec.Width, vec.Height, vec.Depth);
        }

    }

}

