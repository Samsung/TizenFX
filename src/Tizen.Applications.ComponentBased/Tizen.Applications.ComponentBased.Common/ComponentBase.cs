using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.ComponentBased.Common
{
    /// <summary>
    /// This is a base class for components
    /// </summary>
    public abstract class ComponentBase
    {
        /// <summary>
        /// Occurs when the system memory is low.
        /// </summary>
        public EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// Occurs when the system battery is low.
        /// </summary>
        public EventHandler<LowBatteryEventArgs> LowBattery;

        /// <summary>
        /// Occurs when the system language is chagned.
        /// </summary>
        public EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// Occurs when the region format is changed.
        /// </summary>
        public EventHandler<RegionFormatChangedEventArgs> RegionFormatChanged;

        /// <summary>
        /// Occurs when the device orientation is changed.
        /// </summary>
        public EventHandler<DeviceOrientationEventArgs> DeviceOrientationChanged;

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

        /// <summary>
        /// Overrides this method if want to handle behavior to restore the previous status.
        /// </summary>
        /// <param name="c">Contents</param>
        protected virtual void OnRestoreContents(Bundle c)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior to save current status.
        /// </summary>
        /// <param name="c">Contents</param>
        protected virtual void OnSaveContent(Bundle c)
        {
        }
    }
}
