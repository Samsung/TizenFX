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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    // Please do not use! This will be changed to internal class.
    /// <summary>
    /// A three-dimensional size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(SizeTypeConverter))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Size : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>swigCMemOwn.</summary>
        /// <since_tizen> 3 </since_tizen>
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
        ~Size()
        {
            if (!isDisposeQueued)
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
                    NDalicPINVOKE.delete_Vector3(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            disposed = true;
        }

        /// <summary>
        /// The addition operator for A+B.
        /// </summary>
        /// <param name="arg1">Size to assign A.</param>
        /// <param name="arg2">Size to assign B.</param>
        /// <returns>A size containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator +(Size arg1, Size arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator for A-B.
        /// </summary>
        /// <param name="arg1">Size to subtract A.</param>
        /// <param name="arg2">Size to subtract B.</param>
        /// <returns>The size containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator -(Size arg1, Size arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation.</param>
        /// <returns>A size containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator -(Size arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication.</param>
        /// <param name="arg2">The size to multiply.</param>
        /// <returns>A size containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator *(Size arg1, Size arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">Size for multiplication.</param>
        /// <param name="arg2">The float value to scale the size.</param>
        /// <returns>A size containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator *(Size arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">Size for division.</param>
        /// <param name="arg2">The size to divide.</param>
        /// <returns>A size containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator /(Size arg1, Size arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">Size for division.</param>
        /// <param name="arg2">The float value to scale the size by.</param>
        /// <returns>A Size containing the result of the scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size operator /(Size arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The array subscript operator.
        /// </summary>
        /// <param name="index">Subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 3 </since_tizen>
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
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x (or width) component.</param>
        /// <param name="y">The y (or height) component.</param>
        /// <param name="z">The z (or depth) component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Size(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size2d">Size2D with x (width) and y (height).</param>
        /// <since_tizen> 3 </since_tizen>
        public Size(Size2D size2d) : this(NDalicPINVOKE.new_Vector3__SWIG_3(Size2D.getCPtr(size2d)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The Zero constant, (0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Size size = obj as Size;
            bool equal = false;
            if (Width == size?.Width && Height == size?.Height && Depth == size?.Depth)
            {
                equal = true;
            }
            return equal;
        }


        /// <summary>
        /// Checks equality.<br />
        /// Utilizes appropriate machine epsilon values.<br />
        /// </summary>
        /// <param name="rhs">The size to test against.</param>
        /// <returns>True if the sizes are equal.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Size rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, Size.getCPtr(rhs));
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
        public bool NotEqualTo(Size rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, Size.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The Width property for the width component of size
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The Height property for the height component of size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The Depth property for the depth component of size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The type cast operator, Size to Vector3.
        /// </summary>
        /// <param name="size">The object of size type.</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector3(Size size)
        {
            return new Vector3(size.Width, size.Height, size.Depth);
        }

        /// <summary>
        /// The type cast operator, Vector3 to Size type.
        /// </summary>
        /// <param name="vec">The object of Vector3 type.</param>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Size(Vector3 vec)
        {
            return new Size(vec.Width, vec.Height, vec.Depth);
        }

    }

}

