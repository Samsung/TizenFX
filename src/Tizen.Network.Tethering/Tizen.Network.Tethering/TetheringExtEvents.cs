using System;


namespace Tizen.Network.Tethering
{

    internal static class EventHandlerExtension
    {
        internal static void SafeInvoke(this EventHandler evt, object sender, EventArgs e)
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        internal static void SafeInvoke<T>(this EventHandler<T> evt, object sender, T e) where T : EventArgs
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }

    internal partial class TetheringExtManagerImpl {
        private event EventHandler<TetheringExtEnabledEventArgs> _tetheringExtEnabled;
        private event EventHandler<TetheringExtDisabledEventArgs> _tetheringExtDisabled;
        private event EventHandler<ConnectionStateChangedEventArgs> _connectionStateChanged;

        private Interop.TetheringExt.EnabledCallback _enabledCallback;
        private Interop.TetheringExt.DisabledCallback _disabledCallback;
        private Interop.TetheringExt.ConnectionStateChangedCallback _connectionStateChangedCallback;

        internal event EventHandler<TetheringExtEnabledEventArgs> TetheringExtEnabled
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
                        Log.Error(Globals.LogTag, "Exception on adding TetheringExtEnabled\n" + e);
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
                        Log.Error(Globals.LogTag, "Exception on removing TetheringExtEnabled\n" + e);
                    }
                }
            }
        }

        internal event EventHandler<TetheringExtDisabledEventArgs> TetheringExtDisabled
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
                        Log.Error(Globals.LogTag, "Exception on adding TetheringExtDisabled\n" + e);
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
                        Log.Error(Globals.LogTag, "Exception on removing TetheringExtDisabled\n" + e);
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
                TetheringExtEnabledEventArgs e = new TetheringExtEnabledEventArgs(result, isRequested);
                _tetheringExtEnabled.SafeInvoke(null, e);
            };

            int ret = Interop.TetheringExt.SetEnabledCallback(GetHandle(), _enabledCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set tethering extension enabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterEnabledEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterTetheringEnabledEvent");
            int ret = Interop.TetheringExt.UnsetEnabledCallback(GetHandle());
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
                TetheringExtDisabledEventArgs e = new TetheringExtDisabledEventArgs(result, cause);
                _tetheringExtDisabled.SafeInvoke(null, e);
            };

            int ret = Interop.TetheringExt.SetDisabledCallback(GetHandle(), _disabledCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set tethering extension disabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterDisabledEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterTetheringDisabledEvent");
            int ret = Interop.TetheringExt.UnsetDisabledCallback(GetHandle());
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset tethering extension disabled callback, Error - " + (TetheringError)ret);
            }
        }

        private void RegisterConnectionStateChangedEvent()
        {
            _connectionStateChangedCallback = (IntPtr client, bool opened, IntPtr userData) =>
            {
                TetheringExtClient tetheringExtClient = new TetheringExtClient(client);
                ConnectionStateChangedEventArgs e = new ConnectionStateChangedEventArgs(tetheringExtClient, opened);
                _connectionStateChanged.SafeInvoke(null, e);
            };

            int ret = Interop.TetheringExt.SetConnectionStateChangedCallback(GetHandle(), _connectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection state changed callback, Error - " + (TetheringError)ret);
            }
        }

        private void UnregisterConnectionStatechangedEvent()
        {
            Log.Info(Globals.LogTag, "UnregisterConnectionStatechangedEvent");
            int ret = Interop.TetheringExt.UnsetConnectionStateChangedCallback(GetHandle());
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection state changed callback, Error - " + (TetheringError)ret);
            }
        }

    }
}

