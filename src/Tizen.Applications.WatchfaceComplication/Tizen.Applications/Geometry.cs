using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Geometry class for the editable.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Geometry
    {
        private IntPtr _raw = IntPtr.Zero;

        /// <summary>
        /// Initializes the Geometry class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public Geometry(int x, int y, int w, int h)
        {
            ComplicationError ret = Interop.WatchfaceComplication.CreateGeometry(out _raw);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to create geometry");
            }
            ret = Interop.WatchfaceComplication.SetGeometry(_raw, x, y, w, h);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to set geometry");
            }
        }

        /// <summary>
        /// Destructor of the Geometry class.
        /// </summary>
        ~Geometry()
        {
            Interop.WatchfaceComplication.DestroyGeometry(_raw);
        }

        internal IntPtr Raw
        {
            get
            {
                return _raw;
            }
        }

        /// <summary>
        /// The x coordinate.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int X
        {
            get
            {
                int x;
                int y;
                int w;
                int h;

                ComplicationError ret = Interop.WatchfaceComplication.GetGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get geometry");
                }
                return x;
            }
        }

        /// <summary>
        /// The y coordinate.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int Y
        {
            get
            {
                int x;
                int y;
                int w;
                int h;

                ComplicationError ret = Interop.WatchfaceComplication.GetGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get geometry");
                }
                return y;
            }
        }

        /// <summary>
        /// The width of editable.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int W
        {
            get
            {
                int x;
                int y;
                int w;
                int h;

                ComplicationError ret = Interop.WatchfaceComplication.GetGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get geometry");
                }
                return w;
            }
        }

        /// <summary>
        /// The height of editable.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public int H
        {
            get
            {
                int x;
                int y;
                int w;
                int h;

                ComplicationError ret = Interop.WatchfaceComplication.GetGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get geometry");
                }
                return h;
            }
        }
    }
}
