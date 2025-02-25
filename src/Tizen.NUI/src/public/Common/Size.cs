/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
    public class Size : Disposable, ICloneable
    {
        private static readonly Size zero = new Size(0.0f, 0.0f, 0.0f);

        private float width;
        private float height;
        private float depth;

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
        public Size()
        {
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
        public Size(float width, float height, float depth = 0.0f)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size2d">Size2D with width and height.</param>
        /// <since_tizen> 5 </since_tizen>
        public Size(Size2D size2d)
        {
            if (null != size2d)
            {
                width = size2d.Width;
                height = size2d.Height;
            }
        }

        /// <summary>
        /// The Zero constant, (0.0f, 0.0f, 0.0f).
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static Size Zero => zero;

        /// <summary>
        /// The Width property for the width component of size
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Size(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Size size = new Size();
        /// size.Width = 0.1f; 
        /// // USE like this
        /// float width = 0.1f, height = 0.5f, depth = 0.9f;
        /// Size size = new Size(width, height, depth);
        /// </code>
        /// <since_tizen> 5 </since_tizen>
        public float Width
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Size(...) constructor")]
            set
            {
                width = value;
                callback?.Invoke(width, Height, Depth);
            }
            get
            {
                return width;
            }
        }

        /// <summary>
        /// The Height property for the height component of size.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Size(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Size size = new Size();
        /// size.Height = 0.5f; 
        /// // USE like this
        /// float width = 0.1f, height = 0.5f, depth = 0.9f;
        /// Size size = new Size(width, height, depth);
        /// </code>
        /// <since_tizen> 5 </since_tizen>
        public float Height
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Size(...) constructor")]
            set
            {
                height = value;
                callback?.Invoke(width, Height, Depth);
            }
            get
            {
                return height;
            }
        }

        /// <summary>
        /// The Depth property for the depth component of size.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Size(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Size size = new Size();
        /// size.Depth = 0.9f; 
        /// // USE like this
        /// float width = 0.1f, height = 0.5f, depth = 0.9f;
        /// Size size = new Size(width, height, depth);
        /// </code>
        /// <since_tizen> 5 </since_tizen>
        public float Depth
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Size(...) constructor")]
            set
            {
                depth = value;
                callback?.Invoke(width, Height, Depth);
            }
            get
            {
                return depth;
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
            return arg1?.Add(arg2);
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
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation.</param>
        /// <returns>A size containing the negation.</returns>
        /// <since_tizen> 5 </since_tizen>
        public static Size operator -(Size arg1)
        {
            return arg1?.Subtract();
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Divide(arg2);
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
            return arg1?.Divide(arg2);
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
            if (width == size?.width && height == size?.height && depth == size?.depth)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Size.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
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
            if (null != rhs && width == rhs.width && height == rhs.height && depth == rhs.depth)
            {
                return true;
            }

            return false;
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
            if (null != rhs && width == rhs.width && height == rhs.height && depth == rhs.depth)
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Size(width, height, depth);

        /// <summary>
        /// The type cast operator, Size to Vector3.
        /// </summary>
        /// <param name="size">The object of size type.</param>
        /// <since_tizen> 5 </since_tizen>
        public static implicit operator Vector3(Size size)
        {
            if (size == null)
            {
                return null;
            }
            return new Vector3(size.width, size.height, size.depth);
        }

        /// <summary>
        /// The type cast operator, Vector3 to Size type.
        /// </summary>
        /// <param name="vec">The object of Vector3 type.</param>
        /// <since_tizen> 5 </since_tizen>
        public static implicit operator Size(Vector3 vec)
        {
            if (vec == null)
            {
                return null;
            }
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
            if (size2d == null)
            {
                return null;
            }
            return new Size(size2d.Width, size2d.Height);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.DeleteVector3(swigCPtr);
        }

        protected override void Dispose(bool disposing)
        {
        }

        private Size Add(Size rhs)
        {
            return new Size(width + rhs.width, height + rhs.height, depth + rhs.depth);
        }

        private Size Subtract(Size rhs)
        {
            return new Size(width - rhs.width, height - rhs.height, depth - rhs.depth);
        }

        private Size Multiply(Size rhs)
        {
            return new Size(width * rhs.width, height * rhs.height, depth * rhs.depth);
        }

        private Size Multiply(float rhs)
        {
            return new Size(width * rhs, height * rhs, depth * rhs);
        }

        private Size Divide(Size rhs)
        {
            return new Size(width / rhs.width, height / rhs.height, depth / rhs.depth);
        }

        private Size Divide(float rhs)
        {
            return new Size(width / rhs, height / rhs, depth / rhs);
        }

        private Size Subtract()
        {
            return new Size(-width, -height, -depth);
        }

        private float ValueOfIndex(uint index)
        {
            var ret = 0.0f;

            switch (index)
            {
                case 0:
                    ret = width;
                    break;

                case 1:
                    ret = height;
                    break;

                case 2:
                    ret = depth;
                    break;
            }

            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef GetHandleRef(Size obj)
        {
            if (null == obj)
            {
                return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                return new global::System.Runtime.InteropServices.HandleRef(obj, Interop.Vector3.NewVector3(obj.width, obj.height, obj.depth));
            }
        }

        internal static void ReleaseHandleRef(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                Interop.Vector3.DeleteVector3(swigCPtr);
            }
        }

        internal delegate void SizeChangedCallback(float width, float height, float depth);

        internal Size(IntPtr ptr, bool cMemoryOwn)
        {
            var swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, ptr);
            width = Interop.Vector3.WidthGet(swigCPtr);
            height = Interop.Vector3.HeightGet(swigCPtr);
            depth = Interop.Vector3.DepthGet(swigCPtr);

            if (cMemoryOwn)
            {
                Interop.Vector3.DeleteVector3(swigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal Size(SizeChangedCallback cb, float w, float h, float d)
        {
            callback = cb;
            
            width = w;
            height = h;
            depth = d;
        }

        internal Size(SizeChangedCallback cb, Size other) : this(cb, other.width, other.height, other.depth)
        {
        }

        internal void ResetValue(float w, float h, float d)
        {
            width = w;
            height = h;
            depth = d;
        }

        private SizeChangedCallback callback = null;
    }
}
