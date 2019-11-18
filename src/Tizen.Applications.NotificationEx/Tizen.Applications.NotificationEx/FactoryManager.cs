using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Interop.NotificationEx;

namespace Tizen.Applications.NotificationEx
{
    internal class FactoryManager
    {
        static private IItemFactory _factory;

        private FactoryManager()
        {
        }

        public static NotificationEx.AbstractItem CreateItem(IntPtr ptr)
        {
            if (_factory == null)
            {
                _factory = new DefaultItemFactory();
            }
            return _factory.CreateItem(ptr);
        }
    }
}
