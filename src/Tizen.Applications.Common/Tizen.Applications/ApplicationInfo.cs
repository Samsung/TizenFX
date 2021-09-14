/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ApplicationInfo : IDisposable
    {
        private const string LogTag = "Tizen.Applications";
        private bool _disposed = false;
        private IntPtr _infoHandle = IntPtr.Zero;
        private string _applicationId = string.Empty;
        private Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

        internal ApplicationInfo(IntPtr infoHandle)
        {
            err = Interop.ApplicationManager.AppInfoGetAppId(infoHandle, out _applicationId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw new ArgumentException("Invalid native handle.");
            }
            _infoHandle = infoHandle;
        }

        /// <summary>
        /// A constructor of ApplicationInfo that takes the application ID.
        /// </summary>
        /// <param name="applicationId">Application ID.</param>
        /// <since_tizen> 3 </since_tizen>
        public ApplicationInfo(string applicationId)
        {
            _applicationId = applicationId;
        }

        /// <summary>
        /// Destructor of the class.
        /// </summary>
        ~ApplicationInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    err = Interop.ApplicationManager.AppInfoGetAppId(infoHandle, out appid);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the application id. err = " + err);
                    }
                }
                return appid;
            }
        }

        /// <summary>
        /// Gets the package ID of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PackageId
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string packageid = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetPackage(infoHandle, out packageid);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the package id of " + _applicationId + ". err = " + err);
                    }
                }
                return packageid;
            }
        }

        /// <summary>
        /// Gets the label of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Label
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string label = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetLabel(infoHandle, out label);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the app label of " + _applicationId + ". err = " + err);
                    }
                }
                return label;
            }
        }

        /// <summary>
        /// Gets the executable path of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExecutablePath
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string exec = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetExec(infoHandle, out exec);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the executable file path of " + _applicationId + ". err = " + err);
                    }
                }
                return exec;
            }
        }

        /// <summary>
        /// Gets the absolute path to the icon image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IconPath
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string path = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetIcon(infoHandle, out path);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the app icon path of " + _applicationId + ". err = " + err);
                    }
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the application type name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ApplicationType
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                string type = string.Empty;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetType(infoHandle, out type);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the application type of " + _applicationId + ". err = " + err);
                    }
                }
                return type;
            }
        }

        /// <summary>
        /// Gets the application component type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ApplicationComponentType ComponentType
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                Interop.ApplicationManager.AppInfoAppComponentType componentType = 0;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoGetAppComponentType(infoHandle, out componentType);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the application component type of " + _applicationId + ". err = " + err);
                    }
                }
                return (ApplicationComponentType)componentType;
            }
        }

        /// <summary>
        /// Gets the application's metadata.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IDictionary<String, String> Metadata
        {
            get
            {
                IDictionary<string, string> metadata = new Dictionary<String, String>();

                Interop.ApplicationManager.AppInfoMetadataCallback cb = (string key, string value, IntPtr userData) =>
                {
                    if (key.Length != 0)
                    {
                        if (!metadata.ContainsKey(key))
                            metadata.Add(key, value);
                    }
                    return true;
                };

                IntPtr infoHandle = GetInfoHandle();
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoForeachMetadata(infoHandle, cb, IntPtr.Zero);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get application metadata of " + _applicationId + ". err = " + err);
                    }
                }
                return metadata;
            }
        }

        /// <summary>
        /// Checks whether the application information is nodisplay. If the application icon is not displayed on the menu screen, true; otherwise, false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsNoDisplay
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool nodisplay = false;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoIsNodisplay(infoHandle, out nodisplay);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the IsNoDisplay value of " + _applicationId + ". err = " + err);

                    }
                }
                return nodisplay;
            }
        }

        /// <summary>
        /// Checks whether the application is launched on booting time. If the application automatically starts on boot, true; otherwise, false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOnBoot
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool onboot = false;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoIsOnBoot(infoHandle, out onboot);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the IsOnBoot value of " + _applicationId + ". err = " + err);
                    }
                }
                return onboot;
            }
        }

        /// <summary>
        /// Checks whether the application is preloaded. If the application is preloaded, true; otherwise, false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsPreload
        {
            get
            {
                IntPtr infoHandle = GetInfoHandle();
                bool preloaded = false;
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoIsPreLoad(infoHandle, out preloaded);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the IsPreload value of " + _applicationId + ". err = " + err);
                    }
                }
                return preloaded;
            }
        }

        /// <summary>
        /// Gets the application's category values specified in the tizen-manifest
        /// </summary>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<string> Categories
        {
            get
            {
                List<string> categories = new List<string>();

                Interop.ApplicationManager.AppInfoCategoryCallback cb = (string category, IntPtr userData) =>
                {
                    categories.Add(category);
                    return true;
                };

                IntPtr infoHandle = GetInfoHandle();
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoForeachCategory(infoHandle, cb, IntPtr.Zero);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get application category of " + _applicationId + ". err = " + err);
                    }
                }
                return categories;
            }
        }

        /// <summary>
        /// Gets the shared data path.
        /// </summary>
        /// <remarks>
        /// An application that wants to use shared/data directory must declare http://tizen.org/privilege/appdir.shareddata privilege. If the application doesn't declare the privilege, the framework will not create shared/data directory for the application. This property will return empty string when the application doesn't have shared/data directory.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public string SharedDataPath
        {
            get
            {
                string path = string.Empty;
                err = Interop.ApplicationManager.AppManagerGetSharedDataPath(ApplicationId, out path);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the SharedDataPath of " + _applicationId + ". err = " + err);
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the shared resource path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SharedResourcePath
        {
            get
            {
                string path = string.Empty;
                err = Interop.ApplicationManager.AppManagerGetSharedResourcePath(ApplicationId, out path);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the SharedResourcePath of " + _applicationId + ". err = " + err);
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the shared trust path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SharedTrustedPath
        {
            get
            {
                string path = string.Empty;
                err = Interop.ApplicationManager.AppManagerGetSharedTrustedPath(ApplicationId, out path);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the SharedTrustedPath of " + _applicationId + ". err = " + err);
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the external shared data path.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExternalSharedDataPath
        {
            get
            {
                string path = string.Empty;
                err = Interop.ApplicationManager.AppManagerGetExternalSharedDataPath(ApplicationId, out path);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the ExternalSharedDataPath of " + _applicationId + ". err = " + err);
                }
                return path;
            }
        }

        /// <summary>
        /// Gets the resource controls.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IEnumerable<ResourceControl> ResourceControls
        {
            get
            {
                List<ResourceControl> resourceControls = new List<ResourceControl>();
                Interop.ApplicationManager.AppInfoResControlCallback cb = (string resType, string minResourceVersion, string maxResourceVersion, string isAutoClose, IntPtr userData) =>
                {
                    resourceControls.Add(new ResourceControl(resType, minResourceVersion, maxResourceVersion, isAutoClose == "true"));
                    return true;
                };

                IntPtr infoHandle = GetInfoHandle();
                if (infoHandle != null)
                {
                    err = Interop.ApplicationManager.AppInfoForeachResControl(infoHandle, cb, IntPtr.Zero);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the resource controls of " + _applicationId + ". err = " + err);
                    }
                }

                return resourceControls;
            }
        }

        /// <summary>
        /// Gets the localized label of the application for the given locale.
        /// </summary>
        /// <param name="locale">Locale.</param>
        /// <returns>The localized label.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetLocalizedLabel(string locale)
        {
            string label = string.Empty;
            err = Interop.ApplicationManager.AppInfoGetLocaledLabel(ApplicationId, locale, out label);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get the GetLocalizedLabel of " + _applicationId + ". err = " + err);
                label = Label;
            }
            return label;
        }

        private IntPtr GetInfoHandle()
        {
            if (_infoHandle == IntPtr.Zero)
            {
                IntPtr infoHandle = IntPtr.Zero;
                err = Interop.ApplicationManager.AppManagerGetAppInfo(_applicationId, out infoHandle);
                if (err != Interop.ApplicationManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get the handle of the ApplicationInfo. err = " + err);
                }
                _infoHandle = infoHandle;
            }
            return _infoHandle;
        }

        /// <summary>
        /// Releases all resources used by the ApplicationInfo class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
