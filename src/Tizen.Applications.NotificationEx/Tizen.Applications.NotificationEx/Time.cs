using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Time : AbstractItem
        {
            private DateTime _time;
            public Time(string id, DateTime time) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                Int32 nativeTime = Convert.ToInt32((time - new DateTime(1970, 1, 1)).TotalSeconds);
                ErrorCode err = Interop.NotificationEx.TimeCreate(out handle, id, nativeTime);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Time(IntPtr ptr) : base(ptr)
            {
            }

            internal override void Serialize()
            {
                base.Serialize();
                if (_time != null)
                    DateTime = _time;
            }

            public DateTime DateTime
            {
                get
                {
                    if (_time != null)
                        return _time;
                    Int32 time;
                    Interop.NotificationEx.TimeGetTime(NativeHandle, out time);
                    _time = new DateTime(1970, 1, 1).AddSeconds(time);
                    return _time;
                }
                private set
                {
                    Interop.NotificationEx.TimeSetTime(NativeHandle, (int)(value - new DateTime(1970, 1, 1)).TotalSeconds);
                    _time = value;
                }
            }
        }
    }
}
