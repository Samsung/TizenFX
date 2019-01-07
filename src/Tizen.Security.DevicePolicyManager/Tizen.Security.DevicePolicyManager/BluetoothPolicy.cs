/*
 *  Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;

namespace Tizen.Security.DevicePolicyManager
{
    /// <summary>
    /// The BluetoothPolicy provides methods to manage Bluetooth policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class BluetoothPolicy : DevicePolicy, IDisposable
    {
        private readonly string _bluetoothPolicyName = "bluetooth";
        private readonly string _bluetoothTetheringPolicyName = "bluetooth_tethering";
        private int _bluetoothCallbackId;
        private int _bluetoothTetheringCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _bluetoothPolicyChangedCallback;
        private Interop.DevicePolicyManager.PolicyChangedCallback _bluetoothTetheringPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _bluetoothPolicyChanged;
        private EventHandler<PolicyChangedEventArgs> _bluetoothTetheringPolicyChanged;

        internal BluetoothPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of BluetoothPolicy.
        /// </summary>
        ~BluetoothPolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }

                if (_bluetoothCallbackId != 0)
                {
                    try
                    {
                        RemoveBluetoothPolicyChangedCallback();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, e.ToString());
                    }
                }

                if (_bluetoothTetheringCallbackId != 0)
                {
                    try
                    {
                        RemoveBluetoothTetheringPolicyChangedCallback();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, e.ToString());
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// The BluetoothPolicyChanged event is raised when the Bluetooth policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when BluetoothPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> BluetoothPolicyChanged
        {
            add
            {
                if (_bluetoothPolicyChanged == null)
                {
                    AddBluetoothPolicyChangedCallback();
                }

                _bluetoothPolicyChanged += value;
            }

            remove
            {
                _bluetoothPolicyChanged -= value;
                if (_bluetoothPolicyChanged == null)
                {
                    RemoveBluetoothPolicyChangedCallback();
                }
            }
        }

        private void AddBluetoothPolicyChangedCallback()
        {
            if (_bluetoothPolicyChangedCallback == null)
            {
                _bluetoothPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _bluetoothPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _bluetoothPolicyName, _bluetoothPolicyChangedCallback, IntPtr.Zero, out _bluetoothCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _bluetoothPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveBluetoothPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _bluetoothCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _bluetoothPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _bluetoothPolicyChangedCallback = null;
            _bluetoothCallbackId = 0;
        }

        /// <summary>
        /// The BluetoothTetheringPolicyChanged event is raised when the Bluetooth tethering policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when BluetoothPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> BluetoothTetheringPolicyChanged
        {
            add
            {
                if (_bluetoothTetheringPolicyChanged == null)
                {
                    AddBluetoothTetheringPolicyChangedCallback();
                }

                _bluetoothTetheringPolicyChanged += value;
            }

            remove
            {
                _bluetoothTetheringPolicyChanged -= value;
                if (_bluetoothTetheringPolicyChanged == null)
                {
                    RemoveBluetoothTetheringPolicyChangedCallback();
                }
            }
        }

        private void AddBluetoothTetheringPolicyChangedCallback()
        {
            if (_bluetoothTetheringPolicyChangedCallback == null)
            {
                _bluetoothTetheringPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _bluetoothTetheringPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _bluetoothTetheringPolicyName, _bluetoothTetheringPolicyChangedCallback, IntPtr.Zero, out _bluetoothTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _bluetoothTetheringPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveBluetoothTetheringPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _bluetoothTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _bluetoothTetheringPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _bluetoothTetheringPolicyChangedCallback = null;
            _bluetoothTetheringCallbackId = 0;
        }
    }
}