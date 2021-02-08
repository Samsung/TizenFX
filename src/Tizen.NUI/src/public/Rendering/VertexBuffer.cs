/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// VertexBuffer is a handle to an object that contains a buffer of structured data.<br />
    /// VertexBuffers can be used to provide data to Geometry objects.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class VertexBuffer : BaseHandle
    {

        /// <summary>
        /// Creates a VertexBuffer.
        /// </summary>
        /// <param name="bufferFormat">The map of names and types that describes the components of the buffer.</param>
        /// <since_tizen> 8 </since_tizen>
        public VertexBuffer(PropertyMap bufferFormat) : this(Interop.VertexBuffer.New(PropertyMap.getCPtr(bufferFormat)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VertexBuffer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Updates the whole buffer information.<br />
        /// This function expects an array of structures with the same format that was given in the construction.
        /// </summary>
        /// <param name="vertices">The vertex data that will be copied to the buffer.</param>
        /// <exception cref="ArgumentNullException"> Thrown when vertices is null. </exception>
        /// <since_tizen> 8 </since_tizen>

        public void SetData<VertexType>(VertexType[] vertices) where VertexType : struct
        {
            if (null == vertices)
            {
                throw new ArgumentNullException(nameof(vertices));
            }

            int structSize = Marshal.SizeOf<VertexType>();
            global::System.IntPtr buffer = Marshal.AllocHGlobal(structSize * vertices.Length);

            for (int i = 0; i < vertices.Length; i++)
            {
                Marshal.StructureToPtr(vertices[i], buffer + i * structSize, true);
            }

            Interop.VertexBuffer.SetData(SwigCPtr, buffer, (uint)vertices.Length);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the number of elements in the buffer.
        /// </summary>
        /// <returns>Number of elements in the buffer.</returns>
        /// <since_tizen> 8 </since_tizen>
        public uint GetSize()
        {
            uint ret = Interop.VertexBuffer.GetSize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(VertexBuffer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VertexBuffer.DeleteVertexBuffer(swigCPtr);
        }
    }
}
