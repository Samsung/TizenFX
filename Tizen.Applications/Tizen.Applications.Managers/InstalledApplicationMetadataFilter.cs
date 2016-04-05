/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;

namespace Tizen.Applications.Managers
{
    /// <summary>
    /// InstalledApplicationMetadataFilter class. This class is a parameter of InstallerApplicationAppsAsync method.
    /// </summary>
    public class InstalledApplicationMetadataFilter
    {
        public IDictionary<string, string> Filter
        {
            get;
            set;
        }
    }
}
