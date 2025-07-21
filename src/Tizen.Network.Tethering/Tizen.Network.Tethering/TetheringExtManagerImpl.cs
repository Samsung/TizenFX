using System;

namespace Tizen.Network.Tethering
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Tethering";
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

        // TODO: change these two values
        private string PrivilegeNetworkGet = "...";
        private string PrivilegeNetworkProfile = "...";

        internal bool Enabled
        {
            get
            {
                bool enabled = false;
                int ret = Interop.TetheringExt.IsEnabled(GetSafeHandle(), out enabled);
                CheckReturnValue(ret, "Enabled", PrivilegeNetworkGet);
                return enabled;
            }
        }

        internal void SetSSID(string ssid)
        {
            Log.Info(Globals.LogTag, "SetSSID");
            int ret = Interop.TetheringExt.SetSSID(GetSafeHandle(), ssid);
            CheckReturnValue(ret, "SetSSID", PrivilegeNetworkGet);
        }

        internal void SetPassphrase(string passphrase)
        {
            Log.Info(Globals.LogTag, "SetPassphrase");
            int ret = Interop.TetheringExt.SetPassphrase(GetSafeHandle(), passphrase);
            CheckReturnValue(ret, "SetPassphrase", PrivilegeNetworkGet);
        }

        internal int Channel
        {
            get
            {
                Log.Info(Globals.LogTag, "GetChannel");
                int channel = 0;
                int ret = Interop.TetheringExt.GetChannel(GetSafeHandle(), out channel);
                CheckReturnValue(ret, "GetChannel", PrivilegeNetworkGet);
                return channel;
            }

            set
            {
                Log.Info(Globals.LogTag, "SetChannel");
                int ret = Interop.TetheringExt.SetChannel(GetSafeHandle(), value);
                CheckReturnValue(ret, "SetChannel", PrivilegeNetworkGet);
            }
        }

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
            SafeTetheringExtManagerHandle handle;
            Log.Info(Globals.LogTag, "PInvoke tethering_ext_initialize");
            int ret = Interop.TetheringExt.Initialize(out handle);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Initialize Fail, Error - " + (TetheringError)ret);
                TetheringErrorFactory.ThrowTetheringException(ret, PrivilegeNetworkGet);
            }
            return handle;
        }

        internal void Activate()
        {
            Log.Info(Globals.LogTag, "Activate");
            int ret = Interop.TetheringExt.Activate(GetSafeHandle());
            CheckReturnValue(ret, "Activate", PrivilegeNetworkGet);
        }

        internal void DeActivate()
        {
            Log.Info(Globals.LogTag, "DeActivate");
            int ret = Interop.TetheringExt.DeActivate(GetSafeHandle());
            CheckReturnValue(ret, "DeActivate", PrivilegeNetworkGet);
        }

        public TetheringInfo GetTetheringInfo()
        {
            Log.Info(Globals.LogTag, "GetTetheringInfo");
            IntPtr tetheringInfoPtr;
            int ret = Interop.TetheringExt.GetTetheringInfo(GetSafeHandle(), out tetheringInfoPtr);
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
                int ret = Interop.TetheringExt.GetSecurity(GetSafeHandle(), out security);
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
                int ret = Interop.TetheringExt.GetVisibility(GetSafeHandle(), out visibility);
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
                int ret = Interop.TetheringExt.GetSharing(GetSafeHandle(), out sharing);
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
