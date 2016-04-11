// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications
{
    /// <summary>
    /// Represents directory information of the application.
    /// </summary>
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
        /// Gets the absolute path to the application's data directory which is used to store private data of the application.
        /// </summary>
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
        /// Gets the absolute path to the application's cache directory which is used to store temporary data of the application.
        /// </summary>
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
        /// Gets the absolute path to the application's shared data directory which is used to share data with other applications.
        /// </summary>
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
        /// Gets the absolute path to the application's shared resource directory which is used to share resources with other applications.
        /// </summary>
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
        /// Gets the absolute path to the application's shared trusted directory which is used to share data with a family of trusted applications.
        /// </summary>
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
        /// Gets the absolute path to the application's external data directory which is used to store data of the application.
        /// </summary>
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
        /// Gets the absolute path to the application's external cache directory which is used to store temporary data of the application.
        /// </summary>
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
        /// Gets the absolute path to the application's external shared data directory which is used to share data with other applications.
        /// </summary>
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
        public string ExpansionPackageResource
        {
            get
            {
                if (_expansionPackageResourcePath == null)
                    _expansionPackageResourcePath = Interop.AppCommon.AppGetTepResourcePath();
                return _expansionPackageResourcePath;
            }
        }
    }
}
