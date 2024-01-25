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
using System.Runtime.InteropServices;
using Tizen.Internals;

namespace Tizen.System
{
	/// <summary>
    /// The structure of the resource pid information.
    /// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[NativeStruct("resource_pid_t", Include="cpu-boosting-type.h", PkgConfig="capi-system-resource")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ResourcePidInfo
	{
		/// <summary>
		/// The process id of target.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Pid;
		/// <summary>
		/// The thread id list of target.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Tid;
		/// <summary>
		/// The number of target thread.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TidCount;
	}

	/// <summary>
    /// The structure of the cpu boosting leve information.
    /// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[NativeStruct("cpu_boosting_level_info_t", Include="cpu-boosting-type.h", PkgConfig="capi-system-resource")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CpuBoostingLevelInfo
	{
		/// <summary>
		/// The thread level list of target.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr TidLevel;
		/// <summary>
		/// The number of target thread.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TidCount;
	}
}
