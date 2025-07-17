using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Network.Tethering
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Tethering";
    }

    internal class HandleHolder
    {
        private SafeTetheringManagerHandle _handle;

        internal HandleHolder()
        {
            _handle = TetheringManagerImpl.Instance.Initialize();
            Log.Info(Globals.LogTag, "Handle: " + _handle);
        }

        internal SafeTetheringManagerHandle GetSafeHandle()
        {
            Log.Debug(Globals.LogTag, "HandleHolder safehandle = " +  _handle);
            return _handle;
        }
    }

    internal partial class TetheringManagerImpl
    {
        private static readonly Lazy<TetheringManagerImpl> _instance =
            new Lazy<TetheringManagerImpl>(() => new TetheringManagerImpl());

        private bool _enabled = false;
        private int _ssid;
        private string _passphrase;
        private int _channel;

        internal static TetheringManagerImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private static HandleHolder _handle = new HandleHolder();

        private TetheringManagerImpl()
        {
            Log.Info(Globals.LogTag, "TetheringManagerImpl constructor");
        }

        internal SafeTetheringManagerHandle GetSafeHandle()
        {
            return _handle.GetSafeHandle();
        }

        internal SafeTetheringManagerHandle Initialize()
        {
            return null;
        }
    }
}