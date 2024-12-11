// Copyright (c) 2025 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for the description of the type of primitive mesh,
    /// used to determine how the coordinates will be used.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PrimitiveType
    {
        /// <summary>
        /// Individual points.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Points,

        /// <summary>
        /// Individual lines (made of 2 points each).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Lines,

        /// <summary>
        /// A strip of lines (made of 1 point each) which also joins the first and last point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LineLoop,

        /// <summary>
        /// A strip of lines (made of 1 point each).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        LineStrip,

        /// <summary>
        /// Individual triangles (made of 3 points each).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Triangles,

        /// <summary>
        /// A fan of triangles around a centre point (after the first triangle, following triangles need only 1 point).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TriangleFan,

        /// <summary>
        /// A strip of triangles (after the first triangle, following triangles need only 1 point).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TriangleStrip
    }
}