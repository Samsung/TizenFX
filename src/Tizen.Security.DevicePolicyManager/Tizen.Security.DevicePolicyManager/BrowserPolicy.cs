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
    /// The BrowserPolicy provides methods to manage browser policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class BrowserPolicy : DevicePolicy, IDisposable
    {
        private readonly string _browserPolicyName = "browser";
        private int _browserCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _browserPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _browserPolicyChanged;

        internal BrowserPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of BrowserPolicy.
        /// </summary>
        ~BrowserPolicy()
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

                if (_browserCallbackId != 0)
                {
                    try
                    {
                        RemoveBrowserPolicyChangedCallback();
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
        /// The BrowserPolicyChanged event is raised when the browser policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when BrowserPolicy is destroyed.</remarks>
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

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _browserPolicyName, _browserPolicyChangedCallback, IntPtr.Zero, out _browserCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _browserPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveBrowserPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _browserCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _browserPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _browserPolicyChangedCallback = null;
            _browserCallbackId = 0;
        }
    }
}
