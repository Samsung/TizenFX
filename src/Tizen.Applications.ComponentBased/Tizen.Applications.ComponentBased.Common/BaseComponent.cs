/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// This is a base-component class.
    /// It provides common functions of FrameComponent and ServiceComponent.
    /// </summary>
    /// <remarks>
    /// This class cannot be registered by ComponentBased applications.
    /// </remarks>
    /// <since_tizen> 6 </since_tizen>
    public abstract class BaseComponent
    {
        internal IntPtr Handle;

        /// <summary>
        /// Occurs when the system memory is low.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when the system battery is low.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is chagned.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<SuspendedStateEventArgs> SuspendedStateChanged;

        /// <summary>
        /// A component instance ID.
        /// It will be created after OnCreate method is invoked.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id { get; private set; }

        /// <summary>
        /// A component ID
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ComponentId { get; private set; }

        /// <summary>
        /// Parent object
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ComponentBasedApplication Parent { get; private set; }

        /// <summary>
        /// Finish current component
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Finish()
        {
            Interop.CBApplication.ComponentFinish(Handle);
        }

        /// <summary>
        /// A Context Handle
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr ContextHandle
        {
            get
            {
                return Handle;
            }
            set
            {
                Handle = value;
            }
        }

        internal void Bind(IntPtr handle, string compId, string instanceId, ComponentBasedApplication parent)
        {
            Handle = handle;
            Id = instanceId;
            ComponentId = compId;
            Parent = parent;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to restore the previous status.
        /// </summary>
        /// <param name="c">Contents. It can be used only in the callback. To use outside, make a copy. </param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnRestoreContents(Bundle c)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to save current status.
        /// </summary>
        /// <param name="c">Contents. It can be used only in the callback. To use outside, make a copy. </param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void OnSaveContent(Bundle c)
        {
        }

        internal void OnLanguageChangedCallback(string language)
        {
            LocaleChanged?.Invoke(this, new LocaleChangedEventArgs(language));
        }

        internal void OnDeviceOrientationChangedCallback(int orientation)
        {
            DeviceOrientationChanged?.Invoke(this, new DeviceOrientationEventArgs((DeviceOrientation)orientation));
        }

        internal void OnLowBatteryCallback(int status)
        {
            LowBattery?.Invoke(this, new LowBatteryEventArgs((LowBatteryStatus)status));
        }

        internal void OnLowMemoryCallback(int status)
        {
            LowMemory?.Invoke(this, new LowMemoryEventArgs((LowMemoryStatus)status));
        }

        internal void OnRegionFormatChangedCallback(string region)
        {
            RegionFormatChanged?.Invoke(this, new RegionFormatChangedEventArgs(region));
        }

        internal void OnSuspendedStateCallback(int state)
        {
            SuspendedStateChanged?.Invoke(this, new SuspendedStateEventArgs((SuspendedState)state));
        }

        /// <summary>
        /// Sends the launch request asynchronously.
        /// </summary>
        /// <remarks>
        /// To use group mode, you must use this function instead of SendLaunchRequestAsync().
        /// </remarks>
        /// <param name="control">appcontrol object</param>
        /// <param name="replyAfterLaunching">The callback function to be called when the reply is delivered.</param>
        /// <returns>A task with the result of the launch request.</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when fail to set component information to the AppControl.</exception>
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 6 </since_tizen>
        public Task<AppControlResult> SendLaunchRequestAsync(AppControl control, AppControlReplyCallback replyAfterLaunching)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            int ret = Interop.AppControl.SetCallerInstanceId(control.SafeAppControlHandle, Id);
            if (ret != 0)
                throw new InvalidOperationException("Failed to set id");

            return AppControl.SendLaunchRequestAsync(control, replyAfterLaunching);
        }
    }
}
