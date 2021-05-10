/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Diagnostics;
using static Interop;
using Native = Interop.Camera;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This camera class provides methods to capture photos and supports setting up notifications
    /// for state changes of capturing, previewing, focusing, and informing about the resolution and the binary format,
    /// and functions for picture manipulations like sepia, negative, and many more.
    /// It also notifies you when a significant picture parameter changes, (For example, focus).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <feature> http://tizen.org/feature/camera </feature>
    public partial class Camera : IDisposable, IDisplayable<CameraError>
    {
        /// <summary>
        /// Gets or sets the various camera settings.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraSettings Settings { get; }

        /// <summary>
        /// Gets the various camera capabilities.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraCapabilities Capabilities { get; }

        /// <summary>
        /// Get/set various camera display properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraDisplaySettings DisplaySettings { get; }

        private Display _display;

        private CameraError SetDisplay(Display display)
        {
            if (display == null)
            {
                return CameraDisplay.SetDisplay(GetHandle(), DisplayType.None, IntPtr.Zero);
            }

            return display.ApplyTo(this);
        }

        private void ReplaceDisplay(Display newDisplay)
        {
            _display?.SetOwner(null);
            _display = newDisplay;
            _display?.SetOwner(this);
        }

        /// <summary>
        /// Sets or gets the display type and handle to show preview images.
        /// The camera must be in the <see cref="CameraState.Created"/> state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// This must be set before the StartPreview() method.
        /// In custom ROI display mode, DisplayRoiArea property must be set before calling this method.
        /// </remarks>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="NotSupportedException">In case of this feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException" > The camera already has been disposed of.</exception>
        /// <exception cref="UnauthorizedAccessException">In case of access to the resources cannot be granted.</exception>
        public Display Display
        {
            get
            {
                return _display;
            }

            set
            {
                ValidateState(CameraState.Created);

                if (value?.Owner != null)
                {
                    if (ReferenceEquals(this, value.Owner))
                    {
                        return;
                    }

                    throw new ArgumentException("The display has already been assigned to another.");
                }

                SetDisplay(value).ThrowIfFailed("Failed to set the camera display");

                ReplaceDisplay(value);
            }
        }

        CameraError IDisplayable<CameraError>.ApplyEvasDisplay(DisplayType type, ElmSharp.EvasObject evasObject)
        {
            Debug.Assert(_disposed == false);
            ValidationUtil.ValidateEnum(typeof(DisplayType), type, nameof(type));

            return CameraDisplay.SetDisplay(GetHandle(), type, evasObject);
        }

        CameraError IDisplayable<CameraError>.ApplyEcoreWindow(IntPtr windowHandle)
        {
            Debug.Assert(_disposed == false);

            return CameraDisplay.SetEcoreDisplay(GetHandle(), windowHandle);
        }

        /// <summary>
        /// Gets the state of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value> None, Created, Preview, Capturing, Captured.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraState State
        {
            get
            {
                ValidateNotDisposed();

                CameraState val = CameraState.None;

                Native.GetState(_handle, out val).ThrowIfFailed("Failed to get camera state");

                return val;
            }
        }

        /// <summary>
        /// The hint for the display reuse.
        /// If the hint is set to true, the display will be reused when the camera device is changed with
        /// the ChangeDevice method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">In case of invalid parameters.</exception>
        /// <exception cref="InvalidOperationException">An invalid state.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public bool DisplayReuseHint
        {
            get
            {
                ValidateNotDisposed();

                Native.GetDisplayReuseHint(_handle, out bool val).ThrowIfFailed("Failed to get camera display reuse hint");

                return val;
            }

            set
            {
                ValidateState(CameraState.Preview);

                Native.SetDisplayReuseHint(_handle, value).ThrowIfFailed("Failed to set display reuse hint.");
            }
        }

        /// <summary>
        /// Gets the facing direction of the camera module.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>A <see cref="CameraFacingDirection"/> that specifies the facing direction of the camera device.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public CameraFacingDirection Direction
        {
            get
            {
                ValidateNotDisposed();

                Native.GetFacingDirection(_handle, out var val).ThrowIfFailed("Failed to get camera direction");

                return val;
            }
        }

        /// <summary>
        /// Gets the camera device count.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>This returns 2, if the device supports primary and secondary cameras.
        /// Otherwise 1, if the device only supports primary camera.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed of.</exception>
        public int CameraCount
        {
            get
            {
                ValidateNotDisposed();

                Native.GetDeviceCount(_handle, out int val).ThrowIfFailed("Failed to get camera device count");

                return val;
            }
        }
    }
}
