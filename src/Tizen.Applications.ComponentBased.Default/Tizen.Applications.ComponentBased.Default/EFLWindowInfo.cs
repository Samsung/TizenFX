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
        private const string LogTag = "Tizen.Applications";
        private Window _win;
        private int _resId;
        private bool _disposed = false;

        /// <summary>
        /// Initializes the EFLWindow class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        /// <since_tizen> 6 </since_tizen>
        public EFLWindowInfo(Window win)
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
                        Log.Info(LogTag, "Fail to get resource ID");
                }

                return _resId;
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
            }

            _win.Unrealize();
            _win = null;
            _disposed = true;
        }

        /// <summary>
        /// Dispose the window resources
        /// </summary>
        /// <returns></returns>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
