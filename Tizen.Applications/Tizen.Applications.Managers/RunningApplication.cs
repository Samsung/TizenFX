/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

namespace Tizen.Applications.Managers
{
    /// <summary>
    /// RunningApplication class. This class has the properties of RunningApplication.
    /// </summary>
    public class RunningApplication
    {
        internal RunningApplication(string applicationId, int processId)
        {
            ApplicationId = applicationId;
            ProcessId = processId;
        }

        /// <summary>
        /// ApplicationId property.
        /// </summary>
        /// <returns>string application id.</returns>
        public string ApplicationId
        {
            get;
            set;
        }

        /// <summary>
        /// ProcessId property.
        /// </summary>
        /// <returns>string process id.</returns>
        public int ProcessId
        {
            get;
            set;
        }
    }
}
