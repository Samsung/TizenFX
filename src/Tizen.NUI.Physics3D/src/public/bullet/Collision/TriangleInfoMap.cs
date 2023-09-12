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
using System.Runtime.InteropServices;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleInfo : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleInfo()
		{
			IntPtr native = btTriangleInfo_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EdgeV0V1Angle
		{
			get => btTriangleInfo_getEdgeV0V1Angle(Native);
			set => btTriangleInfo_setEdgeV0V1Angle(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EdgeV1V2Angle
		{
			get => btTriangleInfo_getEdgeV1V2Angle(Native);
			set => btTriangleInfo_setEdgeV1V2Angle(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EdgeV2V0Angle
		{
			get => btTriangleInfo_getEdgeV2V0Angle(Native);
			set => btTriangleInfo_setEdgeV2V0Angle(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Flags
		{
			get => btTriangleInfo_getFlags(Native);
			set => btTriangleInfo_setFlags(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btTriangleInfo_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TriangleInfoMap : BulletDisposableObject
	{
		internal TriangleInfoMap(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleInfoMap()
		{
			IntPtr native = btTriangleInfoMap_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btTriangleInfoMap_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ConvexEpsilon
		{
			get => btTriangleInfoMap_getConvexEpsilon(Native);
			set => btTriangleInfoMap_setConvexEpsilon(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EdgeDistanceThreshold
		{
			get => btTriangleInfoMap_getEdgeDistanceThreshold(Native);
			set => btTriangleInfoMap_setEdgeDistanceThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EqualVertexThreshold
		{
			get => btTriangleInfoMap_getEqualVertexThreshold(Native);
			set => btTriangleInfoMap_setEqualVertexThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxEdgeAngleThreshold
		{
			get => btTriangleInfoMap_getMaxEdgeAngleThreshold(Native);
			set => btTriangleInfoMap_setMaxEdgeAngleThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float PlanarEpsilon
		{
			get => btTriangleInfoMap_getPlanarEpsilon(Native);
			set => btTriangleInfoMap_setPlanarEpsilon(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ZeroAreaThreshold
		{
			get => btTriangleInfoMap_getZeroAreaThreshold(Native);
			set => btTriangleInfoMap_setZeroAreaThreshold(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btTriangleInfoMap_delete(Native);
			}
		}
	}
}
