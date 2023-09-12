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
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum SolverModes
	{
		None = 0,
		RandomizeOrder = 1,
		FrictionSeparate = 2,
		UseWarmStarting = 4,
		Use2FrictionDirections = 16,
		EnableFrictionDirectionCaching = 32,
		DisableVelocityDependentFrictionDirection = 64,
		CacheFriendly = 128,
		Simd = 256,
		InterleaveContactAndFrictionConstraints = 512,
		AllowZeroLengthFrictionDirections = 1024,
		DisableImplicitConeFriction = 2048
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ContactSolverInfoData : BulletDisposableObject
	{
		internal ContactSolverInfoData(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactSolverInfoData()
		{
			IntPtr native = btContactSolverInfoData_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btContactSolverInfoData_getDamping(Native);
			set => btContactSolverInfoData_setDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DeformableErp
		{
			get => btContactSolverInfoData_getDeformableErp(Native);
			set => btContactSolverInfoData_setDeformableErp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Erp
		{
			get => btContactSolverInfoData_getErp(Native);
			set => btContactSolverInfoData_setErp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Erp2
		{
			get => btContactSolverInfoData_getErp2(Native);
			set => btContactSolverInfoData_setErp2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btContactSolverInfoData_getFriction(Native);
			set => btContactSolverInfoData_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float FrictionCfm
		{
			get => btContactSolverInfoData_getFrictionCfm(Native);
			set => btContactSolverInfoData_setFrictionCfm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float FrictionErp
		{
			get => btContactSolverInfoData_getFrictionErp(Native);
			set => btContactSolverInfoData_setFrictionErp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GlobalCfm
		{
			get => btContactSolverInfoData_getGlobalCfm(Native);
			set => btContactSolverInfoData_setGlobalCfm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LeastSquaresResidualThreshold
		{
			get => btContactSolverInfoData_getLeastSquaresResidualThreshold(Native);
			set => btContactSolverInfoData_setLeastSquaresResidualThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearSlop
		{
			get => btContactSolverInfoData_getLinearSlop(Native);
			set => btContactSolverInfoData_setLinearSlop(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxErrorReduction
		{
			get => btContactSolverInfoData_getMaxErrorReduction(Native);
			set => btContactSolverInfoData_setMaxErrorReduction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxGyroscopicForce
		{
			get => btContactSolverInfoData_getMaxGyroscopicForce(Native);
			set => btContactSolverInfoData_setMaxGyroscopicForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MinimumSolverBatchSize
		{
			get => btContactSolverInfoData_getMinimumSolverBatchSize(Native);
			set => btContactSolverInfoData_setMinimumSolverBatchSize(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumIterations
		{
			get => btContactSolverInfoData_getNumIterations(Native);
			set => btContactSolverInfoData_setNumIterations(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RestingContactRestitutionThreshold
		{
			get => btContactSolverInfoData_getRestingContactRestitutionThreshold(Native);
			set => btContactSolverInfoData_setRestingContactRestitutionThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Restitution
		{
			get => btContactSolverInfoData_getRestitution(Native);
			set => btContactSolverInfoData_setRestitution(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionVelocityThreshold
		{
			get => btContactSolverInfoData_getRestitutionVelocityThreshold(Native);
			set => btContactSolverInfoData_setRestitutionVelocityThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SingleAxisRollingFrictionThreshold
		{
			get => btContactSolverInfoData_getSingleAxisRollingFrictionThreshold(Native);
			set => btContactSolverInfoData_setSingleAxisRollingFrictionThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SolverModes SolverMode
		{
			get => btContactSolverInfoData_getSolverMode(Native);
			set => btContactSolverInfoData_setSolverMode(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Sor
		{
			get => btContactSolverInfoData_getSor(Native);
			set => btContactSolverInfoData_setSor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SplitImpulse
		{
			get => btContactSolverInfoData_getSplitImpulse(Native);
			set => btContactSolverInfoData_setSplitImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SplitImpulsePenetrationThreshold
		{
			get => btContactSolverInfoData_getSplitImpulsePenetrationThreshold(Native);
			set => btContactSolverInfoData_setSplitImpulsePenetrationThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SplitImpulseTurnErp
		{
			get => btContactSolverInfoData_getSplitImpulseTurnErp(Native);
			set => btContactSolverInfoData_setSplitImpulseTurnErp(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Tau
		{
			get => btContactSolverInfoData_getTau(Native);
			set => btContactSolverInfoData_setTau(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TimeStep
		{
			get => btContactSolverInfoData_getTimeStep(Native);
			set => btContactSolverInfoData_setTimeStep(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float WarmStartingFactor
		{
			get => btContactSolverInfoData_getWarmstartingFactor(Native);
			set => btContactSolverInfoData_setWarmstartingFactor(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btContactSolverInfoData_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ContactSolverInfo : ContactSolverInfoData
	{
		internal ContactSolverInfo(IntPtr native, BulletObject owner)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactSolverInfo()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btContactSolverInfo_new();
			InitializeUserOwned(native);
		}
	}
}
