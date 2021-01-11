/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace Tizen.Applications
{
    /// <summary>
    /// PackageManager class. This class has the methods and events of the PackageManager.
    /// </summary>
    /// <remarks>
    /// The package manager is one of the core modules of the Tizen application framework and responsible for getting their information.
    /// You can also retrieve information related to the packages that are installed on the device.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public static class PackageManager
    {
        private const string LogTag = "Tizen.Applications.PackageManager";

        private static SafePackageManagerHandle s_handle = new SafePackageManagerHandle();
        private static Interop.PackageManager.EventStatus s_eventStatus = Interop.PackageManager.EventStatus.All;
        private static event EventHandler<PackageManagerEventArgs> s_installEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_uninstallEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_updateEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_moveEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_clearDataEventHandler;

        private static readonly object s_pkgEventLock = new object();
        private static Interop.PackageManager.PackageManagerEventCallback s_packageManagerEventCallback = new Interop.PackageManager.PackageManagerEventCallback(InternalEventCallback);

        private static Dictionary<IntPtr, Interop.PackageManager.PackageManagerTotalSizeInfoCallback> s_totalSizeInfoCallbackDict = new Dictionary<IntPtr, Interop.PackageManager.PackageManagerTotalSizeInfoCallback>();
        private static int s_callbackId = 0;

        /// <summary>
        /// Event callback method for the request.
        /// </summary>
        /// <param name="type">Type of the package which was requested.</param>
        /// <param name="packageId">ID of the package which was requested.</param>
        /// <param name="eventType">Event type of the request.</param>
        /// <param name="eventState">Current event state of the request.</param>
        /// <param name="progress">Progress for the request being processed by the package manager (in percent).</param>
        /// <since_tizen> 3 </since_tizen>
        public delegate void RequestEventCallback(string type, string packageId, PackageEventType eventType, PackageEventState eventState, int progress);

        private static Dictionary<int, RequestEventCallback> RequestCallbacks = new Dictionary<int, RequestEventCallback>();
        private static Dictionary<int, SafePackageManagerRequestHandle> RequestHandles = new Dictionary<int, SafePackageManagerRequestHandle>();
        private static Dictionary<int, int> RequestPackageCount = new Dictionary<int, int>();

        private delegate Interop.PackageManager.ErrorCode InstallMethodWithCallback(SafePackageManagerRequestHandle requestHandle, string pkgPath, Interop.PackageManager.PackageManagerRequestEventCallback requestCallback, IntPtr userData, out int requestID);
        private delegate Interop.PackageManager.ErrorCode InstallPackagesMethodWithCallback(SafePackageManagerRequestHandle requestHandle, string[] pkgPaths, int pathsCount, Interop.PackageManager.PackageManagerRequestEventCallback requestCallback, IntPtr userData, out int requestId);
        private delegate Interop.PackageManager.ErrorCode InstallMethod(SafePackageManagerRequestHandle requestHandle, string pkgPath, out int requestID);
        private delegate Interop.PackageManager.ErrorCode InstallPackagesMethod(SafePackageManagerRequestHandle requestHandle, string[] pkgPaths, int pathsCount, out int requestID);

        /// <summary>
        /// InstallProgressChanged event. This event occurs when a package is getting installed and the progress of the request to the package manager is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PackageManagerEventArgs> InstallProgressChanged
        {
            add
            {
                lock (s_pkgEventLock)
                {
                    SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Install);
                    RegisterPackageManagerEventIfNeeded();
                    s_installEventHandler += value;
                }
            }
            remove
            {
                lock (s_pkgEventLock)
                {
                    s_installEventHandler -= value;
                    UnregisterPackageManagerEventIfNeeded();
                    UnsetPackageManagerEventStatus();
                }
            }
        }

        /// <summary>
        /// UninstallProgressChanged event. This event occurs when a package is getting uninstalled and the progress of the request to the package manager is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PackageManagerEventArgs> UninstallProgressChanged
        {
            add
            {
                lock (s_pkgEventLock)
                {
                    SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Uninstall);
                    RegisterPackageManagerEventIfNeeded();
                    s_uninstallEventHandler += value;
                }
            }
            remove
            {
                lock (s_pkgEventLock)
                {
                    s_uninstallEventHandler -= value;
                    UnregisterPackageManagerEventIfNeeded();
                    UnsetPackageManagerEventStatus();
                }
           }
        }

        /// <summary>
        /// UpdateProgressChanged event. This event occurs when a package is getting updated and the progress of the request to the package manager is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PackageManagerEventArgs> UpdateProgressChanged
        {
            add
            {
                lock (s_pkgEventLock)
                {
                    SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Upgrade);
                    RegisterPackageManagerEventIfNeeded();
                    s_updateEventHandler += value;
                }
            }
            remove
            {
                lock (s_pkgEventLock)
                {
                    s_updateEventHandler -= value;
                    UnregisterPackageManagerEventIfNeeded();
                    UnsetPackageManagerEventStatus();
                }
            }
        }

        /// <summary>
        /// MoveProgressChanged event. This event occurs when a package is getting moved and the progress of the request to the package manager is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PackageManagerEventArgs> MoveProgressChanged
        {
            add
            {
                lock (s_pkgEventLock)
                {
                    SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Move);
                    RegisterPackageManagerEventIfNeeded();
                    s_moveEventHandler += value;
                }
            }
            remove
            {
                lock (s_pkgEventLock)
                {
                    s_moveEventHandler -= value;
                    UnregisterPackageManagerEventIfNeeded();
                    UnsetPackageManagerEventStatus();
                }
            }
        }

        /// <summary>
        /// ClearDataProgressChanged event. This event occurs when data directories are cleared in the given package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PackageManagerEventArgs> ClearDataProgressChanged
        {
            add
            {
                lock (s_pkgEventLock)
                {
                    SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.ClearData);
                    RegisterPackageManagerEventIfNeeded();
                    s_clearDataEventHandler += value;
                }
            }
            remove
            {
                lock (s_pkgEventLock)
                {
                    s_clearDataEventHandler -= value;
                    UnregisterPackageManagerEventIfNeeded();
                    UnsetPackageManagerEventStatus();
                }
            }
        }

        private static SafePackageManagerHandle Handle
        {
            get
            {
                if (s_handle.IsInvalid)
                {
                    var err = Interop.PackageManager.PackageManagerCreate(out s_handle);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to create package manager handle. err = {0}", err));
                    }
                }
                return s_handle;
            }
        }

        private static Interop.PackageManager.PackageManagerRequestEventCallback internalRequestEventCallback = (id, packageType, packageId, eventType, eventState, progress, error, userData) =>
        {
            if (RequestCallbacks.ContainsKey(id))
            {
                try
                {
                    RequestCallbacks[id](packageType, packageId, (PackageEventType)eventType, (PackageEventState)eventState, progress);
                    if (eventState == Interop.PackageManager.PackageEventState.Completed || eventState == Interop.PackageManager.PackageEventState.Failed)
                    {
                        RequestPackageCount[id] -= 1;
                        if (RequestPackageCount[id] < 1)
                        {
                            Log.Debug(LogTag, string.Format("release request handle for id : {0}", id));
                            RequestHandles[id].Dispose();
                            RequestHandles.Remove(id);
                            RequestCallbacks.Remove(id);
                            RequestPackageCount.Remove(id);
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(LogTag, e.Message);
                    RequestHandles[id].Dispose();
                    RequestHandles.Remove(id);
                    RequestCallbacks.Remove(id);
                    RequestPackageCount.Remove(id);
                }
            }
        };

        /// <summary>
        /// Gets the package ID for the given application ID.
        /// </summary>
        /// <param name="applicationId">The ID of the application.</param>
        /// <returns>Returns the ID of the package.</returns>
        /// <remarks>It returns null if the input is null.</remarks>
        /// <exception cref="ArgumentException">Thrown when input application ID does not exist.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static string GetPackageIdByApplicationId(string applicationId)
        {
            string packageId;
            var err = Interop.PackageManager.PackageManagerGetPackageIdByAppId(applicationId, out packageId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get package Id of {0}. err = {1}", applicationId, err));
                if (err != Interop.PackageManager.ErrorCode.InvalidParameter)
                {
                    throw PackageManagerErrorFactory.GetException(err, "Failed to get package Id");
                }
            }
            return packageId;
        }

        /// <summary>
        /// Gets the package information for the given package.
        /// </summary>
        /// <param name="packageId">The ID of the package.</param>
        /// <returns>Returns the package information for the given package ID.</returns>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method fails due to an internal I/O error.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Package GetPackage(string packageId)
        {
            return Package.GetPackage(packageId);
        }

        /// <summary>
        /// Clears the application's internal and external cache directories.
        /// </summary>
        /// <param name="packageId">ID of the package.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method fails due to an internal I/O error.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="SystemException">Thrown when the method failed due to an internal system error.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.clearcache</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static void ClearCacheDirectory(string packageId)
        {
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerClearCacheDir(packageId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to clear cache directory for {0}. err = {1}", packageId, err));
                throw PackageManagerErrorFactory.GetException(err, "Failed to clear cache directory");
            }
        }

        /// <summary>
        /// Clears all the application's internal and external cache directories.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method fails due to an internal IO error.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="SystemException">Thrown when the method failed due to an internal system error.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static void ClearAllCacheDirectory()
        {
            var err = Interop.PackageManager.PackageManagerClearAllCacheDir();
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to clear all cache directories. err = {0}", err));
                throw PackageManagerErrorFactory.GetException(err, "Failed to clear all cache directories");
            }
        }

        /// <summary>
        /// Clears the application's internal and external data directories.
        /// </summary>
        /// <remarks>
        /// All files under data, shared/data, and shared/trusted in the internal storage are removed.
        /// And, if the external storage exists, then all files under data and shared/trusted in the external storage are removed.
        /// </remarks>
        /// <param name="packageId">ID of the package.</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal IO error.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <exception cref="SystemException">Thrown when the method failed due to an internal system error.</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static void ClearDataDirectory(string packageId)
        {
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerClearDataDir(packageId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to clear data directory for {0}. err = {1}", packageId, err));
                throw PackageManagerErrorFactory.GetException(err, "Failed to clear data directory");
            }
        }

        /// <summary>
        /// Retrieves the package information of all installed packages.
        /// </summary>
        /// <returns>Returns the list of packages.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<Package> GetPackages()
        {
            return GetPackages(null);
        }

        /// <summary>
        /// Retrieves the package information of all the installed packages satisfying the filter conditions.
        /// </summary>
        /// <param name="filter">Optional - package filters.</param>
        /// <returns>Returns the list of packages.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static IEnumerable<Package> GetPackages(PackageFilter filter)
        {
            List<Package> packageList = new List<Package>();

            IntPtr filterHandle;
            var err = Interop.PackageManager.PackageManagerFilterCreate(out filterHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to create package filter handle. err = {0}", err));
                return packageList;
            }

            if (filter != null && filter.Filters != null)
            {
                foreach (KeyValuePair<string, bool> entry in filter?.Filters)
                {
                    err = Interop.PackageManager.PackageManagerFilterAdd(filterHandle, entry.Key, entry.Value);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to configure package filter. err = {0}", err));
                        break;
                    }
                }
            }

            if (err == Interop.PackageManager.ErrorCode.None)
            {
                Interop.PackageManager.PackageManagerPackageInfoCallback cb = (handle, userData) =>
                {
                    packageList.Add(Package.GetPackage(handle));
                    return true;
                };

                err = Interop.PackageManager.PackageManagerFilterForeachPackageInfo(filterHandle, cb, IntPtr.Zero);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to get package Informations. err = {0}", err));
                }
            }

            err = Interop.PackageManager.PackageManagerFilterDestroy(filterHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy package filter handle. err = {0}", err));
            }
            return packageList;
        }

        /// <summary>
        /// Gets the total package size information.
        /// </summary>
        /// <returns>Returns the total package size information asynchronously.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static async Task<PackageSizeInformation> GetTotalSizeInformationAsync()
        {
            TaskCompletionSource<PackageSizeInformation> tcs = new TaskCompletionSource<PackageSizeInformation>();

            Interop.PackageManager.PackageManagerTotalSizeInfoCallback cb = (handle, userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    tcs.TrySetResult(PackageSizeInformation.GetPackageSizeInformation(handle));
                }

                lock (s_totalSizeInfoCallbackDict)
                {
                    s_totalSizeInfoCallbackDict.Remove(userData);
                }
            };

            IntPtr callbackId;
            lock (s_totalSizeInfoCallbackDict)
            {
                callbackId = (IntPtr)s_callbackId++;
                s_totalSizeInfoCallbackDict[callbackId] = cb;
            }

            var err = Interop.PackageManager.PackageManagerGetTotalSizeInfo(cb, callbackId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                tcs.TrySetException(PackageManagerErrorFactory.GetException(err, "Failed to get total package size info"));
            }
            return await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if the installation request is successful, otherwise false.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of the installation, the caller should check the progress using the InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, null, PackageType.UNKNOWN, null, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="eventCallback">The event callback will be invoked only for the current request.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, RequestEventCallback eventCallback, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, null, PackageType.UNKNOWN, eventCallback, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="type">Package type for the package to be installed.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, PackageType type, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, null, type, null, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="expansionPackagePath">Absolute path for the expansion package to be installed.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, string expansionPackagePath, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, expansionPackagePath, PackageType.UNKNOWN, null, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="type">Package type for the package to be installed.</param>
        /// <param name="eventCallback">The event callback will be invoked only for the current request.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, PackageType type, RequestEventCallback eventCallback, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, null, type, eventCallback, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="expansionPackagePath">Absolute path for the expansion package to be installed.</param>
        /// <param name="eventCallback">The event callback will be invoked only for the current request.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, string expansionPackagePath, RequestEventCallback eventCallback, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, expansionPackagePath, PackageType.UNKNOWN, eventCallback, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="expansionPackagePath">Absolute path for the expansion package to be installed.</param>
        /// <param name="type">Package type for the package to be installed.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, string expansionPackagePath, PackageType type, InstallationMode installMode = InstallationMode.Normal)
        {
            return Install(packagePath, expansionPackagePath, type, null, installMode);
        }

        /// <summary>
        /// Installs the package located at the given path.
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed.</param>
        /// <param name="expansionPackagePath">Absolute path for the expansion package to be installed.</param>
        /// <param name="type">Package type for the package to be installed.</param>
        /// <param name="eventCallback">The event callback will be invoked only for the current request.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Install(string packagePath, string expansionPackagePath, PackageType type, RequestEventCallback eventCallback, InstallationMode installMode = InstallationMode.Normal)
        {
            return InstallInternal(new List<string>{ packagePath }, expansionPackagePath, type, eventCallback, installMode);
        }

        /// <summary>
        /// Installs the packages located at the given path.
        /// </summary>
        /// <param name="packagePaths">Absolute paths for the package to be installed.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 8 </since_tizen>
        public static bool Install(List<string> packagePaths, InstallationMode installMode = InstallationMode.Normal)
        {
            return InstallInternal(packagePaths, null, PackageType.UNKNOWN, null, installMode);
        }

        /// <summary>
        /// Installs the packages located at the given path.
        /// </summary>
        /// <param name="packagePaths">Absolute paths for the package to be installed.</param>
        /// <param name="eventCallback">The event callback will be invoked only for the current request.</param>
        /// <param name="installMode">Optional parameter to indicate special installation mode.</param>
        /// <returns>Returns true if installation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for installation is successful.
        /// To check the result of installation, the caller should check the progress using the InstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 8 </since_tizen>
        public static bool Install(List<string> packagePaths, RequestEventCallback eventCallback, InstallationMode installMode = InstallationMode.Normal)
        {
            return InstallInternal(packagePaths, null, PackageType.UNKNOWN, eventCallback, installMode);
        }

        private static bool InstallInternal(List<string> packagePaths, string expansionPackagePath, PackageType type, RequestEventCallback eventCallback, InstallationMode installMode)
        {
            if (packagePaths == null || !packagePaths.Any())
            {
                Log.Warn(LogTag, string.Format("Invalid argument"));
                return false;
            }

            SafePackageManagerRequestHandle RequestHandle;
            var err = Interop.PackageManager.PackageManagerRequestCreate(out RequestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to install packages. Error in creating package manager request handle. err = {0}", err));
                return false;
            }

            try
            {
                if (type != PackageType.UNKNOWN)
                {
                    err = Interop.PackageManager.PackageManagerRequestSetType(RequestHandle, type.ToString().ToLower());
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to install packages. Error in setting request package type. err = {0}", err));
                        RequestHandle.Dispose();
                        return false;
                    }
                }

                if (!string.IsNullOrEmpty(expansionPackagePath))
                {
                    err = Interop.PackageManager.PackageManagerRequestSetTepPath(RequestHandle, expansionPackagePath);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to install package. Error in setting request package mode. err = {0}", err));
                        RequestHandle.Dispose();
                        return false;
                    }
                }

                int requestId;
                if (eventCallback != null)
                {
                    if (packagePaths.Count > 1)
                    {
                        InstallPackagesMethodWithCallback installPackages;
                        if (installMode == InstallationMode.Mount)
                        {
                            installPackages = Interop.PackageManager.PackageManagerRequestMountInstallPackagesWithCb;
                        }
                        else
                        {
                            installPackages = Interop.PackageManager.PackageManagerRequestInstallPackagesWithCb;
                        }
                        err = installPackages(RequestHandle, packagePaths.ToArray(), packagePaths.Count, internalRequestEventCallback, IntPtr.Zero, out requestId);
                        if (err == Interop.PackageManager.ErrorCode.None)
                        {
                            RequestCallbacks.Add(requestId, eventCallback);
                            RequestHandles.Add(requestId, RequestHandle);
                            RequestPackageCount.Add(requestId, packagePaths.Count);
                        }
                        else
                        {
                            Log.Warn(LogTag, string.Format("Failed to install packages. err = {0}",  err));
                            RequestHandle.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        InstallMethodWithCallback install;
                        if (installMode == InstallationMode.Mount)
                        {
                            install = Interop.PackageManager.PackageManagerRequestMountInstallWithCB;
                        }
                        else
                        {
                            install = Interop.PackageManager.PackageManagerRequestInstallWithCB;
                        }
                        err = install(RequestHandle, packagePaths[0], internalRequestEventCallback, IntPtr.Zero, out requestId);
                        if (err == Interop.PackageManager.ErrorCode.None)
                        {
                            RequestCallbacks.Add(requestId, eventCallback);
                            RequestHandles.Add(requestId, RequestHandle);
                            RequestPackageCount.Add(requestId, packagePaths.Count);

                        }
                        else
                        {
                            Log.Warn(LogTag, string.Format("Failed to install package {0}. err = {1}", packagePaths, err));
                            RequestHandle.Dispose();
                            return false;
                        }

                    }

                }
                else
                {
                    if (packagePaths.Count > 1)
                    {
                        InstallPackagesMethod installPackages;
                        if (installMode == InstallationMode.Mount)
                        {
                            installPackages = Interop.PackageManager.PackageManagerRequestMountInstallPackages;
                        }
                        else
                        {
                            installPackages = Interop.PackageManager.PackageManagerRequestInstallPackages;
                        }
                        err = installPackages(RequestHandle, packagePaths.ToArray(), packagePaths.Count, out requestId);
                        if (err != Interop.PackageManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, string.Format("Failed to install package {0}. err = {1}", packagePaths, err));
                            RequestHandle.Dispose();
                            return false;
                        }
                    }
                    else
                    {
                        InstallMethod install;
                        if (installMode == InstallationMode.Mount)
                        {
                            install = Interop.PackageManager.PackageManagerRequestMountInstall;
                        }
                        else
                        {
                            install = Interop.PackageManager.PackageManagerRequestInstall;
                        }
                        err = install(RequestHandle, packagePaths[0], out requestId);
                        if (err != Interop.PackageManager.ErrorCode.None)
                        {
                            Log.Warn(LogTag, string.Format("Failed to install package {0}. err = {1}", packagePaths, err));
                            RequestHandle.Dispose();
                            return false;
                        }
                    }

                    // RequestHandle isn't necessary when this method is called without 'eventCallback' parameter.
                    RequestHandle.Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Warn(LogTag, e.Message);
                RequestHandle.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Uninstalls the package with the given name.
        /// </summary>
        /// <param name="packageId">ID of the package to be uninstalled.</param>
        /// <returns>Returns true if the uninstallation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for uninstallation is successful.
        /// To check the result of uninstallation, the caller should check the progress using the UninstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Uninstall(string packageId)
        {
            return Uninstall(packageId, PackageType.UNKNOWN, null);
        }

        /// <summary>
        /// Uninstalls package with the given names.
        /// </summary>
        /// <param name="packageId">ID of the package to be uninstalled.</param>
        /// <param name="type">Optional - Package type for the package to be uninstalled.</param>
        /// <returns>Returns true if the uninstallation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for uninstallation is successful.
        /// To check the result of uninstallation, the caller should check the progress using the UninstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Uninstall(string packageId, PackageType type)
        {
            return Uninstall(packageId, type, null);
        }

        /// <summary>
        /// Uninstalls the package with the given name.
        /// </summary>
        /// <param name="packageId">ID of the package to be uninstalled.</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request.</param>
        /// <returns>Returns true if the uninstallation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for uninstallation is successful.
        /// To check the result of uninstallation, the caller should check the progress using the UninstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Uninstall(string packageId, RequestEventCallback eventCallback)
        {
            return Uninstall(packageId, PackageType.UNKNOWN, eventCallback);
        }

        /// <summary>
        /// Uninstalls the package with the given name.
        /// </summary>
        /// <param name="packageId">ID of the package to be uninstalled</param>
        /// <param name="type">Optional - Package type for the package to be uninstalled.</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request.</param>
        /// <returns>Returns true if the uninstallation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for uninstallation is successful.
        /// To check the result of uninstallation, the caller should check the progress using the UninstallProgressChanged event or eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Uninstall(string packageId, PackageType type, RequestEventCallback eventCallback)
        {
            SafePackageManagerRequestHandle RequestHandle;
            var err = Interop.PackageManager.PackageManagerRequestCreate(out RequestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to uninstall package {0}. Error in creating package manager request handle. err = {1}", packageId, err));
                return false;
            }

            try
            {
                err = Interop.PackageManager.PackageManagerRequestSetType(RequestHandle, type.ToString().ToLower());
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to uninstall package {0}. Error in setting request package type. err = {1}", packageId, err));
                    RequestHandle.Dispose();
                    return false;
                }

                int requestId;
                if (eventCallback != null)
                {
                    err = Interop.PackageManager.PackageManagerRequestUninstallWithCB(RequestHandle, packageId, internalRequestEventCallback, IntPtr.Zero, out requestId);
                    if (err == Interop.PackageManager.ErrorCode.None)
                    {
                        RequestCallbacks.Add(requestId, eventCallback);
                        RequestHandles.Add(requestId, RequestHandle);
                        RequestPackageCount.Add(requestId, 1);
                    }
                    else
                    {
                        Log.Warn(LogTag, string.Format("Failed to uninstall package {0}. err = {1}", packageId, err));
                        RequestHandle.Dispose();
                        return false;
                    }
                }
                else
                {
                    err = Interop.PackageManager.PackageManagerRequestUninstall(RequestHandle, packageId, out requestId);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to uninstall package. err = {0}", err));
                        RequestHandle.Dispose();
                        return false;
                    }
                    // RequestHandle isn't necessary when this method is called without 'eventCallback' parameter.
                    RequestHandle.Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Warn(LogTag, e.Message);
                RequestHandle.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Moves the package to the given storage.
        /// </summary>
        /// <param name="packageId">ID of the package to be moved.</param>
        /// <param name="newStorage">Storage package should be moved to.</param>
        /// <returns>Returns true if the move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for move is successful.
        /// To check the result of move, the caller should check the progress using the MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Move(string packageId, StorageType newStorage)
        {
            return Move(packageId, PackageType.UNKNOWN, newStorage, null);
        }

        /// <summary>
        /// Moves the package to the given storage.
        /// </summary>
        /// <param name="packageId">ID of the package to be moved.</param>
        /// <param name="type">Optional - Package type for the package to be moved.</param>
        /// <param name="newStorage">Storage package should be moved to.</param>
        /// <returns>Returns true if the move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for move is successful.
        /// To check the result of move, the caller should check the progress using the MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Move(string packageId, PackageType type, StorageType newStorage)
        {
            return Move(packageId, type, newStorage, null);
        }

        /// <summary>
        /// Moves the package to the given storage.
        /// </summary>
        /// <param name="packageId">ID of the package to be moved.</param>
        /// <param name="newStorage">Storage package should be moved to.</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request.</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for move is successful.
        /// To check the result of move, the caller should check the progress using the MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Move(string packageId, StorageType newStorage, RequestEventCallback eventCallback)
        {
            return Move(packageId, PackageType.UNKNOWN, newStorage, eventCallback);
        }

        /// <summary>
        /// Moves the package to the given storage.
        /// </summary>
        /// <param name="packageId">ID of the package to be moved.</param>
        /// <param name="type">Optional - Package type for the package to be moved.</param>
        /// <param name="newStorage">Storage, package should be moved to.</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request.</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that the request for move is successful.
        /// To check the result of move, the caller should check the progress using the MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static bool Move(string packageId, PackageType type, StorageType newStorage, RequestEventCallback eventCallback)
        {
            SafePackageManagerRequestHandle RequestHandle;
            var err = Interop.PackageManager.PackageManagerRequestCreate(out RequestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to create package manager request handle. err = {0}", err));
                return false;
            }

            try
            {
                bool result = true;
                err = Interop.PackageManager.PackageManagerRequestSetType(RequestHandle, type.ToString().ToLower());
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to move package. Error in setting request package type. err = {0}", err));
                    RequestHandle.Dispose();
                    return false;
                }

                if (eventCallback != null)
                {
                    int requestId;
                    err = Interop.PackageManager.PackageManagerRequestMoveWithCB(RequestHandle, packageId, (Interop.PackageManager.StorageType)newStorage, internalRequestEventCallback, IntPtr.Zero, out requestId);
                    if (err == Interop.PackageManager.ErrorCode.None)
                    {
                        RequestCallbacks.Add(requestId, eventCallback);
                        RequestHandles.Add(requestId, RequestHandle);
                        RequestPackageCount.Add(requestId, 1);
                    }
                    else
                    {
                        Log.Warn(LogTag, string.Format("Failed to move package to requested location. err = {0}", err));
                        RequestHandle.Dispose();
                        result = false;
                    }
                }
                else
                {
                    err = Interop.PackageManager.PackageManagerRequestMove(RequestHandle, packageId, (Interop.PackageManager.StorageType)newStorage);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to move package to requested location. err = {0}", err));
                        RequestHandle.Dispose();
                        result = false;
                    }
                    // RequestHandle isn't necessary when this method is called without 'eventCallback' parameter.
                    RequestHandle.Dispose();
                }
                return result;
            }
            catch (Exception e)
            {
                Log.Warn(LogTag, e.Message);
                RequestHandle.Dispose();
                return false;
            }
        }

        /// <summary>
        /// Gets the permission type of the package which has a given application ID.
        /// </summary>
        /// <param name="applicationId">ID of the application.</param>
        /// <returns>Returns the permission type.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static PermissionType GetPermissionTypeByApplicationId(string applicationId)
        {
            Interop.PackageManager.PackageManagerPermissionType permissionType;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerGetPermissionType(applicationId, out permissionType);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to get permission type.");
            }

            return (PermissionType)permissionType;
        }

        /// <summary>
        /// Gets the package's preload attribute which contains a given application ID.
        /// </summary>
        /// <param name="applicationId">ID of the application.</param>
        /// <returns>Returns true if the package is preloaded, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsPreloadPackageByApplicationId(string applicationId)
        {
            bool isPreloadPackage;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerIsPreloadPackageByApplicationId(applicationId, out isPreloadPackage);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to get preload info");
            }

            return isPreloadPackage;
        }

        /// <summary>
        /// Compares the certificate of the two packages.
        /// </summary>
        /// <param name="lhsPackageId">Package ID to compare.</param>
        /// <param name="rhsPackageId">Package ID to be compared.</param>
        /// <returns>Returns certificate comparison result.</returns>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static CertCompareResultType CompareCertInfo(string lhsPackageId, string rhsPackageId)
        {
            Interop.PackageManager.CertCompareResultType compareResult;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerCompareCertInfo(lhsPackageId, rhsPackageId, out compareResult);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to compare cert info");
            }

            return (CertCompareResultType)compareResult;
        }

        /// <summary>
        /// Compares the certificate of the two packages which contain each given application ID.
        /// </summary>
        /// <param name="lhsApplicationId">Application ID to compare.</param>
        /// <param name="rhsApplicationId">Application ID to be compared.</param>
        /// <returns>Returns certificate comparison result.</returns>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static CertCompareResultType CompareCertInfoByApplicationId(string lhsApplicationId, string rhsApplicationId)
        {
            Interop.PackageManager.CertCompareResultType compareResult;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerCompareCertInfoByApplicationId(lhsApplicationId, rhsApplicationId, out compareResult);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to compare cert info by application id");
            }

            return (CertCompareResultType)compareResult;
        }

        /// <summary>
        /// Gets the package archive's information for the given archive path.
        /// </summary>
        /// <param name="archivePath">The path of the package archive.</param>
        /// <remarks>
        /// Regular 3rd party apps do not need to use this API
        /// </remarks>
        /// <returns>Returns the package archive information for the given archive path.</returns>
        /// <exception cref="ArgumentException">Thrown when the failed input package ID is invalid.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method fails due to an internal I/O error.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static PackageArchive GetPackageArchive(string archivePath)
        {
            return PackageArchive.GetPackageArchive(archivePath);
        }

        /// <summary>
        /// Drm nested class. This class has the PackageManager's drm related methods.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static class Drm
        {
            /// <summary>
            /// Generates a request for getting the license.
            /// </summary>
            /// <param name="responseData">Response data string of the purchase request.</param>
            /// <returns>Returns the package DRM information of a given response data which contains the required data and license URL.</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <privlevel>platform</privlevel>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid.</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
            /// <exception cref="SystemException">Thrown when the method failed due to an internal system error.</exception>
            /// <since_tizen> 3 </since_tizen>
            public static PackageDrm GenerateLicenseRequest(string responseData)
            {
                return PackageDrm.GenerateLicenseRequest(responseData);

            }

            /// <summary>
            /// Registers the encrypted license.
            /// </summary>
            /// <param name="responseData">The response data string of the rights request.</param>
            /// <returns>Returns true if succeeds, otherwise false.</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <privlevel>platform</privlevel>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid.</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
            /// <exception cref="SystemException">Thrown when the method failed due to internal system error.</exception>
            /// <since_tizen> 3 </since_tizen>
            public static bool RegisterLicense(string responseData)
            {
                Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerDrmRegisterLicense(responseData);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    throw PackageManagerErrorFactory.GetException(err, "Failed to register drm license");
                }

                return true;
            }

            /// <summary>
            /// Decrypts the contents which are encrypted.
            /// </summary>
            /// <param name="drmFilePath">Drm file path.</param>
            /// <param name="decryptedFilePath">Decrypted file path.</param>
            /// <returns>Returns true if succeeds, otherwise false.</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <privlevel>platform</privlevel>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid.</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method.</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have the privilege to access this method.</exception>
            /// <exception cref="SystemException">Thrown when the method failed due to an internal system error.</exception>
            /// <since_tizen> 3 </since_tizen>
            public static bool DecryptPackage(string drmFilePath, string decryptedFilePath)
            {
                Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerDrmDecryptPackage(drmFilePath, decryptedFilePath);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    throw PackageManagerErrorFactory.GetException(err, "Failed to decrypt drm package");
                }

                return true;
            }
        }

        private static void SetPackageManagerEventStatus(Interop.PackageManager.EventStatus status)
        {
            if (Handle.IsInvalid) return;

            Interop.PackageManager.EventStatus eventStatus = s_eventStatus;
            eventStatus |= status;
            if (eventStatus != Interop.PackageManager.EventStatus.All)
                eventStatus |= Interop.PackageManager.EventStatus.Progress;

            var err = Interop.PackageManager.ErrorCode.None;
            if (s_eventStatus != eventStatus)
            {
                err = Interop.PackageManager.PackageManagerSetEventStatus(Handle, eventStatus);
                if (err == Interop.PackageManager.ErrorCode.None)
                {
                    s_eventStatus = eventStatus;
                    Log.Debug(LogTag, string.Format("New Event Status flag: {0}", s_eventStatus));
                    return;
                }
                Log.Debug(LogTag, string.Format("Failed to set flag for {0} event. err = {1}", eventStatus, err));
            }
        }

        private static void UnsetPackageManagerEventStatus()
        {
            if (Handle.IsInvalid) return;

            Interop.PackageManager.EventStatus eventStatus = Interop.PackageManager.EventStatus.All;
            if (s_installEventHandler != null) eventStatus |= Interop.PackageManager.EventStatus.Install;
            if (s_uninstallEventHandler != null) eventStatus |= Interop.PackageManager.EventStatus.Uninstall;
            if (s_updateEventHandler != null) eventStatus |= Interop.PackageManager.EventStatus.Upgrade;
            if (s_moveEventHandler != null) eventStatus |= Interop.PackageManager.EventStatus.Move;
            if (s_clearDataEventHandler != null) eventStatus |= Interop.PackageManager.EventStatus.ClearData;
            if (eventStatus != Interop.PackageManager.EventStatus.All)
                eventStatus |= Interop.PackageManager.EventStatus.Progress;

            var err = Interop.PackageManager.ErrorCode.None;
            if (s_eventStatus != eventStatus)
            {
                err = Interop.PackageManager.PackageManagerSetEventStatus(Handle, eventStatus);
                if (err == Interop.PackageManager.ErrorCode.None)
                {
                    s_eventStatus = eventStatus;
                    Log.Debug(LogTag, string.Format("New Event Status flag: {0}", s_eventStatus));
                    return;
                }
                Log.Debug(LogTag, string.Format("Failed to set flag for {0} event. err = {1}", eventStatus, err));
            }
        }

        private static void RegisterPackageManagerEventIfNeeded()
        {
            if (s_installEventHandler != null && s_uninstallEventHandler != null && s_updateEventHandler != null && s_moveEventHandler != null && s_clearDataEventHandler != null)
                return;

            var err = Interop.PackageManager.ErrorCode.None;

            if (!Handle.IsInvalid)
            {
                lock (Handle)
                {
                    err = Interop.PackageManager.PackageManagerSetEvent(Handle, s_packageManagerEventCallback, IntPtr.Zero);
                }
            }
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to register callback for package manager event. err = {0}", err));
            }
        }

        private static void InternalEventCallback(string packageType, string packageId, Interop.PackageManager.EventType eventType, Interop.PackageManager.PackageEventState eventState, int progress, Interop.PackageManager.ErrorCode error, IntPtr user_data)
        {
            PackageManagerEventArgs args;
            try
            {
                args = new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress);
            }
            catch (Exception e)
            {
                Log.Warn(LogTag, e.Message);
                return;
            }

            EventHandler<PackageManagerEventArgs> handlers = null;
            lock (s_pkgEventLock)
            {
                if (eventType == Interop.PackageManager.EventType.Install)
                {
                    handlers = s_installEventHandler;
                }
                else if (eventType == Interop.PackageManager.EventType.Uninstall)
                {
                    handlers = s_uninstallEventHandler;
                }
                else if (eventType == Interop.PackageManager.EventType.Update)
                {
                    handlers = s_updateEventHandler;
                }
                else if (eventType == Interop.PackageManager.EventType.Move)
                {
                    handlers = s_moveEventHandler;
                }
                else if (eventType == Interop.PackageManager.EventType.ClearData)
                {
                    handlers = s_clearDataEventHandler;
                }
            }

            handlers?.Invoke(null, args);
        }

        private static void UnregisterPackageManagerEventIfNeeded()
        {
            if (s_packageManagerEventCallback == null || s_installEventHandler != null || s_uninstallEventHandler != null || s_updateEventHandler != null || s_moveEventHandler != null || s_clearDataEventHandler != null)
            {
                return;
            }

            lock (Handle)
            {
                var err = Interop.PackageManager.PackageManagerUnsetEvent(Handle);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    throw PackageManagerErrorFactory.GetException(err, "Failed to unregister package manager event event.");
                }
            }
        }
    }

    internal static class PackageManagerErrorFactory
    {
        internal static Exception GetException(Interop.PackageManager.ErrorCode err, string message)
        {
            string errMessage = string.Format("{0} err = {1}", message, err);
            switch (err)
            {
                case Interop.PackageManager.ErrorCode.InvalidParameter:
                case Interop.PackageManager.ErrorCode.NoSuchPackage:
                    return new ArgumentException(errMessage);
                case Interop.PackageManager.ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException(errMessage);
                case Interop.PackageManager.ErrorCode.IoError:
                    return new global::System.IO.IOException(errMessage);
                default:
                    return new InvalidOperationException(errMessage);
            }
        }
    }
}
