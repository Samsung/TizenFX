using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// This is a base class for components
    /// </summary>
    public abstract class BaseComponent
    {
        internal IntPtr Handle;

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
        public string Id { get; private set; }

        /// <summary>
        /// Component ID
        /// </summary>
        public string ComponentId { get; }

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

        internal void Bind(IntPtr handle, string id)
        {
            Handle = handle;
            Id = id;
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
    }
}
