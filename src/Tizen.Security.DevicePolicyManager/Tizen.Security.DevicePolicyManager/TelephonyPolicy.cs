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
    /// The TelephonyPolicy provides methods to manage telephony policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class TelephonyPolicy : DevicePolicy, IDisposable
    {
        private readonly string _messagingPolicyName = "messaging";
        private int _messagingCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _messagingPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _messagingPolicyChanged;

        internal TelephonyPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of TelephonyPolicy.
        /// </summary>
        ~TelephonyPolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Checks whether the text messaging is allowed or not.
        /// </summary>
        /// <param name="simId">SIM identifier</param>
        /// <returns>true if the messaging is allowed, false otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when failed because of invalid parameter.</exception>
        /// <exception cref="TimeoutException">Thrown when failed because of timeout.</exception>
        public bool IsMessagingAllowed(string simId)
        {
            int state;
            int ret = Interop.DevicePolicyManager.RestrictionGetMessagingState(_dpm.GetHandle(), simId, out state);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            return state == 1;
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

                if (_messagingCallbackId != 0)
                {
                    try
                    {
                        RemoveMessagingPolicyChangedCallback();
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
        /// The MessagingPolicyChanged event is raised when the messaging policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when TelephonyPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> MessagingPolicyChanged
        {
            add
            {
                if (_messagingPolicyChanged == null)
                {
                    AddMessagingPolicyChangedCallback();
                }

                _messagingPolicyChanged += value;
            }

            remove
            {
                _messagingPolicyChanged -= value;
                if (_messagingPolicyChanged == null)
                {
                    RemoveMessagingPolicyChangedCallback();
                }
            }
        }

        private void AddMessagingPolicyChangedCallback()
        {
            if (_messagingPolicyChangedCallback == null)
            {
                _messagingPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _messagingPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _messagingPolicyName, _messagingPolicyChangedCallback, IntPtr.Zero, out _messagingCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _messagingPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveMessagingPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _messagingCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _messagingPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _messagingPolicyChangedCallback = null;
            _messagingCallbackId = 0;
        }
    }
}
