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
    /// A two dimensional size
    /// </summary>
    public class Size2D : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Size2D(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Size2D obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~Size2D()
        {
            DisposeQueue.Instance.Add(this);
        }

        /// <summary>
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
                        NDalicPINVOKE.delete_Vector2(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Addition operator.
        /// </summary>
        public static Size2D operator +(Size2D arg1, Size2D arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        public static Size2D operator -(Size2D arg1, Size2D arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// </summary>
        public static Size2D operator -(Size2D arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        public static Size2D operator *(Size2D arg1, Size2D arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        public static Size2D operator *(Size2D arg1, int arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        public static Size2D operator /(Size2D arg1, Size2D arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        public static Size2D operator /(Size2D arg1, int arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Array subscript operator.
        /// </summary>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        public static Size2D GetSize2DFromPtr(global::System.IntPtr cPtr)
        {
            Size2D ret = new Size2D(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Size2D() : this(NDalicPINVOKE.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Size2D(int x, int y) : this(NDalicPINVOKE.new_Vector2__SWIG_1((float)x, (float)y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Size2D(Size size) : this(NDalicPINVOKE.new_Vector2__SWIG_3(Size.getCPtr(size)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Size2D Add(Size2D rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Add(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Subtract(Size2D rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Subtract__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        private Size2D Multiply(Size2D rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Multiply__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Multiply(int rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Multiply__SWIG_1(swigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        private Size2D Divide(Size2D rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Divide__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Divide(int rhs)
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Divide__SWIG_1(swigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Subtract()
        {
            Size2D ret = new Size2D(NDalicPINVOKE.Vector2_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Check equality.
        /// Utilizes appropriate machine epsilon values.
        /// </summary>
        public bool EqualTo(Size2D rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, Size2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Check inequality.
        /// Utilizes appropriate machine epsilon values.
        /// </summary>
        public bool NotEqualTo(Size2D rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_NotEqualTo(swigCPtr, Size2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private int ValueOfIndex(uint index)
        {
            int ret = (int)NDalicPINVOKE.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// </summary>
        public int Width
        {
            set
            {
                NDalicPINVOKE.Vector2_Width_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (int)ret;
            }
        }

        /// <summary>
        /// </summary>
        public int Height
        {
            set
            {
                NDalicPINVOKE.Vector2_Height_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (int)ret;
            }
        }

        /// <summary>
        /// </summary>
        public static implicit operator Vector2(Size2D size)
        {
            return new Vector2((float)size.Width, (float)size.Height);
        }

        /// <summary>
        /// </summary>
        public static implicit operator Size2D(Vector2 vec)
        {
            return new Size2D((int)vec.X, (int)vec.Y);
        }

    }

}

