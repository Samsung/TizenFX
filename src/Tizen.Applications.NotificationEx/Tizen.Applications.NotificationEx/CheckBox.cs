using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class CheckBox : AbstractItem
        {
            public CheckBox(string id, string title, bool isChecked) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.CheckboxCreate(out handle, id, title, isChecked);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal CheckBox(IntPtr ptr) : base(ptr)
            {
            }

            public string Title
            {
                get
                {
                    string title;
                    Interop.NotificationEx.CheckboxGetTitle(NativeHandle, out title);
                    return title;
                }
            }

            public void SetMultiLanguageTitle(MultiLanguage title)
            {
                if (title == null)
                    Interop.NotificationEx.CheckboxSetMultiLanguage(NativeHandle, IntPtr.Zero);
                else
                    Interop.NotificationEx.CheckboxSetMultiLanguage(NativeHandle, title.NativeHandle);
            }

            public bool IsChecked
            {
                get
                {
                    bool isChecked;
                    Interop.NotificationEx.CheckboxGetCheckedState(NativeHandle, out isChecked);
                    return isChecked;
                }
                set
                {
                    Interop.NotificationEx.CheckboxSetCheckedState(NativeHandle, value);
                }
            }
        }
    }
}
