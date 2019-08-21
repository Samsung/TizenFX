using ElmSharp;
using System;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.Applications.ComponentBased.Default
{
    /// <summary>
    /// Window information class for ComponentBasedApplication
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class EFLWindowInfo : IWindowInfo
    {
        private const string LogTag = "Tizen.Applications.EFLWindow";
        private EvasObject _win;
        private int _resId;

        /// <summary>
        /// Initializes the EFLWindow class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        /// <since_tizen> 6 </since_tizen>
        public EFLWindowInfo(EvasObject win)
        {
            _win = win;
        }

        /// <summary>
        /// Gets the resource ID of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        /// <since_tizen> 6 </since_tizen>
        public int ResourceId
        {
            get
            {
                if (_resId == 0)
                {
                    int err = Interop.EflCBApplication.GetResourceId(_win.RealHandle, out _resId);
                    if (err != 0)
                        Log.Info(LogTag, "elm_config_accel_preference_set is not called");
                }

                return _resId;
            }
        }

    }

}
