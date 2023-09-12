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
	public class SphereBoxCollisionAlgorithm : ActivatingCollisionAlgorithm
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class CreateFunc : CollisionAlgorithmCreateFunc
		{
			internal CreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
				InitializeSubObject(native, owner);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CreateFunc()
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btSphereBoxCollisionAlgorithm_CreateFunc_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0, CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new SphereBoxCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}
		}

		internal SphereBoxCollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SphereBoxCollisionAlgorithm(PersistentManifold mf, CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, bool isSwapped)
		{
			IntPtr native = btSphereBoxCollisionAlgorithm_new(mf.Native, ci.Native, body0Wrap.Native,
				body1Wrap.Native, isSwapped);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GetSphereDistanceRef(CollisionObjectWrapper boxObjWrap, out global::System.Numerics.Vector3 v3PointOnBox,
			out global::System.Numerics.Vector3 normal, out float penetrationDepth, global::System.Numerics.Vector3 v3SphereCenter,
			float fRadius, float maxContactDistance)
		{
			return btSphereBoxCollisionAlgorithm_getSphereDistance(Native, boxObjWrap.Native,
				out v3PointOnBox, out normal, out penetrationDepth, ref v3SphereCenter,
				fRadius, maxContactDistance);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GetSphereDistance(CollisionObjectWrapper boxObjWrap, out global::System.Numerics.Vector3 v3PointOnBox,
			out global::System.Numerics.Vector3 normal, out float penetrationDepth, global::System.Numerics.Vector3 v3SphereCenter,
			float fRadius, float maxContactDistance)
		{
			return btSphereBoxCollisionAlgorithm_getSphereDistance(Native, boxObjWrap.Native,
				out v3PointOnBox, out normal, out penetrationDepth, ref v3SphereCenter,
				fRadius, maxContactDistance);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetSpherePenetrationRef(ref global::System.Numerics.Vector3 boxHalfExtent, ref global::System.Numerics.Vector3 sphereRelPos,
			out global::System.Numerics.Vector3 closestPoint, out global::System.Numerics.Vector3 normal)
		{
			return btSphereBoxCollisionAlgorithm_getSpherePenetration(Native, ref boxHalfExtent,
				ref sphereRelPos, out closestPoint, out normal);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetSpherePenetration(global::System.Numerics.Vector3 boxHalfExtent, global::System.Numerics.Vector3 sphereRelPos,
			out global::System.Numerics.Vector3 closestPoint, out global::System.Numerics.Vector3 normal)
		{
			return btSphereBoxCollisionAlgorithm_getSpherePenetration(Native, ref boxHalfExtent,
				ref sphereRelPos, out closestPoint, out normal);
		}
	}
}
