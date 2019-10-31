/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A two-dimensional size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Size2DTypeConverter))]
    public class Size2D : Disposable
    {

        private Size2DChangedCallback callback = null;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <remarks>
        /// Size2D and Size are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Size2D = new Size(10.0f, 10.0f, 10.0f); // be aware that here the depth value(10.0f) will be lost. <br />
        /// view.Size = new Size2D(10, 10); // be aware that here the depth value is 0.0f by default. <br />
        /// view.MinimumSize = new Size(10, 10, 0); <br />
        /// Size Tmp = view.MaximumSize; //here Tmp.Depth will be 0.0f. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Size2D() : this(Interop.Vector2.new_Vector2__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="width">The width component.</param>
        /// <param name="height">The height component.</param>
        /// <remarks>
        /// Size2D and Size are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Size2D = new Size(10.0f, 10.0f, 10.0f); // be aware that here the depth value(10.0f) will be lost. <br />
        /// view.Size = new Size2D(10, 10); // be aware that here the depth value is 0.0f by default. <br />
        /// view.MinimumSize = new Size(10, 10, 0); <br />
        /// Size Tmp = view.MaximumSize; //here Tmp.Depth will be 0.0f. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Size2D(int width, int height) : this(Interop.Vector2.new_Vector2__SWIG_1((float)width, (float)height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                Interop.Vector2.Vector2_Width_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height);
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Width_get(swigCPtr);
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
                Interop.Vector2.Vector2_Height_set(swigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height);
            }
            get
            {
                float ret = Interop.Vector2.Vector2_Height_get(swigCPtr);
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
        /// Implicit type cast operator, Size to Size2D
        /// </summary>
        /// <param name="size">The object of Size type.</param>
        /// <since_tizen> none </since_tizen>
        /// This will be public opened in tizen_next by ACR.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Size2D(Size size)
        {
            return new Size2D((int)size.Width, (int)size.Height);
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
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return swigCPtr.Handle.GetHashCode();
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
            bool ret = Interop.Vector2.Vector2_EqualTo(swigCPtr, Size2D.getCPtr(rhs));
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
            bool ret = Interop.Vector2.Vector2_NotEqualTo(swigCPtr, Size2D.getCPtr(rhs));
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

        internal Size2D(Size2DChangedCallback cb, int x, int y) : this(Interop.Vector2.new_Vector2__SWIG_1((float)x, (float)y), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Size2D(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector2.delete_Vector2(swigCPtr);
        }

        private Size2D Add(Size2D rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Add(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Subtract(Size2D rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Subtract__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Multiply(Size2D rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Multiply__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Multiply(int rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Multiply__SWIG_1(swigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Divide(Size2D rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Divide__SWIG_0(swigCPtr, Size2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Divide(int rhs)
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Divide__SWIG_1(swigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size2D Subtract()
        {
            Size2D ret = new Size2D(Interop.Vector2.Vector2_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private int ValueOfIndex(uint index)
        {
            int ret = (int)Interop.Vector2.Vector2_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
