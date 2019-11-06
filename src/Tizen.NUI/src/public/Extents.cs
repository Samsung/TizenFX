/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Extents class describing the a collection of uint16_t.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [TypeConverter(typeof(ExtentsTypeConverter))]
    public class Extents : Disposable
    {

        /// <summary>
        /// Extents class
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected bool swigCMemOwn;

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

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
        /// Constructor
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <since_tizen> Only used by Tizen.NUI.Components, will not be opened </since_tizen>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Extents(ExtentsChangedCallback cb, ushort start, ushort end, ushort top, ushort bottom) : this(Interop.Extents.new_Extents__SWIG_2(start, end, top, bottom), true)
        {
            callback = cb;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy other extents
        /// </summary>
        /// <param name="that"></param>
        /// <since_tizen> Only used by Tizen.NUI.Components, will not be opened </since_tizen>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void CopyFrom(Extents that)
        {
            Interop.Extents.Extents_start_set(swigCPtr, that.Start);
            Interop.Extents.Extents_end_set(swigCPtr, that.End);
            Interop.Extents.Extents_top_set(swigCPtr, that.Top);
            Interop.Extents.Extents_bottom_set(swigCPtr, that.End);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        /// <since_tizen> Only used by Tizen.NUI.Components, will not be opened </since_tizen>
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public delegate void ExtentsChangedCallback(ushort start, ushort end, ushort top, ushort bottom);
        private ExtentsChangedCallback callback = null;

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

                callback?.Invoke(Start, End, Top, Bottom);
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

                callback?.Invoke(Start, End, Top, Bottom);
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

                callback?.Invoke(Start, End, Top, Bottom);
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

                callback?.Invoke(Start, End, Top, Bottom);
            }
            get
            {
                ushort ret = Interop.Extents.Extents_bottom_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
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
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
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
            base.Dispose(type);
        }
    }
}
