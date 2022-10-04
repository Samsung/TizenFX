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
using System.ComponentModel;

namespace Tizen.System
{
	/// <summary>
	/// Provides methods to support CPU boosting and CPU inheritance.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Resource
	{
        /// <summary>
		/// Set cpu boosting for the target process (pid/tids).
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="pid">The target process pid/tids.</param>
		/// <param name="level">The cpu boosting level</param>
		/// <param name="flags">The cpu boosting flag bits</param>
		/// <param name="timeoutMsec">The timeout in milliseconds</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceSetCpuBoosting (ResourcePidInfo pid, CpuBoostingLevel level, CpuBoostingFlag flags, int timeoutMsec)
		{
			ResourceError ret = Interop.Resource.ResourceSetCpuBoosting(pid, level, flags, timeoutMsec);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to set cpu boosting");
				ResourceErrorFactory.ThrowException(ret);
			}
		}

		/// <summary>
		/// Clear cpu boosting for the boosted process (pid/tids).
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="pid">The target process pid/tids.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceClearCpuBoosting (ResourcePidInfo pid)
		{
			ResourceError ret = Interop.Resource.ResourceClearCpuBoosting(pid);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to clear cpu boosting");
				ResourceErrorFactory.ThrowException(ret);
			}
		}

		/// <summary>
		/// Get the cpu boosting level for the target process (pid/tids).
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="pid">The target process pid/tids.</param>
		/// <param name="level">The boosting level for the target process (pid/tids).</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceGetCpuBoostingLevel (ResourcePidInfo pid, out CpuBoostingLevelInfo level)
		{
			ResourceError ret = Interop.Resource.ResourceGetCpuBoostingLevel(pid, out level);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to get cpu boosting");
				ResourceErrorFactory.ThrowException(ret);
			}

			if (level.TidLevel == IntPtr.Zero) {
				Log.Error(ResourceErrorFactory.LogTag, "TidLevel cannot be zero");
				ResourceErrorFactory.ThrowException(ResourceError.InvalidParameter);
			}
		}

		/// <summary>
		/// Set cpu resource inheritance from the source tid to the destination process (pid/tids).
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="sourceTid">The caller thread tid.</param>
		/// <param name="destProcess">The name of destination process.</param>
		/// <param name="timeoutMsec">The timeout in milliceconds.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceSetCpuInheritance (int sourceTid, string destProcess, int timeoutMsec)
		{
			ResourceError ret = Interop.Resource.ResourceSetCpuInheritance(sourceTid, destProcess, timeoutMsec);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to set inheritance");
				ResourceErrorFactory.ThrowException(ret);
			}
		}

		/// <summary>
		/// Clear cpu resource inheritance from the source tid to the destination process (pid/tids).
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="sourceTid">The caller thread tid.</param>
		/// <param name="destProcess">The name of destination process.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceClearCpuInheritance (int sourceTid, string destProcess)
		{
			ResourceError ret = Interop.Resource.ResourceClearCpuInheritance(sourceTid, destProcess);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to clear inheritance");
				ResourceErrorFactory.ThrowException(ret);
			}
		}

		/// <summary>
		/// Register a destination process (pid/tids) for cpu resource inheritance.
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="destProcess">The name of destination process.</param>
		/// <param name="pid">The destination process pid/tids.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceRegisterCpuInheritanceDestination (string destProcess, ResourcePidInfo pid)
		{
			ResourceError ret = Interop.Resource.ResourceRegisterCpuInheritanceDestination(destProcess, pid);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to register destination");
				ResourceErrorFactory.ThrowException(ret);
			}
		}

		/// <summary>
		/// Unregister a destination process (pid/tids) for cpu resource inheritance.
        /// </summary>
		/// <privilege>
		/// http://tizen.org/privilege/internal/default/partner
		/// </privilege>
		/// <param name="destProcess">The name of destination process.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ResourceUnregisterCpuInheritanceDestination (string destProcess)
		{
			ResourceError ret = Interop.Resource.ResourceUnregisterCpuInheritanceDestination(destProcess);
			if (ret != ResourceError.None) {
				Log.Error(ResourceErrorFactory.LogTag, "Interop failed to unregister destination");
				ResourceErrorFactory.ThrowException(ret);
			}
		}
	}
}
