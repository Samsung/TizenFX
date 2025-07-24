using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Network.TetheringExt
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.TetheringExt";
    }

    internal class HandleHolder
    {
        private SafeTetheringExtManagerHandle _handle;

        internal HandleHolder()
        {
            _handle = TetheringExtManagerImpl.Instance.Initialize();
            Log.Info(Globals.LogTag, "Handle: " + _handle);
        }

        internal SafeTetheringExtManagerHandle GetSafeHandle()
        {
            Log.Debug(Globals.LogTag, "HandleHolder safehandle = " +  _handle);
            return _handle;
        }
    }

    internal partial class TetheringExtManagerImpl
    {
        private static readonly Lazy<TetheringExtManagerImpl> _instance =
            new Lazy<TetheringExtManagerImpl>(() => new TetheringExtManagerImpl());

        private bool _enabled = false;
        private int _ssid;
        private string _passphrase;
        private int _channel;

        internal static TetheringExtManagerImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private static HandleHolder _handle = new HandleHolder();

        private TetheringExtManagerImpl()
        {
            Log.Info(Globals.LogTag, "TetheringExtManagerImpl constructor");
        }

        internal SafeTetheringExtManagerHandle GetSafeHandle()
        {
            return _handle.GetSafeHandle();
        }

        internal SafeTetheringExtManagerHandle Initialize()
        {
            return null;
        }
    }
}
