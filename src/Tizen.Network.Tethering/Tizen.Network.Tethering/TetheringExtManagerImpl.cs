using System;

namespace Tizen.Network.Tethering
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Tethering";
    }

    internal partial class TetheringExtManagerImpl : IDisposable
    {
        private static readonly Lazy<TetheringExtManagerImpl> _instance =
            new Lazy<TetheringExtManagerImpl>(() => new TetheringExtManagerImpl());

        private string PrivilegeNetworkGet = "http://tizen.org/privilege/network.get";
        private string PrivilegeNetworkProfile = "http://tizen.org/privilege/tethering.admin";
        private IntPtr _handle;
        private bool _disposed = false;

        internal bool Enabled
        {
            get
            {
                bool enabled = false;
                int ret = Interop.TetheringExt.IsEnabled(GetHandle(), out enabled);
                CheckReturnValue(ret, "Enabled", PrivilegeNetworkProfile);
                return enabled;
            }
        }

        internal string Ssid
        {
            set
            {
                Log.Info(Globals.LogTag, "SetSSID");
                int ret = Interop.TetheringExt.SetSSID(GetHandle(), value);
                CheckReturnValue(ret, "SetSSID", PrivilegeNetworkProfile);
            }
        }

        internal string Passphrase
        {
            set
            {
                Log.Info(Globals.LogTag, "SetPassphrase");
                int ret = Interop.TetheringExt.SetPassphrase(GetHandle(), value);
                CheckReturnValue(ret, "SetPassphrase", PrivilegeNetworkProfile);
            }
        }

        internal int Channel
        {
            get
            {
                Log.Info(Globals.LogTag, "GetChannel");
                int channel = 0;
                int ret = Interop.TetheringExt.GetChannel(GetHandle(), out channel);
                CheckReturnValue(ret, "GetChannel", PrivilegeNetworkGet);
                return channel;
            }

            set
            {
                Log.Info(Globals.LogTag, "SetChannel");
                int ret = Interop.TetheringExt.SetChannel(GetHandle(), value);
                CheckReturnValue(ret, "SetChannel", PrivilegeNetworkProfile);
            }
        }

        internal static TetheringExtManagerImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private TetheringExtManagerImpl()
        {
            Log.Info(Globals.LogTag, "TetheringExtManagerImpl constructor");
            _handle = IntPtr.Zero;
        }

        ~TetheringExtManagerImpl()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            Log.Info(Globals.LogTag, "TetheringExtManagerImpl Handle HashCode: " + _handle.GetHashCode());
            int ret = Interop.TetheringExt.Deinitialize(_handle);
            if (ret == (int)TetheringError.None)
            {
                _handle = IntPtr.Zero;
            }
            _disposed = true;
        }

        internal IntPtr GetHandle()
        {
            if (_handle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Tethering extension not initialized");
            }
            return _handle;
        }

        internal void Initialize()
        {
            IntPtr handle;
            Log.Info(Globals.LogTag, "PInvoke tethering_ext_initialize");
            int ret = Interop.TetheringExt.Initialize(out handle);
            CheckReturnValue(ret, "Initialize", PrivilegeNetworkProfile);
            _handle = handle;
        }

        internal void Activate()
        {
            Log.Info(Globals.LogTag, "Activate");
            int ret = Interop.TetheringExt.Activate(GetHandle());
            CheckReturnValue(ret, "Activate", PrivilegeNetworkProfile);
        }

        internal void DeActivate()
        {
            Log.Info(Globals.LogTag, "DeActivate");
            int ret = Interop.TetheringExt.DeActivate(GetHandle());
            CheckReturnValue(ret, "DeActivate", PrivilegeNetworkProfile);
        }

        public TetheringInfo GetTetheringInfo()
        {
            Log.Info(Globals.LogTag, "GetTetheringInfo");
            IntPtr tetheringInfoPtr;
            int ret = Interop.TetheringExt.GetTetheringInfo(GetHandle(), out tetheringInfoPtr);
            CheckReturnValue(ret, "GetTetheringInfo", PrivilegeNetworkGet);
            TetheringInfo tetheringInfo = new TetheringInfo(tetheringInfoPtr);
            return tetheringInfo;
        }

        public int Security
        {
            get
            {
                Log.Info(Globals.LogTag, "Security");
                int security = 0;
                int ret = Interop.TetheringExt.GetSecurity(GetHandle(), out security);
                CheckReturnValue(ret, "Security", PrivilegeNetworkGet);
                return security;
            }
        }

        public int Visibility
        {
            get
            {
                Log.Info(Globals.LogTag, "Visibility");
                int visibility = 0;
                int ret = Interop.TetheringExt.GetVisibility(GetHandle(), out visibility);
                CheckReturnValue(ret, "Visibility", PrivilegeNetworkGet);
                return visibility;
            }
        }

        public bool Sharing
        {
            get
            {
                Log.Info(Globals.LogTag, "Sharing");
                bool sharing = false;
                int ret = Interop.TetheringExt.GetSharing(GetHandle(), out sharing);
                CheckReturnValue(ret, "Sharing", PrivilegeNetworkGet);
                return sharing;
            }
        }

        private void CheckReturnValue(int ret, string method, string privilege)
        {
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, method + " Fail, Error - " + (TetheringError)ret);
                TetheringErrorFactory.ThrowTetheringException(ret, privilege);
            }
        }
    }
}
