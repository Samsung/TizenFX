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

using System.IO;
using System;
using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents directory information of the application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DirectoryInfo
    {
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

        internal DirectoryInfo()
        {
        }

        /// <summary>
        /// Gets the absolute path to the application's data directory, which is used to store private data of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Data
        {
            get
            {
                if (_dataPath == null)
                    _dataPath = Interop.AppCommon.AppGetDataPath();
                return _dataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's cache directory, which is used to store temporary data of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Cache
        {
            get
            {
                if (_cachePath == null)
                    _cachePath = Interop.AppCommon.AppGetCachePath();
                return _cachePath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application resource directory. The resource files are delivered with the application package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Resource
        {
            get
            {
                if (_resourcePath == null)
                    _resourcePath = Interop.AppCommon.AppGetResourcePath();
                return _resourcePath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's shared data directory, which is used to share data with other applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SharedData
        {
            get
            {
                if (_sharedDataPath == null)
                    _sharedDataPath = Interop.AppCommon.AppGetSharedDataPath();
                return _sharedDataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's shared resource directory, which is used to share resources with other applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SharedResource
        {
            get
            {
                if (_sharedResourcePath == null)
                    _sharedResourcePath = Interop.AppCommon.AppGetSharedResourcePath();
                return _sharedResourcePath;
            }
        }


        /// <summary>
        /// Gets the absolute path to the application's shared trusted directory, which is used to share data with a family of trusted applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string SharedTrusted
        {
            get
            {
                if (_sharedTrustedPath == null)
                    _sharedTrustedPath = Interop.AppCommon.AppGetSharedTrustedPath();
                return _sharedTrustedPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's external data directory, which is used to store data of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExternalData
        {
            get
            {
                if (_externalDataPath == null)
                    _externalDataPath = Interop.AppCommon.AppGetExternalDataPath();
                return _externalDataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's external cache directory, which is used to store temporary data of the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExternalCache
        {
            get
            {
                if (_externalCachePath == null)
                    _externalCachePath = Interop.AppCommon.AppGetExternalCachePath();
                return _externalCachePath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's external shared data directory, which is used to share data with other applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExternalSharedData
        {
            get
            {
                if (_externalSharedDataPath == null)
                    _externalSharedDataPath = Interop.AppCommon.AppGetExternalSharedDataPath();
                return _externalSharedDataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's TEP(Tizen Expansion Package) directory. The resource files are delivered with the expansion package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ExpansionPackageResource
        {
            get
            {
                if (_expansionPackageResourcePath == null)
                    _expansionPackageResourcePath = Interop.AppCommon.AppGetTepResourcePath();
                return _expansionPackageResourcePath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's common data directory, which is used to store private data of the application.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonData
        {
            get
            {
                if (_dataPath == null)
                    _dataPath = Interop.AppCommon.AppGetCommonDataPath();
                return _dataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's common cache directory, which is used to store temporary data of the application.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonCache
        {
            get
            {
                if (_cachePath == null)
                    _cachePath = Interop.AppCommon.AppGetCommonCachePath();
                return _cachePath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's common shared data directory, which is used to share data with other applications.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedData
        {
            get
            {
                if (_sharedDataPath == null)
                    _sharedDataPath = Interop.AppCommon.AppGetCommonSharedDataPath();
                return _sharedDataPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's common shared trusted directory, which is used to share data with a family of trusted applications.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CommonSharedTrusted
        {
            get
            {
                if (_sharedTrustedPath == null)
                    _sharedTrustedPath = Interop.AppCommon.AppGetCommonSharedTrustedPath();
                return _sharedTrustedPath;
            }
        }

        /// <summary>
        /// Gets the absolute path to the application's resource control directory, which is used to share the allowed resources of the resource packages.
        /// </summary>
        /// <param name="resourceType">The resource type defined in the resource package</param>
        /// <returns> The absolute path to the application's resource control directory, which is used to share the allowed resources of the resource packages.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown in case of nonexistence of resource.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 11 </since_tizen>
        public string GetResourceControlAllowedResource(string resourceType)
        {
            string path = string.Empty;
            Interop.AppCommon.AppCommonErrorCode err = Interop.AppCommon.AppGetResControlAllowedResourcePath(resourceType, out path);
            if (err != Interop.AppCommon.AppCommonErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppCommon.AppCommonErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppCommon.AppCommonErrorCode.OutOfMemory:
                        throw new OutOfMemoryException("Out of memory");
                    case Interop.AppCommon.AppCommonErrorCode.InvalidContext:
                        throw new InvalidOperationException("Invalid app context");
                    case Interop.AppCommon.AppCommonErrorCode.PermissionDenied:
                        throw new DirectoryNotFoundException(String.Format("Allowed Resource about {0} is not Found", resourceType));
                    default:
                        throw new InvalidOperationException("Invalid Operation");
                }
            }

            return path;
        }

        /// <summary>
        /// Gets the absolute path to the application's resource control directory, which is used to share the global resources of the resource packages.
        /// </summary>
        /// <param name="resourceType">The resource type defined in the resource package</param>
        /// <returns> The absolute path to the application's resource control directory, which is used to share the global resources of the resource packages.</returns>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown in case of out of memory.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown in case of nonexistence of resource.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <since_tizen> 11 </since_tizen>
        public string GetResourceControlGlobalResource(string resourceType)
        {
            string path = string.Empty;
            Interop.AppCommon.AppCommonErrorCode err = Interop.AppCommon.AppGetResControlGlobalResourcePath(resourceType, out path);
            if (err != Interop.AppCommon.AppCommonErrorCode.None)
            {
                switch (err)
                {
                    case Interop.AppCommon.AppCommonErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.AppCommon.AppCommonErrorCode.OutOfMemory:
                        throw new OutOfMemoryException("Out of memory");
                    case Interop.AppCommon.AppCommonErrorCode.InvalidContext:
                        throw new InvalidOperationException("Invalid app context");
                    case Interop.AppCommon.AppCommonErrorCode.PermissionDenied:
                        throw new DirectoryNotFoundException(String.Format("Allowed Resource about {0} is not Found", resourceType));
                    default:
                        throw new InvalidOperationException("Invalid Operation");
                }
            }

            return path;
        }
    }
}
