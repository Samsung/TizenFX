// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a service application.
    /// </summary>
    public class ServiceApplication : CoreApplication
    {
        /// <summary>
        /// Initializes ServiceApplication class.
        /// </summary>
        public ServiceApplication() : base(new ServiceCoreBackend())
        {
        }

        /// <summary>
        /// Runs the service application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        public override void Run(string[] args)
        {
            base.Run(args);
        }
    }
}
