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
	public class MultiBodySolverConstraint : BulletDisposableObject
	{
		protected MultiBody _multiBodyA;
		protected MultiBody _multiBodyB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodySolverConstraint()
		{
			IntPtr native = btMultiBodySolverConstraint_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularComponentA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getAngularComponentA(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setAngularComponentA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularComponentB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getAngularComponentB(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setAngularComponentB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulse
		{
			get => btMultiBodySolverConstraint_getAppliedImpulse(Native);
			set => btMultiBodySolverConstraint_setAppliedImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedPushImpulse
		{
			get => btMultiBodySolverConstraint_getAppliedPushImpulse(Native);
			set => btMultiBodySolverConstraint_setAppliedPushImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Cfm
		{
			get => btMultiBodySolverConstraint_getCfm(Native);
			set => btMultiBodySolverConstraint_setCfm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ContactNormal1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getContactNormal1(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setContactNormal1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ContactNormal2
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getContactNormal2(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setContactNormal2(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DeltaVelAindex
		{
			get => btMultiBodySolverConstraint_getDeltaVelAindex(Native);
			set => btMultiBodySolverConstraint_setDeltaVelAindex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DeltaVelBindex
		{
			get => btMultiBodySolverConstraint_getDeltaVelBindex(Native);
			set => btMultiBodySolverConstraint_setDeltaVelBindex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btMultiBodySolverConstraint_getFriction(Native);
			set => btMultiBodySolverConstraint_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FrictionIndex
		{
			get => btMultiBodySolverConstraint_getFrictionIndex(Native);
			set => btMultiBodySolverConstraint_setFrictionIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int JacAindex
		{
			get => btMultiBodySolverConstraint_getJacAindex(Native);
			set => btMultiBodySolverConstraint_setJacAindex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int JacBindex
		{
			get => btMultiBodySolverConstraint_getJacBindex(Native);
			set => btMultiBodySolverConstraint_setJacBindex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float JacDiagABInv
		{
			get => btMultiBodySolverConstraint_getJacDiagABInv(Native);
			set => btMultiBodySolverConstraint_setJacDiagABInv(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LinkA
		{
			get => btMultiBodySolverConstraint_getLinkA(Native);
			set => btMultiBodySolverConstraint_setLinkA(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LinkB
		{
			get => btMultiBodySolverConstraint_getLinkB(Native);
			set => btMultiBodySolverConstraint_setLinkB(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LowerLimit
		{
			get => btMultiBodySolverConstraint_getLowerLimit(Native);
			set => btMultiBodySolverConstraint_setLowerLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody MultiBodyA
		{
			get
			{
				if (_multiBodyA == null)
				{
					_multiBodyA = new MultiBody(btMultiBodySolverConstraint_getMultiBodyA(Native), this);
				}
				return _multiBodyA;
			}
			set
			{
				btMultiBodySolverConstraint_setMultiBodyA(Native, value.Native);
				_multiBodyA = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody MultiBodyB
		{
			get
			{
				if (_multiBodyB == null)
				{
					_multiBodyB = new MultiBody(btMultiBodySolverConstraint_getMultiBodyB(Native), this);
				}
				return _multiBodyB;
			}
			set
			{
				btMultiBodySolverConstraint_setMultiBodyB(Native, value.Native);
				_multiBodyB = value;
			}
		}
		/*
		public MultiBodyConstraint OrgConstraint
		{
			get { return btMultiBodySolverConstraint_getOrgConstraint(_native); }
			set { btMultiBodySolverConstraint_setOrgConstraint(_native, value._native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int OrgDofIndex
		{
			get => btMultiBodySolverConstraint_getOrgDofIndex(Native);
			set => btMultiBodySolverConstraint_setOrgDofIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr OriginalContactPoint
		{
			get => btMultiBodySolverConstraint_getOriginalContactPoint(Native);
			set => btMultiBodySolverConstraint_setOriginalContactPoint(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int OverrideNumSolverIterations
		{
			get => btMultiBodySolverConstraint_getOverrideNumSolverIterations(Native);
			set => btMultiBodySolverConstraint_setOverrideNumSolverIterations(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Relpos1CrossNormal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getRelpos1CrossNormal(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setRelpos1CrossNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Relpos2CrossNormal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBodySolverConstraint_getRelpos2CrossNormal(Native, out value);
				return value;
			}
			set => btMultiBodySolverConstraint_setRelpos2CrossNormal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Rhs
		{
			get => btMultiBodySolverConstraint_getRhs(Native);
			set => btMultiBodySolverConstraint_setRhs(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RhsPenetration
		{
			get => btMultiBodySolverConstraint_getRhsPenetration(Native);
			set => btMultiBodySolverConstraint_setRhsPenetration(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SolverBodyIdA
		{
			get => btMultiBodySolverConstraint_getSolverBodyIdA(Native);
			set => btMultiBodySolverConstraint_setSolverBodyIdA(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SolverBodyIdB
		{
			get => btMultiBodySolverConstraint_getSolverBodyIdB(Native);
			set => btMultiBodySolverConstraint_setSolverBodyIdB(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UnusedPadding4
		{
			get => btMultiBodySolverConstraint_getUnusedPadding4(Native);
			set => btMultiBodySolverConstraint_setUnusedPadding4(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpperLimit
		{
			get => btMultiBodySolverConstraint_getUpperLimit(Native);
			set => btMultiBodySolverConstraint_setUpperLimit(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btMultiBodySolverConstraint_delete(Native);
		}
	}
}
