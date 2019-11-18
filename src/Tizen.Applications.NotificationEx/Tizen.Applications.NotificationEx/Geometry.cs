using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Geometry
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            internal Geometry(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            public Geometry(int x, int y, int width, int height)
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.GeometryCreate(out handle, x, y, width, height);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = handle;
            }

            ~Geometry()
            {
                ErrorCode err = Interop.NotificationEx.GeometryDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy geometry : " + err);
            }

            public int X
            {
                get
                {
                    int x;
                    Interop.NotificationEx.GeometryGetX(NativeHandle, out x);
                    return x;
                }
            }

            public int Y
            {
                get
                {
                    int y;
                    Interop.NotificationEx.GeometryGetY(NativeHandle, out y);
                    return y;
                }
            }

            public int Width
            {
                get
                {
                    int width;
                    Interop.NotificationEx.GeometryGetWidth(NativeHandle, out width);
                    return width;
                }
            }

            public int Height
            {
                get
                {
                    int height;
                    Interop.NotificationEx.GeometryGetX(NativeHandle, out height);
                    return height;
                }
            }
        }
    }
}
