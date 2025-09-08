using System;
using System.Runtime.InteropServices;

namespace Tizen.Network.Tethering
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Tethering";
    }

    internal partial class TetheringExtensionManagerImpl : IDisposable
    {
        private static readonly Lazy<TetheringExtensionManagerImpl> _instance =
            new Lazy<TetheringExtensionManagerImpl>(() => new TetheringExtensionManagerImpl());

        private string PrivilegeNetworkGet = "http://tizen.org/privilege/network.get";
        private string PrivilegeNetworkProfile = "http://tizen.org/privilege/tethering.admin";
        private IntPtr _handle;
        private bool _disposed = false;
        private bool _enabled = false;
        private int _channel = 0;
        private TetheringSecurityType _security = TetheringSecurityType.None;
        private bool _visibility = false; 

        internal bool Enabled
        {
            get
            {
                bool enabled = false;
                int ret = Interop.TetheringExtension.IsEnabled(GetHandle(), out enabled);
                if (ret != (int)TetheringError.None)
                {
                    _enabled = false;
                    Log.Error(Globals.LogTag, "Failed to get is enabled, Error - " + (TetheringError)ret);
                }
                else
                {
                    _enabled = enabled;
                }
                return _enabled;
            }
        }

        internal void Ssid(string ssid)
        {
            Log.Info(Globals.LogTag, "SetSSID");
            int ret = Interop.TetheringExtension.SetSSID(GetHandle(), ssid);
            CheckReturnValue(ret, "SetSSID", PrivilegeNetworkProfile);
        }

        internal void Passphrase(string passphrase)
        {
            Log.Info(Globals.LogTag, "SetPassphrase");
            int ret = Interop.TetheringExtension.SetPassphrase(GetHandle(), passphrase);
            CheckReturnValue(ret, "SetPassphrase", PrivilegeNetworkProfile);
        }

        internal int Channel
        {
            get
            {
                Log.Info(Globals.LogTag, "GetChannel");
                int channel = 0;
                int ret = Interop.TetheringExtension.GetChannel(GetHandle(), out channel);
                if (ret != (int)TetheringError.None)
                {
                    channel = 0;
                    Log.Error(Globals.LogTag, "Failed to get channel, Error - " + (TetheringError)ret);
                }
                else
                {
                    _channel = channel;
                }
                return _channel;
            }

            set
            {
                Log.Info(Globals.LogTag, "SetChannel");
                int ret = Interop.TetheringExtension.SetChannel(GetHandle(), value);
                CheckReturnValue(ret, "SetChannel", PrivilegeNetworkProfile);
            }
        }

        internal static TetheringExtensionManagerImpl Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private TetheringExtensionManagerImpl()
        {
            Log.Info(Globals.LogTag, "TetheringExtensionManagerImpl constructor");
            _handle = IntPtr.Zero;
            Initialize();
        }

        ~TetheringExtensionManagerImpl()
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
            Log.Info(Globals.LogTag, "TetheringExtensionManagerImpl Handle HashCode: " + _handle.GetHashCode());
            int ret = Interop.TetheringExtension.Deinitialize(_handle);
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
            int ret = Interop.TetheringExtension.Initialize(out handle);
            CheckReturnValue(ret, "Initialize", PrivilegeNetworkProfile);
            _handle = handle;
        }

        internal void Activate()
        {
            Log.Info(Globals.LogTag, "Activate");
            int ret = Interop.TetheringExtension.Activate(GetHandle());
            CheckReturnValue(ret, "Activate", PrivilegeNetworkProfile);
        }

        internal void DeActivate()
        {
            Log.Info(Globals.LogTag, "DeActivate");
            int ret = Interop.TetheringExtension.DeActivate(GetHandle());
            CheckReturnValue(ret, "DeActivate", PrivilegeNetworkProfile);
        }

        public TetheringInfo GetTetheringInfo()
        {
            Log.Info(Globals.LogTag, "GetTetheringInfo");
            IntPtr tetheringInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf<TetheringInfoStruct>());
            int ret = Interop.TetheringExtension.GetTetheringInfo(GetHandle(), tetheringInfoPtr);
            CheckReturnValue(ret, "GetTetheringInfo", PrivilegeNetworkGet);
            TetheringInfo tetheringInfo = new TetheringInfo(tetheringInfoPtr);
            Marshal.FreeHGlobal(tetheringInfoPtr);
            return tetheringInfo;
        }

        public TetheringSecurityType Security
        {
            get
            {
                Log.Info(Globals.LogTag, "Security");
                int security = 0;
                int ret = Interop.TetheringExtension.GetSecurity(GetHandle(), out security);
                if (ret != (int)TetheringError.None)
                {
                    _security = TetheringSecurityType.None;
                    Log.Error(Globals.LogTag, "Failed to get security, Error - " + (TetheringError)ret);
                }
                else
                {
                    _security = (TetheringSecurityType)security;
                }
                return _security;
            }
        }

        public bool Visibility
        {
            get
            {
                Log.Info(Globals.LogTag, "Visibility");
                int visibility = 0;
                int ret = Interop.TetheringExtension.GetVisibility(GetHandle(), out visibility);
                if (ret != (int)TetheringError.None)
                {
                    _visibility = false;
                    Log.Error(Globals.LogTag, "Failed to get visibility, Error - " + (TetheringError)ret);
                }
                else
                {
                    if (visibility == 1) 
                    {
                        _visibility = true;
                    }
                    else
                    {
                        _visibility = false;
                    }
                }
                return _visibility;
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
