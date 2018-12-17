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
    /// The BrowserPolicy provides methods to control browser policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class BrowserPolicy
    {
        private readonly string _browserPolicyName = "browser";
        private readonly DevicePolicyManager handle;
        private int _browserCallbackId;

        private Interop.DevicePolicyManager.PolicyChangedCallback _browserPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _browserPolicyChanged;

        internal BrowserPolicy()
        {
        }

        internal BrowserPolicy(DevicePolicyManager dpm)
        {
            handle = dpm;
        }

        /// <summary>
        /// The BrowserPolicyChanged event is raised when the browser policy is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> BrowserPolicyChanged
        {
            add
            {
                if (_browserPolicyChanged == null)
                {
                    AddBrowserPolicyChangedCallback();
                }
                _browserPolicyChanged += value;
            }
            remove
            {
                _browserPolicyChanged -= value;
                if (_browserPolicyChanged == null)
                {
                    RemoveBrowserPolicyChangedCallback();
                }
            }
        }

        private void AddBrowserPolicyChangedCallback()
        {
            if (_browserPolicyChangedCallback == null)
            {
                _browserPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _browserPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(handle.GetHandle(), _browserPolicyName, _browserPolicyChangedCallback, IntPtr.Zero, out _browserCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
        }

        private void RemoveBrowserPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(handle.GetHandle(), _browserCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
            _browserPolicyChangedCallback = null;
            _browserCallbackId = 0;
        }
    }
}
