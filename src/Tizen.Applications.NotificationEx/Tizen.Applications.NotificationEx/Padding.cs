using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Padding
        {
            internal IntPtr NativeHandle { get; set; }

            internal Padding(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            public Padding(int left, int top, int right, int bottom)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.PaddingCreate(out ptr, left, top, right, bottom);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = ptr;
            }

            public int Left
            {
                get
                {
                    int left;
                    Interop.NotificationEx.PaddingGetLeft(NativeHandle, out left);
                    return left;
                }
            }

            public int Top
            {
                get
                {
                    int top;
                    Interop.NotificationEx.PaddingGetTop(NativeHandle, out top);
                    return top;
                }
            }

            public int Right
            {
                get
                {
                    int right;
                    Interop.NotificationEx.PaddingGetRight(NativeHandle, out right);
                    return right;
                }
            }

            public int Bottom
            {
                get
                {
                    int bottom;
                    Interop.NotificationEx.PaddingGetBottom(NativeHandle, out bottom);
                    return bottom;
                }
            }
        }
    }
}
