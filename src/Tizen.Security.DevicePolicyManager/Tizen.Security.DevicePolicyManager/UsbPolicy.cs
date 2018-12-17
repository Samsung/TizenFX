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
    /// The UsbPolicy provides methods to control usb policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class UsbPolicy
    {
        private readonly string _usbTetheringPolicyName = "usb_tethering";
        private readonly DevicePolicyManager handle;
        private int _usbTetheringCallbackId;

        private Interop.DevicePolicyManager.PolicyChangedCallback _usbTetheringPolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _usbTetheringPolicyChanged;

        internal UsbPolicy()
        {
        }

        internal UsbPolicy(DevicePolicyManager dpm)
        {
            handle = dpm;
        }

        /// <summary>
        /// The UsbTetheringPolicyChanged event is raised when the usb tethering policy is changed.
        /// </summary>
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
                    _usbTetheringPolicyChanged?.Invoke(null, new PolicyChangedEventArgs(name, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(handle.GetHandle(), _usbTetheringPolicyName, _usbTetheringPolicyChangedCallback, IntPtr.Zero, out _usbTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
        }

        private void RemoveUsbTetheringPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(handle.GetHandle(), _usbTetheringCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.DpmError.None)
            {
                throw DevicePolicyManagerErrorFactory.GetException(ret);
            }
            _usbTetheringPolicyChangedCallback = null;
            _usbTetheringCallbackId = 0;
        }
    }
}