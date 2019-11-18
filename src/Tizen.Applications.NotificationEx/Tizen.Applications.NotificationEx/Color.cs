using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Color
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            public Color(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            public Color(byte alpha, byte red, byte green, byte blue)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ColorCreate(out ptr, alpha, red, green, blue);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = ptr;
            }

            ~Color()
            {
                ErrorCode err = Interop.NotificationEx.ColorDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy Color : " + err);
            }

            public byte Red
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetRed(NativeHandle, out val);
                    return val;
                }
            }

            public byte Green
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetGreen(NativeHandle, out val);
                    return val;
                }
            }

            public byte Blue
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetBlue(NativeHandle, out val);
                    return val;
                }
            }

            public byte Alpha
            {
                get
                {
                    byte val;
                    Interop.NotificationEx.ColorGetAlpha(NativeHandle, out val);
                    return val;
                }
            }
        }
    }
}
