using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class LEDInfo
        {
            private Color _color;
            internal IntPtr NativeHandle { get; set; }

            internal LEDInfo(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            public LEDInfo(Color color)
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.LEDInfoCreate(out handle, color.NativeHandle);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            ~LEDInfo()
            {
                ErrorCode err = Interop.NotificationEx.LEDInfoDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy LEDInfo");
            }

            public int OnPeriod
            {
                get
                {
                    int period;
                    Interop.NotificationEx.LEDInfoGetOnPeriod(NativeHandle, out period);
                    return period;
                }
                set
                {
                    Interop.NotificationEx.LEDInfoSetOnPeriod(NativeHandle, value);
                }
            }

            public int OffPeriod
            {
                get
                {
                    int period;
                    Interop.NotificationEx.LEDInfoGetOffPeriod(NativeHandle, out period);
                    return period;
                }
                set
                {
                    Interop.NotificationEx.LEDInfoSetOffPeriod(NativeHandle, value);
                }
            }

            public Color Color
            {
                get
                {
                    if (_color != null)
                        return _color;
                    IntPtr handle;
                    ErrorCode err = Interop.NotificationEx.LEDInfoGetColor(NativeHandle, out handle);
                    if (err != ErrorCode.None)
                        ErrorFactory.ThrowException(err);
                    _color = new Color(handle);
                    return _color;
                }
                private set
                {
                    if (value == null)
                        Interop.NotificationEx.LEDInfoSetColor(NativeHandle, IntPtr.Zero);
                    else
                        Interop.NotificationEx.LEDInfoSetColor(NativeHandle, value.NativeHandle);
                    _color = value;
                }
            }
        }
    }
}
