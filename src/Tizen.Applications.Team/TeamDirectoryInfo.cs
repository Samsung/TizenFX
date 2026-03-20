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
using System.ComponentModel;
using System.IO;
using Tizen.Internals;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    public class TeamDirectoryInfo
    {
        private IntPtr _memberHandle;
        private string _dataPath;
        private string _cachePath;
        private string _resourcePath;
        private string _sharedDataPath;
        private string _sharedResourcePath;
        private string _sharedTrustedPath;
        private string _externalDataPath;
        private string _externalCachePath;
        private string _externalSharedDataPath;
        private string _expansionPackageResourcePath;
        private string _commonDataPath;
        private string _commonCachePath;
        private string _commonSharedDataPath;
        private string _commonSharedTrustedPath;

        internal TeamDirectoryInfo(IntPtr memberHandle)
        {
            _memberHandle = memberHandle;
        }

        public string Data
        {
            get
            {
                if (_dataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("Data", err);
                    _dataPath = path;
                }
                return _dataPath;
            }
        }

        public string Cache
        {
            get
            {
                if (_cachePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCachePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("Cache", err);
                    _cachePath = path;
                }
                return _cachePath;
            }
        }

        public string Resource
        {
            get
            {
                if (_resourcePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetResourcePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("Resource", err);
                    _resourcePath = path;
                }
                return _resourcePath;
            }
        }

        public string SharedData
        {
            get
            {
                if (_sharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("SharedData", err);
                    _sharedDataPath = path;
                }
                return _sharedDataPath;
            }
        }

        public string SharedResource
        {
            get
            {
                if (_sharedResourcePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedResourcePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("SharedResource", err);
                    _sharedResourcePath = path;
                }
                return _sharedResourcePath;
            }
        }

        public string SharedTrusted
        {
            get
            {
                if (_sharedTrustedPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetSharedTrustedPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("SharedTrusted", err);
                    _sharedTrustedPath = path;
                }
                return _sharedTrustedPath;
            }
        }

        public string ExternalData
        {
            get
            {
                if (_externalDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetExternDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("ExternalData", err);
                    _externalDataPath = path;
                }
                return _externalDataPath;
            }
        }

        public string ExternalCache
        {
            get
            {
                if (_externalCachePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetExternCachePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("ExternalCache", err);
                    _externalCachePath = path;
                }
                return _externalCachePath;
            }
        }

        public string ExternalSharedData
        {
            get
            {
                if (_externalSharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetExternSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("ExternalSharedData", err);
                    _externalSharedDataPath = path;
                }
                return _externalSharedDataPath;
            }
        }

        public string ExpansionPackageResource
        {
            get
            {
                if (_expansionPackageResourcePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetTepResourcePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("ExpansionPackageResource", err);
                    _expansionPackageResourcePath = path;
                }
                return _expansionPackageResourcePath;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonData
        {
            get
            {
                if (_commonDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("CommonData", err);
                    _commonDataPath = path;
                }
                return _commonDataPath;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonCache
        {
            get
            {
                if (_commonCachePath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonCachePath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("CommonCache", err);
                    _commonCachePath = path;
                }
                return _commonCachePath;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedData
        {
            get
            {
                if (_commonSharedDataPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonSharedDataPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("CommonSharedData", err);
                    _commonSharedDataPath = path;
                }
                return _commonSharedDataPath;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedTrusted
        {
            get
            {
                if (_commonSharedTrustedPath == null)
                {
                    Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetCommonSharedTrustedPath(_memberHandle, out string path);
                    if (err != Interop.TeamManager.TeamAppErrorCode.None)
                        throw GetExceptionFromError("CommonSharedTrusted", err);
                    _commonSharedTrustedPath = path;
                }
                return _commonSharedTrustedPath;
            }
        }

        public string GetResourceControlAllowedResource(string resType)
        {
            Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetResControlAllowedPath(_memberHandle, resType, out string path);
            if (err != Interop.TeamManager.TeamAppErrorCode.None)
                throw GetExceptionFromError($"GetResourceControlAllowedResource({resType})", err);
            return path;
        }

        public string GetResourceControlGlobalResource(string resType)
        {
            Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetResControlGlobalPath(_memberHandle, resType, out string path);
            if (err != Interop.TeamManager.TeamAppErrorCode.None)
                throw GetExceptionFromError($"GetResourceControlGlobalResource({resType})", err);
            return path;
        }

        private Exception GetExceptionFromError(string operationName, Interop.TeamManager.TeamAppErrorCode err)
        {
            switch (err)
            {
                case Interop.TeamManager.TeamAppErrorCode.InvalidParameter:
                    return new ArgumentException($"Invalid Arguments for {operationName}");
                case Interop.TeamManager.TeamAppErrorCode.OutOfMemory:
                    return new OutOfMemoryException($"Out of memory for {operationName}");
                case Interop.TeamManager.TeamAppErrorCode.InvalidContext:
                    return new InvalidOperationException($"Invalid team member context for {operationName}");
                case Interop.TeamManager.TeamAppErrorCode.NoSuchMember:
                    return new DirectoryNotFoundException($"{operationName} not found");
                default:
                    return new InvalidOperationException($"Failed to get {operationName}");
            }
        }
    }
}