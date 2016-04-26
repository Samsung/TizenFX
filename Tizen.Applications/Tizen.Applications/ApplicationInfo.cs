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
        private IntPtr _infoHandle = IntPtr.Zero;
        private string _applicationId = string.Empty;

        internal ApplicationInfo(IntPtr infoHandle)
        {
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// A constructor of ApplicationInfo that takes the application id.
        /// </summary>
        /// <param name="applicationId">application id.</param>
        public ApplicationInfo(string applicationId)
        {
            _applicationId = applicationId;
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
                if (!string.IsNullOrEmpty(_applicationId))
                    return _applicationId;
                IntPtr infoHandle = GetInfoHandle();
                string appid = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetAppId(infoHandle, out appid);
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
                IntPtr infoHandle = GetInfoHandle();
                string packageid = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetPackage(infoHandle, out packageid);
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
                IntPtr infoHandle = GetInfoHandle();
                string label = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetLabel(infoHandle, out label);
                }
                return label;
            }
        }

        /// <summary>
        /// Gets the executable path of the application.
        /// </summary>
        public string ExecutablePath
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string exec = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetExec(infoHandle, out exec);
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
                IntPtr infoHandle = GetInfoHandle();
                string path = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetIcon(infoHandle, out path);
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the application type name.
        /// </summary>
        public string ApplicationType
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string type = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoGetType(infoHandle, out type);
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

                IntPtr infoHandle = GetInfoHandle();
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppInfoForeachMetadata(infoHandle, cb, IntPtr.Zero);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get metadata of the application. err = " + err);
                    }
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
                IntPtr infoHandle = GetInfoHandle();
                bool nodisplay = false;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoIsNodisplay(infoHandle, out nodisplay);
                }
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
                IntPtr infoHandle = GetInfoHandle();
                bool onboot = false;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoIsOnBoot(infoHandle, out onboot);
                }
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
                IntPtr infoHandle = GetInfoHandle();
                bool preloaded = false;
                if (infoHandle != IntPtr.Zero)
                {
                    Interop.ApplicationManager.AppInfoIsPreLoad(infoHandle, out preloaded);
                }
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
        /// Gets the shared data path.
        /// </summary>
        public string SharedDataPath
        {
            get
            {
                string path = string.Empty;
                Interop.ApplicationManager.AppManagerGetSharedDataPath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the shared resource path.
        /// </summary>
        public string SharedResourcePath
        {
            get
            {
                string path = string.Empty;
                Interop.ApplicationManager.AppManagerGetSharedResourcePath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the shared trust path.
        /// </summary>
        public string SharedTrustedPath
        {
            get
            {
                string path = string.Empty;
                Interop.ApplicationManager.AppManagerGetSharedTrustedPath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the external shared data path.
        /// </summary>
        public string ExternalSharedDataPath
        {
            get
            {
                string path = string.Empty;
                Interop.ApplicationManager.AppManagerGetExternalSharedDataPath(ApplicationId, out path);
                return path;
            }
        }

        /// <summary>
        /// Gets the localized label of application for the given locale.
        /// </summary>
        /// <param name="locale">locale.</param>
        public string GetLocalizedLabel(string locale)
        {
            string label = Label;
            Interop.ApplicationManager.AppInfoGetLocaledLabel(ApplicationId, locale, out label);
            return label;
        }

        private IntPtr GetInfoHandle()
        {
            if (_infoHandle == IntPtr.Zero)
            {
                IntPtr infoHandle = IntPtr.Zero;
                Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.AppManagerGetAppInfo(_applicationId, out infoHandle);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the handle of the ApplicationInfo.");
                }
                _infoHandle = infoHandle;
            }
            return _infoHandle;
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
