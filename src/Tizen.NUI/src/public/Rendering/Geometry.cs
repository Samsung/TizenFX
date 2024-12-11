/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    /// Geometry is handle to an object that can be used to define a geometric elements.
    /// The geometry is defined by VertexBuffer and IndexBuffer.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Geometry : BaseHandle
    {
        /// <summary>
        /// Create an instance of Geometry.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Geometry() : this(Interop.Geometry.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Geometry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>,
        /// Sets and gets PrimitiveType
        /// </summary>
        /// <remarks>
        /// The PremitiveType should be matched with Vertex and Index Buffer.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PrimitiveType PrimitiveType
        {
            get
            {
                return GetPrimitiveType();
            }
            set
            {
                SetPrimitiveType(value);
            }
        }

        /// <summary>
        /// Adds a VertexBuffer to be used as source of geometry vertices.
        /// </summary>
        /// <param name="vertexBuffer">VertexBuffer to be used as source of geometry vertices.</param>
        /// <returns>Index of the newly added buffer.</returns>
        /// <since_tizen> 8 </since_tizen>
        public uint AddVertexBuffer(VertexBuffer vertexBuffer)
        {
            uint ret = Interop.Geometry.AddVertexBuffer(SwigCPtr, VertexBuffer.getCPtr(vertexBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the number of vertex buffers that have been added to this geometry.
        /// </summary>
        /// <returns>Number of vertex buffers that have been added to this geometry.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetNumberOfVertexBuffers()
        {
            uint ret = Interop.Geometry.GetNumberOfVertexBuffers(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a vertex buffer.
        /// </summary>
        /// <param name="index">Index to the vertex buffer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveVertexBuffer(uint index)
        {
            Interop.Geometry.RemoveVertexBuffer(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a the index data to be used as a source of indices for the geometry
        /// Setting this buffer will cause the geometry to be rendered using indices.
        /// </summary>
        /// <param name="indices">Array of indices.</param>
        /// <param name="count">Number of indices in the array.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetIndexBuffer(ushort[] indices, uint count)
        {
            Interop.Geometry.SetIndexBuffer(SwigCPtr, indices, count);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets the type of primitives this geometry contains.
        /// </summary>
        /// <param name="primitiveType">Array of indices.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetPrimitiveType(PrimitiveType primitiveType)
        {
            Interop.Geometry.SetType(SwigCPtr, (int)primitiveType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the type of primitives this geometry contains.
        /// </summary>
        /// <returns>Type of primitives this geometry contains.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private PrimitiveType GetPrimitiveType()
        {
            PrimitiveType ret = (PrimitiveType)Interop.Geometry.GetType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Geometry.DeleteGeometry(swigCPtr);
        }
    }
}
