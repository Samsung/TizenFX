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

using System.Numerics;
using System;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactQuantizedBvhNode : BulletDisposableObject
	{
		internal GImpactQuantizedBvhNode(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactQuantizedBvhNode()
		{
			IntPtr native = BT_QUANTIZED_BVH_NODE_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestQuantizedBoxOverlapp(ushort[] quantizedMin, ushort[] quantizedMax)
		{
			return BT_QUANTIZED_BVH_NODE_testQuantizedBoxOverlapp(Native, quantizedMin, quantizedMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DataIndex
		{
			get => BT_QUANTIZED_BVH_NODE_getDataIndex(Native);
			set => BT_QUANTIZED_BVH_NODE_setDataIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndex
		{
			get => BT_QUANTIZED_BVH_NODE_getEscapeIndex(Native);
			set => BT_QUANTIZED_BVH_NODE_setEscapeIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndexOrDataIndex
		{
			get => BT_QUANTIZED_BVH_NODE_getEscapeIndexOrDataIndex(Native);
			set => BT_QUANTIZED_BVH_NODE_setEscapeIndexOrDataIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode => BT_QUANTIZED_BVH_NODE_isLeafNode(Native);
		/*
		public UShortArray QuantizedAabbMax
		{
			get => BT_QUANTIZED_BVH_NODE_getQuantizedAabbMax(Native);
		}

		public UShortArray QuantizedAabbMin
		{
			get => BT_QUANTIZED_BVH_NODE_getQuantizedAabbMin(Native);
		}
		*/

		protected override void Dispose(bool disposing)
		{
			BT_QUANTIZED_BVH_NODE_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactQuantizedBvhNodeArray : BulletObject
	{
		internal GImpactQuantizedBvhNodeArray(IntPtr native)
		{
			Initialize(native);
		}
		/*
		public GimGImpactQuantizedBvhNodeArray()
		{
			Native = GIM_QUANTIZED_BVH_NODE_ARRAY_new();
		}
		*/
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class QuantizedBvhTree : BulletDisposableObject
	{
		internal QuantizedBvhTree(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public QuantizedBvhTree()
		{
			IntPtr native = btQuantizedBvhTree_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildTree(GimBvhDataArray primitiveBoxes)
		{
			btQuantizedBvhTree_build_tree(Native, primitiveBoxes.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearNodes()
		{
			btQuantizedBvhTree_clearNodes(Native);
		}
		/*
		public GImpactQuantizedBvhNode GetNodePointer(int index = 0)
		{
			return btQuantizedBvhTree_get_node_pointer(Native, index);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetEscapeNodeIndex(int nodeIndex)
		{
			return btQuantizedBvhTree_getEscapeNodeIndex(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLeftNode(int nodeIndex)
		{
			return btQuantizedBvhTree_getLeftNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeBound(int nodeIndex, Aabb bound)
		{
			btQuantizedBvhTree_getNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodeData(int nodeIndex)
		{
			return btQuantizedBvhTree_getNodeData(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetRightNode(int nodeIndex)
		{
			return btQuantizedBvhTree_getRightNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode(int nodeIndex)
		{
			return btQuantizedBvhTree_isLeafNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void QuantizePoint(ushort[] quantizedpoint, global::System.Numerics.Vector3 point)
		{
			btQuantizedBvhTree_quantizePoint(Native, quantizedpoint, ref point);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetNodeBound(int nodeIndex, Aabb bound)
		{
			btQuantizedBvhTree_setNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestQuantizedBoxOverlap(int nodeIndex, ushort[] quantizedMin, ushort[] quantizedMax)
		{
			return btQuantizedBvhTree_testQuantizedBoxOverlapp(Native, nodeIndex, quantizedMin, quantizedMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NodeCount => btQuantizedBvhTree_getNodeCount(Native);

		protected override void Dispose(bool disposing)
		{
			btQuantizedBvhTree_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactQuantizedBvh : BulletDisposableObject
	{
		private Aabb _globalBox;

		private PrimitiveManagerBase _primitiveManager;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactQuantizedBvh()
		{
			IntPtr native = btGImpactQuantizedBvh_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactQuantizedBvh(PrimitiveManagerBase primitiveManager)
		{
			IntPtr native = btGImpactQuantizedBvh_new2(primitiveManager.Native);
			InitializeUserOwned(native);
			_primitiveManager = primitiveManager;
		}
		/*
		public bool BoxQuery(Aabb box, AlignedIntArray collidedResults)
		{
			return btGImpactQuantizedBvh_boxQuery(Native, box.Native, collidedResults.Native);
		}

		public bool BoxQueryTrans(Aabb box, Matrix transform, AlignedIntArray collidedResults)
		{
			return btGImpactQuantizedBvh_boxQueryTrans(Native, box.Native, ref transform,
				collidedResults.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildSet()
		{
			btGImpactQuantizedBvh_buildSet(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void FindCollision(GImpactQuantizedBvh boxset1, Matrix4x4 trans1,
			GImpactQuantizedBvh boxset2, Matrix4x4 trans2, PairSet collisionPairs)
		{
			btGImpactQuantizedBvh_find_collision(boxset1.Native, ref trans1, boxset2.Native,
				ref trans2, collisionPairs.Native);
		}
		/*
		public GImpactQuantizedBvhNode GetNodePointer(int index = 0)
		{
			return btGImpactQuantizedBvh_get_node_pointer(Native, index);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetEscapeNodeIndex(int nodeIndex)
		{
			return btGImpactQuantizedBvh_getEscapeNodeIndex(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLeftNode(int nodeIndex)
		{
			return btGImpactQuantizedBvh_getLeftNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeBound(int nodeIndex, Aabb bound)
		{
			btGImpactQuantizedBvh_getNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodeData(int nodeIndex)
		{
			return btGImpactQuantizedBvh_getNodeData(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeTriangle(int nodeIndex, PrimitiveTriangle triangle)
		{
			btGImpactQuantizedBvh_getNodeTriangle(Native, nodeIndex, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetRightNode(int nodeIndex)
		{
			return btGImpactQuantizedBvh_getRightNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode(int nodeIndex)
		{
			return btGImpactQuantizedBvh_isLeafNode(Native, nodeIndex);
		}
		/*
		public bool RayQuery(global::System.Numerics.Vector3 rayDir, global::System.Numerics.Vector3 rayOrigin, AlignedIntArray collidedResults)
		{
			return btGImpactQuantizedBvh_rayQuery(Native, ref rayDir, ref rayOrigin,
				collidedResults.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetNodeBound(int nodeIndex, Aabb bound)
		{
			btGImpactQuantizedBvh_setNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Update()
		{
			btGImpactQuantizedBvh_update(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb GlobalBox => _globalBox ?? (_globalBox = new Aabb(btGImpactQuantizedBvh_getGlobalBox(Native), this));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasHierarchy => btGImpactQuantizedBvh_hasHierarchy(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsTrimesh => btGImpactQuantizedBvh_isTrimesh(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NodeCount => btGImpactQuantizedBvh_getNodeCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PrimitiveManagerBase PrimitiveManager
		{
			get => _primitiveManager;
			set
			{
				btGImpactQuantizedBvh_setPrimitiveManager(Native, value.Native);
				_primitiveManager = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			btGImpactQuantizedBvh_delete(Native);
		}
	}
}
