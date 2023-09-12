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
	public class DbvtProxy : BroadphaseProxy
	{
		internal DbvtProxy(IntPtr native)
			: base(native)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtNode Leaf
		{
			get
			{
				IntPtr ptr = btDbvtProxy_getLeaf(Native);
				return (ptr != IntPtr.Zero) ? new DbvtNode(ptr) : null;
			}
			set => btDbvtProxy_setLeaf(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		//public DbvtProxyPtrArray Links => btDbvtProxy_getLinks(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Stage
		{
			get => btDbvtProxy_getStage(Native);
			set => btDbvtProxy_setStage(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DbvtBroadphase : BroadphaseInterface
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtBroadphase(OverlappingPairCache pairCache = null)
		{
			IntPtr native = btDbvtBroadphase_new(pairCache?.Native ?? IntPtr.Zero);
			InitializeUserOwned(native);

			InitializeMembers(pairCache ?? new HashedOverlappingPairCache(
				btBroadphaseInterface_getOverlappingPairCache(Native), this));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void Benchmark(BroadphaseInterface broadphase)
		{
			btDbvtBroadphase_benchmark(broadphase.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Collide(Dispatcher dispatcher)
		{
			btDbvtBroadphase_collide(Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphaseProxy CreateProxy(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, int shapeType, IntPtr userPtr, int collisionFilterGroup, int collisionFilterMask, Dispatcher dispatcher)
		{
			return new DbvtProxy(btBroadphaseInterface_createProxy(Native, ref aabbMin, ref aabbMax, shapeType, userPtr, collisionFilterGroup, collisionFilterMask, dispatcher.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Optimize()
		{
			btDbvtBroadphase_optimize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PerformDeferredRemoval(Dispatcher dispatcher)
		{
			btDbvtBroadphase_performDeferredRemoval(Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAabbForceUpdateRef(BroadphaseProxy absproxy, ref global::System.Numerics.Vector3 aabbMin,
			ref global::System.Numerics.Vector3 aabbMax, Dispatcher __unnamed3)
		{
			btDbvtBroadphase_setAabbForceUpdate(Native, absproxy.Native, ref aabbMin,
				ref aabbMax, __unnamed3.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAabbForceUpdate(BroadphaseProxy absproxy, global::System.Numerics.Vector3 aabbMin,
		 	global::System.Numerics.Vector3 aabbMax, Dispatcher __unnamed3)
		{
			btDbvtBroadphase_setAabbForceUpdate(Native, absproxy.Native, ref aabbMin,
				ref aabbMax, __unnamed3.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CId
		{
			get => btDbvtBroadphase_getCid(Native);
			set => btDbvtBroadphase_setCid(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CUpdates
		{
			get => btDbvtBroadphase_getCupdates(Native);
			set => btDbvtBroadphase_setCupdates(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool DeferredCollide
		{
			get => btDbvtBroadphase_getDeferedcollide(Native);
			set => btDbvtBroadphase_setDeferedcollide(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DUpdates
		{
			get => btDbvtBroadphase_getDupdates(Native);
			set => btDbvtBroadphase_setDupdates(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FixedLeft
		{
			get => btDbvtBroadphase_getFixedleft(Native);
			set => btDbvtBroadphase_setFixedleft(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FUpdates
		{
			get => btDbvtBroadphase_getFupdates(Native);
			set => btDbvtBroadphase_setFupdates(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GId
		{
			get => btDbvtBroadphase_getGid(Native);
			set => btDbvtBroadphase_setGid(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedCleanup
		{
			get => btDbvtBroadphase_getNeedcleanup(Native);
			set => btDbvtBroadphase_setNeedcleanup(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NewPairs
		{
			get => btDbvtBroadphase_getNewpairs(Native);
			set => btDbvtBroadphase_setNewpairs(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlappingPairCache PairCache
		{
			get => OverlappingPairCache;
			set
			{
				_overlappingPairCache = value;
				btDbvtBroadphase_setPaircache(Native, value.Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PId
		{
			get => btDbvtBroadphase_getPid(Native);
			set => btDbvtBroadphase_setPid(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Prediction
		{
			get => btDbvtBroadphase_getPrediction(Native);
			set => btDbvtBroadphase_setPrediction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ReleasePairCache
		{
			get => btDbvtBroadphase_getReleasepaircache(Native);
			set => btDbvtBroadphase_setReleasepaircache(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DbvtArray Sets => new DbvtArray(btDbvtBroadphase_getSets(Native), 2);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int StageCurrent
		{
			get => btDbvtBroadphase_getStageCurrent(Native);
			set => btDbvtBroadphase_setStageCurrent(Native, value);
		}

		//public DbvtProxyPtrArray StageRoots => btDbvtBroadphase_getStageRoots(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint UpdatesCall
		{
			get => btDbvtBroadphase_getUpdates_call(Native);
			set => btDbvtBroadphase_setUpdates_call(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint UpdatesDone
		{
			get => btDbvtBroadphase_getUpdates_done(Native);
			set => btDbvtBroadphase_setUpdates_done(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpdatesRatio
		{
			get => btDbvtBroadphase_getUpdates_ratio(Native);
			set => btDbvtBroadphase_setUpdates_ratio(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float VelocityPrediction
		{
			get => btDbvtBroadphase_getVelocityPrediction(Native);
			set => btDbvtBroadphase_setVelocityPrediction(Native, value);
		}
	}
}
