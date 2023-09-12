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
	public class CollisionAlgorithmConstructionInfo : BulletDisposableObject
	{
		private Dispatcher _dispatcher1;
		private PersistentManifold _manifold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionAlgorithmConstructionInfo()
		{
			IntPtr native = btCollisionAlgorithmConstructionInfo_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionAlgorithmConstructionInfo(Dispatcher dispatcher, int temp)
		{
			Native = btCollisionAlgorithmConstructionInfo_new2((dispatcher != null) ? dispatcher.Native : IntPtr.Zero,
				temp);
			_dispatcher1 = dispatcher;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Dispatcher Dispatcher
		{
			get => _dispatcher1;
			set
			{
				btCollisionAlgorithmConstructionInfo_setDispatcher1(Native, (value != null) ? value.Native : IntPtr.Zero);
				_dispatcher1 = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold Manifold
		{
			get => _manifold;
			set
			{
				btCollisionAlgorithmConstructionInfo_setManifold(Native, (value != null) ? value.Native : IntPtr.Zero);
				_manifold = value;
			}
		}

		protected override void Dispose(bool disposing)
		{
			btCollisionAlgorithmConstructionInfo_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CollisionAlgorithm : BulletDisposableObject
	{
		protected internal CollisionAlgorithm()
		{
		}

		internal CollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CalculateTimeOfImpact(CollisionObject body0, CollisionObject body1,
			DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			return btCollisionAlgorithm_calculateTimeOfImpact(Native, body0.Native,
				body1.Native, dispatchInfo.Native, resultOut.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAllContactManifolds(AlignedManifoldArray manifoldArray)
		{
			btCollisionAlgorithm_getAllContactManifolds(Native, manifoldArray.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessCollision(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap,
			DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			btCollisionAlgorithm_processCollision(Native, body0Wrap.Native, body1Wrap.Native,
				dispatchInfo.Native, resultOut.Native);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btCollisionAlgorithm_delete(Native);
			}
		}
	}
}
