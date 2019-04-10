/* Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// [Draft] This class implements a absolute layout, allowing explicit positioning of children.
    ///  Positions are from the top left of the layout and can be set using the Actor::Property::POSITION and alike.
    /// </summary>
    internal class AbsoluteLayout : LayoutGroupWrapper
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal AbsoluteLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AbsoluteLayout.AbsoluteLayout_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AbsoluteLayout obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
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
                    Interop.AbsoluteLayout.delete_AbsoluteLayout(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
            base.Dispose(type);
        }

        /// <summary>
        /// [Draft] Creates a AbsoluteLayout object.
        /// </summary>
        public AbsoluteLayout() : this(Interop.AbsoluteLayout.AbsoluteLayout_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [Draft] Downcasts a handle to a AbsoluteLayout handle.
        /// If handle points to a AbsoluteLayout, the downcast produces a valid handle.
        /// If not, the returned handle is left uninitialized.
        /// </summary>
        /// <param name="handle">handle to an object</param>
        /// <returns>Handle to a AbsoluteLayout or an uninitialized handle</returns>
        internal static AbsoluteLayout DownCast(BaseHandle handle)
        {
            AbsoluteLayout ret = new AbsoluteLayout(Interop.AbsoluteLayout.AbsoluteLayout_DownCast(BaseHandle.getCPtr(handle)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Draft] Copy constructor
        /// </summary>
        /// <param name="other"></param>
        internal AbsoluteLayout(AbsoluteLayout other) : this(Interop.AbsoluteLayout.new_AbsoluteLayout__SWIG_1(AbsoluteLayout.getCPtr(other)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal AbsoluteLayout Assign(AbsoluteLayout other)
        {
            AbsoluteLayout ret = new AbsoluteLayout(Interop.AbsoluteLayout.AbsoluteLayout_Assign(swigCPtr, AbsoluteLayout.getCPtr(other)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal enum PropertyRange
        {
            CHILD_PROPERTY_START_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX,
            CHILD_PROPERTY_END_INDEX = PropertyRanges.CHILD_PROPERTY_REGISTRATION_START_INDEX + 1000
        }

    }

}
