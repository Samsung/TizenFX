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
    /// The StoragePolicy provides methods to manage storage policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class StoragePolicy
    {
        private readonly string _externalStoragePolicyName = "external_storage";
        private readonly DevicePolicyManager _dpm;
        private int _externalStorageCallbackId;

        private Interop.DevicePolicyManager.PolicyChangedCallback _externalStoragePolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _externalStoragePolicyChanged;

        internal StoragePolicy()
        {
        }

        internal StoragePolicy(DevicePolicyManager dpm)
        {
            _dpm = dpm;
        }

        /// <summary>
        /// The ExternalStoragePolicyChanged event is raised when the external storage policy is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> ExternalStoragePolicyChanged
        {
            add
            {
                if (_externalStoragePolicyChanged == null)
                {
                    AddExternalStoragePolicyChangedCallback();
                }
                _externalStoragePolicyChanged += value;
            }
            remove
            {
                _externalStoragePolicyChanged -= value;
                if (_externalStoragePolicyChanged == null)
                {
                    RemoveExternalStoragePolicyChangedCallback();
                }
            }
        }

        private void AddExternalStoragePolicyChangedCallback()
        {
            if (_externalStoragePolicyChangedCallback == null)
            {
                _externalStoragePolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _externalStoragePolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _externalStoragePolicyName, _externalStoragePolicyChangedCallback, IntPtr.Zero, out _externalStorageCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _externalStoragePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
        }

        private void RemoveExternalStoragePolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _externalStorageCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _externalStoragePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
            _externalStoragePolicyChangedCallback = null;
            _externalStorageCallbackId = 0;
        }
    }
}