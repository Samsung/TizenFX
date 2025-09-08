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
    /// Simple class for window position pairs of  integers.
    /// Use this for integer position with window coordinates.
    /// </summary>
    internal class Int32Pair : Disposable
    {
        internal Int32Pair(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Int32Pair.DeleteInt32Pair(swigCPtr);
        }

        /// <summary>
        /// Default constructor for the(0, 0) tuple.
        /// </summary>
        public Int32Pair() : this(Interop.Int32Pair.NewInt32Pair(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Default constructor for the(0, 0) tuple.
        /// </summary>
        /// <param name="x">The X dimension of the tuple.</param>
        /// <param name="y">The Y dimension of the tuple.</param>
        public Int32Pair(int x, int y) : this(Interop.Int32Pair.NewInt32Pair(x, y), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the x dimension.
        /// </summary>
        /// <param name="x">The x dimension to be stored in this 2-tuple.</param>
        public void SetX(int x)
        {
            Interop.Int32Pair.SetX(SwigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the x dimension.
        /// </summary>
        /// <return>
        /// The x dimension stored in this 2-tuple.
        /// </return>
        public int GetX()
        {
            int ret = Interop.Int32Pair.GetX(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the y dimension.
        /// </summary>
        /// <param name="y">The y dimension to be stored in this 2-tuple.</param>
        public void SetY(int y)
        {
            Interop.Int32Pair.SetY(SwigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the y dimension.
        /// </summary>
        /// <return>
        /// The y dimension stored in this 2-tuple.
        /// </return>
        public int GetY()
        {
            int ret = Interop.Int32Pair.GetY(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
