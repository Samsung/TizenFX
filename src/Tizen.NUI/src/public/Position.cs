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

namespace Tizen.NUI
{

    /// <summary>
    /// Position is a three dimensional vector.
    /// </summary>
    public class Position : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal Position(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Position obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~Position()
        {
            DisposeQueue.Instance.Add(this);
        }

        public virtual void Dispose()
        {
            if (!Stage.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_Vector3(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
            }
        }


        /// <summary>
        /// Addition operator.
        /// </summary>
        /// <param name="arg1">Vector to add</param>
        /// <param name="arg2">Vector to add</param>
        /// <returns>A vector containing the result of the addition</returns>
        public static Position operator +(Position arg1, Position arg2)
        {
            return arg1.Add(arg2);
        }

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="arg1">Vector to subtract</param>
        /// <param name="arg2">Vector to subtract</param>
        /// <returns>A vector containing the result of the subtraction</returns>
        public static Position operator -(Position arg1, Position arg2)
        {
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// Unary negation operator.
        /// </summary>
        /// <param name="arg1">Vector to netate</param>
        /// <returns>A vector containg the negation</returns>
        public static Position operator -(Position arg1)
        {
            return arg1.Subtract();
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The vector to multiply</param>
        /// <returns>A vector containing the result of the multiplication</returns>
        public static Position operator *(Position arg1, Position arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="arg1">The vector to multiply</param>
        /// <param name="arg2">The float value to scale the vector</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static Position operator *(Position arg1, float arg2)
        {
            return arg1.Multiply(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The vector to divide</param>
        /// <returns>A vector containing the result of the division</returns>
        public static Position operator /(Position arg1, Position arg2)
        {
            return arg1.Divide(arg2);
        }

        /// <summary>
        /// Division operator.
        /// </summary>
        /// <param name="arg1">The vector to divide</param>
        /// <param name="arg2">The float value to scale the vector by</param>
        /// <returns>A vector containing the result of the scaling</returns>
        public static Position operator /(Position arg1, float arg2)
        {
            return arg1.Divide(arg2);
        }


        /// <summary>
        /// Const array subscript operator overload. Should be 0, 1 or 2.
        /// </summary>
        /// <param name="index">Subscript index</param>
        /// <returns>The float at the given index</returns>
        public float this[uint index]
        {
            get
            {
                return ValueOfIndex(index);
            }
        }

        /// <summary>
        /// </summary>
        internal static Position GetPositionFromPtr(global::System.IntPtr cPtr)
        {
            Position ret = new Position(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public Position() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x component</param>
        /// <param name="y">y component</param>
        /// <param name="z">z component</param>
        public Position(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="position2d">Position2D to create this vector from</param>
        public Position(Position2D position2d) : this(NDalicPINVOKE.new_Vector3__SWIG_3(Position2D.getCPtr(position2d)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }



        private Position Add(Position rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Add(swigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract(Position rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Subtract__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(Position rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Multiply__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Multiply(float rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Multiply__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(Position rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Divide__SWIG_0(swigCPtr, Position.getCPtr(rhs)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Divide(float rhs)
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Divide__SWIG_1(swigCPtr, rhs), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private Position Subtract()
        {
            Position ret = new Position(NDalicPINVOKE.Vector3_Subtract__SWIG_1(swigCPtr), true);
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
        /// Compare if rhs is equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false</returns>
        public bool EqualTo(Position rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Compare if rhs is not equal to
        /// </summary>
        /// <param name="rhs">The vector to compare</param>
        /// <returns>Returns true if the two vectors are not equal, otherwise false</returns>
        public bool NotEqualTo(Position rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// x component
        /// </summary>
        public float X
        {
            set
            {
                NDalicPINVOKE.Vector3_X_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_X_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// y component
        /// </summary>
        public float Y
        {
            set
            {
                NDalicPINVOKE.Vector3_Y_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Y_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// z component
        /// </summary>
        public float Z
        {
            set
            {
                NDalicPINVOKE.Vector3_Z_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.Vector3_Z_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        public static float ParentOriginTop
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        public static float ParentOriginBottom
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.0.
        /// </summary>
        public static float ParentOriginLeft
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 1.0.
        /// </summary>
        public static float ParentOriginRight
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants. It's 0.5.
        /// </summary>
        public static float ParentOriginMiddle
        {
            get
            {
                float ret = NDalicPINVOKE.ParentOriginMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.0, 0.5
        /// </summary>
        public static Position ParentOriginTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.5, 0.0, 0.5
        /// </summary>
        public static Position ParentOriginTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.0, 0.5
        /// </summary>
        public static Position ParentOriginTopRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5
        /// </summary>
        public static Position ParentOriginCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0, 0.5, 0.5
        /// </summary>
        public static Position ParentOriginCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 0.5, 0.5
        /// </summary>
        public static Position ParentOriginCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.0f, 1.0f, 0.5f
        /// </summary>
        public static Position ParentOriginBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 0.5, 1.0, 0.5
        /// </summary>
        public static Position ParentOriginBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// ParentOrigin constants: 1.0, 1.0, 0.5
        /// </summary>
        public static Position ParentOriginBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.ParentOriginBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0
        /// </summary>
        public static float AnchorPointTop
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 1.0
        /// </summary>
        public static float AnchorPointBottom
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0
        /// </summary>
        public static float AnchorPointLeft
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 1.0
        /// </summary>
        public static float AnchorPointRight
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0
        /// </summary>
        public static float AnchorPointMiddle
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0, 0.0, 0.5
        /// </summary>
        public static Position AnchorPointTopLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.5, 0.0, 0.5
        /// </summary>
        public static Position AnchorPointTopCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 1.0, 0.0, 0.5
        /// </summary>
        public static Position AnchorPointTopRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0, 0.5, 0.5
        /// </summary>
        public static Position AnchorPointCenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.5, 0.5, 0.5
        /// </summary>
        public static Position AnchorPointCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 1.0, 0.5, 0.5
        /// </summary>
        public static Position AnchorPointCenterRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.0, 1.0, 0.5
        /// </summary>
        public static Position AnchorPointBottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 0.5, 1.0, 0.5
        /// </summary>
        public static Position AnchorPointBottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// AnchorPoint constants: 1.0, 1.0, 0.5
        /// </summary>
        public static Position AnchorPointBottomRight
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.AnchorPointBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Constant ( 1.0f, 1.0f, 1.0f )
        /// </summary>
        public static Position One
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ONE_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position XAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position YAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position ZAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeXAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeYAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Position NegativeZAxis
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_NEGATIVE_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Constant ( 0.0f, 0.0f, 0.0f )
        /// </summary>
        public static Position Zero
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Vector3_ZERO_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Convert a position instance to a vector3 instance.
        /// </summary>
        public static implicit operator Vector3(Position Position)
        {
            return new Vector3(Position.X, Position.Y, Position.Z);
        }

        /// <summary>
        /// Convert a vector3 instance to a position instance.
        /// </summary>
        public static implicit operator Position(Vector3 vec)
        {
            return new Position(vec.X, vec.Y, vec.Z);
        }
    }
}
