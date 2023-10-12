/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// PointerConstraints is used when pointer is locked/unlocked
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PointerConstraints : Disposable
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PointerConstraints() : this(Interop.PointerConstraints.NewPointerConstraints(0, 0, false, false), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x">The x coordinate relative to window where event happened.</param>
        /// <param name="y">The y coordinate relative to window where event happened.</param>
        /// <param name="locked">The status whether pointer is locked/unlocked.</param>
        /// <param name="confined">The status whether pointer is confined/unconfined.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PointerConstraints(int x, int y, bool locked, bool confined): this(Interop.PointerConstraints.NewPointerConstraints(x, y, locked, confined), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PointerConstraints(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets the x, y position,
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position
        {
            get
            {
                return position;
            }
        }

        /// <summary>
        /// Gets the status whether pointer is locked/unlocked.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Locked
        {
            get
            {
                return locked;
            }
        }

        /// <summary>
        /// Gets the status whether pointer is confined/unconfined.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Confined
        {
            get
            {
                return confined;
            }
        }

        private Position2D position
        {
            get
            {
                Position2D ret = new Position2D(Interop.PointerConstraints.XGet(SwigCPtr), Interop.PointerConstraints.YGet(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private bool locked
        {
            get
            {
                bool ret = Interop.PointerConstraints.LockedGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private bool confined
        {
            get
            {
                bool ret = Interop.PointerConstraints.ConfinedGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static PointerConstraints GetPointerConstraintsFromPtr(global::System.IntPtr cPtr)
        {
            PointerConstraints ret = new PointerConstraints(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PointerConstraints.DeletePointerConstraints(swigCPtr);
        }
    }
}
