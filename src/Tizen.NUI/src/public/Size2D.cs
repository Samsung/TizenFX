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

        //NUI Dispose Pattern written by Jinwoo Nam(jjw.nam) 

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;
        //A Flat to check if it is already disposed.
        protected bool disposed = false;

        ~Size2D()
        {
            if(!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
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
        /// Addition operator for A+B
        /// </summary>
        /// <param name="arg1">Size, A</param>
        /// <param name="arg2">Size to assign, B</param>
        /// <returns>A Size containing the result of the addition</returns>
        public static Size2D operator +(Size2D arg1, Size2D arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator for A-B
        /// </summary>
        /// <param name="arg1">Size, A</param>
        /// <param name="arg2">Size to subtract, B</param>
        /// <returns>A Size containing the result of the subtraction</returns>
        public static Size2D operator -(Size2D arg1, Size2D arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// Unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation</param>
        /// <returns>A Size containg the negation</returns>
        public static Size2D operator -(Size2D arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication</param>
        /// <param name="arg2">The Size to multipl</param>
        /// <returns>A Size containing the result of the multiplication</returns>
        public static Size2D operator *(Size2D arg1, Size2D arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication</param>
        /// <param name="arg2">The int value to scale the Size</param>
        /// <returns>A Size containing the result of the scaling</returns>

        public static Size2D operator *(Size2D arg1, int arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">Size for division</param>
        /// <param name="arg2">The Size to divide</param>
        /// <returns>A Size containing the result of the division></returns>
        public static Size2D operator /(Size2D arg1, Size2D arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">Size for division</param>
        /// <param name="arg2">The int value to scale the Size by</param>
        /// <returns>A Size containing the result of the scaling</returns>
        public static Size2D operator /(Size2D arg1, int arg2)
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

        /// <summary>
        /// Get Size from pointer.
        /// </summary>
        /// <param name="cPtr">Pointer of the Size</param>
        /// <returns>Size</returns>
        internal static Size2D GetSize2DFromPtr(global::System.IntPtr cPtr)
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
        /// <param name="x">x (or width) component</param>
        /// <param name="y">y (or height) component</param>
        public Size2D(int x, int y) : this(NDalicPINVOKE.new_Vector2__SWIG_1((float)x, (float)y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size">Size with x (width), y (height), and z (depth)</param>
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
        /// Check equality.<br>
        /// Utilizes appropriate machine epsilon values.<br>
        /// </summary>
        /// <param name="rhs">The Size to test against</param>
        /// <returns>True if the Sizes are equal</returns>
        public bool EqualTo(Size2D rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, Size2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Check inequality.<br>
        /// Utilizes appropriate machine epsilon values.<br>
        /// </summary>
        /// <param name="rhs">The Size to test against</param>
        /// <returns>True if the Sizes are not equal</returns>
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
        /// Property for width component of Size
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
        /// Property for height component of Size
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
        /// Type cast operator, Size2D to Vector2.
        /// </summary>
        /// <param name="size">Object of Size2D type</param>
        public static implicit operator Vector2(Size2D size)
        {
            return new Vector2((float)size.Width, (float)size.Height);
        }

        /// <summary>
        /// Type cast operator, Vector2 to Size2D type.
        /// </summary>
        /// <param name="vec">Object of Vector2 type</param>
        public static implicit operator Size2D(Vector2 vec)
        {
            return new Size2D((int)vec.X, (int)vec.Y);
        }

    }

}

