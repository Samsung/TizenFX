/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Applications.Managers
{
    /// <summary>
    /// InstalledApplication class. This class has the methods and properties of InstalledApplication.
    /// </summary>
    public class InstalledApplication : IDisposable
    {
        private IntPtr _handle;
        private bool disposed = false;

        private const string LogTag = "Tizen.Applications.Managers";

        internal InstalledApplication(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// ApplicationId property.
        /// </summary>
        /// <returns>string application id.</returns>
        public string ApplicationId
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetAppId(_handle, out ptr);
                string appid = "";
                if (ptr != IntPtr.Zero)
                {
                    appid = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get ApplicationId failed.");
                }
                return appid;
            }
        }
        /// <summary>
        /// PackageId property.
        /// </summary>
        /// <returns>string package id.</returns>
        public string PackageId
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetPackage(_handle, out ptr);
                string packageid = "";
                if (ptr != IntPtr.Zero)
                {
                    packageid = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get PackageId failed.");
                }
                return packageid;
            }
        }
        /// <summary>
        /// Label property.
        /// </summary>
        /// <returns>string label.</returns>
        public string Label
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetLabel(_handle, out ptr);
                string label = "";
                if (ptr != IntPtr.Zero)
                {
                    label = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get Label failed.");
                }
                return label;
            }
        }
        /// <summary>
        /// ExcutablePath property.
        /// </summary>
        /// <returns>string executable path.</returns>
        public string ExcutablePath
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetExec(_handle, out ptr);
                string exec = "";
                if (ptr != IntPtr.Zero)
                {
                    exec = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get ExcutablePath failed.");
                }
                return exec;
            }
        }
        /// <summary>
        /// IconPath property.
        /// </summary>
        /// <returns>string icon path.</returns>
        public string IconPath
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetIcon(_handle, out ptr);
                string path = "";
                if (ptr != IntPtr.Zero)
                {
                    path = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get IconPath failed.");
                }
                return path;
            }
        }
        /// <summary>
        /// Type property.
        /// </summary>
        /// <returns>string application type.</returns>
        public string Type
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetType(_handle, out ptr);
                string type = "";
                if (ptr != IntPtr.Zero)
                {
                    type = Marshal.PtrToStringAuto(ptr);
                }
                else
                {
                    Log.Warn(LogTag, "InstalledApplication get Type failed.");
                }
                return type;
            }
        }

        /// <summary>
        /// Metadata property.
        /// </summary>
        /// <returns>It returns IDictionary object with string key value pairs.</returns>
        public IDictionary<String, String> Metadata
        {
            get
            {
                IDictionary<string, string> metadata = new Dictionary<String, String>();

                Interop.ApplicationManager.AppInfoMetadataCallback cb = (string key, string value, IntPtr userData) =>
                {
                    Log.Debug(LogTag, "AppInfoMetadataCallback");
                    if (key.Length != 0)
                    {
                        metadata.Add(key, value);
                    }
                    return true;
                };

                int ret = Interop.ApplicationManager.AppInfoForeachMetadata(_handle, cb, IntPtr.Zero);
                if (ret != 0)
                {
                    Log.Warn(LogTag, "InstalledApplication get Metadata failed.");
                }
                return metadata;
            }
        }
        /// <summary>
        /// NoDisplay property.
        /// </summary>
        /// <returns>bool. If the application icon is not displayed on the menu screen, true; otherwise, false.</returns>
        public bool NoDisplay
        {
            get
            {
                bool nodisplay = false;
                Interop.ApplicationManager.AppInfoIsNodisplay(_handle, out nodisplay);
                return nodisplay;
            }
        }
        /// <summary>
        /// OnBoot property.
        /// </summary>
        /// <returns>bool. If the application will be automatically start on boot, true; otherwise, false.</returns>
        public bool OnBoot
        {
            get
            {
                bool onboot = false;
                Interop.ApplicationManager.AppInfoIsOnBoot(_handle, out onboot);
                return onboot;
            }
        }
        /// <summary>
        /// PreLoaded property.
        /// </summary>
        /// <returns>bool. If the application is preloaded, true; otherwise, false.</returns>
        public bool PreLoaded
        {
            get
            {
                bool preloaded = false;
                Interop.ApplicationManager.AppInfoIsPreLoad(_handle, out preloaded);
                return preloaded;
            }
        }
        /// <summary>
        /// GetLocalizedLabel method.
        /// </summary>
        /// <param name="locale">string locale.</param>
        /// <returns>string Localized Label. It returns the label for the input locale.</returns>
        public string GetLocalizedLabel(string locale)
        {
            IntPtr ptr = IntPtr.Zero;
            Interop.ApplicationManager.AppInfoGetLocaledLabel(ApplicationId, locale, out ptr);
            string label = Label;
            if (ptr != IntPtr.Zero)
            {
                label = Marshal.PtrToStringAuto(ptr);
            }
            else
            {
                Log.Warn(LogTag, "InstalledApplication GetLocalizedLabel(" + locale + ") failed.");
            }
            return label;
        }

        ~InstalledApplication()
        {
            Dispose(false);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(disposed)
                return;
            if(disposing)
            {
                // to be used if there are any other disposable objects
            }
            if (_handle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppInfoDestroy(_handle);
                _handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
