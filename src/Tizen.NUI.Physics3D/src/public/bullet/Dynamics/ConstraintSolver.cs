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
	public enum ConstraintSolverType
	{
		SequentialImpulse = 1,
		Mlcp = 2,
		Nncg = 4
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class ConstraintSolver : BulletDisposableObject
	{
		protected internal ConstraintSolver()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AllSolved(ContactSolverInfo __unnamed0, DebugDraw __unnamed1)
		{
			btConstraintSolver_allSolved(Native, __unnamed0.Native, __unnamed1 != null ? __unnamed1.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PrepareSolve(int __unnamed0, int __unnamed1)
		{
			btConstraintSolver_prepareSolve(Native, __unnamed0, __unnamed1);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btConstraintSolver_reset(Native);
		}
		/*
		public float SolveGroup(CollisionObject bodies, int numBodies, PersistentManifold manifold,
			int numManifolds, TypedConstraint constraints, int numConstraints, ContactSolverInfo info,
			IDebugDraw debugDrawer, Dispatcher dispatcher)
		{
			return btConstraintSolver_solveGroup(Native, bodies._native, numBodies,
				manifold._native, numManifolds, constraints._native, numConstraints,
				info._native, DebugDraw.GetUnmanaged(debugDrawer), dispatcher._native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConstraintSolverType SolverType => btConstraintSolver_getSolverType(Native);

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btConstraintSolver_delete(Native);
			}
		}
	}
}
