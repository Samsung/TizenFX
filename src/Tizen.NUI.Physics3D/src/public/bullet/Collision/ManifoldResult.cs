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
	public class ManifoldResult : DiscreteCollisionDetectorInterface.Result
	{
		internal ManifoldResult(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldResult()
		{
			IntPtr native = btManifoldResult_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldResult(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
		{
			IntPtr native = btManifoldResult_new2(body0Wrap.Native, body1Wrap.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float CalculateCombinedContactDamping(CollisionObject body0,
			CollisionObject body1)
		{
			return btManifoldResult_calculateCombinedContactDamping(body0.Native,
				body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float CalculateCombinedContactStiffness(CollisionObject body0,
			CollisionObject body1)
		{
			return btManifoldResult_calculateCombinedContactStiffness(body0.Native,
				body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float CalculateCombinedFriction(CollisionObject body0, CollisionObject body1)
		{
			return btManifoldResult_calculateCombinedFriction(body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float CalculateCombinedRestitution(CollisionObject body0, CollisionObject body1)
		{
			return btManifoldResult_calculateCombinedRestitution(body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float CalculateCombinedRollingFriction(CollisionObject body0,
			CollisionObject body1)
		{
			return btManifoldResult_calculateCombinedRollingFriction(body0.Native,
				body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefreshContactPoints()
		{
			btManifoldResult_refreshContactPoints(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject Body0Internal => CollisionObject.GetManaged(btManifoldResult_getBody0Internal(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectWrapper Body0Wrap
		{
			get => new CollisionObjectWrapper(btManifoldResult_getBody0Wrap(Native));
			set => btManifoldResult_setBody0Wrap(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject Body1Internal => CollisionObject.GetManaged(btManifoldResult_getBody1Internal(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectWrapper Body1Wrap
		{
			get => new CollisionObjectWrapper(btManifoldResult_getBody1Wrap(Native));
			set => btManifoldResult_setBody1Wrap(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ClosestPointDistanceThreshold
		{
			get => btManifoldResult_getClosestPointDistanceThreshold(Native);
			set => btManifoldResult_setClosestPointDistanceThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold PersistentManifold
		{
			get => new PersistentManifold(btManifoldResult_getPersistentManifold(Native), this);
			set => btManifoldResult_setPersistentManifold(Native, value.Native);
		}
	}
}
