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

namespace Tizen.Applications
{
    /// <summary>
    /// This class has read-only properties to get the package size information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PackageSizeInformation
    {
        private long _dataSize;
        private long _cacheSize;
        private long _appSize;
        private long _externalDataSize;
        private long _externalCacheSize;
        private long _externalAppSize;

        private PackageSizeInformation() { }

        /// <summary>
        /// Data size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long DataSize { get { return _dataSize; } }

        /// <summary>
        /// Cache size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long CacheSize { get { return _cacheSize; } }

        /// <summary>
        /// Application size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long AppSize { get { return _appSize; } }

        /// <summary>
        /// External data size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long ExternalDataSize { get { return _externalDataSize; } }

        /// <summary>
        /// External cache size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long ExternalCacheSize { get { return _externalCacheSize; } }

        /// <summary>
        /// External application size for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public long ExternalAppSize { get { return _externalAppSize; } }

        // This method assumes that pass handle is already validated
        internal static PackageSizeInformation GetPackageSizeInformation(IntPtr handle)
        {
            var pkgSizeInfo = new PackageSizeInformation();
            Interop.PackageManager.PackageSizeInfoGetDataSize(handle, out pkgSizeInfo._dataSize);
            Interop.PackageManager.PackageSizeInfoGetCacheSize(handle, out pkgSizeInfo._cacheSize);
            Interop.PackageManager.PackageSizeInfoGetAppSize(handle, out pkgSizeInfo._appSize);
            Interop.PackageManager.PackageSizeInfoGetExtDataSize(handle, out pkgSizeInfo._externalDataSize);
            Interop.PackageManager.PackageSizeInfoGetExtCacheSize(handle, out pkgSizeInfo._externalCacheSize);
            Interop.PackageManager.PackageSizeInfoGetExtAppSize(handle, out pkgSizeInfo._externalAppSize);
            return pkgSizeInfo;
        }
    }
}