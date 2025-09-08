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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Geometry is handle to an object that can be used to define a geometric elements.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Geometry : BaseHandle
    {
        /// <summary>
        /// Enumeration for the description of the type of geometry,
        /// used to determine how the coordinates will be used.
        /// </summary>
        /// <returns>Type of primitives this geometry contains.</returns>
        /// <since_tizen> 3 </since_tizen>
        public enum Type
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// Individual points.
            /// </summary>
            POINTS,

            /// <summary>
            /// Individual lines (made of 2 points each).
            /// </summary>
            LINES,

            /// <summary>
            /// A strip of lines (made of 1 point each) which also joins the first and last point.
            /// </summary>
            LINE_LOOP,

            /// <summary>
            /// A strip of lines (made of 1 point each).
            /// </summary>
            LINE_STRIP,

            /// <summary>
            /// Individual triangles (made of 3 points each).
            /// </summary>
            TRIANGLES,

            /// <summary>
            /// A fan of triangles around a centre point (after the first triangle, following triangles need only 1 point).
            /// </summary>
            TRIANGLE_FAN,

            /// <summary>
            /// A strip of triangles (after the first triangle, following triangles need only 1 point).
            /// </summary>
            TRIANGLE_STRIP
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Adds a PropertyBuffer to be used as source of geometry vertices.
        /// </summary>
        /// <param name="vertexBuffer">PropertyBuffer to be used as source of geometry vertices.</param>
        /// <returns>Index of the newly added buffer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint AddVertexBuffer(PropertyBuffer vertexBuffer)
        {
            uint ret = Interop.Geometry.AddVertexBuffer(SwigCPtr, PropertyBuffer.getCPtr(vertexBuffer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the type of primitives this geometry contains.
        /// </summary>
        /// <param name="geometryType">Array of indices.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetType(Geometry.Type geometryType)
        {
            Interop.Geometry.SetType(SwigCPtr, (int)geometryType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the type of primitives this geometry contains.
        /// </summary>
        /// <returns>Type of primitives this geometry contains.</returns>
        /// <since_tizen> 3 </since_tizen>
        public new Geometry.Type GetType()
        {
            Geometry.Type ret = (Geometry.Type)Interop.Geometry.GetType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
