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
    /// <summary>
    /// Represents the directory paths available to a Team application instance.
    /// </summary>
    /// <remarks>
    /// Each path is resolved lazily on first access and cached. Any failure in the native call is translated
    /// into a .NET exception; see each property for the specific exceptions that can be thrown.
    /// </remarks>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamDirectoryInfo : IDirectoryInfo
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

        /// <summary>
        /// Gets the absolute path to the private data directory of this Team application.
        /// </summary>
        /// <value>The private data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the private cache directory of this Team application.
        /// </summary>
        /// <value>The private cache directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the read-only resource directory of this Team application.
        /// </summary>
        /// <value>The read-only resource directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the directory shared with other applications.
        /// </summary>
        /// <value>The shared data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the read-only resource directory shared with other applications.
        /// </summary>
        /// <value>The shared resource directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the directory shared only with trusted applications.
        /// </summary>
        /// <value>The shared trusted directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the private data directory on the external storage.
        /// </summary>
        /// <value>The external data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the private cache directory on the external storage.
        /// </summary>
        /// <value>The external cache directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the shared directory on the external storage.
        /// </summary>
        /// <value>The external shared data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the resource directory of the Tizen Expansion Package.
        /// </summary>
        /// <value>The expansion package resource directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Gets the absolute path to the common data directory shared among users.
        /// </summary>
        /// <value>The common data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
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

        /// <summary>
        /// Gets the absolute path to the common cache directory shared among users.
        /// </summary>
        /// <value>The common cache directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
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

        /// <summary>
        /// Gets the absolute path to the common shared data directory shared among users.
        /// </summary>
        /// <value>The common shared data directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
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

        /// <summary>
        /// Gets the absolute path to the common shared trusted directory shared among users.
        /// </summary>
        /// <value>The common shared trusted directory path.</value>
        /// <exception cref="ArgumentException">Thrown when the member handle is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
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

        /// <summary>
        /// Gets the absolute path to the resource directory allowed by resource control for the given resource type.
        /// </summary>
        /// <param name="resType">The resource type.</param>
        /// <returns>The path to the allowed resource directory.</returns>
        /// <exception cref="ArgumentException">Thrown when the member handle or <paramref name="resType"/> is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetResourceControlAllowedResource(string resType)
        {
            Interop.TeamManager.TeamAppErrorCode err = Interop.TeamManager.TeamAppGetResControlAllowedPath(_memberHandle, resType, out string path);
            if (err != Interop.TeamManager.TeamAppErrorCode.None)
                throw GetExceptionFromError($"GetResourceControlAllowedResource({resType})", err);
            return path;
        }

        /// <summary>
        /// Gets the absolute path to the global resource directory by resource control for the given resource type.
        /// </summary>
        /// <param name="resType">The resource type.</param>
        /// <returns>The path to the global resource directory.</returns>
        /// <exception cref="ArgumentException">Thrown when the member handle or <paramref name="resType"/> is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system runs out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the team member context is invalid or the path cannot be retrieved.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when the Team member is not found.</exception>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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
