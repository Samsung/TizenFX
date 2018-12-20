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
    /// The LocationPolicy provides methods to manage location policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class LocationPolicy
    {
        private readonly string _locationPolicyName = "location";
        private readonly DevicePolicyManager _dpm;
        private int _locationCallbackId;

        private Interop.DevicePolicyManager.PolicyChangedCallback _locationPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _locationPolicyChanged;

        internal LocationPolicy()
        {
        }

        internal LocationPolicy(DevicePolicyManager dpm)
        {
            _dpm = dpm;
        }

        /// <summary>
        /// The LocationPolicyChanged event is raised when the location policy is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> LocationPolicyChanged
        {
            add
            {
                if (_locationPolicyChanged == null)
                {
                    AddLocationPolicyChangedCallback();
                }

                _locationPolicyChanged += value;
            }

            remove
            {
                _locationPolicyChanged -= value;
                if (_locationPolicyChanged == null)
                {
                    RemoveLocationPolicyChangedCallback();
                }
            }
        }

        private void AddLocationPolicyChangedCallback()
        {
            if (_locationPolicyChangedCallback == null)
            {
                _locationPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _locationPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _locationPolicyName, _locationPolicyChangedCallback, IntPtr.Zero, out _locationCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _locationPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
        }

        private void RemoveLocationPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _locationCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _locationPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            _locationPolicyChangedCallback = null;
            _locationCallbackId = 0;
        }
    }
}