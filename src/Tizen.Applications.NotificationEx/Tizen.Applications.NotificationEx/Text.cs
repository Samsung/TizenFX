using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Text : AbstractItem
        {
            public Text(string id, string contents, string hyperlink) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.TextCreate(out handle, id, contents, hyperlink);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Text(IntPtr ptr) : base(ptr)
            {
            }

            string Contents
            {
                get
                {
                    string contents;
                    Interop.NotificationEx.TextGetContents(NativeHandle, out contents);                    
                    return contents;
                }
                set
                {
                    Interop.NotificationEx.TextSetContents(NativeHandle, value);                    
                }
            }

            public void SetMultiLanguage(MultiLanguage multi)
            {
                if (multi == null)
                    Interop.NotificationEx.TextSetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.TextSetMultiLanguage(NativeHandle, multi.NativeHandle);
            }
        }
    }
}
