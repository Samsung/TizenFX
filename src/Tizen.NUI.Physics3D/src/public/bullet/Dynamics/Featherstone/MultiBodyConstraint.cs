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

using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum TypedMultiBodyConstraintType
	{
		Limit = 3,
		OneDofJointMotor,
		Gear,
		PointToPoint,
		Slider,
		SphericalMotor,
		Fixed
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class MultiBodyConstraint : BulletDisposableObject
	{
		protected internal MultiBodyConstraint()
		{
		}

		protected internal void InitializeMembers(MultiBody bodyA, MultiBody bodyB)
		{
			MultiBodyA = bodyA;
			MultiBodyB = bodyB;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AllocateJacobiansMultiDof()
		{
			btMultiBodyConstraint_allocateJacobiansMultiDof(Native);
		}
		/*
		public void CreateConstraintRows(MultiBodyConstraintArray constraintRows,
			MultiBodyJacobianData data, ContactSolverInfo infoGlobal)
		{
			btMultiBodyConstraint_createConstraintRows(Native, constraintRows.Native,
				data.Native, infoGlobal.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DebugDraw(DebugDraw drawer)
		{
			btMultiBodyConstraint_debugDraw(Native, drawer.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FinalizeMultiDof()
		{
			btMultiBodyConstraint_finalizeMultiDof(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetAppliedImpulse(int dof)
		{
			return btMultiBodyConstraint_getAppliedImpulse(Native, dof);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetPosition(int row)
		{
			return btMultiBodyConstraint_getPosition(Native, row);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InternalSetAppliedImpulse(int dof, float appliedImpulse)
		{
			btMultiBodyConstraint_internalSetAppliedImpulse(Native, dof, appliedImpulse);
		}
		/*
		public float JacobianA(int row)
		{
			return btMultiBodyConstraint_jacobianA(Native, row);
		}

		public float JacobianB(int row)
		{
			return btMultiBodyConstraint_jacobianB(Native, row);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPosition(int row, float pos)
		{
			btMultiBodyConstraint_setPosition(Native, row, pos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateJacobianSizes()
		{
			btMultiBodyConstraint_updateJacobianSizes(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedMultiBodyConstraintType ConstraintType => (TypedMultiBodyConstraintType)btMultiBodyConstraint_getConstraintType(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IslandIdA => btMultiBodyConstraint_getIslandIdA(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IslandIdB => btMultiBodyConstraint_getIslandIdB(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsUnilateral => btMultiBodyConstraint_isUnilateral(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxAppliedImpulse
		{
			get => btMultiBodyConstraint_getMaxAppliedImpulse(Native);
			set => btMultiBodyConstraint_setMaxAppliedImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody MultiBodyA { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody MultiBodyB { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumRows => btMultiBodyConstraint_getNumRows(Native);

		protected override void Dispose(bool disposing)
		{
			btMultiBodyConstraint_delete(Native);
		}
	}
}
