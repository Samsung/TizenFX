using ElmSharp;
using System;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.Applications.ComponentBased.Default
{
    /// <summary>
    /// Window class for basic application type
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ElmWindow : IWindow
    {
        internal static readonly string LogTag = typeof(ElmWindow).Namespace;
        private EvasObject _win;
        private int _resId;

        /// <summary>
        /// Initializes the CBBasicApplication class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        /// <since_tizen> 6 </since_tizen>
        public ElmWindow(EvasObject win)
        {
            _win = win;
        }

        /// <summary>
        /// Gets the raw handle of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        /// <since_tizen> 6 </since_tizen>
        public IntPtr GetRaw()
        {
            return _win.RealHandle;
        }

        /// <summary>
        /// Gets the resource ID of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        /// <since_tizen> 6 </since_tizen>
        public int GetResId()
        {
            if (_resId == 0)
            {
                int err = Interop.EflCBApplication.GetResourceId(GetRaw(), out _resId);
                if (err != 0)
                    Log.Info(LogTag, "elm_config_accel_preference_set is not called");
            }

            return _resId;
        }
    }

}
