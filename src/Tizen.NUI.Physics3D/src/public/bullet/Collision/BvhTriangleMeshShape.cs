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
	public class BvhTriangleMeshShape : TriangleMeshShape
	{
		private OptimizedBvh _optimizedBvh;
		private TriangleInfoMap _triangleInfoMap;

		protected internal BvhTriangleMeshShape()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BvhTriangleMeshShape(StridingMeshInterface meshInterface, bool useQuantizedAabbCompression,
			bool buildBvh = true)
		{
			IntPtr native = btBvhTriangleMeshShape_new(meshInterface.Native, useQuantizedAabbCompression,
				buildBvh);
			InitializeCollisionShape(native);
			InitializeMembers(meshInterface);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BvhTriangleMeshShape(StridingMeshInterface meshInterface, bool useQuantizedAabbCompression,
			global::System.Numerics.Vector3 bvhAabbMin, global::System.Numerics.Vector3 bvhAabbMax, bool buildBvh = true)
		{
			IntPtr native = btBvhTriangleMeshShape_new2(meshInterface.Native, useQuantizedAabbCompression,
				ref bvhAabbMin, ref bvhAabbMax, buildBvh);
			InitializeCollisionShape(native);
			InitializeMembers(meshInterface);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildOptimizedBvh()
		{
			btBvhTriangleMeshShape_buildOptimizedBvh(Native);
			_optimizedBvh = null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PartialRefitTreeRef(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax)
		{
			btBvhTriangleMeshShape_partialRefitTree(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PartialRefitTree(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btBvhTriangleMeshShape_partialRefitTree(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PerformConvexcast(TriangleCallback callback, global::System.Numerics.Vector3 boxSource,
		 	global::System.Numerics.Vector3 boxTarget, global::System.Numerics.Vector3 boxMin, global::System.Numerics.Vector3 boxMax)
		{
			btBvhTriangleMeshShape_performConvexcast(Native, callback.Native, ref boxSource,
				ref boxTarget, ref boxMin, ref boxMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PerformRaycast(TriangleCallback callback, global::System.Numerics.Vector3 raySource,
		 	global::System.Numerics.Vector3 rayTarget)
		{
			btBvhTriangleMeshShape_performRaycast(Native, callback.Native, ref raySource,
				ref rayTarget);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefitTreeRef(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax)
		{
			btBvhTriangleMeshShape_refitTree(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefitTree(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btBvhTriangleMeshShape_refitTree(Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetOptimizedBvh(OptimizedBvh bvh, global::System.Numerics.Vector3 localScaling)
		{
			global::System.Diagnostics.Debug.Assert(!OwnsBvh);
			btBvhTriangleMeshShape_setOptimizedBvh2(Native, (bvh != null) ? bvh.Native : IntPtr.Zero, ref localScaling);
			_optimizedBvh = bvh;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OptimizedBvh OptimizedBvh
		{
			get
			{
				if (_optimizedBvh == null && OwnsBvh)
				{
					IntPtr optimizedBvhPtr = btBvhTriangleMeshShape_getOptimizedBvh(Native);
					_optimizedBvh = new OptimizedBvh(optimizedBvhPtr, this);
				}
				return _optimizedBvh;
			}
			set
			{
				global::System.Diagnostics.Debug.Assert(!OwnsBvh);
				btBvhTriangleMeshShape_setOptimizedBvh(Native, (value != null) ? value.Native : IntPtr.Zero);
				_optimizedBvh = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool OwnsBvh => btBvhTriangleMeshShape_getOwnsBvh(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TriangleInfoMap TriangleInfoMap
		{
			get
			{
				if (_triangleInfoMap == null)
				{
					IntPtr triangleInfoMap = btBvhTriangleMeshShape_getTriangleInfoMap(Native);
					if (triangleInfoMap != IntPtr.Zero)
					{
						_triangleInfoMap = new TriangleInfoMap(triangleInfoMap, this);
					}
				}
				return _triangleInfoMap;
			}
			set
			{
				btBvhTriangleMeshShape_setTriangleInfoMap(Native, (value != null) ? value.Native : IntPtr.Zero);
				_triangleInfoMap = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UsesQuantizedAabbCompression => btBvhTriangleMeshShape_usesQuantizedAabbCompression(Native);
	}
}
