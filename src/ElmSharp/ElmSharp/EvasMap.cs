/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// The EvasMap is an opaque handle to map points.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EvasMap
    {
        IntPtr _evasMap;
        bool _ownership;

        /// <summary>
        /// Creates and initializes a new instance of the EvasMap class.
        /// </summary>
        /// <param name="count">The number of points in the map</param>
        /// <since_tizen> preview </since_tizen>
        public EvasMap(int count)
        {
            _evasMap = Interop.Evas.evas_map_new(count);
            _ownership = true;
        }

        internal EvasMap(IntPtr handle)
        {
            _evasMap = handle;
            _ownership = false;
        }

        /// <summary>
        /// Destructor for the EvasMap class.
        /// </summary>
        ~EvasMap()
        {
            if (_ownership)
            {
                Interop.Evas.evas_map_free(_evasMap);
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _evasMap;
            }
        }

        /// <summary>
        /// Gets or sets the flag of the object to move synchronization for map rendering.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsMoveSync
        {
            get
            {
                return Interop.Evas.evas_map_util_object_move_sync_get(_evasMap);
            }
            set
            {
                Interop.Evas.evas_map_util_object_move_sync_set(_evasMap, value);
            }
        }

        /// <summary>
        /// Populates the source and destination map points to exactly match the object.
        /// </summary>
        /// <param name="obj">The object to use unmapped geometry to populate the map coordinates.</param>
        /// <since_tizen> preview </since_tizen>
        public void PopulatePoints(EvasObject obj)
        {
            Interop.Evas.evas_map_util_points_populate_from_object_full(_evasMap, obj, 0);
        }

        /// <summary>
        /// Populates the source and destination map points to exactly match the object.
        /// </summary>
        /// <param name="obj">The object to use unmapped geometry to populate the map coordinates.</param>
        /// <param name="z">
        /// The point Z-coordinate hint (pre-perspective transform). This value is used for all the four points.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        public void PopulatePoints(EvasObject obj, int z)
        {
            Interop.Evas.evas_map_util_points_populate_from_object_full(_evasMap, obj, z);
        }

        /// <summary>
        /// Populates the source and destination map points to match the given geometry.
        /// </summary>
        /// <param name="geometry">The geometry value contains X-coordinate, Y-coordinate, the width and height to use, to calculate the second and third points.</param>
        /// <param name="z">The Z-coordinate hint (pre-perspective transform) This value is used for all the four points.</param>
        /// <since_tizen> preview </since_tizen>
        public void PopulatePoints(Rect geometry, int z)
        {
            Interop.Evas.evas_map_util_points_populate_from_geometry(_evasMap, geometry.X, geometry.Y, geometry.Width, geometry.Height, z);
        }

        /// <summary>
        /// Rotates the map.
        /// </summary>
        /// <param name="degrees">The abount of degrees from 0.0 to 360.0 to rotate.</param>
        /// <param name="cx">The rotation's center horizontal position.</param>
        /// <param name="cy">The rotation's center vertical position.</param>
        /// <since_tizen> preview </since_tizen>
        public void Rotate(double degrees, int cx, int cy)
        {
            Interop.Evas.evas_map_util_rotate(_evasMap, degrees, cx, cy);
        }

        /// <summary>
        /// Rotates the map around 3 axes in 3D.
        /// </summary>
        /// <param name="dx">The amount of degrees from 0.0 to 360.0 to rotate around the X-axis.</param>
        /// <param name="dy">The amount of degrees from 0.0 to 360.0 to rotate around the Y-axis.</param>
        /// <param name="dz">The amount of degrees from 0.0 to 360.0 to rotate around the Z-axis.</param>
        /// <param name="cx">The rotation's center horizontal position.</param>
        /// <param name="cy">The rotation's center vertical position.</param>
        /// <param name="cz">The rotation's center depth position.</param>
        /// <since_tizen> preview </since_tizen>
        public void Rotate3D(double dx, double dy, double dz, int cx, int cy, int cz)
        {
            Interop.Evas.evas_map_util_3d_rotate(_evasMap, dx, dy, dz, cx, cy, cz);
        }

        /// <summary>
        /// Changes the map point's coordinate.
        /// </summary>
        /// <param name="idx">The index of point to change, this must be smaller than the map size.</param>
        /// <param name="point">The 3D point coordinate.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetPointCoordinate(int idx, Point3D point)
        {
            Interop.Evas.evas_map_point_coord_set(_evasMap, idx, point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Gets the map point's coordinate.
        /// </summary>
        /// <param name="idx">The index of point to change, this must be smaller than the map size.</param>
        /// <returns>The coordinates of a given point in the map.</returns>
        /// <since_tizen> preview </since_tizen>
        public Point3D GetPointCoordinate(int idx)
        {
            Point3D point;
            Interop.Evas.evas_map_point_coord_get(_evasMap, idx, out point.X, out point.Y, out point.Z);
            return point;
        }

        /// <summary>
        /// Changes the map to apply the given zooming.
        /// </summary>
        /// <param name="x">The horizontal zoom to use.</param>
        /// <param name="y">The vertical zoom to use.</param>
        /// <param name="cx">The zooming center horizontal position.</param>
        /// <param name="cy">The zooming center vertical position.</param>
        /// <since_tizen> preview </since_tizen>
        public void Zoom(double x, double y, int cx, int cy)
        {
            Interop.Evas.evas_map_util_zoom(_evasMap, x, y, cx, cy);
        }
    }
}