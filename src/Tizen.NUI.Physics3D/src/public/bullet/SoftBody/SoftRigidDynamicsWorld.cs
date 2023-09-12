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

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SoftRigidDynamicsWorld : DiscreteDynamicsWorld
	{
		private AlignedSoftBodyArray _softBodyArray;
		private SoftBodySolver _softBodySolver; // private ref passed to bodies during AddSoftBody
		private bool _ownsSolver;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftRigidDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache,
			ConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration,
			SoftBodySolver softBodySolver = null)
		{
			if (softBodySolver != null) {
				_softBodySolver = softBodySolver;
				_ownsSolver = false;
			} else {
				_softBodySolver = new DefaultSoftBodySolver();
				_ownsSolver = true;
			}

			IntPtr native = btSoftRigidDynamicsWorld_new(dispatcher.Native, pairCache.Native,
				(constraintSolver != null) ? constraintSolver.Native : IntPtr.Zero,
				collisionConfiguration.Native, _softBodySolver.Native);
			InitializeUserOwned(native);
			InitializeMembers(dispatcher, pairCache, constraintSolver);

			WorldInfo = new SoftBodyWorldInfo(btSoftRigidDynamicsWorld_getWorldInfo(Native), this)
			{
				Dispatcher = dispatcher,
				Broadphase = pairCache
			};
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body)
		{
			body.SoftBodySolver = _softBodySolver;
			CollisionObjectArray.Add(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
		{
			body.SoftBodySolver = _softBodySolver;
			CollisionObjectArray.Add(body, (int)collisionFilterGroup, (int)collisionFilterMask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body, int collisionFilterGroup, int collisionFilterMask)
		{
			body.SoftBodySolver = _softBodySolver;
			CollisionObjectArray.Add(body, collisionFilterGroup, collisionFilterMask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveSoftBody(SoftBody body)
		{
			CollisionObjectArray.Remove(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DrawFlags
		{
			get => btSoftRigidDynamicsWorld_getDrawFlags(Native);
			set => btSoftRigidDynamicsWorld_setDrawFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedSoftBodyArray SoftBodyArray
		{
			get
			{
				if (_softBodyArray == null)
				{
					_softBodyArray = new AlignedSoftBodyArray(btSoftRigidDynamicsWorld_getSoftBodyArray(Native));
				}
				return _softBodyArray;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodyWorldInfo WorldInfo { get; }

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_ownsSolver)
				{
					_softBodySolver.Dispose();
				}
			}
			base.Dispose(disposing);
		}
	}
}
