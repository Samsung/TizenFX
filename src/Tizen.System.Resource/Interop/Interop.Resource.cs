/*
 * Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Resource
    {
		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_set_cpu_boosting", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceSetCpuBoosting (ResourcePidInfo pid, CpuBoostingLevel level, CpuBoostingFlag flags, int timeoutMsec);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_clear_cpu_boosting", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceClearCpuBoosting (ResourcePidInfo pid);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_get_cpu_boosting_level", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceGetCpuBoostingLevel (ResourcePidInfo pid, out CpuBoostingLevelInfo level);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_set_cpu_inheritance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceSetCpuInheritance (int sourceTid, string destProcess, int timeoutMsec);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_clear_cpu_inheritance", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceClearCpuInheritance (int sourceTid, string destProcess);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_register_cpu_inheritance_destination", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceRegisterCpuInheritanceDestination (string destProcess, ResourcePidInfo pid);

		[DllImport("libcapi-system-resource.so.1", EntryPoint = "resource_unregister_cpu_inheritance_destination", CallingConvention = CallingConvention.Cdecl)]
		internal static extern ResourceError ResourceUnregisterCpuInheritanceDestination (string destProcess);
	}
}
