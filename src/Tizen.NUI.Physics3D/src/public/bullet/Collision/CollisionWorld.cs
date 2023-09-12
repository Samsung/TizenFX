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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AllHitsRayResultCallback : RayResultCallback
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public AllHitsRayResultCallback(global::System.Numerics.Vector3 rayFromWorld, global::System.Numerics.Vector3 rayToWorld)
		{
			RayFromWorld = rayFromWorld;
			RayToWorld = rayToWorld;

			CollisionObjects = new List<CollisionObject>();
			HitFractions = new List<float>();
			HitNormalWorld = new List<global::System.Numerics.Vector3>();
			HitPointWorld = new List<global::System.Numerics.Vector3>();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace)
		{
			CollisionObject = rayResult.CollisionObject;
			CollisionObjects.Add(rayResult.CollisionObject);
			if (normalInWorldSpace)
			{
				HitNormalWorld.Add(rayResult.HitNormalLocal);
			}
			else
			{
				// need to transform normal into worldspace
				Matrix4x4 transform = CollisionObject.WorldTransform;
				HitNormalWorld.Add(global::System.Numerics.Vector3.Transform(rayResult.HitNormalLocal, transform.GetBasis()));
			}
			HitPointWorld.Add(global::System.Numerics.Vector3.Lerp(RayFromWorld, RayToWorld, rayResult.HitFraction));
			HitFractions.Add(rayResult.HitFraction);
			return ClosestHitFraction;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<CollisionObject> CollisionObjects { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<float> HitFractions { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<global::System.Numerics.Vector3> HitNormalWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<global::System.Numerics.Vector3> HitPointWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayFromWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayToWorld { get; set; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClosestConvexResultCallback : ConvexResultCallback
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ClosestConvexResultCallback()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ClosestConvexResultCallback(ref global::System.Numerics.Vector3 convexFromWorld, ref global::System.Numerics.Vector3 convexToWorld)
		{
			ConvexFromWorld = convexFromWorld;
			ConvexToWorld = convexToWorld;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override float AddSingleResult(ref LocalConvexResult convexResult, bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			Debug.Assert(convexResult.HitFraction <= ClosestHitFraction);

			ClosestHitFraction = convexResult.HitFraction;
			HitCollisionObject = convexResult.HitCollisionObject;
			if (normalInWorldSpace)
			{
				HitNormalWorld = convexResult.HitNormalLocal;
			}
			else
			{
				// need to transform normal into worldspace
				Matrix4x4 transform = HitCollisionObject.WorldTransform;
				HitNormalWorld = global::System.Numerics.Vector3.Transform(convexResult.HitNormalLocal, transform.GetBasis());
			}
			HitPointWorld = convexResult.HitPointLocal;
			return convexResult.HitFraction;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ConvexFromWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ConvexToWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject HitCollisionObject { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitNormalWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitPointWorld { get; set; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ClosestRayResultCallback : RayResultCallback
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ClosestRayResultCallback(ref global::System.Numerics.Vector3 rayFromWorld, ref global::System.Numerics.Vector3 rayToWorld)
		{
			RayFromWorld = rayFromWorld;
			RayToWorld = rayToWorld;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace)
		{
			//caller already does the filter on the m_closestHitFraction
			Debug.Assert(rayResult.HitFraction <= ClosestHitFraction);

			ClosestHitFraction = rayResult.HitFraction;
			CollisionObject = rayResult.CollisionObject;
			if (normalInWorldSpace)
			{
				HitNormalWorld = rayResult.HitNormalLocal;
			}
			else
			{
				// need to transform normal into worldspace
				Matrix4x4 transform = CollisionObject.WorldTransform;
				HitNormalWorld = global::System.Numerics.Vector3.Transform(rayResult.HitNormalLocal, transform.GetBasis());
			}
			HitPointWorld = global::System.Numerics.Vector3.Lerp(RayFromWorld, RayToWorld, rayResult.HitFraction);
			return rayResult.HitFraction;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayFromWorld { get; set; } //used to calculate hitPointWorld from hitFraction

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayToWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitNormalWorld { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitPointWorld { get; set; }
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ContactResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;
			IntPtr native = btCollisionWorld_ContactResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1)
		{
			return AddSingleResult(new ManifoldPoint(cp),
				new CollisionObjectWrapper(colObj0Wrap), partId0, index0,
				new CollisionObjectWrapper(colObj1Wrap), partId1, index1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract float AddSingleResult(ManifoldPoint cp, CollisionObjectWrapper colObj0Wrap, int partId0, int index0, CollisionObjectWrapper colObj1Wrap, int partId1, int index1);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ContactResultCallbackWrapper_needsCollision(Native, proxy0.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ClosestDistanceThreshold
		{
			get => btCollisionWorld_ContactResultCallback_getClosestDistanceThreshold(Native);
			set => btCollisionWorld_ContactResultCallback_setClosestDistanceThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterGroup
		{
			get => btCollisionWorld_ContactResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_ContactResultCallback_setCollisionFilterGroup(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterMask
		{
			get => btCollisionWorld_ContactResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_ContactResultCallback_setCollisionFilterMask(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_ContactResultCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ConvexResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr convexResult, bool normalInWorldSpace);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		protected ConvexResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;
			IntPtr native = btCollisionWorld_ConvexResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr convexResult, bool normalInWorldSpace)
		{
			var convexResultManaged = new LocalConvexResult(convexResult);
			return AddSingleResult(ref convexResultManaged, normalInWorldSpace);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract float AddSingleResult(ref LocalConvexResult convexResult, bool normalInWorldSpace);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_ConvexResultCallbackWrapper_needsCollision(Native,
				proxy0.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ClosestHitFraction
		{
			get => btCollisionWorld_ConvexResultCallback_getClosestHitFraction(Native);
			set => btCollisionWorld_ConvexResultCallback_setClosestHitFraction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterGroup
		{
			get => btCollisionWorld_ConvexResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_ConvexResultCallback_setCollisionFilterGroup(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterMask
		{
			get => btCollisionWorld_ConvexResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_ConvexResultCallback_setCollisionFilterMask(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasHit => btCollisionWorld_ConvexResultCallback_hasHit(Native);

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_ConvexResultCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct LocalConvexResult
	{
		private readonly IntPtr _native;
		private CollisionObject _hitCollisionObject;

		internal LocalConvexResult(IntPtr native)
		{
			_native = native;
			_hitCollisionObject = null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject HitCollisionObject
		{
			get
			{
				if (_hitCollisionObject == null)
				{
					_hitCollisionObject = CollisionObject.GetManaged(btCollisionWorld_LocalConvexResult_getHitCollisionObject(_native));
				}
				return _hitCollisionObject;
			}
			set
			{
				btCollisionWorld_LocalConvexResult_setHitCollisionObject(_native, value?.Native ?? IntPtr.Zero);
				_hitCollisionObject = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HitFraction
		{
			get => btCollisionWorld_LocalConvexResult_getHitFraction(_native);
			set => btCollisionWorld_LocalConvexResult_setHitFraction(_native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitNormalLocal
		{
			get
			{
				global::System.Numerics.Vector3 value;
				btCollisionWorld_LocalConvexResult_getHitNormalLocal(_native, out value);
				return value;
			}
			set => btCollisionWorld_LocalConvexResult_setHitNormalLocal(_native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitPointLocal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionWorld_LocalConvexResult_getHitPointLocal(_native, out value);
				return value;
			}
			set => btCollisionWorld_LocalConvexResult_setHitPointLocal(_native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LocalShapeInfo? LocalShapeInfo
		{
			get
			{
				IntPtr localShapeInfoPtr = btCollisionWorld_LocalConvexResult_getLocalShapeInfo(_native);
				return localShapeInfoPtr != IntPtr.Zero
					? new LocalShapeInfo?(new LocalShapeInfo(localShapeInfoPtr))
					: null;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct LocalRayResult
	{
		private readonly IntPtr _native;
		private CollisionObject _collisionObject;

		internal LocalRayResult(IntPtr native)
		{
			_native = native;
			_collisionObject = null;

		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject CollisionObject
		{
			get
			{
				if (_collisionObject == null)
				{
					_collisionObject = CollisionObject.GetManaged(btCollisionWorld_LocalRayResult_getCollisionObject(_native));
				}
				return _collisionObject;
			}
			set
			{
				btCollisionWorld_LocalRayResult_setCollisionObject(_native, value?.Native ?? IntPtr.Zero);
				_collisionObject = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HitFraction
		{
			get => btCollisionWorld_LocalRayResult_getHitFraction(_native);
			set => btCollisionWorld_LocalRayResult_setHitFraction(_native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 HitNormalLocal
		{
			get
			{
				 global::System.Numerics.Vector3 value;
				btCollisionWorld_LocalRayResult_getHitNormalLocal(_native, out value);
				return value;
			}
			set => btCollisionWorld_LocalRayResult_setHitNormalLocal(_native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LocalShapeInfo? LocalShapeInfo
		{
			get
			{
				IntPtr localShapeInfoPtr = btCollisionWorld_LocalRayResult_getLocalShapeInfo(_native);
				return localShapeInfoPtr != IntPtr.Zero
					? new LocalShapeInfo?(new LocalShapeInfo(localShapeInfoPtr))
					: null;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct LocalShapeInfo
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ShapePart;
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TriangleIndex;

		internal LocalShapeInfo(IntPtr native)
		{
			ShapePart = btCollisionWorld_LocalShapeInfo_getShapePart(native);
			TriangleIndex = btCollisionWorld_LocalShapeInfo_getTriangleIndex(native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class RayResultCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate float AddSingleResultUnmanagedDelegate(IntPtr rayResult, bool normalInWorldSpace);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedsCollisionUnmanagedDelegate(IntPtr proxy0);

		private readonly AddSingleResultUnmanagedDelegate _addSingleResult;
		private readonly NeedsCollisionUnmanagedDelegate _needsCollision;

		protected RayResultCallback()
		{
			_addSingleResult = AddSingleResultUnmanaged;
			_needsCollision = NeedsCollisionUnmanaged;

			IntPtr native = btCollisionWorld_RayResultCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_addSingleResult),
				Marshal.GetFunctionPointerForDelegate(_needsCollision));
			InitializeUserOwned(native);
		}

		private float AddSingleResultUnmanaged(IntPtr rayResult, bool normalInWorldSpace)
		{
			var localRayResult = new LocalRayResult(rayResult);
			return AddSingleResult(ref localRayResult, normalInWorldSpace);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract float AddSingleResult(ref LocalRayResult rayResult, bool normalInWorldSpace);

		private bool NeedsCollisionUnmanaged(IntPtr proxy0)
		{
			return NeedsCollision(BroadphaseProxy.GetManaged(proxy0));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool NeedsCollision(BroadphaseProxy proxy0)
		{
			return btCollisionWorld_RayResultCallbackWrapper_needsCollision(Native, proxy0.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ClosestHitFraction
		{
			get => btCollisionWorld_RayResultCallback_getClosestHitFraction(Native);
			set => btCollisionWorld_RayResultCallback_setClosestHitFraction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterGroup
		{
			get => btCollisionWorld_RayResultCallback_getCollisionFilterGroup(Native);
			set => btCollisionWorld_RayResultCallback_setCollisionFilterGroup(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterMask
		{
			get => btCollisionWorld_RayResultCallback_getCollisionFilterMask(Native);
			set => btCollisionWorld_RayResultCallback_setCollisionFilterMask(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject CollisionObject
		{
			get => CollisionObject.GetManaged(btCollisionWorld_RayResultCallback_getCollisionObject(Native));
			set => btCollisionWorld_RayResultCallback_setCollisionObject(Native, (value != null) ? value.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint Flags
		{
			get => btCollisionWorld_RayResultCallback_getFlags(Native);
			set => btCollisionWorld_RayResultCallback_setFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasHit => btCollisionWorld_RayResultCallback_hasHit(Native);

		protected override void Dispose(bool disposing)
		{
			btCollisionWorld_RayResultCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CollisionWorld : BulletDisposableObject
	{
		private DebugDraw _debugDrawer;
		private BroadphaseInterface _broadphase;
		private DispatcherInfo _dispatchInfo;

		protected internal CollisionWorld()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionWorld(Dispatcher dispatcher, BroadphaseInterface broadphasePairCache,
			CollisionConfiguration collisionConfiguration)
		{
			IntPtr native = btCollisionWorld_new(dispatcher.Native, broadphasePairCache.Native,
				collisionConfiguration.Native);
			InitializeUserOwned(native);
			InitializeMembers(dispatcher, broadphasePairCache);
		}

		protected internal void InitializeMembers(Dispatcher dispatcher, BroadphaseInterface broadphasePairCache)
		{
			Dispatcher = dispatcher;
			Broadphase = broadphasePairCache;
			CollisionObjectArray = new AlignedCollisionObjectArray(btCollisionWorld_getCollisionObjectArray(Native), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddCollisionObject(CollisionObject collisionObject)
		{
			CollisionObjectArray.Add(collisionObject);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup,
			CollisionFilterGroups collisionFilterMask)
		{
			CollisionObjectArray.Add(collisionObject, (int)collisionFilterGroup, (int)collisionFilterMask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddCollisionObject(CollisionObject collisionObject, int collisionFilterGroup,
			int collisionFilterMask)
		{
			CollisionObjectArray.Add(collisionObject, collisionFilterGroup, collisionFilterMask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ComputeOverlappingPairs()
		{
			btCollisionWorld_computeOverlappingPairs(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ContactPairTest(CollisionObject colObjA, CollisionObject colObjB,
			ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactPairTest(Native, colObjA.Native, colObjB.Native,
				resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ContactTest(CollisionObject colObj, ContactResultCallback resultCallback)
		{
			btCollisionWorld_contactTest(Native, colObj.Native, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ConvexSweepTestRef(ConvexShape castShape, ref Matrix4x4 from, ref Matrix4x4 to,
			ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btCollisionWorld_convexSweepTest(Native, castShape.Native, ref from, ref to, resultCallback.Native, allowedCcdPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ConvexSweepTest(ConvexShape castShape, Matrix4x4 from, Matrix4x4 to,
			ConvexResultCallback resultCallback, float allowedCcdPenetration = 0)
		{
			btCollisionWorld_convexSweepTest(Native, castShape.Native, ref from,
				ref to, resultCallback.Native, allowedCcdPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DebugDrawObjectRef(ref Matrix4x4 worldTransform, CollisionShape shape, ref global::System.Numerics.Vector3 color)
		{
			btCollisionWorld_debugDrawObject(Native, ref worldTransform, shape.Native, ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DebugDrawObject(Matrix4x4 worldTransform, CollisionShape shape,
		 	global::System.Numerics.Vector3 color)
		{
			btCollisionWorld_debugDrawObject(Native, ref worldTransform, shape.Native,
				ref color);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DebugDrawWorld()
		{
			btCollisionWorld_debugDrawWorld(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ObjectQuerySingleRef(ConvexShape castShape, ref Matrix4x4 rayFromTrans,
			ref Matrix4x4 rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape,
			ref Matrix4x4 colObjWorldTransform, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingle(castShape.Native, ref rayFromTrans,
				ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform,
				resultCallback.Native, allowedPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ObjectQuerySingle(ConvexShape castShape, Matrix4x4 rayFromTrans,
			Matrix4x4 rayToTrans, CollisionObject collisionObject, CollisionShape collisionShape,
			Matrix4x4 colObjWorldTransform, ConvexResultCallback resultCallback, float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingle(castShape.Native, ref rayFromTrans,
				ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform,
				resultCallback.Native, allowedPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ObjectQuerySingleInternalRef(ConvexShape castShape, ref Matrix4x4 convexFromTrans,
			ref Matrix4x4 convexToTrans, CollisionObjectWrapper colObjWrap, ConvexResultCallback resultCallback,
			float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingleInternal(castShape.Native, ref convexFromTrans,
				ref convexToTrans, colObjWrap.Native, resultCallback.Native, allowedPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void ObjectQuerySingleInternal(ConvexShape castShape, Matrix4x4 convexFromTrans,
			Matrix4x4 convexToTrans, CollisionObjectWrapper colObjWrap, ConvexResultCallback resultCallback,
			float allowedPenetration)
		{
			btCollisionWorld_objectQuerySingleInternal(castShape.Native, ref convexFromTrans,
				ref convexToTrans, colObjWrap.Native, resultCallback.Native, allowedPenetration);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PerformDiscreteCollisionDetection()
		{
			btCollisionWorld_performDiscreteCollisionDetection(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTestRef(ref global::System.Numerics.Vector3 rayFromWorld, ref global::System.Numerics.Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTest(global::System.Numerics.Vector3 rayFromWorld, global::System.Numerics.Vector3 rayToWorld, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTest(Native, ref rayFromWorld, ref rayToWorld, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RayTestSingleRef(ref Matrix4x4 rayFromTrans, ref Matrix4x4 rayToTrans,
			CollisionObject collisionObject, CollisionShape collisionShape, ref Matrix4x4 colObjWorldTransform,
			RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingle(ref rayFromTrans, ref rayToTrans, collisionObject.Native, collisionShape.Native, ref colObjWorldTransform, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RayTestSingle(Matrix4x4 rayFromTrans, Matrix4x4 rayToTrans,
			CollisionObject collisionObject, CollisionShape collisionShape, Matrix4x4 colObjWorldTransform,
			RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingle(ref rayFromTrans, ref rayToTrans, collisionObject.Native,
				collisionShape.Native, ref colObjWorldTransform, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RayTestSingleInternalRef(ref Matrix4x4 rayFromTrans, ref Matrix4x4 rayToTrans,
			CollisionObjectWrapper collisionObjectWrap, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingleInternal(ref rayFromTrans, ref rayToTrans,
				collisionObjectWrap.Native, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RayTestSingleInternal(Matrix4x4 rayFromTrans, Matrix4x4 rayToTrans,
			CollisionObjectWrapper collisionObjectWrap, RayResultCallback resultCallback)
		{
			btCollisionWorld_rayTestSingleInternal(ref rayFromTrans, ref rayToTrans,
				collisionObjectWrap.Native, resultCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveCollisionObject(CollisionObject collisionObject)
		{
			CollisionObjectArray.Remove(collisionObject);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateAabbs()
		{
			btCollisionWorld_updateAabbs(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateSingleAabb(CollisionObject colObj)
		{
			btCollisionWorld_updateSingleAabb(Native, colObj.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseInterface Broadphase
		{
			get => _broadphase;
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException(nameof(value));
				}

				btCollisionWorld_setBroadphase(Native, value.Native);
				_broadphase = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedCollisionObjectArray CollisionObjectArray { get; protected set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugDraw DebugDrawer
		{
			get => _debugDrawer;
			set
			{
				if (_debugDrawer != value)
				{
					_debugDrawer = value;
					btCollisionWorld_setDebugDrawer(Native, value != null ? value.Native : IntPtr.Zero);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dispatcher Dispatcher { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DispatcherInfo DispatchInfo
		{
			get
			{
				if (_dispatchInfo == null)
				{
					_dispatchInfo = new DispatcherInfo(btCollisionWorld_getDispatchInfo(Native));
				}
				return _dispatchInfo;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ForceUpdateAllAabbs
		{
			get => btCollisionWorld_getForceUpdateAllAabbs(Native);
			set => btCollisionWorld_setForceUpdateAllAabbs(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumCollisionObjects => btCollisionWorld_getNumCollisionObjects(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlappingPairCache PairCache => Broadphase.OverlappingPairCache;

		protected override void Dispose(bool disposing)
		{
			// The btCollisionWorld will try to clean up remaining objects from the
			// broadphase and the dispatcher. If either of them have been deleted and
			// there are objects in the world, then deleting the btCollisionWorld or 
			// removing the objects from the world will cause an AccessViolationException.
			if (CollisionObjectArray.Count != 0 && (_broadphase.IsDisposed || Dispatcher.IsDisposed))
			{
				if (disposing)
				{
					throw new Exception(
						"To ensure proper resource cleanup, " +
						"remove all objects from the world before disposing the world.");
				}
				else
				{
					// Do not throw an exception in the GC finalizer thread
				}
			}
			else
			{
				btCollisionWorld_delete(Native);
			}
		}
	}
}
