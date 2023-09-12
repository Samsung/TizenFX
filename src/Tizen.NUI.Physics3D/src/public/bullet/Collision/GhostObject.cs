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
	public class GhostObject : CollisionObject
	{
		AlignedCollisionObjectArray _overlappingPairs;

		internal GhostObject(ConstructionInfo info)
			: base(info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GhostObject()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btGhostObject_new();
			InitializeCollisionObject(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddOverlappingObjectInternal(BroadphaseProxy otherProxy, BroadphaseProxy thisProxy = null)
		{
			btGhostObject_addOverlappingObjectInternal(Native, otherProxy.Native,
				(thisProxy != null) ? thisProxy.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ConvexSweepTestRef(ConvexShape castShape, ref Matrix4x4 convexFromWorld,
			ref Matrix4x4 convexToWorld, ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btGhostObject_convexSweepTest(Native, castShape.Native, ref convexFromWorld,
				ref convexToWorld, resultCallback.Native, allowedCcdPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ConvexSweepTest(ConvexShape castShape, Matrix4x4 convexFromWorld,
			Matrix4x4 convexToWorld, ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btGhostObject_convexSweepTest(Native, castShape.Native, ref convexFromWorld,
				ref convexToWorld, resultCallback.Native, allowedCcdPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject GetOverlappingObject(int index)
		{
			return GetManaged(btGhostObject_getOverlappingObject(
				Native, index));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTestRef(ref global::System.Numerics.Vector3 rayFromWorld, ref global::System.Numerics.Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btGhostObject_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTest(global::System.Numerics.Vector3 rayFromWorld, global::System.Numerics.Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btGhostObject_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveOverlappingObjectInternal(BroadphaseProxy otherProxy, Dispatcher dispatcher,
			BroadphaseProxy thisProxy = null)
		{
			btGhostObject_removeOverlappingObjectInternal(Native, otherProxy.Native,
				dispatcher.Native, (thisProxy != null) ? thisProxy.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static GhostObject Upcast(CollisionObject colObj)
		{
			return GetManaged(btGhostObject_upcast(colObj.Native)) as GhostObject;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumOverlappingObjects => btGhostObject_getNumOverlappingObjects(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedCollisionObjectArray OverlappingPairs
		{
			get
			{
				if (_overlappingPairs == null)
				{
					_overlappingPairs = new AlignedCollisionObjectArray(btGhostObject_getOverlappingPairs(Native));
				}
				return _overlappingPairs;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PairCachingGhostObject : GhostObject
	{
		HashedOverlappingPairCache _overlappingPairCache;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PairCachingGhostObject()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btPairCachingGhostObject_new();
			InitializeCollisionObject(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HashedOverlappingPairCache OverlappingPairCache
		{
			get
			{
				if (_overlappingPairCache == null)
				{
					_overlappingPairCache = new HashedOverlappingPairCache(btPairCachingGhostObject_getOverlappingPairCache(Native), this);
				}
				return _overlappingPairCache;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class GhostPairCallback : OverlappingPairCallback
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GhostPairCallback()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btGhostPairCallback_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return new BroadphasePair(btOverlappingPairCallback_addOverlappingPair(Native, proxy0.Native,
				proxy1.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IntPtr RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1, Dispatcher dispatcher)
		{
			return btOverlappingPairCallback_removeOverlappingPair(Native, proxy0.Native,
				proxy1.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,
			Dispatcher dispatcher)
		{
			btOverlappingPairCallback_removeOverlappingPairsContainingProxy(Native, proxy0.Native,
				dispatcher.Native);
		}
	}
}
