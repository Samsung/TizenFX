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
    /// Enumeration for package manager event state.
    /// </summary>
    public enum PackageEventState
    {
        /// <summary>
        /// Processing started
        /// </summary>
        Started = Interop.PackageManager.PackageEventState.Started,
        /// <summary>
        /// Processing state.
        /// </summary>
        Processing = Interop.PackageManager.PackageEventState.Processing,
        /// <summary>
        /// Processing Completed.
        /// </summary>
        Completed = Interop.PackageManager.PackageEventState.Completed,
        /// <summary>
        /// Processing Failed.
        /// </summary>
        Failed = Interop.PackageManager.PackageEventState.Failed
    }
}