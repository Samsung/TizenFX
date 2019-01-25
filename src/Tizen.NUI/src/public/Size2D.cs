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
    /// A two-dimensional size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Size2DTypeConverter))]
    public class Size2D : global::System.IDisposable
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

        private Size2DChangedCallback callback = null;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D() : this(NDalicPINVOKE.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x (or width) component.</param>
        /// <param name="y">The y (or height) component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Size2D(int x, int y) : this(NDalicPINVOKE.new_Vector2__SWIG_1((float)x, (float)y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        ~Size2D()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        internal delegate void Size2DChangedCallback(int width, int height);

        /// <summary>
        /// The property for the width component of a size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Width
        {
            set
            {
                NDalicPINVOKE.Vector2_Width_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height);
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (int)ret;
            }
        }

        /// <summary>
        /// The property for the height component of a size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Height
        {
            set
            {
                NDalicPINVOKE.Vector2_Height_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height);
            }
            get
            {
                float ret = NDalicPINVOKE.Vector2_Height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return (int)ret;
            }
        }

        /// <summary>
        /// The addition operator for A+B.
        /// </summary>
        /// <param name="arg1">Size A.</param>
        /// <param name="arg2">Size to assign B.</param>
        /// <returns>A size containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator +(Size2D arg1, Size2D arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator for A-B.
        /// </summary>
        /// <param name="arg1">Size A.</param>
        /// <param name="arg2">Size to subtract B.</param>
        /// <returns>A size containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator -(Size2D arg1, Size2D arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation.</param>
        /// <returns>A size containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator -(Size2D arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication.</param>
        /// <param name="arg2">Size to multiply.</param>
        /// <returns>A size containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator *(Size2D arg1, Size2D arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication</param>
        /// <param name="arg2">The integer value to scale the size.</param>
        /// <returns>A size containing the result of the scaling.</returns>

        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator *(Size2D arg1, int arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">Size for division.</param>
        /// <param name="arg2">Size to divide.</param>
        /// <returns>A size containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator /(Size2D arg1, Size2D arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">Size for division.</param>
        /// <param name="arg2">The integer value to scale the size by.</param>
        /// <returns>A size containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator /(Size2D arg1, int arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The type cast operator, Size2D to Vector2.
        /// </summary>
        /// <param name="size">An object of the Size2D type.</param>
        /// <returns>return a Vector2 instance</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector2(Size2D size)
        {
            return new Vector2((float)size.Width, (float)size.Height);
        }

        /// <summary>
        /// The type cast operator, Vector2 to Size2D type.
        /// </summary>
        /// <param name="vector2">An object of the Vector2 type.</param>
        /// <returns>return a Size2D instance</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Size2D(Vector2 vector2)
        {
            return new Size2D((int)vector2.X, (int)vector2.Y);
        }

        /// <summary>
        /// The array subscript operator.
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
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Size2D size2D = obj as Size2D;
            bool equal = false;
            if (Width == size2D?.Width && Height == size2D?.Height)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this Size2D.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 5 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.GetHashCode();
        }

        /// <summary>
        /// Checks equality.<br />
        /// Utilizes appropriate machine epsilon values.<br />
        /// </summary>
        /// <param name="rhs">The size to test against.</param>
        /// <returns>True if the sizes are equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Size2D rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_EqualTo(swigCPtr, Size2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks inequality.<br />
        /// Utilizes appropriate machine epsilon values.<br />
        /// </summary>
        /// <param name="rhs">The size to test against.</param>
        /// <returns>True if the sizes are not equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Size2D rhs)
        {
            bool ret = NDalicPINVOKE.Vector2_NotEqualTo(swigCPtr, Size2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Size2D obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Gets the size from the pointer.
        /// </summary>
        /// <param name="cPtr">The pointer of the size.</param>
        /// <returns>Size</returns>
        internal static Size2D GetSize2DFromPtr(global::System.IntPtr cPtr)
        {
            Size2D ret = new Size2D(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Size2D(Size2DChangedCallback cb, int x, int y) : this(NDalicPINVOKE.new_Vector2__SWIG_1((float)x, (float)y), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Size2D(global::System.IntPtr cPtr, bool cMemoryOwn)
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
                    NDalicPINVOKE.delete_Vector2(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
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

        private int ValueOfIndex(uint index)
        {
            int ret = (int)NDalicPINVOKE.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
