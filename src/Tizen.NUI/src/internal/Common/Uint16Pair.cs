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

namespace Tizen.NUI
{
    /// <summary>
    /// Simple class for passing around pairs of small unsigned integers.<br />
    /// Use this for integer dimensions and points with limited range such as image
    /// sizes and pixel coordinates where a pair of floating point numbers is
    /// inefficient and illogical (i.e.the data is inherently integer).<br />
    /// One of these can be passed in a single 32 bit integer register on
    /// common architectures.<br />
    /// </summary>
    internal class Uint16Pair : Disposable
    {

        internal Uint16Pair(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Uint16Pair obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Uint16Pair.DeleteUint16Pair(swigCPtr);
        }

        /// <summary>
        /// Less than comparison operator for storing in collections (not geometrically meaningful).
        /// </summary>
        /// <param name="arg1">A reference for comparison.</param>
        /// <param name="arg2">A reference for comparison</param>
        /// <return>True if arg1 less than arg2</return>
        public static bool operator <(Uint16Pair arg1, Uint16Pair arg2)
        {
            return arg1.LessThan(arg2);
        }

        /// <summary>
        /// More than comparison operator for storing in collections (not geometrically meaningful).
        /// </summary>
        /// <param name="arg1">A reference for comparison.</param>
        /// <param name="arg2">A reference for comparison</param>
        /// <return>True if arg1 > arg2</return>
        public static bool operator >(Uint16Pair arg1, Uint16Pair arg2)
        {
            return arg1.GreaterThan(arg2);
        }

        /// <summary>
        /// Default constructor for the(0, 0) tuple.
        /// </summary>
        public Uint16Pair() : this(Interop.Uint16Pair.NewUint16Pair(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Default constructor for the(0, 0) tuple.
        /// </summary>
        /// <param name="width">The width or X dimension of the tuple. Make sure it is less than 65536.</param>
        /// <param name="height">The height or Y dimension of the tuple.Make sure it is less than 65536.</param>
        public Uint16Pair(uint width, uint height) : this(Interop.Uint16Pair.NewUint16Pair(width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor taking separate x and y (width and height) parameters.
        /// </summary>
        /// <param name="rhs">A reference to assign.</param>
        public Uint16Pair(Uint16Pair rhs) : this(Interop.Uint16Pair.NewUint16Pair(Uint16Pair.getCPtr(rhs)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the width.
        /// </summary>
        /// <param name="width">The x dimension to be stored in this 2-tuple.</param>
        public void SetWidth(ushort width)
        {
            Interop.Uint16Pair.SetWidth(SwigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the width.
        /// </summary>
        /// <return>
        /// The x dimension stored in this 2-tuple.
        /// </return>
        public ushort GetWidth()
        {
            ushort ret = Interop.Uint16Pair.GetWidth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the height.
        /// </summary>
        /// <param name="height">The y dimension to be stored in this 2-tuple.</param>
        public void SetHeight(ushort height)
        {
            Interop.Uint16Pair.SetHeight(SwigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the height.
        /// </summary>
        /// <return>
        /// The y dimension stored in this 2-tuple.
        /// </return>
        public ushort GetHeight()
        {
            ushort ret = Interop.Uint16Pair.GetHeight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the x dimension.
        /// </summary>
        /// <param name="x">The x dimension to be stored in this 2-tuple.</param>
        public void SetX(ushort x)
        {
            Interop.Uint16Pair.SetX(SwigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the x dimension.
        /// </summary>
        /// <return>
        /// The x dimension stored in this 2-tuple.
        /// </return>
        public ushort GetX()
        {
            ushort ret = Interop.Uint16Pair.GetX(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the y dimension.
        /// </summary>
        /// <param name="y">The y dimension to be stored in this 2-tuple.</param>
        public void SetY(ushort y)
        {
            Interop.Uint16Pair.SetY(SwigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the y dimension.
        /// </summary>
        /// <return>
        /// The y dimension stored in this 2-tuple.
        /// </return>
        public ushort GetY()
        {
            ushort ret = Interop.Uint16Pair.GetY(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Constructor taking separate x and y (width and height) parameters.
        /// </summary>
        /// <param name="rhs">A reference to assign.</param>
        /// <return>The created object.</return>
        public Uint16Pair Assign(Uint16Pair rhs)
        {
            Uint16Pair ret = new Uint16Pair(Interop.Uint16Pair.Assign(SwigCPtr, Uint16Pair.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool EqualTo(Uint16Pair rhs)
        {
            bool ret = Interop.Uint16Pair.EqualTo(SwigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool NotEqualTo(Uint16Pair rhs)
        {
            bool ret = Interop.Uint16Pair.NotEqualTo(SwigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool LessThan(Uint16Pair rhs)
        {
            bool ret = Interop.Uint16Pair.LessThan(SwigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private bool GreaterThan(Uint16Pair rhs)
        {
            bool ret = Interop.Uint16Pair.GreaterThan(SwigCPtr, Uint16Pair.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
