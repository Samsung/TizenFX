using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class VisibilityAction : AbstractAction
        {
            public VisibilityAction(AppControl control, string extra) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ActionVisibilityCreate(out handle, extra);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            public VisibilityAction(IntPtr handle) : base(handle)
            {
            }

            public void SetVisibility(string id, bool visible)
            {
                Interop.NotificationEx.ActionVisibilitySet(NativeHandle, id, visible);
            }
        }
    }
}
