// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// This class is a parameter of InstallerApplicationApplicationsAsync method.
    /// </summary>
    public class ApplicationInfoFilter
    {
        /// <summary>
        /// This class is a possible key to use in the InstalledApplicationFilter.
        /// </summary>
        public static class Keys
        {
            /// <summary>
            ///
            /// </summary>
            public const string Id = "PACKAGE_INFO_PROP_APP_ID";
            /// <summary>
            ///
            /// </summary>
            public const string Type = "PACKAGE_INFO_PROP_APP_TYPE";
            /// <summary>
            ///
            /// </summary>
            public const string Category = "PACKAGE_INFO_PROP_APP_CATEGORY";
            /// <summary>
            ///
            /// </summary>
            public const string NoDisplay = "PACKAGE_INFO_PROP_APP_NODISPLAY";
            /// <summary>
            ///
            /// </summary>
            public const string TaskManage = "PACKAGE_INFO_PROP_APP_TASKMANAGE";
        }

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> Filter
        {
            get;
            set;
        }
    }
}
