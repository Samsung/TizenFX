using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public static class ComplicationProviderTouchLaunch
    {
        public static bool IsTouchLaunch(ReceivedAppControl recvAppCtrl)
        {
            return false;
        }

        public static string GetProviderId(ReceivedAppControl recvAppCtrl)
        {
            return null;
        }

        public static ComplicationType GetComplicationType(ReceivedAppControl recvAppCtrl)
        {
            return ComplicationType.NoData;
        }

        public static Bundle GetContext(ReceivedAppControl recvAppCtrl)
        {
            return null;
        }
    }
}
