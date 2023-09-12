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
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum SixDofFlags
	{
		None = 0,
		CfmNormal = 1,
		CfmStop = 2,
		ErpStop = 4
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RotationalLimitMotor : BulletDisposableObject
	{
		internal RotationalLimitMotor(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor()
		{
			IntPtr native = btRotationalLimitMotor_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor(RotationalLimitMotor limitMotor)
		{
			IntPtr native = btRotationalLimitMotor_new2(limitMotor.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedApplyTorques()
		{
			return btRotationalLimitMotor_needApplyTorques(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SolveAngularLimitsRef(float timeStep, ref global::System.Numerics.Vector3 axis, float jacDiagABInv,
			RigidBody body0, RigidBody body1)
		{
			return btRotationalLimitMotor_solveAngularLimits(Native, timeStep, ref axis,
				jacDiagABInv, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SolveAngularLimits(float timeStep, global::System.Numerics.Vector3 axis, float jacDiagABInv,
			RigidBody body0, RigidBody body1)
		{
			return btRotationalLimitMotor_solveAngularLimits(Native, timeStep, ref axis,
				jacDiagABInv, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TestLimitValue(float testValue)
		{
			return btRotationalLimitMotor_testLimitValue(Native, testValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AccumulatedImpulse
		{
			get => btRotationalLimitMotor_getAccumulatedImpulse(Native);
			set => btRotationalLimitMotor_setAccumulatedImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Bounce
		{
			get => btRotationalLimitMotor_getBounce(Native);
			set => btRotationalLimitMotor_setBounce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CurrentLimit
		{
			get => btRotationalLimitMotor_getCurrentLimit(Native);
			set => btRotationalLimitMotor_setCurrentLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CurrentLimitError
		{
			get => btRotationalLimitMotor_getCurrentLimitError(Native);
			set => btRotationalLimitMotor_setCurrentLimitError(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CurrentPosition
		{
			get => btRotationalLimitMotor_getCurrentPosition(Native);
			set => btRotationalLimitMotor_setCurrentPosition(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btRotationalLimitMotor_getDamping(Native);
			set => btRotationalLimitMotor_setDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableMotor
		{
			get => btRotationalLimitMotor_getEnableMotor(Native);
			set => btRotationalLimitMotor_setEnableMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HiLimit
		{
			get => btRotationalLimitMotor_getHiLimit(Native);
			set => btRotationalLimitMotor_setHiLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited => btRotationalLimitMotor_isLimited(Native);
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness
		{
			get => btRotationalLimitMotor_getLimitSoftness(Native);
			set => btRotationalLimitMotor_setLimitSoftness(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LoLimit
		{
			get => btRotationalLimitMotor_getLoLimit(Native);
			set => btRotationalLimitMotor_setLoLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxLimitForce
		{
			get => btRotationalLimitMotor_getMaxLimitForce(Native);
			set => btRotationalLimitMotor_setMaxLimitForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxMotorForce
		{
			get => btRotationalLimitMotor_getMaxMotorForce(Native);
			set => btRotationalLimitMotor_setMaxMotorForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float NormalCfm
		{
			get => btRotationalLimitMotor_getNormalCFM(Native);
			set => btRotationalLimitMotor_setNormalCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float StopCfm
		{
			get => btRotationalLimitMotor_getStopCFM(Native);
			set => btRotationalLimitMotor_setStopCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float StopErp
		{
			get => btRotationalLimitMotor_getStopERP(Native);
			set => btRotationalLimitMotor_setStopERP(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TargetVelocity
		{
			get => btRotationalLimitMotor_getTargetVelocity(Native);
			set => btRotationalLimitMotor_setTargetVelocity(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btRotationalLimitMotor_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TranslationalLimitMotor : BulletDisposableObject
	{
		internal TranslationalLimitMotor(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor()
		{
			IntPtr native = btTranslationalLimitMotor_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor(TranslationalLimitMotor other)
		{
			IntPtr native = btTranslationalLimitMotor_new2(other.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited(int limitIndex)
		{
			return btTranslationalLimitMotor_isLimited(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedApplyForce(int limitIndex)
		{
			return btTranslationalLimitMotor_needApplyForce(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SolveLinearAxisRef(float timeStep, float jacDiagABInv, RigidBody body1,
			ref global::System.Numerics.Vector3 pointInA, RigidBody body2, ref global::System.Numerics.Vector3 pointInB, int limitIndex, ref global::System.Numerics.Vector3 axisNormalOnA,
			ref global::System.Numerics.Vector3 anchorPos)
		{
			return btTranslationalLimitMotor_solveLinearAxis(Native, timeStep, jacDiagABInv,
				body1.Native, ref pointInA, body2.Native, ref pointInB, limitIndex,
				ref axisNormalOnA, ref anchorPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SolveLinearAxis(float timeStep, float jacDiagABInv, RigidBody body1,
		 	global::System.Numerics.Vector3 pointInA, RigidBody body2, global::System.Numerics.Vector3 pointInB, int limitIndex, global::System.Numerics.Vector3 axisNormalOnA,
		 	global::System.Numerics.Vector3 anchorPos)
		{
			return btTranslationalLimitMotor_solveLinearAxis(Native, timeStep, jacDiagABInv,
				body1.Native, ref pointInA, body2.Native, ref pointInB, limitIndex,
				ref axisNormalOnA, ref anchorPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int TestLimitValue(int limitIndex, float testValue)
		{
			return btTranslationalLimitMotor_testLimitValue(Native, limitIndex,
				testValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AccumulatedImpulse
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getAccumulatedImpulse(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setAccumulatedImpulse(Native, ref value);
		}
		
		/*
		public IntArray CurrentLimit
		{
			get { return new IntArray(btTranslationalLimitMotor_getCurrentLimit(Native), 3); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CurrentLimitError
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getCurrentLimitError(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setCurrentLimitError(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CurrentLinearDiff
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getCurrentLinearDiff(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setCurrentLinearDiff(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btTranslationalLimitMotor_getDamping(Native);
			set => btTranslationalLimitMotor_setDamping(Native, value);
		}
		/*
		public bool EnableMotor
		{
			get { return btTranslationalLimitMotor_getEnableMotor(_native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness
		{
			get => btTranslationalLimitMotor_getLimitSoftness(Native);
			set => btTranslationalLimitMotor_setLimitSoftness(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getLowerLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 MaxMotorForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getMaxMotorForce(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setMaxMotorForce(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 NormalCfm
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getNormalCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setNormalCFM(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Restitution
		{
			get => btTranslationalLimitMotor_getRestitution(Native);
			set => btTranslationalLimitMotor_setRestitution(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 StopCfm
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getStopCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setStopCFM(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 StopErp
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getStopERP(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setStopERP(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TargetVelocity
		{
			get
			{
				global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getTargetVelocity(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setTargetVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 UpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor_getUpperLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor_setUpperLimit(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btTranslationalLimitMotor_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Generic6DofConstraint : TypedConstraint
	{
		private RotationalLimitMotor[] _angularLimits = new RotationalLimitMotor[3];
		private TranslationalLimitMotor _linearLimits;

		protected internal Generic6DofConstraint()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix4x4 frameInA, Matrix4x4 frameInB, bool useLinearReferenceFrameA)
		{
			IntPtr native = btGeneric6DofConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, useLinearReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofConstraint(RigidBody rigidBodyB, Matrix4x4 frameInB, bool useLinearReferenceFrameB)
		{
			IntPtr native = btGeneric6DofConstraint_new2(rigidBodyB.Native, ref frameInB,
				useLinearReferenceFrameB);
			InitializeUserOwned(native);
			InitializeMembers(GetFixedBody(), rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalcAnchorPos()
		{
			btGeneric6DofConstraint_calcAnchorPos(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransformsRef(ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			btGeneric6DofConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransforms(Matrix4x4 transA, Matrix4x4 transB)
		{
			btGeneric6DofConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransforms()
		{
			btGeneric6DofConstraint_calculateTransforms2(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetLimitMotorInfo2(RotationalLimitMotor limitMotor, Matrix4x4 transA,
			Matrix4x4 transB, global::System.Numerics.Vector3 linVelA, global::System.Numerics.Vector3 linVelB, global::System.Numerics.Vector3 angVelA, global::System.Numerics.Vector3 angVelB,
			ConstraintInfo2 info, int row, ref global::System.Numerics.Vector3 ax1, int rotational, int rotAllowed = 0)
		{
			return btGeneric6DofConstraint_get_limit_motor_info2(Native, limitMotor.Native,
				ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB,
				info.Native, row, ref ax1, rotational, rotAllowed);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetAngle(int axisIndex)
		{
			return btGeneric6DofConstraint_getAngle(Native, axisIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetAxis(int axisIndex)
		{
		 	global::System.Numerics.Vector3 value;
			btGeneric6DofConstraint_getAxis(Native, axisIndex, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btGeneric6DofConstraint_getInfo1NonVirtual(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix4x4 transA, Matrix4x4 transB,
		 	global::System.Numerics.Vector3 linVelA, global::System.Numerics.Vector3 linVelB, global::System.Numerics.Vector3 angVelA, global::System.Numerics.Vector3 angVelB)
		{
			btGeneric6DofConstraint_getInfo2NonVirtual(Native, info.Native, ref transA,
				ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetRelativePivotPosition(int axisIndex)
		{
			return btGeneric6DofConstraint_getRelativePivotPosition(Native, axisIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor GetRotationalLimitMotor(int index)
		{
			if (_angularLimits[index] == null)
			{
				_angularLimits[index] = new RotationalLimitMotor(btGeneric6DofConstraint_getRotationalLimitMotor(Native, index), this);
			}
			return _angularLimits[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited(int limitIndex)
		{
			return btGeneric6DofConstraint_isLimited(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisRef(ref global::System.Numerics.Vector3 axis1, ref global::System.Numerics.Vector3 axis2)
		{
			btGeneric6DofConstraint_setAxis(Native, ref axis1, ref axis2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxis(global::System.Numerics.Vector3 axis1, global::System.Numerics.Vector3 axis2)
		{
			btGeneric6DofConstraint_setAxis(Native, ref axis1, ref axis2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFramesRef(ref Matrix4x4 frameA, ref Matrix4x4 frameB)
		{
			btGeneric6DofConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFrames(Matrix4x4 frameA, Matrix4x4 frameB)
		{
			btGeneric6DofConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(int axis, float lo, float hi)
		{
			btGeneric6DofConstraint_setLimit(Native, axis, lo, hi);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestAngularLimitMotor(int axisIndex)
		{
			return btGeneric6DofConstraint_testAngularLimitMotor(Native, axisIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateRhs(float timeStep)
		{
			btGeneric6DofConstraint_updateRHS(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularLowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofConstraint_getAngularLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setAngularLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularUpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofConstraint_getAngularUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setAngularUpperLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformA
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofConstraint_getCalculatedTransformA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformB
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofConstraint_getCalculatedTransformB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SixDofFlags Flags => btGeneric6DofConstraint_getFlags(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetA
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetB
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearLowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofConstraint_getLinearLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setLinearLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearUpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofConstraint_getLinearUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofConstraint_setLinearUpperLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor TranslationalLimitMotor
		{
			get
			{
				if (_linearLimits == null)
				{
					_linearLimits = new TranslationalLimitMotor(btGeneric6DofConstraint_getTranslationalLimitMotor(Native), this);
				}
				return _linearLimits;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseFrameOffset
		{
			get => btGeneric6DofConstraint_getUseFrameOffset(Native);
			set => btGeneric6DofConstraint_setUseFrameOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseLinearReferenceFrameA
		{
			get => btGeneric6DofConstraint_getUseLinearReferenceFrameA(Native);
			set => btGeneric6DofConstraint_setUseLinearReferenceFrameA(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseSolveConstraintObsolete
		{
			get => btGeneric6DofConstraint_getUseSolveConstraintObsolete(Native);
			set => btGeneric6DofConstraint_setUseSolveConstraintObsolete(Native, value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct Generic6DofConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseLinearReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseOffsetForConstraintFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct Generic6DofConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseLinearReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseOffsetForConstraintFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofConstraintDoubleData), fieldName).ToInt32(); }
	}
}
