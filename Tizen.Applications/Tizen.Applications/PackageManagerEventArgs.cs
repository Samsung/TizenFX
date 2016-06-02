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
    /// PackageManagerEventArgs class. This class is an event arguments of the InstallProgressChanged, UninstallProgressChanged and UpdateProgressChanged events.
    /// </summary>
    public class PackageManagerEventArgs : EventArgs
    {
        private readonly PackageType _packageType;
        private readonly string _packageId;
        private readonly PackageEventState _state;
        private readonly int _progress;

        internal PackageManagerEventArgs(string packageType, string packageId, PackageEventState state, int progress)
        {
            _packageType = PackageTypeMethods.ToPackageType(packageType);
            _packageId = packageId;
            _state = state;
            _progress = progress;
        }

        /// <summary>
        /// Type of the package to be installed, uninstalled or updated
        /// </summary>
        public PackageType PackageType { get { return _packageType; } }

        /// <summary>
        /// package ID to be installed, uninstalled or updated
        /// </summary>
        public string PackageId { get { return _packageId; } }

        /// <summary>
        /// Current state of the request to the package manager
        /// </summary>
        public PackageEventState State { get { return _state; } }

        /// <summary>
        /// Progress for the request being processed by the package manager (in percent).
        /// </summary>
        public int Progress { get { return _progress; } }
    }
}
