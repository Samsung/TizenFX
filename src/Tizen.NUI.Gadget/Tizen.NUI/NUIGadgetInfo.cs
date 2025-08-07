/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Tizen.Applications;

using SystemIO = System.IO;

namespace Tizen.NUI
{
    /// <summary>
    /// This class provides properties to retrieve information the gadget.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NUIGadgetInfo
    {
        private const string MetadataUIGadgetDll = "http://tizen.org/metadata/ui-gadget/dll";
        private const string MetadataUIGadgetResourceDll = "http://tizen.org/metadata/ui-gadget/resource/dll";
        private const string MetadataUIGadgetResourceClassName = "http://tizen.org/metadata/ui-gadget/resource/class-name";

        internal NUIGadgetInfo(string packageId)
        {
            PackageId = packageId;
            Log.Warn("PackageId: " + PackageId);
        }

        /// <summary>
        /// Gets the package ID of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string PackageId { get; private set; }

        /// <summary>
        /// Gets the resource type of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string ResourceType { get; private set; }

        /// <summary>
        /// Gets the resource version of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string ResourceVersion { get; private set; }

        /// <summary>
        /// Gets the resource path of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string ResourcePath
        {
            get; private set;
        }

        /// <summary>
        /// Gets the gadget resource path of the gadget.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public string GadgetResourcePath
        {
            get; private set;
        }

        /// <summary>
        /// Gets the executable file of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public string ExecutableFile { get; internal set; }

        /// <summary>
        /// Gets the metadata of the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public IDictionary<string, string> Metadata { get; private set; }

        internal string ResourceFile { get; set; }

        internal string ResourceClassName { get; set; }

        /// <summary>
        /// Gets the assembly of the gadget.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public Assembly Assembly { get; internal set; }

        /// <summary>
        /// Gets the assembly of the gadget.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public NUIGadgetAssembly NUIGadgetAssembly { get; set; }

        private static void SetGadgetResourcePath(NUIGadgetInfo info)
        {
            info.GadgetResourcePath = info.ResourcePath + info.ResourceType + "/";
            if (!Directory.Exists(info.GadgetResourcePath))
            {
                info.GadgetResourcePath = info.ResourcePath;
            }
        }

        private static void SetResourcePath(NUIGadgetInfo info)
        {
            info.ResourcePath = SystemIO.Path.GetDirectoryName(Application.Current.ApplicationInfo.ExecutablePath) + "/.res_mount/gadget/";
            if (!Directory.Exists(info.ResourcePath))
            {
                info.ResourcePath = SystemIO.Path.GetDirectoryName(Application.Current.ApplicationInfo.ExecutablePath) + "/.res_mount/";
                if (!Directory.Exists(info.ResourcePath))
                {
                    info.ResourcePath = SystemIO.Path.GetDirectoryName(Application.Current.ApplicationInfo.ExecutablePath) + "/";
                }
            }
        }

        private static void SetResourceClassName(NUIGadgetInfo info)
        {
            if (info.Metadata.TryGetValue(MetadataUIGadgetResourceClassName, out string resourceClassName))
            {
                info.ResourceClassName = resourceClassName;
                Log.Info("LocaleClassName: " + info.ResourceClassName);
            }
            else
            {
                Log.Warn("There is no locale class");
            }
        }

        private static void SetResourceFile(NUIGadgetInfo info)
        {
            if (info.Metadata.TryGetValue(MetadataUIGadgetResourceDll, out string resourceFile))
            {
                info.ResourceFile = resourceFile;
                Log.Info("LocaleFile: " + info.ResourceFile);
            }
            else
            {
                Log.Warn("There is no locale dll");
            }
        }

        private static void SetExecutableFile(NUIGadgetInfo info)
        {
            if (info.Metadata.TryGetValue(MetadataUIGadgetDll, out string executableFile))
            {
                info.ExecutableFile = executableFile;
                Log.Info("ExecutableFile: " + info.ExecutableFile);
            }
            else
            {
                Log.Error("Failed to find metadata. " + MetadataUIGadgetDll);
            }
        }

        private static void SetMetadata(NUIGadgetInfo info, IntPtr handle)
        {
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            int callback(string key, string value, IntPtr userData)
            {
                Log.Info("key: " + key + ", value: " + value);
                if (key.Length != 0)
                {
                    if (!metadata.ContainsKey(key))
                    {
                        metadata.Add(key, value);
                    }
                }
                return 0;
            }

            Interop.PackageManagerInfo.ErrorCode errorCode = Interop.PackageManagerInfo.PackageInfoForeachMetadata(handle, callback, IntPtr.Zero);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to retrieve meatadata. error = " + errorCode);
            }

            info.Metadata = metadata;
        }

        private static void SetResourceVersion(NUIGadgetInfo info, IntPtr handle)
        {
            Interop.PackageManagerInfo.ErrorCode errorCode = Interop.PackageManagerInfo.PackageInfoGetResourceVersion(handle, out IntPtr resourceVersionPtr);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get resource version. error = " + errorCode);
            }
            else
            {
                info.ResourceVersion = Marshal.PtrToStringAnsi(resourceVersionPtr);
            }
        }

        private static void SetResourceType(NUIGadgetInfo info, IntPtr handle)
        {
            Interop.PackageManagerInfo.ErrorCode errorCode = Interop.PackageManagerInfo.PackageInfoGetResourceType(handle, out IntPtr resourceTypePtr);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get resource type. error = " + errorCode);
            }
            else
            {
                info.ResourceType = Marshal.PtrToStringAnsi(resourceTypePtr);
            }
        }

        internal static NUIGadgetInfo CreateNUIGadgetInfo(string packageId)
        {
            Interop.PackageManagerInfo.ErrorCode errorCode = Interop.PackageManagerInfo.PackageInfoGet(packageId, out IntPtr handle);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get package info. error = " + errorCode);
                return null;
            }

            NUIGadgetInfo info = new NUIGadgetInfo(packageId);

            SetResourceType(info, handle);
            SetResourceVersion(info, handle);
            SetMetadata(info, handle);

            errorCode = Interop.PackageManagerInfo.PackageInfoDestroy(handle);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Warn("Failed to destroy package info. error = " + errorCode);
            }

            SetExecutableFile(info);
            SetResourceFile(info);
            SetResourceClassName(info);
            SetResourcePath(info);
            SetGadgetResourcePath(info);
            return info;
        }
    }
}
