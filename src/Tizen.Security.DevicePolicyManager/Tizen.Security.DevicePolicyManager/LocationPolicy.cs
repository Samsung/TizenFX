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
        /// <summary>
        /// The Location policy name. This represents <see cref="LocationPolicy.IsLocationAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public const string LocationPolicyName = "Location";

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
        /// Gets whether user is allowed to change location state or not.
        /// </summary>
        /// <value>true if the location state change is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsLocationAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetLocationState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get location policy " + ret);
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
                    _locationPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(LocationPolicyName, state));
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