// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        private const string LogTag = "Tizen.Applications";
        private static SafePackageManagerHandle s_handle = new SafePackageManagerHandle();

        private static Interop.PackageManager.EventStatus s_eventStatus;
        private static event EventHandler<PackageManagerEventArgs> s_installEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_uninstallEventHandler;
        private static event EventHandler<PackageManagerEventArgs> s_updateEventHandler;

        private static Interop.PackageManager.PackageManagerEventCallback s_packageManagerEventCallback;

        /// <summary>
        /// InstallProgressChanged event. This event is occurred when a package is getting installed and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> InstallProgressChanged
        {
            add
            {
                RegisterPackageManagerEventIfNeeded(GetFlaggedEventStatus(Interop.PackageManager.EventStatus.Install));
                s_installEventHandler += value;
            }
            remove
            {
                s_installEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded(GetUnflaggedEventStatus(Interop.PackageManager.EventStatus.Install));
            }
        }

        /// <summary>
        /// UninstallProgressChanged event. This event is occurred when a package is getting uninstalled and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> UninstallProgressChanged
        {
            add
            {
                RegisterPackageManagerEventIfNeeded(GetFlaggedEventStatus(Interop.PackageManager.EventStatus.Unstall));
                s_uninstallEventHandler += value;
            }
            remove
            {
                s_uninstallEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded(GetUnflaggedEventStatus(Interop.PackageManager.EventStatus.Unstall));
            }
        }

        /// <summary>
        /// UpdateProgressChanged event. This event is occurred when a package is getting updated and the progress of the request to the package manager changes.
        /// </summary>
        public static event EventHandler<PackageManagerEventArgs> UpdateProgressChanged
        {
            add
            {
                RegisterPackageManagerEventIfNeeded(GetFlaggedEventStatus(Interop.PackageManager.EventStatus.Upgrade));
                s_updateEventHandler += value;
            }
            remove
            {
                s_updateEventHandler -= value;
                UnregisterPackageManagerEventIfNeeded(GetFlaggedEventStatus(Interop.PackageManager.EventStatus.Upgrade));
            }
        }

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
            string packageId = string.Empty;
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
        /// Retrieves package information of all packages satisfying filter conditions.
        /// </summary>
        /// <returns>Returns the list of packages asynchronously.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        public static IEnumerable<Package> GetPackages()
        {
            return GetPackages(null);
        }

        /// <summary>
        /// Retrieves package information of all packages satisfying filter conditions.
        /// </summary>
        /// <param name="filter">Optional - package filters</param>
        /// <returns>Returns the list of packages asynchronously.</returns>
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
        /// <returns>Returns true if installtion is successful, false otherwise.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath)
        {
            return Install(packagePath, null);
        }

        /// <summary>
        /// Installs package located at the given path
        /// </summary>
        /// <param name="packagePath">Absolute path for the package to be installed</param>
        /// <param name="expansionPackagePath">Optional - Absolute path for the expansion package to be installed</param>
        /// <returns>Returns true if installtion is successful, false otherwise.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Install(string packagePath, string expansionPackagePath)
        {
            IntPtr requestHandle;
            var err = Interop.PackageManager.PackageManagerRequestCreate(out requestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to install package. Error in creating request handle. err = {0}", err));
                return false;
            }

            if (!string.IsNullOrEmpty(expansionPackagePath))
            {
                err = Interop.PackageManager.PackageManagerRequestSetTepPath(requestHandle, expansionPackagePath);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to install package. Error in setting request package mode. err = {0}", err));
                    Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
                    return false;
                }
            }

            int requestId;
            err = Interop.PackageManager.PackageManagerRequestInstall(requestHandle, packagePath, out requestId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to install package. err = {0}", err));
                Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
                return false;
            }

            err = Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy package manager request handle. err = {0}", err));
                // This method returns true if all other operations are completed and error occured in destroying request handle.
            }
            return true;
        }

        /// <summary>
        /// Uninstalls package with the given name.
        /// </summary>
        /// <param name="packageId">Id of the package to be uninstalled</param>
        /// <param name="type">Package type for the package to be uninstalled</param>
        /// <returns>Returns true if installtion is successful, false otherwise.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Uninstall(string packageId, PackageType type)
        {
            IntPtr requestHandle;
            var err = Interop.PackageManager.PackageManagerRequestCreate(out requestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to uninstall package. Error in creating request handle. err = {0}", err));
                return false;
            }

            err = Interop.PackageManager.PackageManagerRequestSetType(requestHandle, type.ToString().ToLower());
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to uninstall package. Error in setting request package type. err = {0}", err));
                Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
                return false;
            }

            int requestId;
            err = Interop.PackageManager.PackageManagerRequestUninstall(requestHandle, packageId, out requestId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to uninstall package. err = {0}", err));
                Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
                return false;
            }

            err = Interop.PackageManager.PackageManagerRequestDestroy(requestHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy package manager request handle. err = {0}", err));
                // This method returns true if all other operations are completed and error occured in destroying request handle.
            }
            return true;
        }

        /// <summary>
        /// Move package to given storage.
        /// </summary>
        /// <param name="packageId">Id of the package to be moved</param>
        /// <param name="type">Package type for the package to be moved</param>
        /// <param name="newStorage">Storage, package should be moved to</param>
        /// <returns>Returns true if installtion is successful, false otherwise.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        public static bool Move(string packageId, PackageType type, StorageType newStorage)
        {
            IntPtr request;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerRequestCreate(out request);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to create request handle. err = {0}", err));
                return false;
            }

            err = Interop.PackageManager.PackageManagerRequestSetType(request, type.ToString().ToLower());
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to move package. Error in setting request package type. err = {0}", err));
                Interop.PackageManager.PackageManagerRequestDestroy(request);
                return false;
            }

            bool result = true;
            err = Interop.PackageManager.PackageManagerRequestMove(request, packageId, (Interop.PackageManager.StorageType)newStorage);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to move package to requested location. err = {0}", err));
                result = false;
            }

            err = Interop.PackageManager.PackageManagerRequestDestroy(request);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy package manager request handle. err = {0}", err));
                // This method returns true if all other operations are completed and error occured in destroying request handle.
            }

            return result;
        }

        private static Interop.PackageManager.EventStatus GetFlaggedEventStatus(Interop.PackageManager.EventStatus newEvent)
        {
            return s_eventStatus | newEvent;
        }

        private static Interop.PackageManager.EventStatus GetUnflaggedEventStatus(Interop.PackageManager.EventStatus oldEvent)
        {
            return s_eventStatus & (~oldEvent);
        }

        private static void RegisterPackageManagerEventIfNeeded(Interop.PackageManager.EventStatus eventStatus)
        {
            if (s_installEventHandler != null || s_uninstallEventHandler != null || s_updateEventHandler != null)
            {
                return;
            }

            var err = Interop.PackageManager.ErrorCode.None;
            s_packageManagerEventCallback = (packageType, packageId, eventType, eventState, progress, error, user_data) =>
            {
                try
                {
                    PackageManagerEventArgs eventArgs = new PackageManagerEventArgs(packageType, packageId, (PackageEventState)eventState, progress);
                    if (eventType == Interop.PackageManager.EventType.Install)
                    {
                        s_installEventHandler?.Invoke(null, eventArgs);
                    }
                    else if (eventType == Interop.PackageManager.EventType.Uninstall)
                    {
                        s_uninstallEventHandler?.Invoke(null, eventArgs);
                    }
                    else if (eventType == Interop.PackageManager.EventType.Update)
                    {
                        s_updateEventHandler?.Invoke(null, eventArgs);
                    }
                }
                catch (Exception e)
                {
                    Log.Warn(LogTag, e.Message);
                }
            };

            if (s_handle.IsInvalid)
            {
                err = Interop.PackageManager.PackageManagerCreate(out s_handle);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to create package manager handle. err = {0}", err));
                }
            }

            if (!s_handle.IsInvalid)
            {
                if (s_eventStatus != eventStatus)
                {
                    err = Interop.PackageManager.PackageManagerSetEvenStatus(s_handle, eventStatus);
                    if (err == Interop.PackageManager.ErrorCode.None)
                    {
                        s_eventStatus = eventStatus;
                    }
                }
                err = Interop.PackageManager.PackageManagerSetEvent(s_handle, s_packageManagerEventCallback, IntPtr.Zero);
            }
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to register callback for package manager event. err = {0}", err));
            }
        }

        private static void UnregisterPackageManagerEventIfNeeded(Interop.PackageManager.EventStatus eventStatus)
        {
            if (s_installEventHandler != null || s_uninstallEventHandler != null || s_updateEventHandler != null)
            {
                return;
            }

            if (s_handle.IsInvalid)
            {
                return;
            }

            var err = Interop.PackageManager.PackageManagerUnsetEvent(s_handle);
            if (s_eventStatus != eventStatus)
            {
                err = Interop.PackageManager.PackageManagerSetEvenStatus(s_handle, eventStatus);
                if (err == Interop.PackageManager.ErrorCode.None)
                {
                    s_eventStatus = eventStatus;
                }
            }
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
                    return new System.IO.IOException(errMessage);
                default:
                    return new InvalidOperationException(errMessage);
            }
        }
    }
}
