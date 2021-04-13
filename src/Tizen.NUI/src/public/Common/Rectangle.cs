/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// The Rectangle class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Binding.TypeConverter(typeof(RectangleTypeConverter))]
    public class Rectangle : Disposable, ICloneable
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle() : this(Interop.Rectangle.NewRectangle(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x coordinate (or left).</param>
        /// <param name="y">The y coordinate (or right).</param>
        /// <param name="width">The width (or bottom).</param>
        /// <param name="height">The height (or top).</param>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle(int x, int y, int width, int height) : this(Interop.Rectangle.NewRectangle(x, y, width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rectangle(Rectangle other) : this(other.x, other.y, other.width, other.height)
        {
        }

        internal Rectangle(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Rectangle(RectangleChangedCallback cb, int x, int y, int width, int height) : this(Interop.Rectangle.NewRectangle(x, y, width, height), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rectangle(RectangleChangedCallback cb) : this()
        {
            callback = cb;
        }

        internal Rectangle(RectangleChangedCallback cb, Rectangle other) : this(cb, other.x, other.y, other.width, other.height)
        {
        }

        /// <summary>
        /// The type cast operator, int to Rectangle.
        /// </summary>
        /// <param name="value">A value of int type.</param>
        /// <returns>return a Extents instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Rectangle(int value)
        {
            return new Rectangle(value, value, value, value);
        }

        internal delegate void RectangleChangedCallback(int x, int y, int width, int height);
        private RectangleChangedCallback callback = null;

        /// <summary>
        /// The x position of the rectangle.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Rectangle(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Rectangle rectangle = new Rectangle();
        /// rectangle.X = 1; 
        /// // Please USE like this
        /// int x = 1, y = 2, width = 3, height = 4;
        /// Rectangle rectangle = new Rectangle(x, y, width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Rectangle(...) constructor")]
            set
            {
                x = (value);

                callback?.Invoke(X, Y, Width, Height);
            }
            get
            {
                return x;
            }
        }

        /// <summary>
        /// The Y position of the rectangle.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Rectangle(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Rectangle rectangle = new Rectangle();
        /// rectangle.Y = 2; 
        /// // Please USE like this
        /// int x = 1, y = 2, width = 3, height = 4;
        /// Rectangle rectangle = new Rectangle(x, y, width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Rectangle(...) constructor")]
            set
            {
                y = (value);

                callback?.Invoke(X, Y, Width, Height);
            }
            get
            {
                return y;
            }
        }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Rectangle(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Rectangle rectangle = new Rectangle();
        /// rectangle.Width = 3; 
        /// // Please USE like this
        /// int x = 1, y = 2, width = 3, height = 4;
        /// Rectangle rectangle = new Rectangle(x, y, width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Width
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Rectangle(...) constructor")]
            set
            {
                width = (value);

                callback?.Invoke(X, Y, Width, Height);
            }
            get
            {
                return width;
            }
        }

        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Rectangle(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Rectangle rectangle = new Rectangle();
        /// rectangle.Height = 4; 
        /// // Please USE like this
        /// int x = 1, y = 2, width = 3, height = 4;
        /// Rectangle rectangle = new Rectangle(x, y, width, height);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Height
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Rectangle(...) constructor")]
            set
            {
                height = (value);

                callback?.Invoke(X, Y, Width, Height);
            }
            get
            {
                return height;
            }
        }

        private int x
        {
            set
            {
                Interop.Rectangle.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int left
        {
            set
            {
                Interop.Rectangle.LeftSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.LeftGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int y
        {
            set
            {
                Interop.Rectangle.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int right
        {
            set
            {
                Interop.Rectangle.RightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.RightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int width
        {
            set
            {
                Interop.Rectangle.WidthSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.WidthGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int bottom
        {
            set
            {
                Interop.Rectangle.BottomSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.BottomGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int height
        {
            set
            {
                Interop.Rectangle.HeightSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.HeightGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private int top
        {
            set
            {
                Interop.Rectangle.TopSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.Rectangle.TopGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// THe Equality operator.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>True if the boxes are exactly the same.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(Rectangle a, Rectangle b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">The first rectangle.</param>
        /// <param name="b">The second rectangle.</param>
        /// <returns>True if the rectangles are not identical.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(Rectangle a, Rectangle b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="o">The object to compare with the current object.</param>
        /// <returns>True if boxes are exactly same.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (!(o is Rectangle))
            {
                return false;
            }
            Rectangle r = (Rectangle)o;

            // Return true if the fields match:
            return X == r.X && Y == r.Y && Width == r.Width && Height == r.Height;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Assignment from individual values.
        /// </summary>
        /// <param name="newX">The x coordinate.</param>
        /// <param name="newY">The y coordinate.</param>
        /// <param name="newWidth">The width.</param>
        /// <param name="newHeight">The height.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Set(int newX, int newY, int newWidth, int newHeight)
        {
            Interop.Rectangle.Set(SwigCPtr, newX, newY, newWidth, newHeight);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Determines whether or not this rectangle is empty.
        /// </summary>
        /// <returns>True if width or height are zero.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsEmpty()
        {
            bool ret = Interop.Rectangle.IsEmpty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the left of the rectangle.
        /// </summary>
        /// <returns>The left edge of the rectangle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int Left()
        {
            int ret = Interop.Rectangle.Left(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the right of the rectangle.
        /// </summary>
        /// <returns>The right edge of the rectangle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int Right()
        {
            int ret = Interop.Rectangle.Right(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the top of the rectangle.
        /// </summary>
        /// <returns>The top of the rectangle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int Top()
        {
            int ret = Interop.Rectangle.Top(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the bottom of the rectangle.
        /// </summary>
        /// <returns>The bottom of the rectangle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int Bottom()
        {
            int ret = Interop.Rectangle.Bottom(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the area of the rectangle.
        /// </summary>
        /// <returns>The area of the rectangle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int Area()
        {
            int ret = Interop.Rectangle.Area(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determines whether or not this rectangle and the specified rectangle intersect.
        /// </summary>
        /// <param name="other">The other rectangle to test against this rectangle.</param>
        /// <returns>True if the rectangles intersect.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Intersects(Rectangle other)
        {
            bool ret = Interop.Rectangle.Intersects(SwigCPtr, Rectangle.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Determines whether or not this rectangle contains the specified rectangle.
        /// </summary>
        /// <param name="other">The other rectangle to test against this rectangle.</param>
        /// <returns>True if the specified rectangle is contained.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool Contains(Rectangle other)
        {
            bool ret = Interop.Rectangle.Contains(SwigCPtr, Rectangle.getCPtr(other));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Rectangle(this);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Rectangle obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Rectangle.DeleteRectangle(swigCPtr);
        }

        /// <summary>
        /// Determines whether the reference is null or the Rectangle has all 0 properties.
        /// </summary>
        internal static bool IsNullOrZero(Rectangle rectangle) => (rectangle == null || (rectangle.top == 0 && rectangle.right == 0 && rectangle.bottom == 0 && rectangle.left == 0));
    }
}
