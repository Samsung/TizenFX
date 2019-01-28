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
    /// The UsbPolicy provides methods to manage usb policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <remarks>The UsbPolicy is created by <seealso cref="DevicePolicyManager.GetPolicy{T}"/>. and the DevicePolicyManager instance must exists when using the UsbPolicy.</remarks>
    public class UsbPolicy : DevicePolicy, IDisposable
    {
        /// <summary>
        /// The Usb tethering policy name. This represents <see cref="UsbPolicy.IsUsbTetheringAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public static string UsbTetheringPolicyName => "UsbTethering";

        private readonly string _usbTetheringPolicyName = "usb_tethering";
        private int _usbTetheringCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _usbTetheringPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _usbTetheringPolicyChanged;

        internal UsbPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of UsbPolicy.
        /// </summary>
        ~UsbPolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets whether the USB tethering state change is allowed.
        /// </summary>
        /// <value>true if the change is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsUsbTetheringAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetUsbTetheringState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get usb tethering state change policy " + ret);
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

                if (_usbTetheringCallbackId != 0)
                {
                    try
                    {
                        RemoveUsbTetheringPolicyChangedCallback();
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
        /// The UsbTetheringPolicyChanged event is raised when the usb tethering policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when UsbPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> UsbTetheringPolicyChanged
        {
            add
            {
                if (_usbTetheringPolicyChanged == null)
                {
                    AddUsbTetheringPolicyChangedCallback();
                }

                _usbTetheringPolicyChanged += value;
            }

            remove
            {
                _usbTetheringPolicyChanged -= value;
                if (_usbTetheringPolicyChanged == null)
                {
                    RemoveUsbTetheringPolicyChangedCallback();
                }
            }
        }

        private void AddUsbTetheringPolicyChangedCallback()
        {
            if (_usbTetheringPolicyChangedCallback == null)
            {
                _usbTetheringPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _usbTetheringPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(UsbTetheringPolicyName, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _usbTetheringPolicyName, _usbTetheringPolicyChangedCallback, IntPtr.Zero, out _usbTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _usbTetheringPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveUsbTetheringPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _usbTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _usbTetheringPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _usbTetheringPolicyChangedCallback = null;
            _usbTetheringCallbackId = 0;
        }
    }
}