/*
 * Copyright (c) 2013-2022 Andres Traks
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it freely,
 * subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not claim that you wrote the original software. If you use this software in a product, an acknowledgment in the product documentation would be appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System;
using System.ComponentModel;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PointCollector : DiscreteCollisionDetectorInterface.Result
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PointCollector()
		{
			IntPtr native = btPointCollector_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Distance
		{
			get => btPointCollector_getDistance(Native);
			set => btPointCollector_setDistance(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasResult
		{
			get => btPointCollector_getHasResult(Native);
			set => btPointCollector_setHasResult(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 NormalOnBInWorld
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btPointCollector_getNormalOnBInWorld(Native, out value);
				return value;
			}
			set => btPointCollector_setNormalOnBInWorld(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PointInWorld
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btPointCollector_getPointInWorld(Native, out value);
				return value;
			}
			set => btPointCollector_setPointInWorld(Native, ref value);
		}
	}
}
