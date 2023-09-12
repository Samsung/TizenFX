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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet.SoftBody
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DeformableMultiBodyDynamicsWorld : MultiBodyDynamicsWorld
	{
		private DeformableBodySolver _deformableBodySolver; // private ref passed to bodies during AddSoftBody
		private HashSet<DeformableLagrangianForce> _forces = new HashSet<DeformableLagrangianForce>();

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DeformableMultiBodyDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache,
			DeformableMultiBodyConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration,
			DeformableBodySolver deformableBodySolver)
		{
			_deformableBodySolver = deformableBodySolver;

			IntPtr native = btDeformableMultiBodyDynamicsWorld_new(dispatcher.Native, pairCache.Native,
				constraintSolver.Native, collisionConfiguration.Native, deformableBodySolver.Native);
			InitializeUserOwned(native);
			InitializeMembers(dispatcher, pairCache, constraintSolver);

			WorldInfo = new SoftBodyWorldInfo(btDeformableMultiBodyDynamicsWorld_getWorldInfo(Native), this)
			{
				Dispatcher = dispatcher,
				Broadphase = pairCache
			};
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodyWorldInfo WorldInfo { get; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddForce(SoftBody psb, DeformableLagrangianForce force)
		{
			btDeformableMultiBodyDynamicsWorld_addForce(Native, psb.Native, force.Native);
			_forces.Add(force);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body)
		{
			AddSoftBody(body, CollisionFilterGroups.DefaultFilter, CollisionFilterGroups.AllFilter);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
		{
			AddSoftBody(body, (int)collisionFilterGroup, (int)collisionFilterMask);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddSoftBody(SoftBody body, int collisionFilterGroup, int collisionFilterMask)
		{
			body.SoftBodySolver = _deformableBodySolver;
			CollisionObjectArray.Add(body, collisionFilterGroup, collisionFilterMask);
		}
	}
}
