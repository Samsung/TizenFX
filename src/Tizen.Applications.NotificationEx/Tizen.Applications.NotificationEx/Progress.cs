using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Progress : AbstractItem
        {
            public Progress(string id, float min, float current, float max) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ProgressCreate(out handle, id, min, current, max);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Progress(IntPtr ptr) : base(ptr)
            {
            }

            public float Current
            {
                get
                {
                    float cur;
                    Interop.NotificationEx.ProgressGetCurrent(NativeHandle, out cur);
                    return cur;
                }
                set
                {
                    Interop.NotificationEx.ProgressSetCurrent(NativeHandle, value);
                }
            }

            public float Min
            {
                get
                {
                    float min;
                    Interop.NotificationEx.ProgressGetMin(NativeHandle, out min);
                    return min;
                }
            }

            public float Max
            {
                get
                {
                    float max;
                    Interop.NotificationEx.ProgressGetMax(NativeHandle, out max);
                    return max;
                }
            }

            public ProgressType Type
            {
                get
                {
                    int nativeType;
                    Interop.NotificationEx.ProgressGetType(NativeHandle, out nativeType);
                    return (ProgressType)nativeType;
                }
                set
                {
                    Interop.NotificationEx.ProgressSetType(NativeHandle, (int)value);
                }
            }
        }
    }
}
