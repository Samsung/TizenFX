/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents a Team application that runs without a graphical user interface.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TeamServiceApplication : TeamCoreApplication
    {
        /// <summary>
        /// Initializes the <see cref="TeamServiceApplication"/> class.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CA2000
        public TeamServiceApplication() : base(new TeamServiceCoreBackend())
#pragma warning restore CA2000
        {
        }

        /// <summary>
        /// Runs the Team service application's main loop.
        /// </summary>
        /// <param name="args">Arguments from commandline.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Run(string[] args)
        {
            base.Run(args);
        }
    }
}
