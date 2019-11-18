using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    internal class DefaultItemFactory : IItemFactory
    {
        internal DefaultItemFactory()
        {
        }

        public NotificationEx.AbstractItem CreateItem(IntPtr nativeHandle)
        {
            int nativeType;

            Interop.NotificationEx.ItemGetType(nativeHandle, out nativeType);
            switch ((ItemType)nativeType)
            {
                case ItemType.Button:
                    return new NotificationEx.Button(nativeHandle);
                case ItemType.ChatMessage:
                    return new NotificationEx.ChatMessage(nativeHandle);
                case ItemType.CheckBox:
                    return new NotificationEx.CheckBox(nativeHandle);
                case ItemType.Group:
                    return new NotificationEx.Group(nativeHandle);
                case ItemType.Image:
                    return new NotificationEx.Image(nativeHandle);
                case ItemType.InputSelector:
                    return new NotificationEx.InputSelector(nativeHandle);
                case ItemType.Progress:
                    return new NotificationEx.Progress(nativeHandle);
                case ItemType.Text:
                    return new NotificationEx.Text(nativeHandle);
                case ItemType.Time:
                    return new NotificationEx.Time(nativeHandle);
            }
            return null;
        }
    }
}
