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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// A three-dimensional size.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(SizeTypeConverter))]
    public class Size : Disposable
    {

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
        /// <since_tizen> 5 </since_tizen>
        public Size() : this(Interop.Vector3.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="width">The width component.</param>
        /// <param name="height">The height component.</param>
        /// <param name="depth">The depth component(optional).</param>
        /// <remarks>
        /// Size2D and Size are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Size2D = new Size(10.0f, 10.0f, 10.0f); // be aware that here the depth value(10.0f) will be lost. <br />
        /// view.Size = new Size2D(10, 10); // be aware that here the depth value is 0.0f by default. <br />
        /// view.MinimumSize = new Size(10, 10, 0); <br />
        /// Size Tmp = view.MaximumSize; //here Tmp.Depth will be 0.0f. <br />
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Size(float width, float height, float depth = 0.0f) : this(Interop.Vector3.new_Vector3__SWIG_1(width, height, depth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size2d">Size2D with width and height.</param>
        /// <since_tizen> 5 </since_tizen>
        public Size(Size2D size2d) : this(Interop.Vector3.new_Vector3__SWIG_3(Size2D.getCPtr(size2d)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The Zero constant, (0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static Size Zero
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_ZERO_get();
                Size ret = (cPtr == global::System.IntPtr.Zero) ? null : new Size(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The Width property for the width component of size
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float Width
        {
            set
            {
                Interop.Vector3.Vector3_Width_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height, Depth);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Width_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The Height property for the height component of size.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float Height
        {
            set
            {
                Interop.Vector3.Vector3_Height_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height, Depth);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Height_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The Depth property for the depth component of size.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public float Depth
        {
            set
            {
                Interop.Vector3.Vector3_Depth_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(Width, Height, Depth);
            }
            get
            {
                float ret = Interop.Vector3.Vector3_Depth_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The addition operator for A+B.
        /// </summary>
        /// <param name="arg1">Size to assign A.</param>
        /// <param name="arg2">Size to assign B.</param>
        /// <returns>A size containing the result of the addition.</returns>
        /// <since_tizen> 5 </since_tizen>
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
        /// <since_tizen> 5 </since_tizen>
        public static Size operator -(Size arg1, Size arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation.</param>
        /// <returns>A size containing the negation.</returns>
        /// <since_tizen> 5 </since_tizen>
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
        /// <since_tizen> 5 </since_tizen>
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
        /// <since_tizen> 5 </since_tizen>
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
        /// <since_tizen> 5 </since_tizen>
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
        /// <since_tizen> 5 </since_tizen>
        public static Size operator /(Size arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// The array subscript operator.
        /// </summary>
        /// <param name="index">Subscript index.</param>
        /// <returns>The float at the given index.</returns>
        /// <since_tizen> 5 </since_tizen>
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
            Size size = obj as Size;
            bool equal = false;
            if (Width == size?.Width && Height == size?.Height && Depth == size?.Depth)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the the hash code of this Size.
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
        /// <since_tizen> 5 </since_tizen>
        public bool EqualTo(Size rhs)
        {
            bool ret = Interop.Vector3.Vector3_EqualTo(swigCPtr, Size.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Checks inequality.<br />
        /// Utilizes appropriate machine epsilon values.<br />
        /// </summary>
        /// <param name="rhs">The size to test against.</param>
        /// <returns>True if the sizes are not equal.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool NotEqualTo(Size rhs)
        {
            bool ret = Interop.Vector3.Vector3_NotEqualTo(swigCPtr, Size.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The type cast operator, Size to Vector3.
        /// </summary>
        /// <param name="size">The object of size type.</param>
        /// <since_tizen> 5 </since_tizen>
        public static implicit operator Vector3(Size size)
        {
            return new Vector3(size.Width, size.Height, size.Depth);
        }

        /// <summary>
        /// The type cast operator, Vector3 to Size type.
        /// </summary>
        /// <param name="vec">The object of Vector3 type.</param>
        /// <since_tizen> 5 </since_tizen>
        public static implicit operator Size(Vector3 vec)
        {
            return new Size(vec.Width, vec.Height, vec.Depth);
        }

        /// <summary>
        /// Implicit type cast operator, Size2D to Size
        /// </summary>
        /// <param name="size2d">The object of Size2D type.</param>
        /// <since_tizen> none </since_tizen>
        /// This will be public opened in tizen_next by ACR.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Size(Size2D size2d)
        {
            return new Size(size2d.Width, size2d.Height, 0);
        }
        

        internal static Size GetSizeFromPtr(global::System.IntPtr cPtr)
        {
            Size ret = new Size(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Size obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Size(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.delete_Vector3(swigCPtr);
        }

        private Size Add(Size rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Add(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Subtract(Size rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Subtract__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Multiply(Size rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Multiply__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Multiply(float rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Divide(Size rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Divide__SWIG_0(swigCPtr, Size.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Divide(float rhs)
        {
            Size ret = new Size(Interop.Vector3.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Size Subtract()
        {
            Size ret = new Size(Interop.Vector3.Vector3_Subtract__SWIG_1(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.Vector3_ValueOfIndex__SWIG_0(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal delegate void SizeChangedCallback(float width, float height, float depth);

        internal Size(SizeChangedCallback cb, float w, float h, float d) : this(Interop.Vector3.new_Vector3__SWIG_1(w, h, d), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private SizeChangedCallback callback = null;
    }
}

