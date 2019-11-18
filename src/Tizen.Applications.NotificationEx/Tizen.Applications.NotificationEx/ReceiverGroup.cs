using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        public static class ReceiverGroup
        {
            public static string Panel
            {
                get { return "tizen.org/receiver/panel"; }
            }

            public static string Ticker
            {
                get { return "tizen.org/receiver/ticker"; }
            }

            public static string Lockscreen
            {
                get { return "tizen.org/receiver/lockscreen"; }
            }

            public static string Indicator
            {
                get { return "tizen.org/receiver/indicator"; }
            }

            public static string Popup
            {
                get { return "tizen.org/receiver/popup"; }
            }
        }
    }
}
