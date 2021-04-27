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
    /// Position2D is a two-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(Position2DTypeConverter))]
    public class Position2D : Disposable, ICloneable
    {
        private Position2DChangedCallback callback = null;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <remarks>
        /// Position2D and Position are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Position2D = new Position(10.0f, 10.0f, 10.0f); // be aware that here the z value(10.0f) will be lost. <br />
        /// view.Position = new Position2D(10, 10); // be aware that here the z value is 0.0f by default. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position2D() : this(Interop.Vector2.NewVector2(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="position">Position to create this vector from</param>
        /// <since_tizen> 3 </since_tizen>
        public Position2D(Position position) : this(Interop.Vector2.NewVector2WithVector3(Position.getCPtr(position)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">x component</param>
        /// <param name="y">y component</param>
        /// <remarks>
        /// Position2D and Position are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Position2D = new Position(10.0f, 10.0f, 10.0f); // be aware that here the z value(10.0f) will be lost. <br />
        /// view.Position = new Position2D(10, 10); // be aware that here the z value is 0.0f by default. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position2D(int x, int y) : this(Interop.Vector2.NewVector2((float)x, (float)y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position2D(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Position2D(Position2DChangedCallback cb, int x, int y) : this(Interop.Vector2.NewVector2((float)x, (float)y), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal delegate void Position2DChangedCallback(int x, int y);

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Position2D(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position2D position2d = new Position2D();
        /// position2d.X = 1; 
        /// // Please USE like this
        /// int x = 1, y = 2;
        /// Position2D position2d = new Position2D(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int X
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Position2D(...) constructor")]
            set
            {
                Interop.Vector2.XSet(SwigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return (int)ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Please use new Position2D(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position2D position2d = new Position2D();
        /// position2d.Y = 2; 
        /// // Please USE like this
        /// int x = 1, y = 2;
        /// Position2D position2d = new Position2D(x, y);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public int Y
        {
            [Obsolete("Please do not use this setter, Deprecated in API8, will be removed in API10. please use new Position2D(...) constructor")]
            set
            {
                Interop.Vector2.YSet(SwigCPtr, (float)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y);
            }
            get
            {
                float ret = Interop.Vector2.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return (int)ret;
            }
        }

        /// <summary>
        /// The const array subscript operator overload. Should be 0, or 1.
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
        /// Convert a string to Position2D.
        /// </summary>
        /// <param name="value">The string to convert.</param>
        /// <returns>The converted value.</returns>
        static public Position2D ConvertFromString(System.String value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 2)
                {
                    int x = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim());
                    int y = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim());
                    return new Position2D(x, y);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Position2D)}");
        }

        /// <summary>
        /// Constructor a Position2D from a string.
        /// </summary>
        public static implicit operator Position2D(System.String value)
        {
            return ConvertFromString(value);
        }

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator +(Position2D arg1, Position2D arg2)
        {
            return arg1?.Add(arg2);
        }

        /// <summary>
        /// The subtraction operator.
        /// </summary>
        /// <param name="arg1">The vector to subtract.</param>
        /// <param name="arg2">The vector to subtract.</param>
        /// <returns>The vector containing the result of the subtraction.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator -(Position2D arg1, Position2D arg2)
        {
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The vector to negate.</param>
        /// <returns>The vector containing the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator -(Position2D arg1)
        {
            return arg1?.Subtract();
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The vector to multiply.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator *(Position2D arg1, Position2D arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply.</param>
        /// <param name="arg2">The integer value to scale the vector.</param>
        /// <returns>The vector containing the result of the multiplication.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator *(Position2D arg1, int arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The vector to divide.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator /(Position2D arg1, Position2D arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The integer value to scale the vector by.</param>
        /// <returns>The vector containing the result of the division.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position2D operator /(Position2D arg1, int arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Position2D position2D = obj as Position2D;
            bool equal = false;
            if (X == position2D?.X && Y == position2D?.Y)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Position2D.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if the rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Position2D rhs)
        {
            bool ret = Interop.Vector2.EqualTo(SwigCPtr, Position2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if the rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Position2D rhs)
        {
            bool ret = Interop.Vector2.NotEqualTo(SwigCPtr, Position2D.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts a Position2D instance to a Vector2 instance.
        /// </summary>
        /// <param name="position2d">An object of the Position2D type.</param>
        /// <returns>return an object of the Vector2 type</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector2(Position2D position2d)
        {
            if (position2d == null)
            {
                return null;
            }
            return new Vector2(position2d.X, position2d.Y);
        }

        /// <summary>
        /// Converts a Vector2 instance to a Position2D instance.
        /// </summary>
        /// <param name="vec">An object of the Vector2 type.</param>
        /// <returns>return an object of the Position2D type</returns>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Position2D(Vector2 vec)
        {
            if (vec == null)
            {
                return null;
            }
            return new Position2D((int)vec.X, (int)vec.Y);
        }

        /// <summary>
        /// Implicit type cast operator, Position to Position2D
        /// </summary>
        /// <param name="position">The object of Position type.</param>
        /// <since_tizen> none </since_tizen>
        /// This will be public opened in tizen_next by ACR.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Position2D(Position position)
        {
            if (position == null)
            {
                return null;
            }
            return new Position2D((int)position.X, (int)position.Y);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Position2D(this);

        internal static Position2D GetPosition2DFromPtr(global::System.IntPtr cPtr)
        {
            Position2D ret = new Position2D(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Position2D obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector2.DeleteVector2(swigCPtr);
        }

        private Position2D Add(Position2D rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Add(SwigCPtr, Position2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Subtract(Position2D rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Subtract(SwigCPtr, Position2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Multiply(Position2D rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Multiply(SwigCPtr, Position2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Multiply(int rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Multiply(SwigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Divide(Position2D rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Divide(SwigCPtr, Position2D.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Divide(int rhs)
        {
            Position2D ret = new Position2D(Interop.Vector2.Divide(SwigCPtr, (float)rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position2D Subtract()
        {
            Position2D ret = new Position2D(Interop.Vector2.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private int ValueOfIndex(uint index)
        {
            int ret = (int)Interop.Vector2.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
