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
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Tizen.Applications
{
    /// <summary>
    /// PackageManager class. This class has the methods and events of the PackageManager.
    /// </summary>
    /// <remarks>
    /// The package manager is one of the core modules of Tizen application framework, and responsible for getting their information.
    /// You can also retrieve information related to the packages that are installed on the device.
    /// </remarks>
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

        private static Interop.PackageManager.PackageManagerEventCallback s_packageManagerEventCallback;

        public delegate void RequestEventCallback(string type, string packageId, PackageEventType eventType, PackageEventState eventState, int progress);
        private static Dictionary<int, RequestEventCallback> RequestCallbacks = new Dictionary<int, RequestEventCallback>();
        private static Dictionary<int, SafePackageManagerRequestHandle> RequestHandles = new Dictionary<int, SafePackageManagerRequestHandle>();

        /// <summary>
        /// InstallProgressChanged event. This event is occurred when a package is getting installed and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> InstallProgressChanged
        {
            add
            {
                SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Install);
                RegisterPackageManagerEventIfNeeded();
                s_installEventHandler += value;
            }
            remove
            {
                s_installEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded();
                UnsetPackageManagerEventStatus();
            }
        }

        /// <summary>
        /// UninstallProgressChanged event. This event is occurred when a package is getting uninstalled and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> UninstallProgressChanged
        {
            add
            {
                SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Uninstall);
                RegisterPackageManagerEventIfNeeded();
                s_uninstallEventHandler += value;
            }
            remove
            {
                s_uninstallEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded();
                UnsetPackageManagerEventStatus();
            }
        }

        /// <summary>
        /// UpdateProgressChanged event. This event is occurred when a package is getting updated and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> UpdateProgressChanged
        {
            add
            {
                SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Upgrade);
                RegisterPackageManagerEventIfNeeded();
                s_updateEventHandler += value;
            }
            remove
            {
                s_updateEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded();
                UnsetPackageManagerEventStatus();
            }
        }

        /// <summary>
        /// MoveProgressChanged event. This event is occurred when a package is getting moved and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> MoveProgressChanged
        {
            add
            {
                SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.Move);
                RegisterPackageManagerEventIfNeeded();
                s_moveEventHandler += value;
            }
            remove
            {
                s_moveEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded();
                UnsetPackageManagerEventStatus();
            }
        }

        /// <summary>
        /// ClearDataProgressChanged event. This event is occurred when data directories are cleared in the given package.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> ClearDataProgressChanged
        {
            add
            {
                SetPackageManagerEventStatus(Interop.PackageManager.EventStatus.ClearData);
                RegisterPackageManagerEventIfNeeded();
                s_clearDataEventHandler += value;
            }
            remove
            {
                s_clearDataEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded();
                UnsetPackageManagerEventStatus();
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
                RequestCallbacks[id](packageType, packageId, (PackageEventType)eventType, (PackageEventState)eventState, progress);
                if (eventState == Interop.PackageManager.PackageEventState.Completed || eventState == Interop.PackageManager.PackageEventState.Failed)
                {
                    Log.Debug(LogTag, string.Format("release request handle for id : {0}", id));
                    RequestHandles[id].Dispose();
                }
            }
        };

        /// <summary>
        /// Gets the package ID for the given app ID.
        /// </summary>
        /// <param name="applicationId">The ID of the application</param>
        /// <returns>Returns the ID of the package. Empty string if App ID does not exist</returns>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        public static string GetPackageIdByApplicationId(string applicationId)
        {
            string packageId;
            var err = Interop.PackageManager.PackageManageGetPackageIdByAppId(applicationId, out packageId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get package Id. err = {0}", err));
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
        /// <param name="packageId">The ID of the package</param>
        /// <returns>Returns the package information for the given package ID.</returns>
        /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        public static Package GetPackage(string packageId)
        {
            return Package.GetPackage(packageId);
        }

        /// <summary>
        /// Clears the application's internal and external cache directory.
        /// </summary>
        /// <param name="packageId">Id of the package</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.clearcache</privilege>
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
        /// Clears all application's internal and external cache directory.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
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
        /// Clears the application's internal and external data directories
        /// </summary>
        /// <remarks>
        /// All files under data, shared/data and shared/trusted in the internal storage are removed.
        /// And, If external storeage exists, then all files under data and shared/trusted in the external storage are removed.
        /// </remarks>
        /// <param name="packageId">Id of the package</param>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
        /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
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
        /// Retrieves package information of all installed packages.
        /// </summary>
        /// <returns>Returns the list of packages.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        public static IEnumerable<Package> GetPackages()
        {
            return GetPackages(null);
        }

        /// <summary>
        /// Retrieves package information of all installed packages satisfying filter conditions.
        /// </summary>
        /// <param name="filter">Optional - package filters</param>
        /// <returns>Returns the list of packages.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
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
        public static async Task<PackageSizeInformation> GetTotalSizeInformationAsync()
        {
            TaskCompletionSource<PackageSizeInformation> tcs = new TaskCompletionSource<PackageSizeInformation>();
            Interop.PackageManager.PackageManagerTotalSizeInfoCallback cb = (handle, userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    tcs.TrySetResult(PackageSizeInformation.GetPackageSizeInformation(handle));
                }
            };

            var err = Interop.PackageManager.PackageManagerGetTotalSizeInfo(cb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                tcs.TrySetException(PackageManagerErrorFactory.GetException(err, "Failed to get total package size info"));
            }
            return await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath)
        {
            return Install(packagePath, null, PackageType.UNKNOWN, null);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, RequestEventCallback eventCallback)
        {
            return Install(packagePath, null, PackageType.UNKNOWN, eventCallback);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="type">Optional - Package type for the package to be installed</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, PackageType type)
        {
            return Install(packagePath, null, type, null);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="expansionPackagePath">Optional - Absolute path for the expansion package to be installed</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, string expansionPackagePath)
        {
            return Install(packagePath, expansionPackagePath, PackageType.UNKNOWN, null);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="type">Optional - Package type for the package to be installed</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, PackageType type, RequestEventCallback eventCallback)
        {
            return Install(packagePath, null, type, eventCallback);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="expansionPackagePath">Optional - Absolute path for the expansion package to be installed</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, string expansionPackagePath, RequestEventCallback eventCallback)
        {
            return Install(packagePath, expansionPackagePath, PackageType.UNKNOWN, eventCallback);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="expansionPackagePath">Optional - Absolute path for the expansion package to be installed</param>
        /// <param name="type">Optional - Package type for the package to be installed</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, string expansionPackagePath, PackageType type)
        {
            return Install(packagePath, expansionPackagePath, type, null);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="expansionPackagePath">Optional - Absolute path for the expansion package to be installed</param>
        /// <param name="type">Optional - Package type for the package to be installed</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if installtion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of installation is seccessful.
        /// To check the result of installation, the caller should check the progress using InstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, string expansionPackagePath, PackageType type, RequestEventCallback eventCallback)
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
                if (type != PackageType.UNKNOWN)
                {
                    err = Interop.PackageManager.PackageManagerRequestSetType(RequestHandle, type.ToString().ToLower());
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to install package. Error in setting request package type. err = {0}", err));
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
                    err = Interop.PackageManager.PackageManagerRequestInstallWithCB(RequestHandle, packagePath, internalRequestEventCallback, IntPtr.Zero, out requestId);
                    if (err == Interop.PackageManager.ErrorCode.None)
                    {
                        RequestCallbacks.Add(requestId, eventCallback);
                        RequestHandles.Add(requestId, RequestHandle);
                    }
                    else
                    {
                        Log.Warn(LogTag, string.Format("Failed to install package. err = {0}", err));
                        RequestHandle.Dispose();
                        return false;
                    }
                }
                else
                {
                    err = Interop.PackageManager.PackageManagerRequestInstall(RequestHandle, packagePath, out requestId);
                    if (err != Interop.PackageManager.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to install package. err = {0}", err));
                        RequestHandle.Dispose();
                        return false;
                    }
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
        /// Uninstalls package with the given name.
        /// </summary>
        /// <param name="packageId">Id of the package to be uninstalled</param>
        /// <returns>Returns true if uninstallation request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of uninstallation is seccessful.
        /// To check the result of uninstallation, the caller should check the progress using UninstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Uninstall(string packageId)
        {
            return Uninstall(packageId, PackageType.UNKNOWN, null);
        }

        /// <summary>
        /// Uninstalls package with the given name.
        /// </summary>
        /// <param name="packageId">Id of the package to be uninstalled</param>
        /// <param name="type">Optional - Package type for the package to be uninstalled</param>
        /// <returns>Returns true if uninstalltion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of uninstallation is seccessful.
        /// To check the result of uninstallation, the caller should check the progress using UninstallProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Uninstall(string packageId, PackageType type)
        {
            return Uninstall(packageId, type, null);
        }

        /// <summary>
        /// Uninstalls package with the given name.
        /// </summary>
        /// <param name="packageId">Id of the package to be uninstalled</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if uninstalltion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of uninstallation is seccessful.
        /// To check the result of uninstallation, the caller should check the progress using UninstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Uninstall(string packageId, RequestEventCallback eventCallback)
        {
            return Uninstall(packageId, PackageType.UNKNOWN, eventCallback);
        }

        /// <summary>
        /// Uninstalls package with the given name.
        /// </summary>
        /// <param name="packageId">Id of the package to be uninstalled</param>
        /// <param name="type">Optional - Package type for the package to be uninstalled</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if uninstalltion request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of uninstallation is seccessful.
        /// To check the result of uninstallation, the caller should check the progress using UninstallProgressChanged event OR eventCallback.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Uninstall(string packageId, PackageType type, RequestEventCallback eventCallback)
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
                err = Interop.PackageManager.PackageManagerRequestSetType(RequestHandle, type.ToString().ToLower());
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to uninstall package. Error in setting request package type. err = {0}", err));
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
                    }
                    else
                    {
                        Log.Warn(LogTag, string.Format("Failed to uninstall package. err = {0}", err));
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
        /// Move package to given storage.
        /// </summary>
        /// <param name="packageId">Id of the package to be moved</param>
        /// <param name="newStorage">Storage, package should be moved to</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of move is seccessful.
        /// To check the result of move, the caller should check the progress using MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Move(string packageId, StorageType newStorage)
        {
            return Move(packageId, PackageType.UNKNOWN, newStorage, null);
        }

        /// <summary>
        /// Move package to given storage.
        /// </summary>
        /// <param name="packageId">Id of the package to be moved</param>
        /// <param name="type">Optional - Package type for the package to be moved</param>
        /// <param name="newStorage">Storage, package should be moved to</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of move is seccessful.
        /// To check the result of move, the caller should check the progress using MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Move(string packageId, PackageType type, StorageType newStorage)
        {
            return Move(packageId, type, newStorage, null);
        }

        /// <summary>
        /// Move package to given storage.
        /// </summary>
        /// <param name="packageId">Id of the package to be moved</param>
        /// <param name="newStorage">Storage, package should be moved to</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of move is seccessful.
        /// To check the result of move, the caller should check the progress using MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Move(string packageId, StorageType newStorage, RequestEventCallback eventCallback)
        {
            return Move(packageId, PackageType.UNKNOWN, newStorage, eventCallback);
        }

        /// <summary>
        /// Move package to given storage.
        /// </summary>
        /// <param name="packageId">Id of the package to be moved</param>
        /// <param name="type">Optional - Package type for the package to be moved</param>
        /// <param name="newStorage">Storage, package should be moved to</param>
        /// <param name="eventCallback">Optional - The event callback will be invoked only for the current request</param>
        /// <returns>Returns true if move request is successful, false otherwise.</returns>
        /// <remarks>
        /// The 'true' means that just the request of move is seccessful.
        /// To check the result of move, the caller should check the progress using MoveProgressChanged event.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
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
        /// Gets permission type of package which has given application id
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <returns>Returns permission type.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
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
        /// Gets package's preload attribute which contain given applicion id
        /// </summary>
        /// <param name="applicationId">Id of the application</param>
        /// <returns>Returns true if package is preloaded. Otherwise return false.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
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
        /// Compare certificate of two packages
        /// </summary>
        /// <param name="lhsPackageId">package id to compare</param>
        /// <param name="rhsPackageId">package id to be compared</param>
        /// <returns>Returns certificate comparison result.</returns>
        /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
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
        /// Compare certificate of two packages which contain each given application id
        /// </summary>
        /// <param name="lhsApplicationId">application id to compare</param>
        /// <param name="rhsApplicationId">application id to be compared</param>
        /// <returns>Returns certificate comparison result.</returns>
        /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
        /// <exception cref="System.IO.IOException">Thrown when method failed due to internal IO error</exception>
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
        /// Drm nested class. This class has the PackageManager's drm related methods.
        /// </summary>
        public static class Drm
        {
            /// <summary>
            /// Generates request for getting license
            /// </summary>
            /// <param name="responseData">Response data string of the purchase request</param>
            /// <returns>Returns package drm information of given response data which contains require data and license url</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
            /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
            public static PackageDrm GenerateLicenseRequest(string responseData)
            {
                return PackageDrm.GenerateLicenseRequest(responseData);

            }

            /// <summary>
            /// Registers encrypted license
            /// </summary>
            /// <param name="responseData">The response data string of the rights request</param>
            /// <returns>Returns true if succeed. Otherwise return false</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
            /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
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
            /// Decrypts contents which is encrypted
            /// </summary>
            /// <param name="drmFilePath">Drm file path</param>
            /// <param name="decryptedFilePath">Decrypted file path</param>
            /// <returns>Returns true if succeed. Otherwise return false</returns>
            /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
            /// <exception cref="ArgumentException">Thrown when failed when input package ID is invalid</exception>
            /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory to continue the execution of the method</exception>
            /// <exception cref="UnauthorizedAccessException">Thrown when app does not have privilege to access this method</exception>
            /// <exception cref="SystemException">Thrown when method failed due to internal system error</exception>
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
                err = Interop.PackageManager.PackageManagerSetEvenStatus(Handle, eventStatus);
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
                err = Interop.PackageManager.PackageManagerSetEvenStatus(Handle, eventStatus);
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
            {
                return;
            }

            var err = Interop.PackageManager.ErrorCode.None;
            s_packageManagerEventCallback = (packageType, packageId, eventType, eventState, progress, error, user_data) =>
            {
                try
                {
                    if (eventType == Interop.PackageManager.EventType.Install)
                    {
                        s_installEventHandler?.Invoke(null, new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress));
                    }
                    else if (eventType == Interop.PackageManager.EventType.Uninstall)
                    {
                        s_uninstallEventHandler?.Invoke(null, new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress));
                    }
                    else if (eventType == Interop.PackageManager.EventType.Update)
                    {
                        s_updateEventHandler?.Invoke(null, new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress));
                    }
                    else if (eventType == Interop.PackageManager.EventType.Move)
                    {
                        s_moveEventHandler?.Invoke(null, new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress));
                    }
                    else if (eventType == Interop.PackageManager.EventType.ClearData)
                    {
                        s_clearDataEventHandler?.Invoke(null, new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress));
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(LogTag, e.Message);
                }
            };

            if (!Handle.IsInvalid)
            {
                Log.Debug(LogTag, "Reset Package Event");
                err = Interop.PackageManager.PackageManagerUnsetEvent(Handle);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    throw PackageManagerErrorFactory.GetException(err, "Failed to unregister package manager event event.");
                }

                err = Interop.PackageManager.PackageManagerSetEvent(Handle, s_packageManagerEventCallback, IntPtr.Zero);
            }
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to register callback for package manager event. err = {0}", err));
            }
        }

        private static void UnregisterPackageManagerEventIfNeeded()
        {
            if (Handle.IsInvalid || s_installEventHandler != null || s_uninstallEventHandler != null || s_updateEventHandler != null || s_moveEventHandler != null || s_clearDataEventHandler != null)
            {
                return;
            }

            var err = Interop.PackageManager.PackageManagerUnsetEvent(Handle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to unregister package manager event event.");
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
