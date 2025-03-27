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
#pragma warning disable CA1056
        public string Uri { get; private set; }
#pragma warning restore CA1056

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

        /// <summary>
        /// Gets the recent application package name.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string PackageName { get; private set; }
        /// <summary>
        /// Gets the recent application path.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ApplicationPath { get; private set; }

        /// <summary>
        /// Gets the recent icon path.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string IconPath { get; private set; }

        /// <summary>
        /// Gets the recent image path.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ImagePath { get; private set; }

        /// <summary>
        /// Gets the recent component id.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string CompId { get; private set; }

         internal RecentApplicationInfo(Interop.ApplicationManager.RuaRec record) : base(Marshal.PtrToStringAnsi(record.pkgName))
        {
            
            InstanceId = record.instanceId != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.instanceId) : string.Empty;
            InstanceName = record.instanceName != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.instanceName) : string.Empty;
            Arg = record.arg != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.arg) : string.Empty;
            Uri = record.uri != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.uri) : string.Empty;
            long seconds = record.launchTime.ToInt64();
            PackageName = record.pkgName != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.pkgName) : string.Empty;
            ApplicationPath = record.appPath != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.appPath) : string.Empty;
            IconPath = record.icon != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.icon) : string.Empty;
            ImagePath = record.image != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.image) : string.Empty;
            CompId = record.compId != IntPtr.Zero ? Marshal.PtrToStringAnsi(record.compId) : string.Empty;
            LaunchTime = new DateTime(1970, 1, 1).AddSeconds(seconds);
            
            Controller = new RecentApplicationControl(PackageName);
        }


    }
}
