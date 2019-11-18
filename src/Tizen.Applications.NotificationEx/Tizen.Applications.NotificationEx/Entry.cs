using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Entry : AbstractItem
        {
            public Entry(string id) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.EntryCreate(out handle, id);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Entry(IntPtr ptr) : base(ptr)
            {
            }

            public string Text
            {
                get
                {
                    string text;
                    Interop.NotificationEx.EntryGetText(NativeHandle, out text);
                    return text;
                }
                set
                {
                    Interop.NotificationEx.EntrySetText(NativeHandle, value);
                }
            }

            public void SetMultiLanguage(MultiLanguage multi)
            {
                if (multi == null)
                    Interop.NotificationEx.EntrySetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.EntrySetMultiLanguage(NativeHandle, multi.NativeHandle);
            }
        }
    }
}
