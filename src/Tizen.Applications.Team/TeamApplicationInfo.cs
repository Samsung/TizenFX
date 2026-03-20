/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Internals;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    public class TeamApplicationInfo : IDisposable
    {
        private const string LogTag = "DN_TAMS";
        private bool _disposed = false;
        private IntPtr _infoHandle = IntPtr.Zero;
        private IntPtr _memberHandle = IntPtr.Zero;
        private string _applicationId = string.Empty;
        private Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;

        // Cached path fields
        private string _sharedDataPath = null;
        private string _sharedResourcePath = null;
        private string _sharedTrustedPath = null;
        private string _externalSharedDataPath = null;
        private string _commonSharedDataPath = null;
        private string _commonSharedTrustedPath = null;

        internal TeamApplicationInfo(IntPtr memberHandle, string applicationId)
        {
            _memberHandle = memberHandle;
            _applicationId = applicationId;
        }

        ~TeamApplicationInfo()
        {
            Dispose(false);
        }

        public string ApplicationId
        {
            get
            {
                return _applicationId;
            }
        }

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

                GC.KeepAlive(cb);

                return metadata;
            }
        }

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

                GC.KeepAlive(cb);

                return categories;
            }
        }

        public string SharedDataPath
        {
            get
            {
                if (_sharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the SharedDataPath of " + _applicationId + ". err = " + err);
                    }
                    _sharedDataPath = path;
                }
                return _sharedDataPath;
            }
        }

        public string SharedResourcePath
        {
            get
            {
                if (_sharedResourcePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedResourcePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the SharedResourcePath of " + _applicationId + ". err = " + err);
                    }
                    _sharedResourcePath = path;
                }
                return _sharedResourcePath;
            }
        }

        public string SharedTrustedPath
        {
            get
            {
                if (_sharedTrustedPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedTrustedPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the SharedTrustedPath of " + _applicationId + ". err = " + err);
                    }
                    _sharedTrustedPath = path;
                }
                return _sharedTrustedPath;
            }
        }

        public string ExternalSharedDataPath
        {
            get
            {
                if (_externalSharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetExternSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the ExternalSharedDataPath of " + _applicationId + ". err = " + err);
                    }
                    _externalSharedDataPath = path;
                }
                return _externalSharedDataPath;
            }
        }

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
                if (infoHandle != IntPtr.Zero)
                {
                    err = Interop.ApplicationManager.AppInfoForeachResControl(infoHandle, cb, IntPtr.Zero);
                    if (err != Interop.ApplicationManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the resource controls of " + _applicationId + ". err = " + err);
                    }
                }

                GC.KeepAlive(cb);

                return resourceControls;
            }
        }

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedDataPath
        {
            get
            {
                if (_commonSharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the CommonSharedDataPath of " + _applicationId + ". err = " + err);
                    }
                    _commonSharedDataPath = path;
                }
                return _commonSharedDataPath;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedTrustedPath
        {
            get
            {
                if (_commonSharedTrustedPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonSharedTrustedPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                    {
                        Log.Warn(LogTag, "Failed to get the CommonSharedTrustedPath of " + _applicationId + ". err = " + err);
                    }
                    _commonSharedTrustedPath = path;
                }
                return _commonSharedTrustedPath;
            }
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

#pragma warning disable CA1063
        private void Dispose(bool disposing)
#pragma warning restore CA1063
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
