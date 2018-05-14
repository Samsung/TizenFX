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
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// Position is a three-dimensional vector.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Tizen.NUI.Binding.TypeConverter(typeof(PositionTypeConverter))]
    public class Position : global::System.IDisposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>
        /// swigCMemOwn
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        ~Position()
        {
            if(!isDisposeQueued)
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

            if(type == DisposeTypes.Explicit)
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
        /// An addition operator.
        /// </summary>
        /// <param name="arg1">The vector to add.</param>
        /// <param name="arg2">The vector to add.</param>
        /// <returns>The vector containing the result of the addition.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator +(Position arg1, Position arg2)
        {
            return arg1.Add(arg2);
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
            return arg1.Subtract(arg2);
        }

        /// <summary>
        /// The unary negation operator.
        /// </summary>
        /// <param name="arg1">The vector to negate.</param>
        /// <returns>The vector containg the negation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Position operator -(Position arg1)
        {
            return arg1.Subtract();
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
            return arg1.Multiply(arg2);
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
            return arg1.Multiply(arg2);
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
            return arg1.Divide(arg2);
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
            return arg1.Divide(arg2);
        }


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

        internal static Position GetPositionFromPtr(global::System.IntPtr cPtr)
        {
            Position ret = new Position(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position() : this(NDalicPINVOKE.new_Vector3__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        /// <since_tizen> 3 </since_tizen>
        public Position(float x, float y, float z) : this(NDalicPINVOKE.new_Vector3__SWIG_1(x, y, z), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="position2d">Position2D to create this vector from.</param>
        /// <since_tizen> 3 </since_tizen>
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
        /// Compares if rhs is equal to.
        /// </summary>
        /// <param name="rhs">The vector to compare.</param>
        /// <returns>Returns true if the two vectors are equal, otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool EqualTo(Position rhs)
        {
            bool ret = NDalicPINVOKE.Vector3_EqualTo(swigCPtr, Position.getCPtr(rhs));
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
            bool ret = NDalicPINVOKE.Vector3_NotEqualTo(swigCPtr, Position.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        /// <summary>
        /// The x component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The y component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The z component.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 0.0f, 1.0f, 0.5f.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 0.5, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// ParentOrigin constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointTop
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointBottom
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointLeft
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 1.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointRight
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float PivotPointMiddle
        {
            get
            {
                float ret = NDalicPINVOKE.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// PivotPoint constants: 0.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopLeft
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
        /// PivotPoint constants: 0.5, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopCenter
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
        /// PivotPoint constants: 1.0, 0.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointTopRight
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
        /// PivotPoint constants: 0.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterLeft
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
        /// PivotPoint constants: 0.5, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenter
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
        /// PivotPoint constants: 1.0, 0.5, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointCenterRight
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
        /// PivotPoint constants: 0.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomLeft
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
        /// PivotPoint constants: 0.5, 1.0, 0.5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomCenter
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
        /// PivotPoint constants: 1.0, 1.0, 0.5.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position PivotPointBottomRight
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
        /// Constant ( 1.0f, 1.0f, 1.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Constant ( 0.0f, 0.0f, 0.0f ).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Converts a position instance to a Vector3 instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Vector3(Position Position)
        {
            return new Vector3(Position.X, Position.Y, Position.Z);
        }

        /// <summary>
        /// Converts a Vector3 instance to a position instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static implicit operator Position(Vector3 vec)
        {
            return new Position(vec.X, vec.Y, vec.Z);
        }

    }
}