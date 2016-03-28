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
    /// InstalledApplicationFilter class. This class is a parameter of InstallerApplicationAppsAsync method.
    /// </summary>
    public class InstalledApplicationFilter : IDisposable
    {
        /// <summary>
        /// Keys class. This class is a possible key to use in the InstalledApplicationFilter.
        /// </summary>
        public static class Keys
        {
            /// <summary>
            ///
            /// </summary>
            public const string Id = "PACKAGE_INFO_PROP_APP_ID";
            /// <summary>
            ///
            /// </summary>
            public const string Type = "PACKAGE_INFO_PROP_APP_TYPE";
            /// <summary>
            ///
            /// </summary>
            public const string Category = "PACKAGE_INFO_PROP_APP_CATEGORY";
            /// <summary>
            ///
            /// </summary>
            public const string NoDisplay = "PACKAGE_INFO_PROP_APP_NODISPLAY";
            /// <summary>
            ///
            /// </summary>
            public const string TaskManage = "PACKAGE_INFO_PROP_APP_TASKMANAGE";
        }

        private IntPtr _handle;
        private bool disposed = false;

        public InstalledApplicationFilter(IDictionary<string, string> filter)
        {
            Interop.ApplicationManager.AppInfoFilterCreate(out _handle);
            foreach (var item in filter)
            {
                if ((item.Key == Keys.Id) || (item.Key == Keys.Type) || (item.Key == Keys.Category))
                {
                    Interop.ApplicationManager.AppInfoFilterAddString(_handle, item.Key, item.Value);
                }
                else if ((item.Key == Keys.NoDisplay) || (item.Key == Keys.TaskManage))
                {
                    Interop.ApplicationManager.AppInfoFilterAddBool(_handle, item.Key, Convert.ToBoolean(item.Value));
                }
                else
                {
                    // Not Supported Key
                    Console.WriteLine(item.Key + " is NOT supported for the InstalledApplicationFilter");
                }
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }

        ~InstalledApplicationFilter()
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
                Interop.ApplicationManager.AppInfoFilterDestroy(_handle);
            }
            disposed = true;
        }
    }

}
