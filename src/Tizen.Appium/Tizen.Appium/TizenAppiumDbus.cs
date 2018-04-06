using System;
using System.Linq;
using System.Reflection;
using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    internal class TizenAppiumDbus : IDisposable
    {
        static DbusConnection _dbusConn;
        bool disposed = false;

        internal static DbusConnection Connection
        {
            get
            {
                if (_dbusConn == null)
                {
                    _dbusConn = new DbusConnection(DbusNames.BusName, DbusNames.ObjectPath, DbusNames.InterfaceName);
                }
                return _dbusConn;
            }
        }

        public TizenAppiumDbus()
        {
            Log.Debug("TizenAppiumDbus");

            InitializeDbus();
        }

        static void InitializeDbus()
        {
            Assembly asm = typeof(TizenAppiumDbus).GetTypeInfo().Assembly;
            Type methodType = typeof(IDbusMethod);

            var methods = from method in asm.GetTypes()
                          where methodType.IsAssignableFrom(method) && !method.GetTypeInfo().IsInterface && !method.GetTypeInfo().IsAbstract
                          select Activator.CreateInstance(method) as IDbusMethod;

            foreach (var method in methods)
            {
                Log.Debug("method:" + method);
                Connection.AddMethod(method);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Connection.Close();
            }
            disposed = true;
        }
    }
}
