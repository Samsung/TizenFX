using System;


namespace Tizen.Network.Tethering
{
    internal partial class TetheringExtensionManagerImpl {
        private event EventHandler<TetheringExtensionEnabledEventArgs> _tetheringExtEnabled;
        private event EventHandler<TetheringExtensionDisabledEventArgs> _tetheringExtDisabled;
        private event EventHandler<ConnectionStateChangedEventArgs> _connectionStateChanged;

        private Interop.TetheringExtension.EnabledCallback _enabledCallback;
        private Interop.TetheringExtension.DisabledCallback _disabledCallback;
        private Interop.TetheringExtension.ConnectionStateChangedCallback _connectionStateChangedCallback;

        internal event EventHandler<TetheringExtensionEnabledEventArgs> TetheringExtensionEnabled
        {
            add
            {
                if (_tetheringExtEnabled == null)
                {
                    try
                    {
                        RegisterEnabledEvent();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding TetheringExtensionEnabled\n" + e);
                        return;
                    }
                }
                _tetheringExtEnabled += value;
            }
            remove
            {
                _tetheringExtEnabled -= value;
                if (_tetheringExtEnabled == null)
                {
                    try
                    {
                        UnregisterEnabledEvent();
                    }
                    catch (Exception e) 
                    {
                        Log.Error(Globals.LogTag, "Exception on removing TetheringExtensionEnabled\n" + e);
                    }
                }
            }
        }

        internal event EventHandler<TetheringExtensionDisabledEventArgs> TetheringExtensionDisabled
        {
            add
            {
                if (_tetheringExtDisabled == null)
                {
                    try
                    {
                        RegisterDisabledEvent();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding TetheringExtensionDisabled\n" + e);
                        return;
                    }
                }
                _tetheringExtDisabled += value;
            }
            remove
            {
                _tetheringExtDisabled -= value;
                if (_tetheringExtDisabled == null)
                {
                    try
                    {
                        UnregisterDisabledEvent();
                    }
                    catch (Exception e) 
                    {
                        Log.Error(Globals.LogTag, "Exception on removing TetheringExtensionDisabled\n" + e);
                    }
                }
            }
        }

        internal event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (_connectionStateChanged == null)
                {
                    try
                    {
                        RegisterConnectionStateChangedEvent();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding ConnectionStateChanged\n" + e);
                        return;
                    }
                }
                _connectionStateChanged += value;
            }
            remove
            {
                _connectionStateChanged -= value;
                if (_connectionStateChanged == null)
                {
                    try
                    {
                        UnregisterConnectionStatechangedEvent();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing ConnectionStateChanged\n" + e);
                    }
                }
            }
        }


        private void RegisterEnabledEvent()
        {
            Log.Info(Globals.LogTag, "RegisterEnabledEvent");
            _enabledCallback = (int result, bool isRequested, IntPtr userData) =>
            {
                TetheringExtensionEnabledEventArgs e = new TetheringExtensionEnabledEventArgs(result, isRequested);
                _tetheringExtEnabled?.Invoke(this, e);
            };

            int ret = Interop.TetheringExtension.SetEnabledCallback(GetHandle(), _enabledCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set tethering extension enabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterEnabledEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterTetheringEnabledEvent");
            int ret = Interop.TetheringExtension.UnsetEnabledCallback(GetHandle());
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset tethering extension enabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void RegisterDisabledEvent()
        {
            Log.Info(Globals.LogTag, "RegisterDisabledEvent");
            _disabledCallback = (int result, TetheringDisabledCause cause, IntPtr userData) =>
            {
                TetheringExtensionDisabledEventArgs e = new TetheringExtensionDisabledEventArgs(result, cause);
                _tetheringExtDisabled?.Invoke(this, e);
            };

            int ret = Interop.TetheringExtension.SetDisabledCallback(GetHandle(), _disabledCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set tethering extension disabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterDisabledEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterTetheringDisabledEvent");
            int ret = Interop.TetheringExtension.UnsetDisabledCallback(GetHandle());
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset tethering extension disabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void RegisterConnectionStateChangedEvent()
        {
            _connectionStateChangedCallback = (IntPtr client, bool opened, IntPtr userData) =>
            {
                TetheringExtensionClient tetheringExtClient = new TetheringExtensionClient(client);
                ConnectionStateChangedEventArgs e = new ConnectionStateChangedEventArgs(tetheringExtClient, opened);
                _connectionStateChanged?.Invoke(this, e);
            };

            int ret = Interop.TetheringExtension.SetConnectionStateChangedCallback(GetHandle(), _connectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection state changed callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterConnectionStatechangedEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterConnectionStatechangedEvent");
            int ret = Interop.TetheringExtension.UnsetConnectionStateChangedCallback(GetHandle());
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection state changed callback, Error - " + (TetheringError)ret);
            }
        }

    }
}

