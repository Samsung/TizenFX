/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


namespace Tizen.Applications
{
    /// <summary>
    ///
    /// </summary>
    public class ApplicationInfo
    {
        private SharedPaths _shared = null;
        private ExternalPaths _external = null;

        private string _id;
        private string _name;
        private string _version;
        private string _dataPath;
        private string _cachePath;
        private string _resourcePath;

        internal ApplicationInfo()
        {

        }

        /// <summary>
        /// The ID of the application.
        /// </summary>
        public string Id
        {
            get
            {
                if (_id == null)
                {
                    Interop.AppCommon.AppGetId(out _id);
                }
                return _id;
            }
        }

        /// <summary>
        /// The localized name of the application.
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    Interop.AppCommon.AppGetName(out _name);

                }
                return _name;
            }
        }

        /// <summary>
        /// The version of the application package.
        /// </summary>
        public string Version
        {
            get
            {
                if (_version == null)
                {
                    Interop.AppCommon.AppGetVersion(out _version);
                }
                return _version;
            }
        }

        /// <summary>
        /// The absolute path to the application's data directory which is used to store private data of the application.
        /// </summary>
        public string DataPath
        {
            get
            {
                if (_dataPath == null)
                    _dataPath = Interop.AppCommon.AppGetDataPath();
                return _dataPath;
            }
        }

        /// <summary>
        /// The absolute path to the application's cache directory which is used to store temporary data of the application.
        /// </summary>
        public string CachePath
        {
            get
            {
                if (_cachePath == null)
                    _cachePath = Interop.AppCommon.AppGetCachePath();
                return _cachePath;
            }
        }

        /// <summary>
        /// The absolute path to the application resource directory. The resource files are delivered with the application package.
        /// </summary>
        public string ResourcePath
        {
            get
            {
                if (_resourcePath == null)
                    _resourcePath = Interop.AppCommon.AppGetResourcePath();
                return _resourcePath;
            }
        }

        /// <summary>
        /// The shared paths
        /// </summary>
        public SharedPaths Shared
        {
            get
            {
                if (_shared == null)
                    _shared = new SharedPaths();
                return _shared;
            }
        }

        /// <summary>
        /// The external paths
        /// </summary>
        public ExternalPaths External
        {
            get
            {
                if (_external == null)
                    _external = new ExternalPaths();
                return _external;
            }
        }

        /// <summary>
        /// The absolute path to the application's TEP(Tizen Expansion Package) directory. The resource files are delivered with the expansion package.
        /// </summary>
        public string ExpansionPackageResourcePath
        {
            get
            {
                return Interop.AppCommon.AppGetTepResourcePath();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public class SharedPaths
        {
            private string _dataPath;
            private string _resourcePath;
            private string _trustedPath;

            internal SharedPaths() { }
            /// <summary>
            /// The absolute path to the application's shared data directory which is used to share data with other applications.
            /// </summary>
            public string DataPath
            {
                get
                {
                    if (_dataPath == null)
                        _dataPath = Interop.AppCommon.AppGetSharedDataPath();
                    return _dataPath;
                }
            }

            /// <summary>
            /// The absolute path to the application's shared resource directory which is used to share resources with other applications.
            /// </summary>
            public string ResourcePath
            {
                get
                {
                    if (_resourcePath == null)
                        _resourcePath = Interop.AppCommon.AppGetSharedResourcePath();
                    return _resourcePath;
                }
            }

            /// <summary>
            /// The absolute path to the application's shared trusted directory which is used to share data with a family of trusted applications.
            /// </summary>
            public string TrustedPath
            {
                get
                {
                    if (_trustedPath == null)
                        _trustedPath = Interop.AppCommon.AppGetSharedTrustedPath();
                    return _trustedPath;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ExternalPaths
        {
            private string _dataPath;
            private string _cachePath;
            private string _sharedDataPath;

            internal ExternalPaths() { }

            /// <summary>
            /// The absolute path to the application's external data directory which is used to store data of the application.
            /// </summary>
            public string DataPath
            {
                get
                {
                    if (_dataPath == null)
                        _dataPath = Interop.AppCommon.AppGetExternalDataPath();
                    return _dataPath;
                }
            }

            /// <summary>
            /// The absolute path to the application's external cache directory which is used to store temporary data of the application.
            /// </summary>
            public string CachePath
            {
                get
                {
                    if (_cachePath == null)
                        _cachePath = Interop.AppCommon.AppGetExternalCachePath();
                    return _cachePath;
                }
            }

            /// <summary>
            /// The absolute path to the application's external shared data directory which is used to share data with other applications.
            /// </summary>
            public string SharedDataPath
            {
                get
                {
                    if (_sharedDataPath == null)
                        _sharedDataPath = Interop.AppCommon.AppGetExternalSharedDataPath();
                    return _sharedDataPath;
                }
            }
        }
    }
}
