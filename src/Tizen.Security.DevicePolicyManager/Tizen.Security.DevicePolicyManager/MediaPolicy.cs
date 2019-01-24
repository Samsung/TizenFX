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
    /// The MediaPolicy provides methods to manage media policies.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <remarks>The MediaPolicy is created by <seealso cref="DevicePolicyManager.GetPolicy{T}"/>. and the DevicePolicyManager instance must exists when using the MediaPolicy.</remarks>
    public class MediaPolicy : DevicePolicy, IDisposable
    {
        /// <summary>
        /// The Camera policy name. This represents <see cref="MediaPolicy.IsCameraAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public const string CameraPolicyName = "Camera";

        /// <summary>
        /// The Microphone policy name. This represents <see cref="MediaPolicy.IsMicrophoneAllowed"/>.
        /// </summary>
        /// <remarks>This is used in <see cref="PolicyChangedEventArgs.PolicyName"/>.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public const string MicrophonePolicyName = "Microphone";

        private readonly string _cameraPolicyName = "camera";
        private readonly string _microphonePolicyName = "microphone";
        private int _cameraCallbackId;
        private int _microphoneCallbackId;
        private bool _disposed = false;

        private Interop.DevicePolicyManager.PolicyChangedCallback _cameraPolicyChangedCallback;
        private Interop.DevicePolicyManager.PolicyChangedCallback _microphonePolicyChangedCallback;
        private EventHandler<PolicyChangedEventArgs> _cameraPolicyChanged;
        private EventHandler<PolicyChangedEventArgs> _microphonePolicyChanged;

        internal MediaPolicy(DevicePolicyManager dpm) : base(dpm)
        {
        }

        /// <summary>
        /// A Destructor of MediaPolicy.
        /// </summary>
        ~MediaPolicy()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets whether the use of camera is allowed or not.
        /// </summary>
        /// <value>true if the use of camera is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsCameraAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetCameraState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get camera policy " + ret);
                    return true;
                }

                return state == 1;
            }
        }

        /// <summary>
        /// Gets whether the use of microphone is allowed or not.
        /// </summary>
        /// <value>true if the use of microphone is allowed, false otherwise. The default value is true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool IsMicrophoneAllowed
        {
            get
            {
                int state;
                int ret = Interop.DevicePolicyManager.RestrictionGetMicrophoneState(_dpm.GetHandle(), out state);
                if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get microphone policy " + ret);
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

                if (_cameraCallbackId != 0)
                {
                    try
                    {
                        RemoveCameraPolicyChangedCallback();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, e.ToString());
                    }
                }

                if (_microphoneCallbackId != 0)
                {
                    try
                    {
                        RemoveMicrophonePolicyChangedCallback();
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
        /// The CameraPolicyChanged event is raised when the camera policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when MediaPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> CameraPolicyChanged
        {
            add
            {
                if (_cameraPolicyChanged == null)
                {
                    AddCameraPolicyChangedCallback();
                }

                _cameraPolicyChanged += value;
            }

            remove
            {
                _cameraPolicyChanged -= value;
                if (_cameraPolicyChanged == null)
                {
                    RemoveCameraPolicyChangedCallback();
                }
            }
        }

        private void AddCameraPolicyChangedCallback()
        {
            if (_cameraPolicyChangedCallback == null)
            {
                _cameraPolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _cameraPolicyChanged?.Invoke(this, new PolicyChangedEventArgs(CameraPolicyName, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _cameraPolicyName, _cameraPolicyChangedCallback, IntPtr.Zero, out _cameraCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _cameraPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveCameraPolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _cameraCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _cameraPolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _cameraPolicyChangedCallback = null;
            _cameraCallbackId = 0;
        }

        /// <summary>
        /// The MicrophonePolicyChanged event is raised when the microphone policy is changed.
        /// </summary>
        /// <remarks>This event will be removed automatically when MediaPolicy is destroyed.</remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<PolicyChangedEventArgs> MicrophonePolicyChanged
        {
            add
            {
                if (_microphonePolicyChanged == null)
                {
                    AddMicrophonePolicyChangedCallback();
                }

                _microphonePolicyChanged += value;
            }

            remove
            {
                _microphonePolicyChanged -= value;
                if (_microphonePolicyChanged == null)
                {
                    RemoveMicrophonePolicyChangedCallback();
                }
            }
        }

        private void AddMicrophonePolicyChangedCallback()
        {
            if (_microphonePolicyChangedCallback == null)
            {
                _microphonePolicyChangedCallback = (string name, string state, IntPtr userData) =>
                {
                    _microphonePolicyChanged?.Invoke(this, new PolicyChangedEventArgs(MicrophonePolicyName, state));
                };
            }

            int ret = Interop.DevicePolicyManager.AddPolicyChangedCallback(_dpm.GetHandle(), _microphonePolicyName, _microphonePolicyChangedCallback, IntPtr.Zero, out _microphoneCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to add policy changed callback, name " + _microphonePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }
        }

        private void RemoveMicrophonePolicyChangedCallback()
        {
            int ret = Interop.DevicePolicyManager.RemovePolicyChangedCallback(_dpm.GetHandle(), _microphoneCallbackId);
            if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove policy changed callback, name " + _microphonePolicyName + ", ret : " + ret);
                throw DevicePolicyManagerErrorFactory.CreateException(ret);
            }

            _microphonePolicyChangedCallback = null;
            _microphoneCallbackId = 0;
        }
    }
}