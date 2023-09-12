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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum DispatchFunc
	{
		Discrete = 1,
		Continuous
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum DispatcherQueryType
	{
		ContactPointAlgorithms = 1,
		ClosestPointAlgorithms = 2
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DispatcherInfo : BulletObject
	{
		internal DispatcherInfo(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AllowedCcdPenetration
		{
			get => btDispatcherInfo_getAllowedCcdPenetration(Native);
			set => btDispatcherInfo_setAllowedCcdPenetration(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ConvexConservativeDistanceThreshold
		{
			get => btDispatcherInfo_getConvexConservativeDistanceThreshold(Native);
			set => btDispatcherInfo_setConvexConservativeDistanceThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugDraw DebugDraw
		{
			get => DebugDraw.GetManaged(btDispatcherInfo_getDebugDraw(Native));
			set => btDispatcherInfo_setDebugDraw(Native, value != null ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool DeterministicOverlappingPairs
		{
			get => btDispatcherInfo_getDeterministicOverlappingPairs(Native);
			set => btDispatcherInfo_setDeterministicOverlappingPairs(Native, value);
		}


		[EditorBrowsable(EditorBrowsableState.Never)]
		public DispatchFunc DispatchFunc
		{
			get => btDispatcherInfo_getDispatchFunc(Native);
			set => btDispatcherInfo_setDispatchFunc(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableSatConvex
		{
			get => btDispatcherInfo_getEnableSatConvex(Native);
			set => btDispatcherInfo_setEnableSatConvex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableSpu
		{
			get => btDispatcherInfo_getEnableSPU(Native);
			set => btDispatcherInfo_setEnableSPU(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int StepCount
		{
			get => btDispatcherInfo_getStepCount(Native);
			set => btDispatcherInfo_setStepCount(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TimeOfImpact
		{
			get => btDispatcherInfo_getTimeOfImpact(Native);
			set => btDispatcherInfo_setTimeOfImpact(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TimeStep
		{
			get => btDispatcherInfo_getTimeStep(Native);
			set => btDispatcherInfo_setTimeStep(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseContinuous
		{
			get => btDispatcherInfo_getUseContinuous(Native);
			set => btDispatcherInfo_setUseContinuous(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseConvexConservativeDistanceUtil
		{
			get => btDispatcherInfo_getUseConvexConservativeDistanceUtil(Native);
			set => btDispatcherInfo_setUseConvexConservativeDistanceUtil(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseEpa
		{
			get => btDispatcherInfo_getUseEpa(Native);
			set => btDispatcherInfo_setUseEpa(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class Dispatcher : BulletDisposableObject
	{
		protected internal Dispatcher()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr AllocateCollisionAlgorithm(int size)
		{
			return btDispatcher_allocateCollisionAlgorithm(Native, size);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearManifold(PersistentManifold manifold)
		{
			btDispatcher_clearManifold(Native, manifold.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DispatchAllCollisionPairs(OverlappingPairCache pairCache, DispatcherInfo dispatchInfo,
			Dispatcher dispatcher)
		{
			btDispatcher_dispatchAllCollisionPairs(Native, pairCache.Native, dispatchInfo.Native,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionAlgorithm FindAlgorithm(CollisionObjectWrapper body0Wrap,
			CollisionObjectWrapper body1Wrap, PersistentManifold sharedManifold,
			DispatcherQueryType queryType)
		{
			return new CollisionAlgorithm(btDispatcher_findAlgorithm(Native, body0Wrap.Native, body1Wrap.Native,
				sharedManifold.Native, queryType), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FreeCollisionAlgorithm(IntPtr ptr)
		{
			btDispatcher_freeCollisionAlgorithm(Native, ptr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold GetManifoldByIndexInternal(int index)
		{
			return new PersistentManifold(btDispatcher_getManifoldByIndexInternal(Native, index), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold GetNewManifold(CollisionObject b0, CollisionObject b1)
		{
			return new PersistentManifold(btDispatcher_getNewManifold(Native, b0.Native, b1.Native), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsCollision(CollisionObject body0, CollisionObject body1)
		{
			return btDispatcher_needsCollision(Native, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsResponse(CollisionObject body0, CollisionObject body1)
		{
			return btDispatcher_needsResponse(Native, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReleaseManifold(PersistentManifold manifold)
		{
			btDispatcher_releaseManifold(Native, manifold.Native);
		}
		/*
		public PersistentManifold InternalManifoldPointer
		{
			get { return btDispatcher_getInternalManifoldPointer(Native); }
		}

		public PoolAllocator InternalManifoldPool
		{
			get { return btDispatcher_getInternalManifoldPool(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumManifolds => btDispatcher_getNumManifolds(Native);

		protected override void Dispose(bool disposing)
		{
			btDispatcher_delete(Native);
		}
	}
}
