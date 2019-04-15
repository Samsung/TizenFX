/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
    /// PropertyBuffer is a handle to an object that contains a buffer of structured properties.<br />
    /// PropertyBuffers can be used to provide data to Geometry objects.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PropertyBuffer : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Creates a PropertyBuffer.
        /// </summary>
        /// <param name="bufferFormat">The map of names and types that describes the components of the buffer.</param>
        /// <since_tizen> 3 </since_tizen>
        public PropertyBuffer(PropertyMap bufferFormat) : this(NDalicPINVOKE.PropertyBuffer_New(PropertyMap.getCPtr(bufferFormat)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal PropertyBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PropertyBuffer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Updates the whole buffer information.<br />
        /// This function expects a pointer to an array of structures with the same
        /// format that was given in the construction, and the number of elements to
        /// be the same as the size of the buffer.<br />
        /// </summary>
        /// <param name="data">A pointer to the data that will be copied to the buffer.</param>
        /// <param name="size">Number of elements to expand or contract the buffer.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetData(System.IntPtr data, uint size)
        {
            NDalicPINVOKE.PropertyBuffer_SetData(swigCPtr, data, size);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the number of elements in the buffer.
        /// </summary>
        /// <returns>Number of elements to expand or contract the buffer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetSize()
        {
            uint ret = NDalicPINVOKE.PropertyBuffer_GetSize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyBuffer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    NDalicPINVOKE.delete_PropertyBuffer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

    }

}