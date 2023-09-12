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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum RotateOrder
	{
		XYZ,
		XZY,
		YXZ,
		YZX,
		ZXY,
		ZYX
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RotationalLimitMotor2 : BulletDisposableObject
	{
		internal RotationalLimitMotor2(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor2()
		{
			IntPtr native = btRotationalLimitMotor2_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor2(RotationalLimitMotor2 limitMotor)
		{
			IntPtr native = btRotationalLimitMotor2_new2(limitMotor.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestLimitValue(float testValue)
		{
			btRotationalLimitMotor2_testLimitValue(Native, testValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Bounce
		{
			get => btRotationalLimitMotor2_getBounce(Native);
			set => btRotationalLimitMotor2_setBounce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CurrentLimit
		{
			get => btRotationalLimitMotor2_getCurrentLimit(Native);
			set => btRotationalLimitMotor2_setCurrentLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CurrentLimitError
		{
			get => btRotationalLimitMotor2_getCurrentLimitError(Native);
			set => btRotationalLimitMotor2_setCurrentLimitError(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CurrentLimitErrorHi
		{
			get => btRotationalLimitMotor2_getCurrentLimitErrorHi(Native);
			set => btRotationalLimitMotor2_setCurrentLimitErrorHi(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CurrentPosition
		{
			get => btRotationalLimitMotor2_getCurrentPosition(Native);
			set => btRotationalLimitMotor2_setCurrentPosition(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableMotor
		{
			get => btRotationalLimitMotor2_getEnableMotor(Native);
			set => btRotationalLimitMotor2_setEnableMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableSpring
		{
			get => btRotationalLimitMotor2_getEnableSpring(Native);
			set => btRotationalLimitMotor2_setEnableSpring(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EquilibriumPoint
		{
			get => btRotationalLimitMotor2_getEquilibriumPoint(Native);
			set => btRotationalLimitMotor2_setEquilibriumPoint(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HiLimit
		{
			get => btRotationalLimitMotor2_getHiLimit(Native);
			set => btRotationalLimitMotor2_setHiLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited => btRotationalLimitMotor2_isLimited(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LoLimit
		{
			get => btRotationalLimitMotor2_getLoLimit(Native);
			set => btRotationalLimitMotor2_setLoLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxMotorForce
		{
			get => btRotationalLimitMotor2_getMaxMotorForce(Native);
			set => btRotationalLimitMotor2_setMaxMotorForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MotorCfm
		{
			get => btRotationalLimitMotor2_getMotorCFM(Native);
			set => btRotationalLimitMotor2_setMotorCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MotorErp
		{
			get => btRotationalLimitMotor2_getMotorERP(Native);
			set => btRotationalLimitMotor2_setMotorERP(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ServoMotor
		{
			get => btRotationalLimitMotor2_getServoMotor(Native);
			set => btRotationalLimitMotor2_setServoMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ServoTarget
		{
			get => btRotationalLimitMotor2_getServoTarget(Native);
			set => btRotationalLimitMotor2_setServoTarget(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SpringDamping
		{
			get => btRotationalLimitMotor2_getSpringDamping(Native);
			set => btRotationalLimitMotor2_setSpringDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SpringDampingLimited
		{
			get => btRotationalLimitMotor2_getSpringDampingLimited(Native);
			set => btRotationalLimitMotor2_setSpringDampingLimited(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SpringStiffness
		{
			get => btRotationalLimitMotor2_getSpringStiffness(Native);
			set => btRotationalLimitMotor2_setSpringStiffness(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SpringStiffnessLimited
		{
			get => btRotationalLimitMotor2_getSpringStiffnessLimited(Native);
			set => btRotationalLimitMotor2_setSpringStiffnessLimited(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float StopCfm
		{
			get => btRotationalLimitMotor2_getStopCFM(Native);
			set => btRotationalLimitMotor2_setStopCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float StopErp
		{
			get => btRotationalLimitMotor2_getStopERP(Native);
			set => btRotationalLimitMotor2_setStopERP(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TargetVelocity
		{
			get => btRotationalLimitMotor2_getTargetVelocity(Native);
			set => btRotationalLimitMotor2_setTargetVelocity(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btRotationalLimitMotor2_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class TranslationalLimitMotor2 : BulletDisposableObject
	{
		internal TranslationalLimitMotor2(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor2()
		{
			IntPtr native = btTranslationalLimitMotor2_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor2(TranslationalLimitMotor2 other)
		{
			IntPtr native = btTranslationalLimitMotor2_new2(other.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited(int limitIndex)
		{
			return btTranslationalLimitMotor2_isLimited(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestLimitValue(int limitIndex, float testValue)
		{
			btTranslationalLimitMotor2_testLimitValue(Native, limitIndex, testValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Bounce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getBounce(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setBounce(Native, ref value);
		}
		/*
		public IntArray CurrentLimit
		{
			get { return new IntArray(btTranslationalLimitMotor2_getCurrentLimit(Native), 3); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CurrentLimitError
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getCurrentLimitError(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLimitError(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CurrentLimitErrorHi
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getCurrentLimitErrorHi(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLimitErrorHi(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CurrentLinearDiff
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getCurrentLinearDiff(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setCurrentLinearDiff(Native, ref value);
		}
		/*
		public BoolArray EnableMotor
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getEnableMotor(Native), 3); }
		}

		public BoolArray EnableSpring
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getEnableSpring(Native), 3); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 EquilibriumPoint
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getEquilibriumPoint(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setEquilibriumPoint(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getLowerLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 MaxMotorForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getMaxMotorForce(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMaxMotorForce(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 MotorCFM
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getMotorCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMotorCFM(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 MotorERP
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getMotorERP(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setMotorERP(Native, ref value);
		}
		/*
		public BoolArray ServoMotor
		{
			get { return new BoolArray(btTranslationalLimitMotor2_getServoMotor(Native)); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ServoTarget
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getServoTarget(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setServoTarget(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 SpringDamping
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getSpringDamping(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setSpringDamping(Native, ref value);
		}
		/*
		public BoolArray SpringDampingLimited
		{
			get { return btTranslationalLimitMotor2_getSpringDampingLimited(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 SpringStiffness
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getSpringStiffness(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setSpringStiffness(Native, ref value);
		}
		/*
		public BoolArray SpringStiffnessLimited
		{
			get { return btTranslationalLimitMotor2_getSpringStiffnessLimited(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 StopCfm
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getStopCFM(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setStopCFM(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 StopEep
		{
			get
			{
				global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getStopERP(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setStopERP(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TargetVelocity
		{
			get
			{
				global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getTargetVelocity(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setTargetVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 UpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btTranslationalLimitMotor2_getUpperLimit(Native, out value);
				return value;
			}
			set => btTranslationalLimitMotor2_setUpperLimit(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btTranslationalLimitMotor2_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class Generic6DofSpring2Constraint : TypedConstraint
	{
		private RotationalLimitMotor2[] _angularLimits = new RotationalLimitMotor2[3];
		private TranslationalLimitMotor2 _linearLimits;

		protected internal Generic6DofSpring2Constraint()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofSpring2Constraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix4x4 frameInA, Matrix4x4 frameInB, RotateOrder rotOrder = RotateOrder.XYZ)
		{
			IntPtr native = btGeneric6DofSpring2Constraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, rotOrder);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Generic6DofSpring2Constraint(RigidBody rigidBodyB, Matrix4x4 frameInB,
			RotateOrder rotOrder = RotateOrder.XYZ)
		{
			IntPtr native = btGeneric6DofSpring2Constraint_new2(rigidBodyB.Native, ref frameInB,
				rotOrder);
			InitializeUserOwned(native);
			InitializeMembers(GetFixedBody(), rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static float BtGetMatrixElem(Matrix4x4 mat, int index)
		{
			return btGeneric6DofSpring2Constraint_btGetMatrixElem(ref mat, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransforms(Matrix4x4 transA, Matrix4x4 transB)
		{
			btGeneric6DofSpring2Constraint_calculateTransforms(Native, ref transA,
				ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransforms()
		{
			btGeneric6DofSpring2Constraint_calculateTransforms2(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableMotor(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_enableMotor(Native, index, onOff);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableSpring(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_enableSpring(Native, index, onOff);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetAngle(int axisIndex)
		{
			return btGeneric6DofSpring2Constraint_getAngle(Native, axisIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetAxis(int axisIndex)
		{
		 	global::System.Numerics.Vector3 value;
			btGeneric6DofSpring2Constraint_getAxis(Native, axisIndex, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetRelativePivotPosition(int axisIndex)
		{
			return btGeneric6DofSpring2Constraint_getRelativePivotPosition(Native,
				axisIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotationalLimitMotor2 GetRotationalLimitMotor(int index)
		{
			if (_angularLimits[index] == null)
			{
				_angularLimits[index] = new RotationalLimitMotor2(btGeneric6DofSpring2Constraint_getRotationalLimitMotor(Native, index), this);
			}
			return _angularLimits[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimited(int limitIndex)
		{
			return btGeneric6DofSpring2Constraint_isLimited(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerZXY(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerZXY(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerZYX(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerZYX(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerXZY(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerXZY(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerXYZ(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerXYZ(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerYZX(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerYZX(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool MatrixToEulerYXZ(Matrix4x4 mat, ref global::System.Numerics.Vector3 xyz)
		{
			return btGeneric6DofSpring2Constraint_matrixToEulerYXZ(ref mat, ref xyz);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxis(global::System.Numerics.Vector3 axis1, global::System.Numerics.Vector3 axis2)
		{
			btGeneric6DofSpring2Constraint_setAxis(Native, ref axis1, ref axis2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBounce(int index, float bounce)
		{
			btGeneric6DofSpring2Constraint_setBounce(Native, index, bounce);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetDamping(int index, float damping, bool limitIfNeeded = true)
		{
			btGeneric6DofSpring2Constraint_setDamping(Native, index, damping, limitIfNeeded);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint()
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint(int index, float val)
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint2(Native, index, val);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetEquilibriumPoint(int index)
		{
			btGeneric6DofSpring2Constraint_setEquilibriumPoint3(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFrames(Matrix4x4 frameA, Matrix4x4 frameB)
		{
			btGeneric6DofSpring2Constraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(int axis, float lo, float hi)
		{
			btGeneric6DofSpring2Constraint_setLimit(Native, axis, lo, hi);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimitReversed(int axis, float lo, float hi)
		{
			btGeneric6DofSpring2Constraint_setLimitReversed(Native, axis, lo, hi);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMaxMotorForce(int index, float force)
		{
			btGeneric6DofSpring2Constraint_setMaxMotorForce(Native, index, force);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetServo(int index, bool onOff)
		{
			btGeneric6DofSpring2Constraint_setServo(Native, index, onOff);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetServoTarget(int index, float target)
		{
			btGeneric6DofSpring2Constraint_setServoTarget(Native, index, target);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetStiffness(int index, float stiffness, bool limitIfNeeded = true)
		{
			btGeneric6DofSpring2Constraint_setStiffness(Native, index, stiffness,
				limitIfNeeded);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetTargetVelocity(int index, float velocity)
		{
			btGeneric6DofSpring2Constraint_setTargetVelocity(Native, index, velocity);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularLowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getAngularLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularLowerLimitReversed
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getAngularLowerLimitReversed(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularLowerLimitReversed(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularUpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getAngularUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularUpperLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularUpperLimitReversed
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getAngularUpperLimitReversed(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setAngularUpperLimitReversed(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformA
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofSpring2Constraint_getCalculatedTransformA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformB
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofSpring2Constraint_getCalculatedTransformB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetA
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofSpring2Constraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetB
		{
			get
			{
				Matrix4x4 value;
				btGeneric6DofSpring2Constraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearLowerLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getLinearLowerLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setLinearLowerLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearUpperLimit
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGeneric6DofSpring2Constraint_getLinearUpperLimit(Native, out value);
				return value;
			}
			set => btGeneric6DofSpring2Constraint_setLinearUpperLimit(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RotateOrder RotationOrder
		{
			get => btGeneric6DofSpring2Constraint_getRotationOrder(Native);
			set => btGeneric6DofSpring2Constraint_setRotationOrder(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TranslationalLimitMotor2 TranslationalLimitMotor
		{
			get
			{
				if (_linearLimits == null)
				{
					_linearLimits = new TranslationalLimitMotor2(btGeneric6DofSpring2Constraint_getTranslationalLimitMotor(Native), this);
				}
				return _linearLimits;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpring2ConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypeConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearBounce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearStopErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearStopCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearMotorErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearMotorCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearMaxMotorForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearServoTarget;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearSpringStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearSpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearEquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearEnableMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearServoMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearEnableSpring;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearSpringStiffnessLimited;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearSpringDampingLimited;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularBounce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularStopErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularStopCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularMotorErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularMotorCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularMaxMotorForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularServoTarget;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularSpringStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularSpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularEquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularEnableMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularServoMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularEnableSpring;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularSpringStiffnessLimited;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]

		public byte[] AngularSpringDampingLimited;
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RotateOrder;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpring2ConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct Generic6DofSpring2ConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypeConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearBounce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearStopErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearStopCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearMotorErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearMotorCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearMaxMotorForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearServoTarget;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearSpringStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearSpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearEquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearEnableMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearServoMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearEnableSpring;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearSpringStiffnessLimited;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] LinearSpringDampingLimited;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularBounce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularStopErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularStopCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularMotorErp;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularMotorCfm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularMaxMotorForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularServoTarget;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularSpringStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularSpringDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularEquilibriumPoint;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularEnableMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularServoMotor;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularEnableSpring;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularSpringStiffnessLimited;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public byte[] AngularSpringDampingLimited;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int RotateOrder;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(Generic6DofSpring2ConstraintDoubleData), fieldName).ToInt32(); }
	}
}
