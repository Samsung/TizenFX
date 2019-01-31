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
    /// <remarks>The BluetoothPolicy is created by <seealso cref="DevicePolicyManager.GetPolicy{T}"/>. and the DevicePolicyManager instance must exists when using the BluetoothPolicy.</remarks>
    public class BluetoothPolicy : DevicePolicy, IDisposable
    {
        /// <summary>
        /// The Bluetooth policy name. This represents <see cref="BluetoothPolicy.IsBluetoothAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public static readonly string BluetoothPolicyName = "Bluetooth";

        /// <summary>
        /// The Bluetooth Tethering policy name. This represents <see cref="BluetoothPolicy.IsBluetoothTetheringAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public static readonly string BluetoothTetheringPolicyName = "BluetoothTethering";

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
        /// Gets whether the the bluetooth state change is allowed or not.
        /// </summary>
        /// <value>true if the change is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsBluetoothAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetBluetoothModeChangeState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get bluetooth policy " + ret);
                    return true;
                }

                return state == 1;
            }
        }

        /// <summary>
        /// Gets whether the bluetooth tethering state change is allowed or not.
        /// </summary>
        /// <value>true if the change is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsBluetoothTetheringAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetBluetoothTetheringState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get bluetooth tethering policy " + ret);
                    return true;
                }

                return state == 1;
            }
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
                    _bluetoothPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(BluetoothPolicyName, state));
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
                    _bluetoothTetheringPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(BluetoothTetheringPolicyName, state));
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