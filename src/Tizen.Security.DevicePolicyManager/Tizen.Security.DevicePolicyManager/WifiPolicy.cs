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
    /// The WifiPolicy provides methods to manage wifi policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class WifiPolicy : DevicePolicy, IDisposable
    {
        private readonly string _wifiPolicyName = "wifi";
        private readonly string _wifiHotspotPolicyName = "wifi_hotspot";

        private int _wifiCallbackId;
        private int _wifiHotspotCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _wifiPolicyChangedCallback;
        private Interop.DevicePolicyManager.PolicyChangedCallback _wifiHotspotStatePolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _wifiPolicyChanged;
        private EventHandler<PolicyChangedEventArgs> _wifiHotspotPolicyChanged;

        internal WifiPolicy()
        {
        }

        internal WifiPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of WifiPolicy.
        /// </summary>
        ~WifiPolicy()
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

                if (_wifiCallbackId != 0)
                {
                    try
                    {
                        RemoveWifiStatePolicyChangedCallback();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, e.ToString());
                    }
                }

                if (_wifiHotspotCallbackId != 0)
                {
                    try
                    {
                        RemoveWifiHotspotPolicyChangedCallback();
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
        /// Gets whether the Wi-Fi state change is allowed or not.
        /// </summary>
        /// <value>The wifi policy state. If error occurs, PolicyState UNKNOWN is returned.</value>
        /// <seealso cref="PolicyState"/>
        /// <since_tizen> 6 </since_tizen>
        public PolicyState IsWifiAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetWifiState(_dpm.GetHandle(), out state);

                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get wifi policy " + ret);
                    return PolicyState.UNKNOWN;
                }

                return state == 1 ? PolicyState.ALLOWED : PolicyState.DISALLOWED;
            }
        }

        /// <summary>
        /// The WifiPolicyChanged event is raised when the wifi state policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when WifiPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> WifiPolicyChanged
        {
            add
            {
                if (_wifiPolicyChanged == null)
                {
                    AddWifiStatePolicyChangedCallback();
                }

                _wifiPolicyChanged += value;
            }

            remove
            {
                _wifiPolicyChanged -= value;
                if (_wifiPolicyChanged == null)
                {
                    RemoveWifiStatePolicyChangedCallback();
                }
            }
        }

        private void AddWifiStatePolicyChangedCallback()
        {
            if (_wifiPolicyChangedCallback == null)
            {
                _wifiPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _wifiPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _wifiPolicyName, _wifiPolicyChangedCallback, IntPtr.Zero, out _wifiCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _wifiPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveWifiStatePolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _wifiCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _wifiPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _wifiPolicyChangedCallback = null;
            _wifiCallbackId = 0;
        }

        /// <summary>
        /// The WifiHotspotPolicyChanged event is raised when the wifi hotspot policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when WifiPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> WifiHotspotPolicyChanged
        {
            add
            {
                if (_wifiHotspotPolicyChanged == null)
                {
                    AddWifiHotspotPolicyChangedCallback();
                }

                _wifiHotspotPolicyChanged += value;
            }

            remove
            {
                _wifiHotspotPolicyChanged -= value;
                if (_wifiHotspotPolicyChanged == null)
                {
                    RemoveWifiHotspotPolicyChangedCallback();
                }
            }
        }

        private void AddWifiHotspotPolicyChangedCallback()
        {
            if (_wifiHotspotStatePolicyChangedCallback == null)
            {
                _wifiHotspotStatePolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _wifiHotspotPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _wifiHotspotPolicyName, _wifiHotspotStatePolicyChangedCallback, IntPtr.Zero, out _wifiHotspotCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _wifiHotspotPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveWifiHotspotPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _wifiHotspotCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _wifiHotspotPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _wifiHotspotStatePolicyChangedCallback = null;
            _wifiHotspotCallbackId = 0;
        }
    }
}
