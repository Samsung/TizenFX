/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications.Manager
{
    /// <summary>
    /// InstalledApplicationMetadataFilter class. This class is a parameter of InstallerApplicationAppsAsync method.
    /// </summary>
    public class InstalledApplicationMetadataFilter : IDisposable
    {
        private IntPtr _handle;
        private bool disposed = false;

        public InstalledApplicationMetadataFilter(IDictionary<string, string> filter)
        {
            Interop.ApplicationManager.AppInfoMetadataFilterCreate(out _handle);
            foreach (var item in filter)
            {
                Interop.ApplicationManager.AppInfoMetadataFilterAdd(_handle, item.Key, item.Value);
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }

        ~InstalledApplicationMetadataFilter()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                // to be used if there are any other disposable objects
            }
            if (_handle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppInfoMetadataFilterDestroy(_handle);
            }
            disposed = true;
        }
    }
}
