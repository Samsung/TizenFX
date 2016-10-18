using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
