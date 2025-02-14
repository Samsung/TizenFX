/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

using SystemIO = System.IO;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides properties to retrieve information the service.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ServiceInfo
    {
        private const string MetadataUnitedServiceDll = "http://tizen.org/metadata/united-service/dll";
        private const string MetadataUnitedServiceId = "http://tizen.org/metadata/united-service/id";
        private const string MetadataUnitedServiceUseThread = "http://tizen.org/metadata/united-service/use-thread";
        private const string MetadataUnitedServiceClassName = "http://tizen.org/metadata/united-service/class-name";

        internal ServiceInfo(string packageId)
        {
            PackageId = packageId;
            Log.Warn("PackageId=" +  PackageId);
        }

        /// <summary>
        /// The package ID of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string PackageId { get; private set; }

        /// <summary>
        /// The name of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Name { get; private set; }

        /// <summary>
        /// The Id of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Id {  get; private set; }

        /// <summary>
        /// The resource type of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ResourceType { get; private set; }

        /// <summary>
        /// The resource version of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ResourceVersion {  get; private set; }

        /// <summary>
        /// The name of the dll file of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string DllFile {  get; private set; }

        /// <summary>
        /// The resource path of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ResourcePath { get; private set; }

        /// <summary>
        /// Check whether the service uses a thread or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public bool UseThread { get; private set; }

        /// <summary>
        /// The class name of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string ClassName { get; private set; }

        /// <summary>
        /// The metadata of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public IDictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// The assembly of the service.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public ServiceAssembly Assembly { get; internal set; }

        private static void SetName(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            string resourceType = info.ResourceType;
            info.Name = resourceType.Substring(resourceType.LastIndexOf('.') + 1);
        }

        private static void SetId(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            if (info.Metadata.TryGetValue(MetadataUnitedServiceId, out string id))
            {
                info.Id = id;
                Log.Info("Id=" + id);
            }
            else
            {
                Log.Error("Failed to get id");
            }
        }

        private static void SetClassName(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            if (info.Metadata.TryGetValue(MetadataUnitedServiceClassName, out string className))
            {
                info.ClassName = className;
                Log.Info("ClassName=" + className);
            }
            else
            {
                Log.Error("Failed to get class name");
            }
        }

        private static void SetUseThread(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            if (info.Metadata.TryGetValue(MetadataUnitedServiceUseThread, out string useThread))
            {
                info.UseThread = (useThread == "true") ? true : false;
            }
            else
            {
                info.UseThread = true;
            }
            Log.Info("UseThread=" + info.UseThread);
        }

        private static void SetResourcePath(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            info.ResourcePath = SystemIO.Path.GetDirectoryName(Application.Current.ApplicationInfo.ExecutablePath) + "/.res_mount/";
            if (!Directory.Exists(info.ResourcePath))
            {
                info.ResourcePath = SystemIO.Path.GetDirectoryName(Application.Current.ApplicationInfo.ExecutablePath) + "/";
            }
        }

        private static void SetDllFile(ServiceInfo info)
        {
            if (info == null)
            {
                return;
            }

            if (info.Metadata.TryGetValue(MetadataUnitedServiceDll, out string dllFile))
            {
                info.DllFile = dllFile;
                Log.Info("DllFile=" + info.DllFile);
            }
            else
            {
                Log.Error("Failed to find metadata. " + MetadataUnitedServiceDll);
            }
        }

        private static void SetMetadata(ServiceInfo info, IntPtr handle)
        {
            if (info == null || handle == IntPtr.Zero)
            {
                return;
            }

            Dictionary<string, string> metadata = new Dictionary<string, string>();
            int callback(string key, string value, IntPtr userData)
            {
                Log.Info("key=" + key + ", value=" + value);
                if (key.Length != 0)
                {
                    if (!metadata.ContainsKey(key))
                    {
                        metadata.Add(key, value);
                    }
                }
                return 0;
            }

            var errorCode = Interop.PackageManagerInfo.PackageInfoForeachMetadata(handle, callback, IntPtr.Zero);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to retrieve meatadata. error = " + errorCode);
            }

            info.Metadata = metadata;
        }

        private static void SetResourceVersion(ServiceInfo info, IntPtr handle)
        {
            if (info == null || handle == IntPtr.Zero)
            {
                return;
            }

            var errorCode = Interop.PackageManagerInfo.PackageInfoGetResourceVersion(handle, out IntPtr resourceVersionPtr);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get resource version. error = " + errorCode);
            }
            else
            {
                info.ResourceVersion = Marshal.PtrToStringAnsi(resourceVersionPtr);
            }
        }

        private static void SetResourceType(ServiceInfo info, IntPtr handle)
        {
            if (info == null || handle == IntPtr.Zero)
            {
                return;
            }

            var errorCode = Interop.PackageManagerInfo.PackageInfoGetResourceType(handle, out IntPtr resourceTypePtr);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get resource type. error = " + errorCode);
            }
            else
            {
                info.ResourceType = Marshal.PtrToStringAnsi(resourceTypePtr);
            }
        }

        /// <summary>
        /// Creates the information of the Service.
        /// </summary>
        /// <param name="packageId">The package ID of the service.</param>
        /// <returns>The information of the service.</returns>
        /// <since_tizen> 13 </since_tizen>
        public static ServiceInfo Create(string packageId) 
        {
            Interop.PackageManagerInfo.ErrorCode errorCode = Interop.PackageManagerInfo.PackageInfoGet(packageId, out IntPtr handle);
            if (errorCode != Interop.PackageManagerInfo.ErrorCode.None)
            {
                Log.Error("Failed to get package info. error = " + errorCode);
                return null;
            }

            ServiceInfo info = new ServiceInfo(packageId);
            SetResourceType(info, handle);
            SetResourceVersion(info, handle);
            SetMetadata(info, handle);
            SetDllFile(info);
            SetResourcePath(info);
            SetUseThread(info);
            SetClassName(info);
            SetId(info);
            SetName(info);
            info.Assembly = new ServiceAssembly(info.ResourcePath + info.DllFile);
            Interop.PackageManagerInfo.PackageInfoDestroy(handle);
            return info;
        }

    }
}