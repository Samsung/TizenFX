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
        /// <param name="type">The highlight shape type.</param>
        /// <param name="x">The highlight geometry x.</param>
        /// <param name="y">The highlight geometry y.</param>
        /// <param name="w">The highlight geometry w.</param>
        /// <param name="h">The highlight geometry h.</param>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
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
                ErrorFactory.ThrowException(ret, "Fail to set Highlight geometry");
            }
            ret = Interop.WatchfaceComplication.SetHighlightShapeType(_raw, type);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Fail to set Highlight type");
            }
        }

        /// <summary>
        /// Sets highlight's x, y, w, h value.
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
        /// Sets highlight's shape type value.
        /// </summary>
        /// <param name="type">The editable shape type.</param>
        /// <since_tizen> 5 </since_tizen>
        public ComplicationError SetType(ShapeType type)
        {
            return Interop.WatchfaceComplication.SetHighlightShapeType(_raw, type);
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
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
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
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
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
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
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
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
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

        /// <summary>
        /// The shape of editable.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 5 </since_tizen>
        public ShapeType ShapeType
        {
            get
            {
                ShapeType type;
                ComplicationError ret = Interop.WatchfaceComplication.GetHighlightShapeType(_raw, out type);
                if (ret != ComplicationError.None)
                {
                    ErrorFactory.ThrowException(ret, "Fail to get Highlight");
                }
                return type;
            }
        }
    }
}
