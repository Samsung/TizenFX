using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for App Control Result.
    /// </summary>
    public enum AppControlLaunchResult
    {
        /// <summary>
        /// Callee application is launched actually.
        /// </summary>
        AppStarted = 1,

        /// <summary>
        /// Operation is succeeded
        /// </summary>
        Succeeded = 0,

        /// <summary>
        /// Operation is failed by the callee
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Operation is canceled by the platform
        /// </summary>
        Canceled = -2,
    }
}
