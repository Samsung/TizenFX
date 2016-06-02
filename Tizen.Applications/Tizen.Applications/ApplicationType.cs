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
    /// Enumeration for applications type.
    /// </summary>
    public enum ApplicationType
    {
        /// <summary>
        /// All applications.
        /// </summary>
        All = Interop.Package.AppType.All,
        /// <summary>
        /// UI applications.
        /// </summary>
        Ui = Interop.Package.AppType.Ui,
        /// <summary>
        /// Service applications.
        /// </summary>
        Service = Interop.Package.AppType.Service
    }
}