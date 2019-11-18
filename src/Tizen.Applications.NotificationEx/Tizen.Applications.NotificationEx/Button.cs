using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class Button : AbstractItem
        {
            public Button(string id, string title) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ButtonCreate(out handle, id, title);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal Button(IntPtr ptr) : base(ptr)
            {
            }

            public string Title
            {
                get
                {
                    string title;
                    Interop.NotificationEx.ButtonGetTitle(NativeHandle, out title);                    
                    return title;
                }
            }

            public void SetMultiLanguageTitle(MultiLanguage title)
            {
                if (title == null)
                    Interop.NotificationEx.ButtonSetMultiLanguageTitle(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.ButtonSetMultiLanguageTitle(NativeHandle, title.NativeHandle);
            }
        }
    }
}
