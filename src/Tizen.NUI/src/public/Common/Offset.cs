/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// The Offset class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Offset : Disposable, ICloneable
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Offset() : this(Interop.Rectangle.NewRectangle(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="left">The left offset.</param>
        /// <param name="right">The right offset.</param>
        /// <param name="bottom">The bottom offset.</param>
        /// <param name="top">The top offset.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Offset(int left, int right, int bottom, int top) : this(Interop.Rectangle.NewRectangle(left, right, bottom, top), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Offset(Offset other) : this(other.left, other.right, other.bottom, other.top)
        {
        }

        internal Offset(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The type cast operator, Rectangle to Offset.
        /// </summary>
        /// <param name="value">A value of Rectangle type.</param>
        /// <returns>return a Extents instance</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Offset(Rectangle value)
        {
            return new Offset(value.X, value.X+value.Width, value.Y+value.Height, value.Y);
        }

        /// <summary>
        /// The left offset.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Left
        {
            get
            {
                return left;
            }
        }

        /// <summary>
        /// The right offset.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Right
        {
            get
            {
                return right;
            }
        }

        /// <summary>
        /// The bottom offset.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Bottom
        {
            get
            {
                return bottom;
            }
        }

        /// <summary>
        /// The top offset.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Top
        {
            get
            {
                return top;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Offset a, Offset b)
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
            return a.Left == b.Left && a.Right == b.Right && a.Bottom == b.Bottom && a.Top == b.Top;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">The first offset.</param>
        /// <param name="b">The second offset.</param>
        /// <returns>True if the offset are not identical.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Offset a, Offset b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="o">The object to compare with the current object.</param>
        /// <returns>True if boxes are exactly same.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (!(o is Offset))
            {
                return false;
            }
            Offset r = (Offset)o;

            // Return true if the fields match:
            return Left == r.Left && Right == r.Right && Bottom == r.Bottom && Top == r.Top;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Assignment from individual values.
        /// </summary>
        /// <param name="newLeft">The left offset.</param>
        /// <param name="newRight">The right offset.</param>
        /// <param name="newBottom">The bottom offset.</param>
        /// <param name="newTop">The top offset.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Set(int newLeft, int newRight, int newBottom, int newTop)
        {
            Interop.Rectangle.Set(SwigCPtr, newLeft, newRight, newBottom, newTop);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Offset(this);

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Offset obj)
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
        /// Determines whether the reference is null or the Offset has all 0 properties.
        /// </summary>
        internal static bool IsNullOrZero(Offset offset) => (offset == null || (offset.top == 0 && offset.right == 0 && offset.bottom == 0 && offset.left == 0));
    }
}
