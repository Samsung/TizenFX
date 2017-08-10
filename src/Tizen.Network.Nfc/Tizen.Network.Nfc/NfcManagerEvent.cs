/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Threading.Tasks;

namespace Tizen.Network.Nfc
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

    internal partial class NfcManagerImpl
    {
        private event EventHandler<ActivationChangedEventArgs> _activationChanged;
        private event EventHandler<NdefMessageDiscoveredEventArgs> _ndefMessageDiscovered;

        private Interop.Nfc.ActivationChangedCallback _activationChangedCallback;
        private Interop.Nfc.NdefMessageDiscoveredCallback _ndefMessageDiscoveredCallback;

        internal event EventHandler<ActivationChangedEventArgs> ActivationChanged
        {
            add
            {
                if (_activationChanged == null)
                {
                    RegisterActivationChangedEvent();
                }
                _activationChanged += value;
            }
            remove
            {
                _activationChanged -= value;
                if (_activationChanged == null)
                {
                    UnregisterActivationChangedEvent();
                }
            }
        }

        internal event EventHandler<NdefMessageDiscoveredEventArgs> NdefMessageDiscovered
        {
            add
            {
                if (_ndefMessageDiscovered == null)
                {
                    RegisterNdefMessageDiscoveredEvent();
                }
                _ndefMessageDiscovered += value;
            }
            remove
            {
                _ndefMessageDiscovered -= value;
                if (_ndefMessageDiscovered == null)
                {
                    UnregisterNdefMessageDiscoveredEvent();
                }
            }
        }

        internal void RemoveAllRegisteredEvent()
        {
            //unregister all remaining events when this object is released.
            if (_activationChanged != null)
            {
                UnregisterActivationChangedEvent();
            }
        }

        private void RegisterActivationChangedEvent()
        {
            _activationChangedCallback = (bool activated, IntPtr userData) =>
            {
                bool isActivated = activated;
                ActivationChangedEventArgs e = new ActivationChangedEventArgs(isActivated);
                _activationChanged.SafeInvoke(null, e);
            };
            int ret = Interop.Nfc.SetActivationChangedCallback(_activationChangedCallback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set activation changed callback, Error - " + (NfcError)ret);
            }
        }

        private void UnregisterActivationChangedEvent()
        {
            Interop.Nfc.UnsetActivationChangedCallback();
        }

        private void RegisterNdefMessageDiscoveredEvent()
        {
            _ndefMessageDiscoveredCallback = (IntPtr ndefMessageHandle, IntPtr userData) =>
            {
                NdefMessageDiscoveredEventArgs e = new NdefMessageDiscoveredEventArgs(ndefMessageHandle);
                _ndefMessageDiscovered.SafeInvoke(null, e);
            };

            int ret = Interop.Nfc.SetNdefDiscoveredCallback(_ndefMessageDiscoveredCallback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set ndef message discovered callback, Error - " + (NfcError)ret);
            }
        }

        private void UnregisterNdefMessageDiscoveredEvent()
        {
            Interop.Nfc.UnsetNdefDiscoveredCallback();
        }
    }
}
