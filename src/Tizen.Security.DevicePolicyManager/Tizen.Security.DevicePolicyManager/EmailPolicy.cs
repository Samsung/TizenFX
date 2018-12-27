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
    /// The EmailPolicy provides methods to manage email policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class EmailPolicy
    {
        private readonly string _popImapPolicyName = "popimap_email";
        private readonly DevicePolicyManager _dpm;
        private int _popImapCallbackId;

        private Interop.DevicePolicyManager.PolicyChangedCallback _popImapPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _popImapPolicyChanged;

        internal EmailPolicy()
        {
        }
 
        internal EmailPolicy(DevicePolicyManager dpm)
        {
            _dpm = dpm;
        }

        /// <summary>
        /// Checks whether the access to POP or IMAP email is allowed or not.
        /// </summary>
        /// <returns>true if the POP or IMAP email is allowed, false otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid handle of DevicePolicyManager.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        public bool GetPopImapState()
        {
            int state;
            int ret = Interop.DevicePolicyManager.RestrictionGetPopimapEmailState(_dpm.GetHandle(), out state);

            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get popimap email policy " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            return state == 1;
        }

        /// <summary>
        /// The PopImapPolicyChanged event is raised when the popimap-email policy is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> PopImapPolicyChanged
        {
            add
            {
                if (_popImapPolicyChanged == null)
                {
                    AddPopImapPolicyChangedCallback();
                }

                _popImapPolicyChanged += value;
            }

            remove
            {
                _popImapPolicyChanged -= value;
                if (_popImapPolicyChanged == null)
                {
                    RemovePopImapPolicyChangedCallback();
                }
            }
        }

        private void AddPopImapPolicyChangedCallback()
        {
            if (_popImapPolicyChangedCallback == null)
            {
                _popImapPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _popImapPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _popImapPolicyName, _popImapPolicyChangedCallback, IntPtr.Zero, out _popImapCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _popImapPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
        }

        private void RemovePopImapPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _popImapCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _popImapPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }

            _popImapPolicyChangedCallback = null;
            _popImapCallbackId = 0;
        }
    }
}
