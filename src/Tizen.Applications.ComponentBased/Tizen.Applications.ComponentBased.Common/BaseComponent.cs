using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// This is a base class for components
    /// </summary>
    public abstract class BaseComponent
    {
        internal IntPtr Handle;
        internal static readonly string LogTag = typeof(BaseComponent).Namespace;

        /// <summary>
        /// Component types.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum ComponentType
        {
            /// <summary>
            /// The frame component.
            /// </summary>
            Frame = Interop.CBApplication.NativeComponentType.Frame,

            /// <summary>
            /// The service component.
            /// </summary>
            Service = Interop.CBApplication.NativeComponentType.Service
        }

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
        /// ID for this component instance.
        /// It will be created after OnCreate method is invoked.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id { get; internal set; }

        /// <summary>
        /// Component ID
        /// </summary>
        public string ComponentId { get; internal set; }

        /// <summary>
        /// Parent object
        /// </summary>
        public CBApplicationBase Parent { get; internal set; }

        /// <summary>
        /// Finish current component
        /// </summary>
        public virtual void Finish()
        {
        }

        internal void Bind(IntPtr handle, string compId)
        {
            Handle = handle;
            ComponentId = compId;
        }

        /// <summary>
        /// Overrides this method if you want to specify a type of this component.
        /// Default component type is Service type.
        /// </summary>
        public virtual ComponentType GetComponentType()
        {
            return ComponentType.Service;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to restore the previous status.
        /// </summary>
        /// <param name="c">Contents</param>
        public virtual void OnRestoreContents(Bundle c)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to save current status.
        /// </summary>
        /// <param name="c">Contents</param>
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
        /// <exception cref="Exceptions.AppNotFoundException">Thrown when the application to run is not found.</exception>
        /// <exception cref="Exceptions.LaunchRejectedException">Thrown when the launch request is rejected.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        public Task<AppControlResult> SendLaunchRequestAsync(AppControl control, AppControlReplyCallback replyAfterLaunching)
        {
            int ret = Interop.AppControl.SetCallerInstanceId(control.SafeAppControlHandle, Id);
            if (ret != 0)
                throw new ArgumentException("Failed to set id");

            return AppControl.SendLaunchRequestAsync(control, replyAfterLaunching);
        }
    }
}
