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
    public class EmailPolicy : DevicePolicy, IDisposable
    {
        private readonly string _popImapPolicyName = "popimap_email";
        private int _popImapCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _popImapPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _popImapPolicyChanged;
 
        internal EmailPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of EmailPolicy.
        /// </summary>
        ~EmailPolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets whether the access to POP or IMAP email is allowed or not.
        /// </summary>
        /// <value>true if the POP or IMAP email is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsPopImapAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetPopimapEmailState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get popimap email policy " + ret);
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

                if (_popImapCallbackId != 0)
                {
                    try
                    {
                        RemovePopImapPolicyChangedCallback();
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
        /// The PopImapPolicyChanged event is raised when the popimap-email policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when EmailPolicy is destroyed.</remarks>
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
                    _popImapPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _popImapPolicyName, _popImapPolicyChangedCallback, IntPtr.Zero, out _popImapCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _popImapPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemovePopImapPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _popImapCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _popImapPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _popImapPolicyChangedCallback = null;
            _popImapCallbackId = 0;
        }
    }
}
