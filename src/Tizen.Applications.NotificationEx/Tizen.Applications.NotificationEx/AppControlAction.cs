using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public class AppControlAction : AbstractAction
        {
            public AppControlAction(AppControl control, string extra) : base(((Func<IntPtr>)(delegate ()
            {
                IntPtr handle;
                ErrorCode err = Interop.NotificationEx.ActionAppControlCreate(
                    out handle, control.SafeAppControlHandle.DangerousGetHandle(), extra);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return handle;
            }))())
            {
            }

            internal AppControlAction(IntPtr handle) : base(handle)
            {
            }
        }
    }
}
