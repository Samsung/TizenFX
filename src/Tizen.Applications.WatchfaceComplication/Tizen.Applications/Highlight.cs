using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the Highlight class for the editable.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Highlight
    {
        private IntPtr _raw = IntPtr.Zero;

        /// <summary>
        /// Initializes the Highlight class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Highlight(ShapeType type, int x, int y, int w, int h)
        {
            ComplicationError ret = Interop.WatchfaceComplication.CreateHighlight(out _raw);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to create Highlight");
            }
            ret = Interop.WatchfaceComplication.SetHighlightGeometry(_raw, x, y, w, h);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to set Highlight");
            }
        }

        /// <summary>
        /// Sets geometry's x, y, w, h value.
        /// </summary>
        /// <param name="x">The editable geometry offset x.</param>
        /// <param name="y">The editable geometry offset y.</param>
        /// <param name="w">The editable geometry width.</param>
        /// <param name="h">The editable geometry height.</param>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationError SetGeometry(int x, int y, int w, int h)
        {
            return Interop.WatchfaceComplication.SetHighlightGeometry(_raw, x, y, w, h);
        }

        /// <summary>
        /// Destructor of the Highlight class.
        /// </summary>
        ~Highlight()
        {
            Interop.WatchfaceComplication.DestroyHighlight(_raw);
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

                ComplicationError ret = Interop.WatchfaceComplication.GetHighlightGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get Highlight");
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

                ComplicationError ret = Interop.WatchfaceComplication.GetHighlightGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get Highlight");
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

                ComplicationError ret = Interop.WatchfaceComplication.GetHighlightGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get Highlight");
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

                ComplicationError ret = Interop.WatchfaceComplication.GetHighlightGeometry(_raw, out x, out y, out w, out h);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get Highlight");
                }
                return h;
            }
        }
    }
}
