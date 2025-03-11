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
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// Position is a three-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(PositionTypeConverter))]
    public class Position : Disposable, ICloneable
    {
        private static readonly Position one = new Position(1.0f, 1.0f, 1.0f);
        private static readonly Position zero = new Position(0.0f, 0.0f, 0.0f);

        private static IntPtrPool ptrPool;

        private static IntPtrPool PtrPool
        {
            get
            {
                if (null == ptrPool)
                {
                    ptrPool = new IntPtrPool(CreateEmptryPtr, DeletePtr);
                }

                return ptrPool;
            }
        }

        private static IntPtr CreateEmptryPtr()
        {
            return Interop.Vector3.NewVector3();
        }

        private static void DeletePtr(IntPtr ptr)
        {
            var swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, ptr);
            Interop.Vector3.DeleteVector3(swigCPtr);
        }

        internal static new void Preload()
        {
            // Do nothing. Just call for load static values.
        }

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
        public Position() : this(PtrPool.GetPtr(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component(optional).</param>
        /// <remarks>
        /// Position2D and Position are implicitly converted to each other, so these are compatible and can be replaced without any type casting. <br />
        /// For example, the followings are possible. <br />
        /// view.Position2D = new Position(10.0f, 10.0f, 10.0f); // be aware that here the z value(10.0f) will be lost. <br />
        /// view.Position = new Position2D(10, 10); // be aware that here the z value is 0.0f by default. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position(float x, float y, float z = 0.0f) : this(PtrPool.GetPtr(), true)
        {
            Interop.Vector3.XSet(SwigCPtr, x);
            Interop.Vector3.YSet(SwigCPtr, y);
            Interop.Vector3.ZSet(SwigCPtr, z);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="position2d">Position2D to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
        public Position(Position2D position2d) : this(PtrPool.GetPtr(), true)
        {
            if (null == position2d)
            {
                throw new ArgumentNullException(nameof(position2d));
            }

            Interop.Vector3.XSet(SwigCPtr, position2d.X);
            Interop.Vector3.YSet(SwigCPtr, position2d.Y);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginTop => ParentOrigin.Top;

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginBottom => ParentOrigin.Bottom;

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginLeft => ParentOrigin.Left;

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginRight => ParentOrigin.Right;

        /// <summary>
        /// ParentOrigin constants. It's 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float ParentOriginMiddle => ParentOrigin.Middle;

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopLeft => ParentOrigin.TopLeft;

        /// <summary>
        /// ParentOrigin constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopCenter => ParentOrigin.TopCenter;

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginTopRight => ParentOrigin.TopRight;

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenterLeft => ParentOrigin.CenterLeft;

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenter => ParentOrigin.Center;

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginCenterRight => ParentOrigin.CenterRight;

        /// <summary>
        /// ParentOrigin constants: 0.0f, 1.0f, 0.5f.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomLeft => ParentOrigin.BottomLeft;

        /// <summary>
        /// ParentOrigin constants: 0.5, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomCenter => ParentOrigin.BottomCenter;

        /// <summary>
        /// ParentOrigin constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position ParentOriginBottomRight => ParentOrigin.BottomRight;

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointTop => ParentOrigin.Top;

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointBottom => ParentOrigin.Bottom;

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointLeft => ParentOrigin.Left;

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointRight => ParentOrigin.Right;

        /// <summary>
        /// PivotPoint constants: 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointMiddle => ParentOrigin.Middle;

        /// <summary>
        /// PivotPoint constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopLeft => ParentOrigin.TopLeft;

        /// <summary>
        /// PivotPoint constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopCenter => ParentOrigin.TopCenter;

        /// <summary>
        /// PivotPoint constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopRight => ParentOrigin.TopRight;

        /// <summary>
        /// PivotPoint constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterLeft => ParentOrigin.CenterLeft;

        /// <summary>
        /// PivotPoint constants: 0.5, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenter => ParentOrigin.Center;

        /// <summary>
        /// PivotPoint constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterRight => ParentOrigin.CenterRight;

        /// <summary>
        /// PivotPoint constants: 0.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomLeft => ParentOrigin.BottomLeft;

        /// <summary>
        /// PivotPoint constants: 0.5, 1.0, 0.5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomCenter => ParentOrigin.BottomCenter;

        /// <summary>
        /// PivotPoint constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomRight => ParentOrigin.BottomRight;

        /// <summary>
        /// Constant ( 1.0f, 1.0f, 1.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position One => one;

        /// <summary>
        /// Constant ( 0.0f, 0.0f, 0.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Zero => zero;

        /// <summary>
        /// The x component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.X = 1.0f; 
        /// // USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float X
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Position(...) constructor")]
            set
            {
                Interop.Vector3.XSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(value, Y, Z);
            }
            get
            {
                float ret = Interop.Vector3.XGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The y component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.Y = 2.0f; 
        /// // USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Y
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Position(...) constructor")]
            set
            {
                Interop.Vector3.YSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, value, Z);
            }
            get
            {
                float ret = Interop.Vector3.YGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// The z component.
        /// </summary>
        /// <remarks>
        /// The setter is deprecated in API8 and will be removed in API10. Use new Position(...) constructor.
        /// </remarks>
        /// <code>
        /// // DO NOT use like the followings!
        /// Position position = new Position();
        /// position.Z = 3.0f; 
        /// // USE like this
        /// float x = 1.0f, y = 2.0f, z = 3.0f;
        /// Position position = new Position(x, y, z);
        /// </code>
        /// <since_tizen> 3 </since_tizen>
        public float Z
        {
            [Obsolete("Do not use this setter, that is deprecated in API8 and will be removed in API10. Use new Position(...) constructor")]
            set
            {
                Interop.Vector3.ZSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                callback?.Invoke(X, Y, value);
            }
            get
            {
                float ret = Interop.Vector3.ZGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        internal static Position XAxis => PositionAxis.X;

        internal static Position YAxis => PositionAxis.Y;

        internal static Position ZAxis => PositionAxis.Z;

        internal static Position NegativeXAxis => PositionAxis.NegativeX;

        internal static Position NegativeYAxis => PositionAxis.NegativeY;

        internal static Position NegativeZAxis => PositionAxis.NegativeZ;

        /// <summary>
        /// The const array subscript operator overload. Should be 0, 1, or 2.
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
        /// An addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator +(Position arg1, Position arg2)
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
        public static Position operator -(Position arg1, Position arg2)
        {
            return arg1?.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The vector to negate.</param>
        /// <returns>The vector containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator -(Position arg1)
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
        public static Position operator *(Position arg1, Position arg2)
        {
            return arg1?.Multiply(arg2);
        }

        /// <summary>
        /// The multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator *(Position arg1, float arg2)
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
        public static Position operator /(Position arg1, Position arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// The division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide.</param>
        /// <param name="arg2">The float value to scale the vector by.</param>
        /// <returns>The vector containing the result of scaling.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator /(Position arg1, float arg2)
        {
            return arg1?.Divide(arg2);
        }

        /// <summary>
        /// Converts a position instance to a Vector3 instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector3(Position position)
        {
            if (position == null)
            {
                return null;
            }
            return new Vector3(position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Converts a Vector3 instance to a position instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Position(Vector3 vec)
        {
            if (vec == null)
            {
                return null;
            }
            return new Position(vec.X, vec.Y, vec.Z);
        }

        /// <summary>
        /// Implicit type cast operator, Position2D to Position
        /// </summary>
        /// <param name="position2d">The object of Position2D type.</param>
        /// <since_tizen> none </since_tizen>
        /// This will be public opened in tizen_next by ACR.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Position(Position2D position2d)
        {
            if (position2d == null)
            {
                return null;
            }
            return new Position(position2d.X, position2d.Y, 0);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(System.Object obj)
        {
            Position position = obj as Position;
            bool equal = false;
            if (X == position?.X && Y == position?.Y && Z == position?.Z)
            {
                equal = true;
            }
            return equal;
        }

        /// <summary>
        /// Gets the hash code of this Position.
        /// </summary>
        /// <returns>The Hash Code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override int GetHashCode()
        {
            return SwigCPtr.Handle.GetHashCode();
        }

        /// <summary>
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Position rhs)
        {
            bool ret = Interop.Vector3.EqualTo(SwigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compares if rhs is not equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool NotEqualTo(Position rhs)
        {
            bool ret = Interop.Vector3.NotEqualTo(SwigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new Position(X, Y, Z);

        internal static Position GetPositionFromPtr(global::System.IntPtr cPtr)
        {
            Position ret = new Position(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                PtrPool.PutPtr(SwigCPtr.Handle);
                SwigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                PtrPool.PutPtr(SwigCPtr.Handle);
                SwigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Vector3.DeleteVector3(swigCPtr);
        }


        private Position Add(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Add(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Subtract(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Multiply(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(float rhs)
        {
            Position ret = new Position(Interop.Vector3.Multiply(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(Position rhs)
        {
            Position ret = new Position(Interop.Vector3.Divide(SwigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(float rhs)
        {
            Position ret = new Position(Interop.Vector3.Divide(SwigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract()
        {
            Position ret = new Position(Interop.Vector3.Subtract(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private float ValueOfIndex(uint index)
        {
            float ret = Interop.Vector3.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal delegate void PositionChangedCallback(float x, float y, float z);

        internal Position(PositionChangedCallback cb, float x, float y, float z) : this(PtrPool.GetPtr(), true)
        {
            callback = cb;

            Interop.Vector3.XSet(SwigCPtr, x);
            Interop.Vector3.YSet(SwigCPtr, y);
            Interop.Vector3.ZSet(SwigCPtr, z);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private PositionChangedCallback callback = null;
    }
}
