using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public static class ComplicationProviderSetup
    {
        public static bool IsEditing(ReceivedAppControl recvAppCtrl)
        {
            return false;
        }

        public static int ReplyToEditor(ReceivedAppControl recvAppCtrl, Bundle context)
        {
            return 0;
        }

        public static Bundle GetContext(ReceivedAppControl recvAppCtrl)
        {
            return null;
        }

    }
}
