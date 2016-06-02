// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// This class has the read only properties to get package size information.
    /// </summary>
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
        /// Data size for package.
        /// </summary>
        public long DataSize { get { return _dataSize; } }

        /// <summary>
        /// Cache size for package.
        /// </summary>
        public long CacheSize { get { return _cacheSize; } }

        /// <summary>
        /// Application size for package.
        /// </summary>
        public long AppSize { get { return _appSize; } }

        /// <summary>
        /// External data size for package.
        /// </summary>
        public long ExternalDataSize { get { return _externalDataSize; } }

        /// <summary>
        /// External cache size for package.
        /// </summary>
        public long ExternalCacheSize { get { return _externalCacheSize; } }

        /// <summary>
        /// External application size for package.
        /// </summary>
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