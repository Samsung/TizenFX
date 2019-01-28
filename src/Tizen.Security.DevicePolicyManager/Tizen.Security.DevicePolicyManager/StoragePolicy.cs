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
    /// <remarks>The StoragePolicy is created by <seealso cref="DevicePolicyManager.GetPolicy{T}"/>. and the DevicePolicyManager instance must exists when using the StoragePolicy.</remarks>
    public class StoragePolicy : DevicePolicy, IDisposable
    {
        /// <summary>
        /// The External storage policy name. This represents <see cref="StoragePolicy.IsExternalStorageAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public static string ExternalStoragePolicyName => "ExternalStorage";

        private readonly string _externalStoragePolicyName = "external_storage";
        private int _externalStorageCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _externalStoragePolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _externalStoragePolicyChanged;

        internal StoragePolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of StoragePolicy.
        /// </summary>
        ~StoragePolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets whether the use of external storage is allowed or not.
        /// </summary>
        /// <value>true if the use of external storage is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsExternalStorageAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetExternalStorageState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get external storage policy " + ret);
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

                if (_externalStorageCallbackId != 0)
                {
                    try
                    {
                        RemoveExternalStoragePolicyChangedCallback();
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
        /// The ExternalStoragePolicyChanged event is raised when the external storage policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when StoragePolicy is destroyed.</remarks>
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
                    _externalStoragePolicyChanged?.Invoke(this, new PolicyChangedEventArgs(ExternalStoragePolicyName, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _externalStoragePolicyName, _externalStoragePolicyChangedCallback, IntPtr.Zero, out _externalStorageCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _externalStoragePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveExternalStoragePolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _externalStorageCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _externalStoragePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _externalStoragePolicyChangedCallback = null;
            _externalStorageCallbackId = 0;
        }
    }
}