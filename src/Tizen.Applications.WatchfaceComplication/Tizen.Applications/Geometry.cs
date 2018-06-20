using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public class Geometry
    {
        private IntPtr _raw;

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

        public IntPtr Raw
        {
            get
            {
                return _raw;
            }
        }

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


        ~Geometry()
        {
            Interop.WatchfaceComplication.DestroyGeometry(_raw);            
        }
    }
}
