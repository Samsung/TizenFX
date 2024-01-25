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

using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the cpu boosting flag.
    /// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
    public enum CpuBoostingFlag : int
	{
		/// <summary>
		/// The privilege reset on fork (or pthread_create)
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingRestOnFork = 0x01,
	}

	/// <summary>
    /// Enumeration for the cpu boosting level.
    /// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CpuBoostingLevel : int
	{
		/// <summary>
		/// The cpu boosting level (none).
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingLevelNone = 0,
		/// <summary>
		/// The cpu boosting level (strong).
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingLevelStrong = 1,
		/// <summary>
		/// The cpu boosting level (medium).
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingLevelMedium,
		/// <summary>
		/// The cpu boosting level (weak).
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingLevelWeak,
		/// <summary>
		/// The cpu boosting level.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		CpuBoostingLevelEnd,
	}
}
