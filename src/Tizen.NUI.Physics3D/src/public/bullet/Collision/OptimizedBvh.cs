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
	public class OptimizedBvh : QuantizedBvh
	{
		internal OptimizedBvh(IntPtr native)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, this);
		}

		internal OptimizedBvh(IntPtr native, BulletObject owner)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OptimizedBvh()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btOptimizedBvh_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Build(StridingMeshInterface triangles, bool useQuantizedAabbCompression,
		 	global::System.Numerics.Vector3 bvhAabbMin, global::System.Numerics.Vector3 bvhAabbMax)
		{
			btOptimizedBvh_build(Native, triangles.Native, useQuantizedAabbCompression,
				ref bvhAabbMin, ref bvhAabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static OptimizedBvh DeSerializeInPlace(IntPtr alignedDataBuffer, uint dataBufferSize,
			bool swapEndian)
		{
			return new OptimizedBvh(btOptimizedBvh_deSerializeInPlace(alignedDataBuffer, dataBufferSize,
				swapEndian));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Refit(StridingMeshInterface triangles, global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btOptimizedBvh_refit(Native, triangles.Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefitPartial(StridingMeshInterface triangles, global::System.Numerics.Vector3 aabbMin,
		 	global::System.Numerics.Vector3 aabbMax)
		{
			btOptimizedBvh_refitPartial(Native, triangles.Native, ref aabbMin,
				ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SerializeInPlace(IntPtr alignedDataBuffer, uint dataBufferSize,
			bool swapEndian)
		{
			return btOptimizedBvh_serializeInPlace(Native, alignedDataBuffer, dataBufferSize,
				swapEndian);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateBvhNodes(StridingMeshInterface meshInterface, int firstNode,
			int endNode, int index)
		{
			btOptimizedBvh_updateBvhNodes(Native, meshInterface.Native, firstNode,
				endNode, index);
		}
	}
}
