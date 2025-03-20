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
    /// A two-dimensional size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Size2DTypeConverter))]
    public class Size2D : Disposable, ICloneable
    {
        private int width;
        private int height;

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
        public Size2D()
        {
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
        public Size2D(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        internal delegate void Size2DChangedCallback(int width, int height);

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose. 
        /// </summary>
        /// <remarks>
        /// Following the guide of https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose.
        /// This will replace "protected virtual void Dispose(DisposeTypes type)" which is exactly same in functionality.
        /// </remarks>
        /// <param name="disposing">true in order to free managed objects</param>
        // Protected implementation of Dispose pattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            callback = null;
        }

        /// <summary>
        /// The property for the width component of a size.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Size2D(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Size2D size2d = new Size2D();
        /// size2d.Width = 1; 
        /// // USE like this
        /// int width = 1, height = 2;
        /// Size2D size2d = new Size2D(width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Width
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Size2D(...) constructor")]
            set
            {
                width = value;
                callback?.Invoke(width, Height);
            }
            get
            {
                return width;
            }
        }

        /// <summary>
        /// The property for the height component of a size.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Size2D(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Size2D size2d = new Size2D();
        /// size2d.Height = 2; 
        /// // USE like this
        /// int width = 1, height = 2;
        /// Size2D size2d = new Size2D(width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Height
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Size2D(...) constructor")]
            set
            {
                height = value;
                callback?.Invoke(width, Height);
            }
            get
            {
                return height;
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
            return arg1?.Add(arg2);
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
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">Size for unary negation.</param>
        /// <returns>A size containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Size2D operator -(Size2D arg1)
        {
            return arg1?.Subtract();
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Multiply(arg2);
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
            return arg1?.Divide(arg2);
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
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// The type cast operator, Size2D to Vector2.
        /// </summary>
        /// <param name="size">An object of the Size2D type.</param>
        /// <returns>return a Vector2 instance</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector2(Size2D size)
        {
            if (size == null)
            {
                return null;
            }
            return new Vector2(size.Width, size.Height);
        }

        /// <summary>
        /// The type cast operator, Vector2 to Size2D type.
        /// </summary>
        /// <param name="vector2">An object of the Vector2 type.</param>
        /// <returns>return a Size2D instance</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Size2D(Vector2 vector2)
        {
            if (vector2 == null)
            {
                return null;
            }
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
            if (size == null)
            {
                return null;
            }
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
        /// Gets the hash code of this Size2D.
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
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Size2D rhs)
        {
            if (rhs == null)
            {
                throw new ArgumentNullException(nameof(rhs), "rhs is null.");
            }

            if (width == rhs.width && height == rhs.height)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (rhs == null)
            {
                throw new ArgumentNullException(nameof(rhs), "rhs is null.");
            }

            if (width == rhs.width && height == rhs.height)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Size2D(Width, Height);

        /// <summary>
        /// Gets the size from the pointer.
        /// </summary>
        /// <param name="cPtr">The pointer of the size.</param>
        /// <param name="isMemoryOwned"></param>
        /// <returns>Size</returns>
        internal static Size2D GetSize2DFromPtr(global::System.IntPtr cPtr, bool isMemoryOwned)
        {
            var ret = new Size2D();

            var swigCPtr = new global::System.Runtime.InteropServices.HandleRef(ret, cPtr);
            ret.width = (int)Interop.Vector2.WidthGet(swigCPtr);
            ret.height = (int)Interop.Vector2.HeightGet(swigCPtr);
            return ret;
        }

        internal Size2D(Size2DChangedCallback cb, int w, int h)
        {
            callback = cb;
            width = w;
            height = h;
        }

        internal void ResetValue(int w, int h)
        {
            width = w;
            height = h;
        }

        internal static global::System.Runtime.InteropServices.HandleRef GetHandleRef(Size2D obj)
        {
            if (null == obj)
            {
                return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            else
            {
                return new global::System.Runtime.InteropServices.HandleRef(obj, Interop.Vector2.NewVector2(obj.width, obj.height));
            }
        }

        internal static void ReleaseHandleRef(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                Interop.Vector2.DeleteVector2(swigCPtr);
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector2.DeleteVector2(swigCPtr);
        }

        private Size2D Add(Size2D rhs)
        {
            if (null == rhs)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return new Size2D(width + rhs.width, height + rhs.height);
        }

        private Size2D Subtract(Size2D rhs)
        {
            if (null == rhs)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return new Size2D(width - rhs.width, height - rhs.height);
        }

        private Size2D Multiply(Size2D rhs)
        {
            if (null == rhs)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return new Size2D(width * rhs.width, height * rhs.height);
        }

        private Size2D Multiply(int rhs)
        {
            return new Size2D(width * rhs, height * rhs);
        }

        private Size2D Divide(Size2D rhs)
        {
            if (null == rhs)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            return new Size2D(width / rhs.width, height / rhs.height);
        }

        private Size2D Divide(int rhs)
        {
            return new Size2D(width / rhs, height / rhs);
        }

        private Size2D Subtract()
        {
            return new Size2D(-width, -height);
        }

        private int ValueOfIndex(uint index)
        {
            switch (index)
            {
                case 0:
                    return width;
                case 1:
                    return height;

                default:
                    throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private static int ClampToInt(double v) =>
            v > int.MaxValue ? int.MaxValue
            : v < int.MinValue ? int.MinValue
            : (int)v;
    }
}
