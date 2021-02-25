using System;
using Tizen.NUI;
using Tizen.Applications.ComponentBased.Common;

namespace Tizen.NUI
{
    /// <summary>
    /// Window information class for ComponentApplication
    /// </summary>
    internal class NUIWindowInfo : IWindowInfo
    {
        private const string LogTag = "Tizen.NUI";
        private Window _win;
        private int _resId;
        private bool _disposed = false;

        /// <summary>
        /// Initializes the NUI Window class.
        /// </summary>
        /// <param name="win">The window object of component.</param>
        internal NUIWindowInfo(Window win)
        {
            _win = win;
        }

        /// <summary>
        /// Gets the resource ID of window
        /// </summary>
        /// <returns>The native handle of window</returns>
        public int ResourceId
        {
            get
            {
                if (_resId == 0)
                {
                    _resId = _win.GetNativeId();
                    if (_resId != 0)
                        Log.Info(LogTag, "Fail to get resource ID");
                }

                return _resId;
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _win.Dispose();
                _win = null;
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose the window resources
        /// </summary>
        /// <returns></returns>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

