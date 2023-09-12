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
	public class GImpactPair : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactPair()
		{
			IntPtr native = GIM_PAIR_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactPair(GImpactPair pair)
		{
			IntPtr native = GIM_PAIR_new2(pair.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactPair(int index1, int index2)
		{
			IntPtr native = GIM_PAIR_new3(index1, index2);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index1
		{
			get => GIM_PAIR_getIndex1(Native);
			set => GIM_PAIR_setIndex1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index2
		{
			get => GIM_PAIR_getIndex2(Native);
			set => GIM_PAIR_setIndex2(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			GIM_PAIR_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PairSet : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public PairSet()
		{
			IntPtr native = btPairSet_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PushPair(int index1, int index2)
		{
			btPairSet_push_pair(Native, index1, index2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PushPairInv(int index1, int index2)
		{
			btPairSet_push_pair_inv(Native, index1, index2);
		}

		protected override void Dispose(bool disposing)
		{
			btPairSet_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GImpactBvhData : BulletDisposableObject
	{
		private Aabb _bound;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactBvhData()
		{
			IntPtr native = GIM_BVH_DATA_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb Bound
		{
			get => _bound ?? (_bound = new Aabb(GIM_BVH_DATA_getBound(Native), this));
			set
			{
				GIM_BVH_DATA_setBound(Native, value.Native);
				_bound = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Data
		{
			get => GIM_BVH_DATA_getData(Native);
			set => GIM_BVH_DATA_setData(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				GIM_BVH_DATA_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GimBvhTreeNode : BulletDisposableObject
	{
		private Aabb _bound;

		internal GimBvhTreeNode(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimBvhTreeNode()
		{
			IntPtr native = GIM_BVH_TREE_NODE_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb Bound
		{
			get => _bound ?? (_bound = new Aabb(GIM_BVH_TREE_NODE_getBound(Native), this));
			set
			{
				GIM_BVH_TREE_NODE_setBound(Native, value.Native);
				_bound = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DataIndex
		{
			get => GIM_BVH_TREE_NODE_getDataIndex(Native);
			set => GIM_BVH_TREE_NODE_setDataIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EscapeIndex
		{
			get => GIM_BVH_TREE_NODE_getEscapeIndex(Native);
			set => GIM_BVH_TREE_NODE_setEscapeIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode => GIM_BVH_TREE_NODE_isLeafNode(Native);

		protected override void Dispose(bool disposing)
		{
			GIM_BVH_TREE_NODE_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GimBvhDataArray
	{
		internal IntPtr Native;

		internal GimBvhDataArray(IntPtr native)
		{
			Native = native;
		}
		/*
		public GimBvhDataArray()
		{
			Native = GIM_BVH_DATA_ARRAY_new();
		}
		*/
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GimBvhTreeNodeArray
	{
		internal IntPtr Native;

		internal GimBvhTreeNodeArray(IntPtr native)
		{
			Native = native;
		}
		/*
		public GimBvhTreeNodeArray()
		{
			Native = GIM_BVH_TREE_NODE_ARRAY_new();
		}
		*/
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class BvhTree : BulletDisposableObject
	{
		internal BvhTree(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BvhTree()
		{
			IntPtr native = btBvhTree_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildTree(GimBvhDataArray primitiveBoxes)
		{
			btBvhTree_build_tree(Native, primitiveBoxes.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearNodes()
		{
			btBvhTree_clearNodes(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimBvhTreeNode GetNodePointer()
		{
			return new GimBvhTreeNode(btBvhTree_get_node_pointer(Native), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimBvhTreeNode GetNodePointer(int index)
		{
			return new GimBvhTreeNode(btBvhTree_get_node_pointer2(Native, index), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetEscapeNodeIndex(int nodeIndex)
		{
			return btBvhTree_getEscapeNodeIndex(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLeftNode(int nodeIndex)
		{
			return btBvhTree_getLeftNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeBound(int nodeIndex, Aabb bound)
		{
			btBvhTree_getNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodeData(int nodeIndex)
		{
			return btBvhTree_getNodeData(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetRightNode(int nodeIndex)
		{
			return btBvhTree_getRightNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode(int nodeIndex)
		{
			return btBvhTree_isLeafNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetNodeBound(int nodeIndex, Aabb bound)
		{
			btBvhTree_setNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NodeCount => btBvhTree_getNodeCount(Native);

		protected override void Dispose(bool disposing)
		{
			btBvhTree_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PrimitiveManagerBase : BulletDisposableObject
	{
		protected internal PrimitiveManagerBase(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		protected internal PrimitiveManagerBase()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPrimitiveBox(int primitiveIndex, Aabb primitiveBox)
		{
			btPrimitiveManagerBase_get_primitive_box(Native, primitiveIndex, primitiveBox.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetPrimitiveTriangle(int primitiveIndex, PrimitiveTriangle triangle)
		{
			btPrimitiveManagerBase_get_primitive_triangle(Native, primitiveIndex, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsTrimesh => btPrimitiveManagerBase_is_trimesh(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PrimitiveCount => btPrimitiveManagerBase_get_primitive_count(Native);

		protected override void Dispose(bool disposing)
		{
			btPrimitiveManagerBase_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GImpactBvh : BulletDisposableObject
	{
		private PrimitiveManagerBase _primitiveManager;
		private Aabb _globalBox;

		internal GImpactBvh(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactBvh()
		{
			IntPtr native = btGImpactBvh_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactBvh(PrimitiveManagerBase primitiveManager)
		{
			IntPtr native = btGImpactBvh_new2(primitiveManager.Native);
			InitializeUserOwned(native);
			_primitiveManager = primitiveManager;
		}
		/*
		public bool BoxQuery(Aabb box, AlignedIntArray collidedResults)
		{
			return btGImpactBvh_boxQuery(Native, box.Native, collidedResults.Native);
		}

		public bool BoxQueryTrans(Aabb box, Matrix transform, AlignedIntArray collidedResults)
		{
			return btGImpactBvh_boxQueryTrans(Native, box.Native, ref transform,
				collidedResults.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildSet()
		{
			btGImpactBvh_buildSet(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void FindCollision(GImpactBvh boxSet1, ref Matrix4x4 transform1, GImpactBvh boxSet2,
			ref Matrix4x4 transform2, PairSet collisionPairs)
		{
			btGImpactBvh_find_collision(boxSet1.Native, ref transform1, boxSet2.Native,
				ref transform2, collisionPairs.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GimBvhTreeNode GetNodePointer(int index = 0)
		{
			return new GimBvhTreeNode(btGImpactBvh_get_node_pointer(Native, index), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetEscapeNodeIndex(int nodeIndex)
		{
			return btGImpactBvh_getEscapeNodeIndex(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLeftNode(int nodeIndex)
		{
			return btGImpactBvh_getLeftNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeBound(int nodeIndex, Aabb bound)
		{
			btGImpactBvh_getNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetNodeData(int nodeIndex)
		{
			return btGImpactBvh_getNodeData(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetNodeTriangle(int nodeIndex, PrimitiveTriangle triangle)
		{
			btGImpactBvh_getNodeTriangle(Native, nodeIndex, triangle.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetRightNode(int nodeIndex)
		{
			return btGImpactBvh_getRightNode(Native, nodeIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeafNode(int nodeIndex)
		{
			return btGImpactBvh_isLeafNode(Native, nodeIndex);
		}
		/*
		public bool RayQuery(global::System.Numerics.Vector3 rayDir, global::System.Numerics.Vector3 rayOrigin, AlignedIntArray collidedResults)
		{
			return btGImpactBvh_rayQuery(Native, ref rayDir, ref rayOrigin, collidedResults.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetNodeBound(int nodeIndex, Aabb bound)
		{
			btGImpactBvh_setNodeBound(Native, nodeIndex, bound.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Update()
		{
			btGImpactBvh_update(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Aabb GlobalBox => _globalBox ?? (_globalBox = new Aabb(btGImpactBvh_getGlobalBox(Native), this));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasHierarchy => btGImpactBvh_hasHierarchy(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsTrimesh => btGImpactBvh_isTrimesh(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NodeCount => btGImpactBvh_getNodeCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PrimitiveManagerBase PrimitiveManager
		{
			get => _primitiveManager ?? (_primitiveManager = new PrimitiveManagerBase(btGImpactBvh_getPrimitiveManager(Native), this));
			set => btGImpactBvh_setPrimitiveManager(Native, value.Native);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btGImpactBvh_delete(Native);
			}
		}
	}
}
