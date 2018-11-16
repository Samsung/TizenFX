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
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the recent application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecentApplicationInfo : ApplicationInfo
    {
        private const string LogTag = "Tizen.Applications";

        /// <summary>
        /// Gets the instance ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InstanceId { get; private set; }

        /// <summary>
        /// Gets the instance name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InstanceName { get; private set; }

        /// <summary>
        /// Gets the arguements.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Arg { get; private set; }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uri { get; private set; }

        /// <summary>
        /// Gets the launchTime.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DateTime LaunchTime { get; private set; }

        /// <summary>
        /// Gets the recent application controller.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RecentApplicationControl Controller { get; private set; }

        internal RecentApplicationInfo(Interop.ApplicationManager.RuaRec record) : base(Marshal.PtrToStringAnsi(record.pkgName))
        {
            InstanceId = Marshal.PtrToStringAnsi(record.instanceId);
            InstanceName = Marshal.PtrToStringAnsi(record.instanceName);
            Arg = Marshal.PtrToStringAnsi(record.arg);
            Uri = Marshal.PtrToStringAnsi(record.uri);
            long seconds = record.launchTime.ToInt64();
            LaunchTime = new DateTime(1970, 1, 1).AddSeconds(seconds);
            Controller = new RecentApplicationControl(Marshal.PtrToStringAnsi(record.pkgName));
        }
    }
}
