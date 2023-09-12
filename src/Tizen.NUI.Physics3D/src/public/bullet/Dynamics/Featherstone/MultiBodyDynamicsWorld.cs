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

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class MultiBodyDynamicsWorld : DiscreteDynamicsWorld
	{
		private List<MultiBody> _bodies = new List<MultiBody>();
		private List<MultiBodyConstraint> _constraints = new List<MultiBodyConstraint>();

		protected internal MultiBodyDynamicsWorld()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyDynamicsWorld(Dispatcher dispatcher, BroadphaseInterface pairCache,
			MultiBodyConstraintSolver constraintSolver, CollisionConfiguration collisionConfiguration)
		{
			IntPtr native = btMultiBodyDynamicsWorld_new(dispatcher.Native, pairCache.Native,
				constraintSolver.Native, collisionConfiguration.Native);
			InitializeUserOwned(native);
			InitializeMembers(dispatcher, pairCache, constraintSolver);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddMultiBody(MultiBody body, int group = (int)CollisionFilterGroups.DefaultFilter,
			int mask = (int)CollisionFilterGroups.AllFilter)
		{
			btMultiBodyDynamicsWorld_addMultiBody(Native, body.Native, group,
				mask);
			_bodies.Add(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddMultiBodyConstraint(MultiBodyConstraint constraint)
		{
			btMultiBodyDynamicsWorld_addMultiBodyConstraint(Native, constraint.Native);
			_constraints.Add(constraint);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildIslands()
		{
			btMultiBodyDynamicsWorld_buildIslands(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearMultiBodyConstraintForces()
		{
			btMultiBodyDynamicsWorld_clearMultiBodyConstraintForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearMultiBodyForces()
		{
			btMultiBodyDynamicsWorld_clearMultiBodyForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DebugDrawMultiBodyConstraint(MultiBodyConstraint constraint)
		{
			btMultiBodyDynamicsWorld_debugDrawMultiBodyConstraint(Native, constraint.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ForwardKinematics()
		{
			btMultiBodyDynamicsWorld_forwardKinematics(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody GetMultiBody(int mbIndex)
		{
			return _bodies[mbIndex];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyConstraint GetMultiBodyConstraint(int constraintIndex)
		{
			return _constraints[constraintIndex];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IntegrateMultiBodyTransforms(float timeStep)
		{
			btMultiBodyDynamicsWorld_integrateMultiBodyTransforms(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IntegrateTransforms(float timeStep)
		{
			btMultiBodyDynamicsWorld_integrateTransforms(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictMultiBodyTransforms(float timeStep)
		{
			btMultiBodyDynamicsWorld_predictMultiBodyTransforms(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictUnconstraintMotion(float timeStep)
		{
			btMultiBodyDynamicsWorld_predictUnconstraintMotion(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveMultiBody(MultiBody body)
		{
			btMultiBodyDynamicsWorld_removeMultiBody(Native, body.Native);
			_bodies.Remove(body);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveMultiBodyConstraint(MultiBodyConstraint constraint)
		{
			btMultiBodyDynamicsWorld_removeMultiBodyConstraint(Native, constraint.Native);
			_constraints.Remove(constraint);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SolveExternalForces(ContactSolverInfo solverInfo)
		{
			btMultiBodyDynamicsWorld_solveExternalForces(Native, solverInfo.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SolveInternalConstraints(ContactSolverInfo solverInfo)
		{
			btMultiBodyDynamicsWorld_solveInternalConstraints(Native, solverInfo.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumMultibodies => _bodies.Count;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumMultiBodyConstraints => btMultiBodyDynamicsWorld_getNumMultiBodyConstraints(Native);
	}
}
