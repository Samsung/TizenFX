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
	public class SequentialImpulseConstraintSolver : ConstraintSolver
	{
		internal SequentialImpulseConstraintSolver(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		internal SequentialImpulseConstraintSolver(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SequentialImpulseConstraintSolver()
		{
			IntPtr native = btSequentialImpulseConstraintSolver_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ulong BtRand2()
		{
			return btSequentialImpulseConstraintSolver_btRand2(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int BtRandInt2(int n)
		{
			return btSequentialImpulseConstraintSolver_btRandInt2(Native, n);
		}
/*
		public void SetConstraintRowSolverGeneric(SingleConstraintRowSolver rowSolver)
		{
			btSequentialImpulseConstraintSolver_setConstraintRowSolverGeneric(Native,
				rowSolver.Native);
		}

		public void SetConstraintRowSolverLowerLimit(SingleConstraintRowSolver rowSolver)
		{
			btSequentialImpulseConstraintSolver_setConstraintRowSolverLowerLimit(
				Native, rowSolver.Native);
		}

		public float SolveGroup(CollisionObject bodies, int numBodies, PersistentManifold manifold,
			int numManifolds, TypedConstraint constraints, int numConstraints, ContactSolverInfo info,
			IDebugDraw debugDrawer, Dispatcher dispatcher)
		{
			return btSequentialImpulseConstraintSolver_solveGroup(Native, bodies.Native,
				numBodies, manifold.Native, numManifolds, constraints.Native, numConstraints,
				info.Native, DebugDraw.GetUnmanaged(debugDrawer), dispatcher.Native);
		}

		public SingleConstraintRowSolver ActiveConstraintRowSolverGeneric
		{
			get { return btSequentialImpulseConstraintSolver_getActiveConstraintRowSolverGeneric(Native); }
		}

		public SingleConstraintRowSolver ActiveConstraintRowSolverLowerLimit
		{
			get { return btSequentialImpulseConstraintSolver_getActiveConstraintRowSolverLowerLimit(Native); }
		}
*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ulong RandSeed
		{
			get => btSequentialImpulseConstraintSolver_getRandSeed(Native);
			set => btSequentialImpulseConstraintSolver_setRandSeed(Native, value);
		}
/*
		public SingleConstraintRowSolver ScalarConstraintRowSolverGeneric
		{
			get { return btSequentialImpulseConstraintSolver_getScalarConstraintRowSolverGeneric(Native); }
		}

		public SingleConstraintRowSolver ScalarConstraintRowSolverLowerLimit
		{
			get { return btSequentialImpulseConstraintSolver_getScalarConstraintRowSolverLowerLimit(Native); }
		}

		public SingleConstraintRowSolver SSE2ConstraintRowSolverGeneric
		{
			get { return btSequentialImpulseConstraintSolver_getSSE2ConstraintRowSolverGeneric(Native); }
		}

		public SingleConstraintRowSolver SSE2ConstraintRowSolverLowerLimit
		{
			get { return btSequentialImpulseConstraintSolver_getSSE2ConstraintRowSolverLowerLimit(Native); }
		}

		public SingleConstraintRowSolver SSE41ConstraintRowSolverGeneric
		{
			get { return btSequentialImpulseConstraintSolver_getSSE4_1ConstraintRowSolverGeneric(Native); }
		}

		public SingleConstraintRowSolver SSE41ConstraintRowSolverLowerLimit
		{
			get { return btSequentialImpulseConstraintSolver_getSSE4_1ConstraintRowSolverLowerLimit(Native); }
		}
*/
	}
}
