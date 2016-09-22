// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace ElmSharp
{
    /// <summary>
    /// A view used to draw a polygon (filled).
    /// </summary>
    public class Polygon : EvasObject
    {
        /// <summary>
        /// Create a new Polygon widget.
        /// <param name="p">The EvasObject to which the new Polygon will be attached as a child.</param>
        /// </summary>
        public Polygon (EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Adds a new vertex to the polygon.
        /// <param name="x">The X coordinate of the new vertex.</param>
        /// <param name="y">The Y coordinate of the new vertex.</param>
        /// </summary>
        public void AddPoint(int x, int y)
        {
            Interop.Evas.evas_object_polygon_point_add(Handle, x, y);
        }

        /// <summary>
        /// Adds a new vertex to the polygon.
        /// <param name="p">The coordinates of the new vertex.</param>
        /// </summary>
        public void AddPoint(Point p)
        {
            AddPoint(p.X, p.Y);
        }

        /// <summary>
        /// Removes all the vertices of the polygon, making it empty.
        /// </summary>
        public void ClearPoints()
        {
            Interop.Evas.evas_object_polygon_points_clear(Handle);
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.Evas.evas_object_evas_get(parent.Handle);
            return Interop.Evas.evas_object_polygon_add(evas);
        }
    }
}
