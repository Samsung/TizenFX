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

namespace Tizen.NUI
{
    /// <summary>
    /// Extents class describing the a collection of uint16_t.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class Extents : global::System.IDisposable
    {

        /// <summary>
        /// Extents class
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected bool swigCMemOwn;

        /// <summary>
        /// A Flat to check if it is already disposed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected bool disposed = false;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        //A Flag to check who called Dispose(). (By User or DisposeQueue)
        private bool isDisposeQueued = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Extents() : this(Interop.Extents.new_Extents__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="copy">A reference to the copied Extents.</param>
        /// <since_tizen> 4 </since_tizen>
        public Extents(Extents copy) : this(Interop.Extents.new_Extents__SWIG_1(Extents.getCPtr(copy)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor.
        /// <param name="start">Start extent.</param>
        /// <param name="end">End extent.</param>
        /// <param name="top">Top extent.</param>
        /// <param name="bottom">Bottom extent.</param>
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Extents(ushort start, ushort end, ushort top, ushort bottom) : this(Interop.Extents.new_Extents__SWIG_2(start, end, top, bottom), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Extents(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~Extents()
        {
            if (!isDisposeQueued)
            {
                isDisposeQueued = true;
                DisposeQueue.Instance.Add(this);
            }
        }

        /// <summary>
        /// The Start extent.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ushort Start
        {
            set
            {
                Interop.Extents.Extents_start_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                ushort ret = Interop.Extents.Extents_start_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The End extend.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ushort End
        {
            set
            {
                Interop.Extents.Extents_end_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                ushort ret = Interop.Extents.Extents_end_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The Top extend.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ushort Top
        {
            set
            {
                Interop.Extents.Extents_top_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                ushort ret = Interop.Extents.Extents_top_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The Bottom Extend.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ushort Bottom
        {
            set
            {
                Interop.Extents.Extents_bottom_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                ushort ret = Interop.Extents.Extents_bottom_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// To make a Extents instance be disposed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
        /// Equality operator.
        /// </summary>
        /// <param name="rhs">The Extents to test against.</param>
        /// <returns>True if the extents are not equal.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool EqualTo(Extents rhs)
        {
            bool ret = Interop.Extents.Extents_EqualTo(swigCPtr, Extents.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="rhs">The Extents to test against.</param>
        /// <returns>True if the extents are not equal.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool NotEqualTo(Extents rhs)
        {
            bool ret = Interop.Extents.Extents_NotEqualTo(swigCPtr, Extents.getCPtr(rhs));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Extents obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal Extents Assign(SWIGTYPE_p_uint16_t array)
        {
            Extents ret = new Extents(Interop.Extents.Extents_Assign__SWIG_1(swigCPtr, SWIGTYPE_p_uint16_t.getCPtr(array)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Extents Assign(Extents copy)
        {
            Extents ret = new Extents(Interop.Extents.Extents_Assign__SWIG_0(swigCPtr, Extents.getCPtr(copy)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To make a Extents instance be disposed.
        /// </summary>
        /// <param name="type">Extents type</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
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
                    Interop.Extents.delete_Extents(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            disposed = true;
        }

    }

}
