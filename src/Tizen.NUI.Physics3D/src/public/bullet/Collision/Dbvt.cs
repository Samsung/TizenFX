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
	public class DbvtAabbMm : BulletObject
	{
		internal DbvtAabbMm(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Classify(global::System.Numerics.Vector3 n, float o, int s)
		{
			return btDbvtAabbMm_Classify(Native, ref n, o, s);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Contain(DbvtAabbMm a)
		{
			return btDbvtAabbMm_Contain(Native, a.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Expand(global::System.Numerics.Vector3 e)
		{
			btDbvtAabbMm_Expand(Native, ref e);
		}
		/*
		public static DbvtAabbMm FromCE(global::System.Numerics.Vector3 c, global::System.Numerics.Vector3 e)
		{
			return btDbvtAabbMm_FromCE(ref c, ref e);
		}

		public static DbvtAabbMm FromCR(global::System.Numerics.Vector3 c, float r)
		{
			return btDbvtAabbMm_FromCR(ref c, r);
		}

		public static DbvtAabbMm FromMM(global::System.Numerics.Vector3 mi, global::System.Numerics.Vector3 mx)
		{
			return btDbvtAabbMm_FromMM(ref mi, ref mx);
		}

		public static DbvtAabbMm FromPoints(global::System.Numerics.Vector3 ppts, int n)
		{
			return btDbvtAabbMm_FromPoints(ref ppts, n);
		}

		public static DbvtAabbMm FromPoints(global::System.Numerics.Vector3 pts, int n)
		{
			return btDbvtAabbMm_FromPoints2(ref pts, n);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ProjectMinimum(global::System.Numerics.Vector3 v, uint signs)
		{
			return btDbvtAabbMm_ProjectMinimum(Native, ref v, signs);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SignedExpand(global::System.Numerics.Vector3 e)
		{
			btDbvtAabbMm_SignedExpand(Native, ref e);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Center
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_Center(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Extents
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_Extents(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Lengths
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_Lengths(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Maxs
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_Maxs(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Mins
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_Mins(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TMaxs
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_tMaxs(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TMins
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btDbvtAabbMm_tMins(Native, out value);
				return value;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DbvtNode : BulletObject
	{
		internal DbvtNode(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}

			var objDbvt = obj as DbvtNode;
			if (objDbvt == null)
			{
				return false;
			}

			return Native == objDbvt.Native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode() => (int)Native;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNodePtrArray Childs
		{
			get
			{
				int childCount = IsLeaf ? 0 : 2;
				return new DbvtNodePtrArray(btDbvtNode_getChilds(Native), childCount);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtProxy Data
		{
			get
			{
				if (IsLeaf)
				{
					IntPtr ptr = btDbvtNode_getData(Native);
					return new DbvtProxy(ptr);
				}
				return null;
			}
			set => btDbvtNode_setData(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DataAsInt
		{
			get => btDbvtNode_getDataAsInt(Native);
			set => btDbvtNode_setDataAsInt(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsInternal => btDbvtNode_isinternal(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLeaf => btDbvtNode_isleaf(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Parent
		{
			get
			{
				IntPtr ptr = btDbvtNode_getParent(Native);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set => btDbvtNode_setParent(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtVolume Volume
		{
			get
			{
				IntPtr ptr = btDbvtNode_getVolume(Native);
				return (ptr != IntPtr.Zero) ? new DbvtVolume(ptr) : null;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DbvtVolume : DbvtAabbMm
	{
		internal DbvtVolume(IntPtr native)
			: base(native)
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Dbvt : BulletObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class IClone : BulletDisposableObject
		{
			public IClone()
			{
				IntPtr native = btDbvt_IClone_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void CloneLeaf(DbvtNode __unnamed0)
			{
				btDbvt_IClone_CloneLeaf(Native, __unnamed0.Native);
			}

			protected override void Dispose(bool disposing)
			{
				if (Native != IntPtr.Zero)
				{
					btDbvt_IClone_delete(Native);
					Native = IntPtr.Zero;
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public class ICollide : BulletDisposableObject
		{
			internal ICollide(ConstructionInfo info)
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public ICollide()
			{
				IntPtr native = btDbvt_ICollide_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public bool AllLeaves(DbvtNode __unnamed0)
			{
				return btDbvt_ICollide_AllLeaves(Native, __unnamed0.Native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public bool Descent(DbvtNode __unnamed0)
			{
				return btDbvt_ICollide_Descent(Native, __unnamed0.Native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Process(DbvtNode __unnamed0, DbvtNode __unnamed1)
			{
				btDbvt_ICollide_Process(Native, __unnamed0.Native, __unnamed1.Native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Process(DbvtNode __unnamed0)
			{
				btDbvt_ICollide_Process2(Native, __unnamed0.Native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Process(DbvtNode n, float __unnamed1)
			{
				btDbvt_ICollide_Process3(Native, n.Native, __unnamed1);
			}

			protected override void Dispose(bool disposing)
			{
				btDbvt_ICollide_delete(Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class IWriter : BulletDisposableObject
		{
			protected internal IWriter()
			{
				//IntPtr native = wrapper_new();
				//InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Prepare(DbvtNode root, int numnodes)
			{
				btDbvt_IWriter_Prepare(Native, root.Native, numnodes);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void WriteLeaf(DbvtNode __unnamed0, int index, int parent)
			{
				btDbvt_IWriter_WriteLeaf(Native, __unnamed0.Native, index, parent);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public void WriteNode(DbvtNode __unnamed0, int index, int parent, int child0,
				int child1)
			{
				btDbvt_IWriter_WriteNode(Native, __unnamed0.Native, index, parent,
					child0, child1);
			}

			protected override void Dispose(bool disposing)
			{
				btDbvt_IWriter_delete(Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public class StkNP : BulletDisposableObject
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			public StkNP(DbvtNode n, uint m)
			{
				IntPtr native = btDbvt_sStkNP_new(n.Native, m);
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int Mask
			{
				get => btDbvt_sStkNP_getMask(Native);
				set => btDbvt_sStkNP_setMask(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public DbvtNode Node
			{
				get
				{
					IntPtr ptr = btDbvt_sStkNP_getNode(Native);
					return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
				}
				set => btDbvt_sStkNP_setNode(Native, (value != null) ? value.Native : IntPtr.Zero);
			}

			protected override void Dispose(bool disposing)
			{
				btDbvt_sStkNP_delete(Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public class StkNps : BulletDisposableObject
		{
			public StkNps()
			{
				IntPtr native = btDbvt_sStkNPS_new();
				Initialize(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public StkNps(DbvtNode n, uint m, float v)
			{
				IntPtr native = btDbvt_sStkNPS_new2(n.Native, m, v);
				Initialize(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int Mask
			{
				get => btDbvt_sStkNPS_getMask(Native);
				set => btDbvt_sStkNPS_setMask(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public DbvtNode Node
			{
				get
				{
					IntPtr ptr = btDbvt_sStkNPS_getNode(Native);
					return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
				}
				set => btDbvt_sStkNPS_setNode(Native, (value != null) ? value.Native : IntPtr.Zero);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Value
			{
				get => btDbvt_sStkNPS_getValue(Native);
				set => btDbvt_sStkNPS_setValue(Native, value);
			}

			protected override void Dispose(bool disposing)
			{
				btDbvt_sStkNPS_delete(Native);
			}
		}

		internal Dbvt(IntPtr native)
		{
			Initialize(native);
		}
		/*
		public static int Allocate(AlignedIntArray ifree, AlignedStkNpsArray stock,
			StkNps value)
		{
			return btDbvt_allocate(ifree.Native, stock.Native, value.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Benchmark()
		{
			btDbvt_benchmark();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			btDbvt_clear(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clone(Dbvt dest)
		{
			btDbvt_clone(Native, dest.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clone(Dbvt dest, IClone iclone)
		{
			btDbvt_clone2(Native, dest.Native, iclone.Native);
		}
		/*
		public static void CollideKdop(DbvtNode root, global::System.Numerics.Vector3 normals, float offsets,
			int count, ICollide policy)
		{
			btDbvt_collideKDOP(root.Native, normals.Native, offsets.Native, count,
				policy.Native);
		}

		public static void CollideOcl(DbvtNode root, global::System.Numerics.Vector3 normals, float offsets,
		 	global::System.Numerics.Vector3 sortaxis, int count, ICollide policy)
		{
			btDbvt_collideOCL(root.Native, normals.Native, offsets.Native, ref sortaxis,
				count, policy.Native);
		}

		public static void CollideOcl(DbvtNode root, global::System.Numerics.Vector3 normals, float offsets,
		 	global::System.Numerics.Vector3 sortaxis, int count, ICollide policy, bool fullsort)
		{
			btDbvt_collideOCL2(root.Native, normals.Native, offsets.Native, ref sortaxis,
				count, policy.Native, fullsort);
		}

		public void CollideTT(DbvtNode root0, DbvtNode root1, ICollide policy)
		{
			btDbvt_collideTT(Native, root0.Native, root1.Native, policy.Native);
		}

		public void CollideTTPersistentStack(DbvtNode root0, DbvtNode root1, ICollide policy)
		{
			btDbvt_collideTTpersistentStack(Native, root0.Native, root1.Native,
				policy.Native);
		}

		public static void CollideTU(DbvtNode root, ICollide policy)
		{
			btDbvt_collideTU(root.Native, policy.Native);
		}

		public void CollideTV(DbvtNode root, DbvtVolume volume, ICollide policy)
		{
			btDbvt_collideTV(Native, root.Native, volume.Native, policy.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int CountLeaves(DbvtNode node)
		{
			return btDbvt_countLeaves(node.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Empty()
		{
			return btDbvt_empty(Native);
		}
		/*
		public static void EnumLeaves(DbvtNode root, ICollide policy)
		{
			btDbvt_enumLeaves(root.Native, policy.Native);
		}

		public static void EnumNodes(DbvtNode root, ICollide policy)
		{
			btDbvt_enumNodes(root.Native, policy.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}

			var objDbvt = obj as Dbvt;
			if (objDbvt == null)
			{
				return false;
			}

			return Native == objDbvt.Native;
		}
		/*
		public static void ExtractLeaves(DbvtNode node, AlignedDbvtNodeArray leaves)
		{
			btDbvt_extractLeaves(node.Native, leaves.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode() => (int)Native;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Insert(DbvtVolume box, IntPtr data)
		{
			return new DbvtNode(btDbvt_insert(Native, box.Native, data));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int MaxDepth(DbvtNode node)
		{
			return btDbvt_maxdepth(node.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Nearest(int[] i, StkNps a, float v, int l, int h)
		{
			return btDbvt_nearest(i, a.Native, v, l, h);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OptimizeBottomUp()
		{
			btDbvt_optimizeBottomUp(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OptimizeIncremental(int passes)
		{
			btDbvt_optimizeIncremental(Native, passes);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OptimizeTopDown()
		{
			btDbvt_optimizeTopDown(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void OptimizeTopDown(int buTreshold)
		{
			btDbvt_optimizeTopDown2(Native, buTreshold);
		}
		/*
		public static void RayTest(DbvtNode root, global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo,
			ICollide policy)
		{
			btDbvt_rayTest(root.Native, ref rayFrom, ref rayTo, policy.Native);
		}

		public void RayTestInternal(DbvtNode root, global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo,
		 	global::System.Numerics.Vector3 rayDirectionInverse, UIntArray signs, float lambdaMax, global::System.Numerics.Vector3 aabbMin,
		 	global::System.Numerics.Vector3 aabbMax, ICollide policy)
		{
			btDbvt_rayTestInternal2(Native, root.Native, ref rayFrom, ref rayTo,
				ref rayDirectionInverse, signs.Native, lambdaMax, ref aabbMin, ref aabbMax,
				policy.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Remove(DbvtNode leaf)
		{
			btDbvt_remove(Native, leaf.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Update(DbvtNode leaf, DbvtVolume volume)
		{
			btDbvt_update(Native, leaf.Native, volume.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Update(DbvtNode leaf)
		{
			btDbvt_update2(Native, leaf.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Update(DbvtNode leaf, int lookahead)
		{
			btDbvt_update3(Native, leaf.Native, lookahead);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Update(DbvtNode leaf, DbvtVolume volume, float margin)
		{
			return btDbvt_update4(Native, leaf.Native, volume.Native, margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Update(DbvtNode leaf, DbvtVolume volume, global::System.Numerics.Vector3 velocity)
		{
			return btDbvt_update5(Native, leaf.Native, volume.Native, ref velocity);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Update(DbvtNode leaf, DbvtVolume volume, global::System.Numerics.Vector3 velocity, float margin)
		{
			return btDbvt_update6(Native, leaf.Native, volume.Native, ref velocity,
				margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Write(IWriter iwriter)
		{
			btDbvt_write(Native, iwriter.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Free
		{
			get
			{
				IntPtr ptr = btDbvt_getFree(Native);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set => btDbvt_setFree(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Leaves
		{
			get => btDbvt_getLeaves(Native);
			set => btDbvt_setLeaves(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Lkhd
		{
			get => btDbvt_getLkhd(Native);
			set => btDbvt_setLkhd(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint Opath
		{
			get => btDbvt_getOpath(Native);
			set => btDbvt_setOpath(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Root
		{
			get
			{
				IntPtr ptr = btDbvt_getRoot(Native);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set => btDbvt_setRoot(Native, (value != null) ? value.Native : IntPtr.Zero);
		}
		/*
		public AlignedStkNNArray StkStack
		{
			get { return btDbvt_getStkStack(Native); }
		}
		*/
	}
}
