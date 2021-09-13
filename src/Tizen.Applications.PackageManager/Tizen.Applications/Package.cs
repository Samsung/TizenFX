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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides the methods and properties to get information about the packages.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Package
    {
        private const string LogTag = "Tizen.Applications";

        private string _id = string.Empty;
        private string _mainAppId = string.Empty;
        private string _label = string.Empty;
        private string _iconPath = string.Empty;
        private string _version = string.Empty;
        private PackageType _type;
        private Interop.PackageManager.StorageType _installedStorageType;
        private string _rootPath = string.Empty;
        private string _expansionPackageName = string.Empty;
        private bool _isSystemPackage;
        private bool _isRemovable;
        private bool _isPreloaded;
        private bool _isAccessible;
        private IReadOnlyDictionary<CertificateType, PackageCertificate> _certificates;
        private List<string> _privileges;
        private int _installedTime;

        private Dictionary<IntPtr, Interop.PackageManager.PackageManagerSizeInfoCallback> _packageManagerSizeInfoCallbackDict = new Dictionary<IntPtr, Interop.PackageManager.PackageManagerSizeInfoCallback>();
        private int _callbackId = 0;
        private List<PackageDependencyInformation> _dependencyTo;
        private List<PackageDependencyInformation> _dependencyFrom;
        private IReadOnlyDictionary<string, IEnumerable<string>> _allowedPackagesAndPrivilegesList;

        private Package(string pkgId)
        {
            _id = pkgId;
        }

        /// <summary>
        /// The package ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Id { get { return _id; } }

        /// <summary>
        /// Label of the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Label { get { return _label; } }

        /// <summary>
        /// Absolute path to the icon image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IconPath { get { return _iconPath; } }

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Version { get { return _version; } }

        /// <summary>
        /// Type of the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PackageType PackageType { get { return _type; } }

        /// <summary>
        /// Installed storage type for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public StorageType InstalledStorageType { get { return (StorageType)_installedStorageType; } }

        /// <summary>
        /// Root path for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string RootPath { get { return _rootPath; } }

        /// <summary>
        /// Expansion package name for the package.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/packagemanager.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public string TizenExpansionPackageName { get { return _expansionPackageName; } }

        /// <summary>
        /// Checks whether the package is a system package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsSystemPackage { get { return _isSystemPackage; } }

        /// <summary>
        /// Checks whether the package is removable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsRemovable { get { return _isRemovable; } }

        /// <summary>
        /// Checks whether the package is preloaded.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsPreloaded { get { return _isPreloaded; } }

        /// <summary>
        /// Checks whether the current package is accessible.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsAccessible { get { return _isAccessible; } }

        /// <summary>
        /// Certificate information for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IReadOnlyDictionary<CertificateType, PackageCertificate> Certificates { get { return _certificates; } }

        /// <summary>
        /// Requested privilege for the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<string> Privileges { get { return _privileges; } }

        /// <summary>
        /// Installed time of the package.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int InstalledTime { get { return _installedTime; } }

        /// <summary>
        /// Main application info of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ApplicationInfo MainApplication
        {
            get
            {
                ApplicationInfo applicaionInfo = new ApplicationInfo(_mainAppId);
                return applicaionInfo;
            }
        }

        /// <summary>
        /// Retrieves all the application IDs of this package.
        /// </summary>
        /// <returns>Returns a dictionary containing all the application information for a given application type.</returns>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<ApplicationInfo> GetApplications()
        {
            return GetApplications(ApplicationType.All);
        }

        /// <summary>
        /// Retrieves all the application IDs of this package.
        /// </summary>
        /// <param name="type">Optional: AppType enumeration value.</param>
        /// <returns>Returns a dictionary containing all the application information for a given application type.</returns>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<ApplicationInfo> GetApplications(ApplicationType type)
        {
            List<ApplicationInfo> appInfoList = new List<ApplicationInfo>();
            Interop.Package.PackageInfoAppInfoCallback cb = (Interop.Package.AppType appType, string appId, IntPtr userData) =>
            {
                appInfoList.Add(new ApplicationInfo(appId));
                return true;
            };

            IntPtr packageInfoHandle;
            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoCreate(Id, out packageInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to create native handle for package info of {0}. err = {1}", Id, err));
            }

            err = Interop.Package.PackageInfoForeachAppInfo(packageInfoHandle, (Interop.Package.AppType)type, cb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to application info of {0}. err = {1}", Id, err));
            }

            err = Interop.Package.PackageInfoDestroy(packageInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy native handle for package info of {0}. err = {1}", Id, err));
            }
            return appInfoList;
        }

        /// <summary>
        /// Retrieves all the application IDs of this package.
        /// </summary>
        /// <param name="componentType">Optional: AppType enumeration value.</param>
        /// <returns>Returns a dictionary containing all the application information for a given application type.</returns>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<ApplicationInfo> GetApplications(ApplicationComponentType componentType)
        {
            return GetApplications(ToApplicationType(componentType));
        }

        /// <summary>
        /// Packages required by this package
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<PackageDependencyInformation> DependencyTo { get { return _dependencyTo; } }

        /// <summary>
        /// Packages that require this package
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<PackageDependencyInformation> DependencyFrom { get { return _dependencyFrom; } }

        /// <summary>
        /// Gets the package size information.
        /// </summary>
        /// <returns>Package size information.</returns>
        /// <privilege>http://tizen.org/privilege/packagemanager.info</privilege>
        /// <since_tizen> 3 </since_tizen>
        public async Task<PackageSizeInformation> GetSizeInformationAsync()
        {
            TaskCompletionSource<PackageSizeInformation> tcs = new TaskCompletionSource<PackageSizeInformation>();
            Interop.PackageManager.PackageManagerSizeInfoCallback sizeInfoCb = (pkgId, sizeInfoHandle, userData) =>
            {
                if (sizeInfoHandle != IntPtr.Zero && Id == pkgId)
                {
                    var pkgSizeInfo = PackageSizeInformation.GetPackageSizeInformation(sizeInfoHandle);
                    tcs.TrySetResult(pkgSizeInfo);
                }

                lock (_packageManagerSizeInfoCallbackDict)
                {
                    _packageManagerSizeInfoCallbackDict.Remove(userData);
                }
            };

            IntPtr callbackId;
            lock (_packageManagerSizeInfoCallbackDict)
            {
                callbackId = (IntPtr)_callbackId++;
                _packageManagerSizeInfoCallbackDict[callbackId] = sizeInfoCb;
            }

            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerGetSizeInfo(Id, sizeInfoCb, callbackId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                tcs.TrySetException(PackageManagerErrorFactory.GetException(err, "Failed to get total package size info of " + Id));
            }
            return await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Compares the certificate information with the given package ID.
        /// </summary>
        /// <param name="packageId">ID of the package.</param>
        /// <returns>Certificate comparison result.</returns>
        /// <exception cref="ArgumentException">Thrown when a failed input package ID is invalid.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <since_tizen> 3 </since_tizen>
        public CertCompareResultType CompareCertInfo(string packageId)
        {
            Interop.PackageManager.CertCompareResultType compareResult;
            Interop.PackageManager.ErrorCode err = Interop.PackageManager.PackageManagerCompareCertInfo(Id, packageId, out compareResult);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to compare package cert info");
            }

            return (CertCompareResultType)compareResult;
        }

        /// <summary>
        /// The allowed packages and required privileges information.
        /// </summary>
        /// <remarks> The dictionary contains application IDs as the keys, and a collection of privileges related to that application as the value.</remarks>
        /// <since_tizen> 9 </since_tizen>
        public IReadOnlyDictionary<string, IEnumerable<string>> AllowedPackagesAndPrivileges
        {
            get { return _allowedPackagesAndPrivilegesList; }
        }

        // This method assumes that given arguments are already validated and have valid values.
        internal static Package CreatePackage(IntPtr handle, string pkgId)
        {
            Package package = new Package(pkgId);

            var err = Interop.PackageManager.ErrorCode.None;
            err = Interop.Package.PackageInfoGetMainAppId(handle, out package._mainAppId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package main app id of " + pkgId);
            }
            err = Interop.Package.PackageInfoGetLabel(handle, out package._label);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package label of " + pkgId);
            }
            err = Interop.Package.PackageInfoGetIconPath(handle, out package._iconPath);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package icon path of " + pkgId);
            }
            err = Interop.Package.PackageInfoGetVersion(handle, out package._version);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package version of " + pkgId);
            }

            string type;
            Interop.Package.PackageInfoGetType(handle, out type);
            if (Enum.TryParse(type, true, out package._type) == false)
            {
                Log.Warn(LogTag, "Failed to get package type of " + pkgId);
            }
            err = Interop.Package.PackageInfoGetRootPath(handle, out package._rootPath);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package root directory of " + pkgId);
            }
            err = Interop.Package.PackageInfoGetTepName(handle, out package._expansionPackageName);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get expansion package name of " + pkgId);
                package._expansionPackageName = string.Empty;
            }

            err = Interop.Package.PackageInfoGetInstalledStorage(handle, out package._installedStorageType);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get installed storage type of " + pkgId);
            }
            Interop.Package.PackageInfoIsSystemPackage(handle, out package._isSystemPackage);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get whether package " + pkgId + " is system package or not");
            }
            Interop.Package.PackageInfoIsRemovablePackage(handle, out package._isRemovable);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get whether package " + pkgId + " is removable or not");
            }
            Interop.Package.PackageInfoIsPreloadPackage(handle, out package._isPreloaded);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get whether package " + pkgId + " is preloaded or not");
            }
            Interop.Package.PackageInfoIsAccessible(handle, out package._isAccessible);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get whether package " + pkgId + " is accessible or not");
            }
            try
            {
                Interop.Package.PackageInfoGetInstalledTime(handle, out package._installedTime);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, "Failed to get installed time of " + pkgId);
                }
            }
            catch (TypeLoadException)
            {
                // To support in API vesion 3.0
                package._installedTime = 0;
            }

            package._certificates = PackageCertificate.GetPackageCertificates(handle);
            package._privileges = GetPackagePrivilegeInformation(handle);
            package._dependencyTo = GetPackageDependency(handle);
            package._dependencyFrom = GetPackageDependencyDependsOn(handle);
            package._allowedPackagesAndPrivilegesList = GetAllowedPackagesAndPrivileges(handle);
            return package;
        }

        internal static Package GetPackage(string packageId)
        {
            IntPtr packageInfoHandle;
            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoCreate(packageId, out packageInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, string.Format("Failed to create native handle for package info of {0}", packageId));
            }

            Package package = CreatePackage(packageInfoHandle, packageId);

            err = Interop.Package.PackageInfoDestroy(packageInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy native handle for package info of {0}. err = {1}", packageId, err));
            }
            return package;
        }

        internal static Package GetPackage(IntPtr packageInfoHandle)
        {
            String packageId;
            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoGetPackage(packageInfoHandle, out packageId);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, "Failed to get package id for given package handle.");
            }
            return CreatePackage(packageInfoHandle, packageId);
        }

        private static List<string> GetPackagePrivilegeInformation(IntPtr packageInfoHandle)
        {
            List<string> privileges = new List<string>();
            Interop.Package.PackageInfoPrivilegeInfoCallback privilegeInfoCb = (privilege, userData) =>
            {
                privileges.Add(privilege);
                return true;
            };

            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoForeachPrivilegeInfo(packageInfoHandle, privilegeInfoCb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get privilage info. err = {0}", err));
            }
            return privileges;
        }

        private ApplicationType ToApplicationType(ApplicationComponentType componentType)
        {
            ApplicationType applicationType = 0;
            if (componentType == Tizen.Applications.ApplicationComponentType.UIApplication)
                applicationType = Tizen.Applications.ApplicationType.Ui;
            else if (componentType == Tizen.Applications.ApplicationComponentType.ServiceApplication)
                applicationType = Tizen.Applications.ApplicationType.Service;
            else if (componentType == Tizen.Applications.ApplicationComponentType.WidgetApplication)
                applicationType = Tizen.Applications.ApplicationType.Widget;
            else if (componentType == Tizen.Applications.ApplicationComponentType.WatchApplication)
                applicationType = Tizen.Applications.ApplicationType.Watch;

            return applicationType;
        }

        private static List<PackageDependencyInformation> GetPackageDependency(IntPtr packageInfoHandle)
        {
            List<PackageDependencyInformation> dependencies = new List<PackageDependencyInformation>();
            Interop.Package.PackageInfoDependencyInfoCallback dependencyInfoCb = (from, to, type, requiredVersion, userData) =>
            {
                dependencies.Add(PackageDependencyInformation.GetPackageDependencyInformation(from, to, type, requiredVersion));
                return true;
            };

            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoForeachDependencyInfo(packageInfoHandle, dependencyInfoCb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get dependency info. err = {0}", err));
            }
            return dependencies;
        }

        private static List<PackageDependencyInformation> GetPackageDependencyDependsOn(IntPtr packageInfoHandle)
        {
            List<PackageDependencyInformation> dependencies = new List<PackageDependencyInformation>();
            Interop.Package.PackageInfoDependencyInfoCallback dependencyInfoCb = (from, to, type, requiredVersion, userData) =>
            {
                dependencies.Add(PackageDependencyInformation.GetPackageDependencyInformation(from, to, type, requiredVersion));
                return true;
            };

            Interop.PackageManager.ErrorCode err = Interop.Package.PackageInfoForeachDependencyInfoDependsOn(packageInfoHandle, dependencyInfoCb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get dependency info. err = {0}", err));
            }
            return dependencies;
        }

        private static Dictionary<string, IEnumerable<string>> GetAllowedPackagesAndPrivileges(IntPtr packageInfoHandle)
        {
            Interop.PackageManager.ErrorCode err;
            Dictionary<string, IEnumerable<string>> allowedPackagesAndPrivileges = new Dictionary<string, IEnumerable<string>>();
            Interop.Package.PackageInfoResAllowedPackageCallback allowedPackageCallback = (allowedPackage, requiredPrivileges, userData) =>
            {
                List<string> requiredPrivilegesList = new List<string>();
                Interop.Package.PackageInfoPrivilegeInfoCallback requiredPrivCallback = (priv, requiredPrivCbUserData) =>
                {
                    requiredPrivilegesList.Add(priv);
                    return true;
                };
                err = Interop.Package.PackageInfoForeachRequiredPrivilege(requiredPrivileges, requiredPrivCallback, IntPtr.Zero);
                if (err != Interop.PackageManager.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to get required privileges of allowed packages info. err = {0}", err));
                }
                else
                {
                    allowedPackagesAndPrivileges.Add(allowedPackage, requiredPrivilegesList);
                }
                return true;
            };

            err = Interop.Package.PackageInfoForeachResAllowedPackage(packageInfoHandle, allowedPackageCallback, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get allowed packages info. err = {0}", err));
            }
            return allowedPackagesAndPrivileges;
        }
    }
}
