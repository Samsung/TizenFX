/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the service applications.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ServiceApplication : CoreApplication
    {
        /// <summary>
        /// Initializes the ServiceApplication class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
#pragma warning disable CA2000
        public ServiceApplication() : base(new ServiceCoreBackend())
#pragma warning restore CA2000
        {
        }

        /// <summary>
        /// Runs the service application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// <since_tizen> 3 </since_tizen>
        public override void Run(string[] args)
        {
            base.Run(args);
        }

        /// <summary>
        /// Exits the main loop of the application without restarting.
        /// </summary>
        /// <remarks>
        /// This function terminates the current execution of the application by exiting its main loop. It does not trigger the app restart request.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ExitWithoutRestarting()
        {
            Interop.Service.ExitWithoutRestarting();
        }
    }
}
