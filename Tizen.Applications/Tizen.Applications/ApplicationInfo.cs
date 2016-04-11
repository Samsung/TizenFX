// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the application.
    /// </summary>
    public class ApplicationInfo : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        private IntPtr _infoHandle;

        internal ApplicationInfo(IntPtr infoHandle)
        {
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// Destructor of the class
        /// </summary>
        ~ApplicationInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the application id.
        /// </summary>
        public string ApplicationId
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetAppId(_infoHandle, out ptr);
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
        /// Gets the package id of the application.
        /// </summary>
        public string PackageId
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetPackage(_infoHandle, out ptr);
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
        /// Gets the label of the application.
        /// </summary>
        public string Label
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetLabel(_infoHandle, out ptr);
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
        /// Gets the excutable path of the application.
        /// </summary>
        public string ExcutablePath
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetExec(_infoHandle, out ptr);
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
        /// Gets the absolute path to the icon image. 
        /// </summary>
        public string IconPath
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetIcon(_infoHandle, out ptr);
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
        /// Gets the package type name.
        /// </summary>
        public string Type
        {
            get
            {
                IntPtr ptr = IntPtr.Zero;
                Interop.ApplicationManager.AppInfoGetType(_infoHandle, out ptr);
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
        /// Gets the application's metadata.
        /// </summary>
        public IDictionary<String, String> Metadata
        {
            get
            {
                IDictionary<string, string> metadata = new Dictionary<String, String>();

                Interop.ApplicationManager.AppInfoMetadataCallback cb = (string key, string value, IntPtr userData) =>
                {
                    if (key.Length != 0)
                    {
                        metadata.Add(key, value);
                    }
                    return true;
                };

                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoForeachMetadata(_infoHandle, cb, IntPtr.Zero);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get metadata of the application. err = " + err);
                }
                return metadata;
            }
        }

        /// <summary>
        /// Checks whether application information is nodisplay. If the application icon is not displayed on the menu screen, true; otherwise, false.
        /// </summary>
        public bool IsNoDisplay
        {
            get
            {
                bool nodisplay = false;
                Interop.ApplicationManager.AppInfoIsNodisplay(_infoHandle, out nodisplay);
                return nodisplay;
            }
        }

        /// <summary>
        /// Checks whether application is launched on booting time. If the application will be automatically start on boot, true; otherwise, false.
        /// </summary>
        public bool IsOnBoot
        {
            get
            {
                bool onboot = false;
                Interop.ApplicationManager.AppInfoIsOnBoot(_infoHandle, out onboot);
                return onboot;
            }
        }

        /// <summary>
        /// Checks whether application is preloaded. If the application is preloaded, true; otherwise, false.
        /// </summary>
        public bool IsPreload
        {
            get
            {
                bool preloaded = false;
                Interop.ApplicationManager.AppInfoIsPreLoad(_infoHandle, out preloaded);
                return preloaded;
            }
        }

        /// <summary>
        /// Gets the application's process id. If the application is not running, the value will be zero (0).
        /// </summary>
        public int ProcessId
        {
            get
            {
                int pid = 0;
                IntPtr contextHandle = IntPtr.Zero;
                try
                {
                    Interop.ApplicationManager.AppManagerGetAppContext(ApplicationId, out contextHandle);
                    Interop.ApplicationManager.AppContextGetPid(contextHandle, out pid);
                }
                finally
                {
                    if (contextHandle != IntPtr.Zero)
                    {
                        Interop.ApplicationManager.AppContextDestroy(contextHandle);
                    }
                }
                return pid;
            }
        }

        /// <summary>
        /// Checks whether the application is running. It returns the installed application running state.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                bool running = false;
                Interop.ApplicationManager.AppManagerIsRunning(ApplicationId, out running);
                return running;
            }
        }

        /// <summary>
        /// Gets the localized label of application for the given locale.
        /// </summary>
        /// <param name="locale">locale.</param>
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

        /// <summary>
        /// Releases all resources used by the ApplicationInfo class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
            }
            if (_infoHandle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppInfoDestroy(_infoHandle);
                _infoHandle = IntPtr.Zero;
            }
            _disposed = true;
        }
    }
}
