using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// TetheringExtensionModeChangedEventArgs provides the mode information when the ModeChanged event is raised.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringExtensionModeChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The tethering mode.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public TetheringExtensionMode Mode { get; }

        /// <summary>
        /// Constructor for TetheringExtensionModeChangedEventArgs.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        /// <param name="mode">The tethering mode (Enabled or Disabled).</param>
        public TetheringExtensionModeChangedEventArgs(TetheringExtensionMode mode)
        {
            Mode = mode;
        }
    }
}
