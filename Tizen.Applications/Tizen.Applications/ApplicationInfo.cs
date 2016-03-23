/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    ///
    /// </summary>
    public class ApplicationInfo
    {
        private SharedPaths _shared = null;
        private ExternalPaths _external = null;

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
                string value;
                Interop.AppCommon.AppGetId(out value);
                return value;
            }
        }

        /// <summary>
        /// The localized name of the application.
        /// </summary>
        public string Name
        {
            get
            {
                string value;
                Interop.AppCommon.AppGetName(out value);
                return value;
            }
        }

        /// <summary>
        /// The version of the application package.
        /// </summary>
        public string Version
        {
            get
            {
                string value;
                Interop.AppCommon.AppGetVersion(out value);
                return value;
            }
        }

        /// <summary>
        /// The absolute path to the application's data directory which is used to store private data of the application.
        /// </summary>
        public string DataPath
        {
            get
            {
                return Interop.AppCommon.AppGetDataPath();
            }
        }

        /// <summary>
        /// The absolute path to the application's cache directory which is used to store temporary data of the application.
        /// </summary>
        public string CachePath
        {
            get
            {
                return Interop.AppCommon.AppGetCachePath();
            }
        }

        /// <summary>
        /// The absolute path to the application resource directory. The resource files are delivered with the application package.
        /// </summary>
        public string ResourcePath
        {
            get
            {
                return Interop.AppCommon.AppGetResourcePath();
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


        public class SharedPaths
        {
            internal SharedPaths() { }
            /// <summary>
            /// The absolute path to the application's shared data directory which is used to share data with other applications.
            /// </summary>
            public string DataPath
            {
                get
                {
                    return Interop.AppCommon.AppGetSharedDataPath();
                }
            }

            /// <summary>
            /// The absolute path to the application's shared resource directory which is used to share resources with other applications.
            /// </summary>
            public string ResourcePath
            {
                get
                {
                    return Interop.AppCommon.AppGetSharedResourcePath();
                }
            }

            /// <summary>
            /// The absolute path to the application's shared trusted directory which is used to share data with a family of trusted applications.
            /// </summary>
            public string TrustedPath
            {
                get
                {
                    return Interop.AppCommon.AppGetSharedTrustedPath();
                }
            }
        }

        public class ExternalPaths
        {
            internal ExternalPaths() { }

            /// <summary>
            /// The absolute path to the application's external data directory which is used to store data of the application.
            /// </summary>
            public string DataPath
            {
                get
                {
                    return Interop.AppCommon.AppGetExternalDataPath();
                }
            }

            /// <summary>
            /// The absolute path to the application's external cache directory which is used to store temporary data of the application.
            /// </summary>
            public string CachePath
            {
                get
                {
                    return Interop.AppCommon.AppGetExternalCachePath();
                }
            }

            /// <summary>
            /// The absolute path to the application's external shared data directory which is used to share data with other applications.
            /// </summary>
            public string SharedDataPath
            {
                get
                {
                    return Interop.AppCommon.AppGetExternalSharedDataPath();
                }
            }
        }
    }
}
