using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    internal interface IItemFactory
    {
        NotificationEx.AbstractItem CreateItem(IntPtr nativeHandle);
    }
}
