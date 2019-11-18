using System;
using System.Collections.Generic;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class MultiLanguage
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal IntPtr NativeHandle { get; set; }

            public MultiLanguage(string msgid, string format, params object[] args)
            {
                IntPtr handle;

                ErrorCode err = Interop.NotificationEx.MultiLanguageCreate(out handle, msgid, format, args);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                NativeHandle = handle;
            }

            ~MultiLanguage()
            {
                ErrorCode err = Interop.NotificationEx.MultiLanguageDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy multi language");
            }
        }
    }
}
