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
    public class EvasMap
    {
        IntPtr _evasMap;
        bool _ownership;

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

        public void PopulatePoints(EvasObject obj, int z)
        {
            Interop.Evas.evas_map_util_points_populate_from_object_full(_evasMap, obj, z);
        }

        public void PopulatePoints(Rect geometry, int z)
        {
            Interop.Evas.evas_map_util_points_populate_from_geometry(_evasMap, geometry.X, geometry.Y, geometry.Width, geometry.Height, z);
        }

        public void Rotate3D(double dx, double dy, double dz, int cx, int cy, int cz)
        {
            Interop.Evas.evas_map_util_3d_rotate(_evasMap, dx, dy, dz, cx, cy, cz);
        }

        public void SetPointCoordinate(int idx, Point3D point)
        {
            Interop.Evas.evas_map_point_coord_set(_evasMap, idx, point.X, point.Y, point.Z);
        }

        public Point3D GetPointCoordinate(int idx)
        {
            Point3D point;
            Interop.Evas.evas_map_point_coord_get(_evasMap, idx, out point.X, out point.Y, out point.Z);
            return point;
        }

        public void Zoom(double x, double y, int cx, int cy)
        {
            Interop.Evas.evas_map_util_zoom(_evasMap, x, y, cx, cy);
        }
    }
}
