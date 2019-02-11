/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// The Polygon is a widget that is used to draw a polygon (filled).
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class Polygon : EvasObject
    {
        /// <summary>
        /// Creates and initializes a new instance of the Polygon class.
        /// <param name="parent">The EvasObject to which the new Polygon will be attached as a child.</param>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Polygon(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Adds a new vertex to the polygon.
        /// <param name="x">The X-coordinate of the new vertex.</param>
        /// <param name="y">The Y-coordinate of the new vertex.</param>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void AddPoint(int x, int y)
        {
            Interop.Evas.evas_object_polygon_point_add(Handle, x, y);
        }

        /// <summary>
        /// Adds a new vertex to the polygon.
        /// <param name="p">The coordinates of the new vertex.</param>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void AddPoint(Point p)
        {
            AddPoint(p.X, p.Y);
        }

        /// <summary>
        /// Removes all the vertices of the polygon, making it empty.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void ClearPoints()
        {
            Interop.Evas.evas_object_polygon_points_clear(Handle);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.Evas.evas_object_evas_get(parent.Handle);
            return Interop.Evas.evas_object_polygon_add(evas);
        }
    }
}
