using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public abstract class AbstractAction
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            internal AbstractAction(IntPtr ptr)
            {
                NativeHandle = ptr;
            }

            ~AbstractAction()
            {
                ErrorCode err = Interop.NotificationEx.ActionDestroy(NativeHandle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy action : " + err);
            }

            internal IntPtr NativeHandle { get; set; }
            public bool IsLocal { get; private set; }
            public ActionType Type { get; private set; }
            public string Extra { get; private set; }
            public virtual void Execute(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);

                Interop.NotificationEx.ActionExecute(NativeHandle, item.NativeHandle);
            }
        }
    }
}
