/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides the methods and properties to get information about the package archive.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class PackageArchive
    {
        private const string LogTag = "Tizen.Applications";

        private string _path = string.Empty;
        private string _id = string.Empty;
        private string _type = string.Empty;
        private string _version = string.Empty;
        private string _apiVersion = string.Empty;
        private string _description = string.Empty;
        private string _label = string.Empty;
        private string _author = string.Empty;
        private IntPtr _icon = IntPtr.Zero;
        private int _iconSize = 0;
        private List<PackageDependencyInformation> _dependency_to;

        private PackageArchive(string archivePath)
        {
            _path = archivePath;
        }

        /// <summary>
        /// The package ID.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Id { get { return _id; } }

        /// <summary>
        /// Type of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Type { get { return _type; } }

        /// <summary>
        /// Version of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Version { get { return _version; } }

        /// <summary>
        /// Api version of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ApiVersion { get { return _apiVersion; } }

        /// <summary>
        /// Description of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Description { get { return _description; } }

        /// <summary>
        /// Label of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Label { get { return _label; } }

        /// <summary>
        /// Author of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Author { get { return _author; } }

        /// <summary>
        /// Icon of the package.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public byte[] Icon
        {
            get
            {
                byte[] byteArray = new byte[_iconSize];
                Marshal.Copy(_icon, byteArray, 0, _iconSize);
                return byteArray;
            }
        }

        /// <summary>
        /// Packages that this package is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public List<PackageDependencyInformation> DependencyTo { get { return _dependency_to; } }

        // This method assumes that given arguments are already validated and have valid values.
        internal static PackageArchive CreatePackageArchive(IntPtr handle, string archivePath)
        {
            PackageArchive packageArchive = new PackageArchive(archivePath);

            var err = Interop.PackageManager.ErrorCode.None;
            err = Interop.PackageArchive.PackageArchiveInfoGetPackage(handle, out packageArchive._id);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package id from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetType(handle, out packageArchive._type);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package type from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetVersion(handle, out packageArchive._version);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package version from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetApiVersion(handle, out packageArchive._apiVersion);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package api version from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetDescription(handle, out packageArchive._description);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package description from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetLabel(handle, out packageArchive._label);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package label from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetAuthor(handle, out packageArchive._author);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package author from " + archivePath);
            }
            err = Interop.PackageArchive.PackageArchiveInfoGetIcon(handle, out packageArchive._icon, out packageArchive._iconSize);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, "Failed to get package author from " + archivePath);
            }
            packageArchive._dependency_to = GetPackageArchiveDependencyInformation(handle);

            return packageArchive;
        }

        internal static PackageArchive GetPackageArchive(string archivePath)
        {
            IntPtr packageArchiveInfoHandle;
            Interop.PackageManager.ErrorCode err = Interop.PackageArchive.PackageArchiveInfoCreate(archivePath, out packageArchiveInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                throw PackageManagerErrorFactory.GetException(err, string.Format("Failed to create native handle for package archive info of {0}", archivePath));
            }

            PackageArchive packageArchive = CreatePackageArchive(packageArchiveInfoHandle, archivePath);

            err = Interop.PackageArchive.PackageArchiveInfoDestroy(packageArchiveInfoHandle);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to destroy native handle for package archive info of {0}. err = {1}", archivePath, err));
            }
            return packageArchive;
        }

        private static List<PackageDependencyInformation> GetPackageArchiveDependencyInformation(IntPtr handle)
        {
            List<PackageDependencyInformation> dependencies = new List<PackageDependencyInformation>();
            Interop.Package.PackageInfoDependencyInfoCallback dependencyInfoCb = (from, to, type, requiredVersion, userData) =>
            {
                dependencies.Add(PackageDependencyInformation.GetPackageDependencyInformation(from, to, type, requiredVersion));
                return true;
            };

            Interop.PackageManager.ErrorCode err = Interop.PackageArchive.PackageArchiveInfoForeachDirectDependency(handle, dependencyInfoCb, IntPtr.Zero);
            if (err != Interop.PackageManager.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get dependency info. err = {0}", err));
            }
            return dependencies;
        }
    }
}
