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
    public class LocationPolicy : DevicePolicy, IDisposable
    {
        private readonly string _locationPolicyName = "location";
        private int _locationCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _locationPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _locationPolicyChanged;

        internal LocationPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of LocationPolicy.
        /// </summary>
        ~LocationPolicy()
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

                if (_locationCallbackId != 0)
                {
                    try
                    {
                        RemoveLocationPolicyChangedCallback();
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
        /// The LocationPolicyChanged event is raised when the location policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when LocationPolicy is destroyed.</remarks>
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
                    _locationPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _locationPolicyName, _locationPolicyChangedCallback, IntPtr.Zero, out _locationCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _locationPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveLocationPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _locationCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _locationPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _locationPolicyChangedCallback = null;
            _locationCallbackId = 0;
        }
    }
}