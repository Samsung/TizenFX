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

using System;

namespace Tizen.Network.Nsd
{
    /// <summary>
    /// This class is used for managing network service discovery using SSDP.
    /// </summary>
    public class SsdpBrowser : INsdBrowser
    {
        private string _target;
        private event EventHandler<SsdpServiceFoundEventArgs> _serviceFound;

        /// <summary>
        /// This event is raised when service state changes during service discovery using SSDP.
        /// </summary>
        public event EventHandler<SsdpServiceFoundEventArgs> ServiceFound
        {
            add
            {
                _serviceFound += value;
            }

            remove
            {
                _serviceFound -= value;
            }
        }

        /// <summary>
        /// A public constructor for SsdpBrowser class to create a SsdpBrowser instance for the given target.
        /// </summary>
        /// <param name="target">The target to browse for the service.</param>
        public SsdpBrowser(string target)
        {
            _target = target;
        }
    }
}
