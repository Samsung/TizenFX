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
	public enum HingeFlags
	{
		None = 0,
		CfmStop = 1,
		ErpStop = 2,
		CfmNormal = 4,
		ErpNormal = 8
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HingeConstraint : TypedConstraint
	{
		protected internal HingeConstraint()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, global::System.Numerics.Vector3 pivotInA,
		 	global::System.Numerics.Vector3 pivotInB, global::System.Numerics.Vector3 axisInA, global::System.Numerics.Vector3 axisInB, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref pivotInA, ref pivotInB, ref axisInA, ref axisInB, useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeConstraint(RigidBody rigidBodyA, global::System.Numerics.Vector3 pivotInA, global::System.Numerics.Vector3 axisInA,
			bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeConstraint_new2(rigidBodyA.Native, ref pivotInA, ref axisInA,
				useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix4x4 rigidBodyAFrame,
			Matrix4x4 rigidBodyBFrame, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeConstraint_new3(rigidBodyA.Native, rigidBodyB.Native,
				ref rigidBodyAFrame, ref rigidBodyBFrame, useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeConstraint(RigidBody rigidBodyA, Matrix4x4 rigidBodyAFrame, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeConstraint_new4(rigidBodyA.Native, ref rigidBodyAFrame,
				useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableAngularMotor(bool enableMotor, float targetVelocity, float maxMotorImpulse)
		{
			btHingeConstraint_enableAngularMotor(Native, enableMotor, targetVelocity,
				maxMotorImpulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetHingeAngleRef(ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			return btHingeConstraint_getHingeAngle(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetHingeAngle(Matrix4x4 transA, Matrix4x4 transB)
		{
			return btHingeConstraint_getHingeAngle(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btHingeConstraint_getInfo1NonVirtual(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2Internal(ConstraintInfo2 info, Matrix4x4 transA, Matrix4x4 transB,
		 	global::System.Numerics.Vector3 angVelA, global::System.Numerics.Vector3 angVelB)
		{
			btHingeConstraint_getInfo2Internal(Native, info.Native, ref transA,
				ref transB, ref angVelA, ref angVelB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2InternalUsingFrameOffset(ConstraintInfo2 info, Matrix4x4 transA,
			Matrix4x4 transB, global::System.Numerics.Vector3 angVelA, global::System.Numerics.Vector3 angVelB)
		{
			btHingeConstraint_getInfo2InternalUsingFrameOffset(Native, info.Native,
				ref transA, ref transB, ref angVelA, ref angVelB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix4x4 transA, Matrix4x4 transB,
		 	global::System.Numerics.Vector3 angVelA, global::System.Numerics.Vector3 angVelB)
		{
			btHingeConstraint_getInfo2NonVirtual(Native, info.Native, ref transA,
				ref transB, ref angVelA, ref angVelB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxisRef(ref global::System.Numerics.Vector3 axisInA)
		{
			btHingeConstraint_setAxis(Native, ref axisInA);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAxis(global::System.Numerics.Vector3 axisInA)
		{
			btHingeConstraint_setAxis(Native, ref axisInA);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFramesRef(ref Matrix4x4 frameA, ref Matrix4x4 frameB)
		{
			btHingeConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFrames(Matrix4x4 frameA, Matrix4x4 frameB)
		{
			btHingeConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(float low, float high)
		{
			btHingeConstraint_setLimit(Native, low, high);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(float low, float high, float softness)
		{
			btHingeConstraint_setLimit2(Native, low, high, softness);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(float low, float high, float softness, float biasFactor)
		{
			btHingeConstraint_setLimit3(Native, low, high, softness, biasFactor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(float low, float high, float softness, float biasFactor,
			float relaxationFactor)
		{
			btHingeConstraint_setLimit4(Native, low, high, softness, biasFactor,
				relaxationFactor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMotorTarget(float targetAngle, float deltaTime)
		{
			btHingeConstraint_setMotorTarget(Native, targetAngle, deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMotorTargetRef(ref Quaternion qAinB, float deltaTime)
		{
			btHingeConstraint_setMotorTarget2(Native, ref qAinB, deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMotorTarget(Quaternion qAinB, float deltaTime)
		{
			btHingeConstraint_setMotorTarget2(Native, ref qAinB, deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestLimitRef(ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			btHingeConstraint_testLimit(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestLimit(Matrix4x4 transA, Matrix4x4 transB)
		{
			btHingeConstraint_testLimit(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateRhs(float timeStep)
		{
			btHingeConstraint_updateRHS(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 AFrame
		{
			get
			{
				Matrix4x4 value;
				btHingeConstraint_getAFrame(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AngularOnly
		{
			get => btHingeConstraint_getAngularOnly(Native);
			set => btHingeConstraint_setAngularOnly(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 BFrame
		{
			get
			{
				Matrix4x4 value;
				btHingeConstraint_getBFrame(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EnableMotor
		{
			get => btHingeConstraint_getEnableAngularMotor(Native);
			set => btHingeConstraint_enableMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeFlags Flags => btHingeConstraint_getFlags(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetA
		{
			get
			{
				Matrix4x4 value;
				btHingeConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetB
		{
			get
			{
				Matrix4x4 value;
				btHingeConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasLimit => btHingeConstraint_hasLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HingeAngle => btHingeConstraint_getHingeAngle2(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitBiasFactor => btHingeConstraint_getLimitBiasFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitRelaxationFactor => btHingeConstraint_getLimitRelaxationFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSign => btHingeConstraint_getLimitSign(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness => btHingeConstraint_getLimitSoftness(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LowerLimit => btHingeConstraint_getLowerLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxMotorImpulse
		{
			get => btHingeConstraint_getMaxMotorImpulse(Native);
			set => btHingeConstraint_setMaxMotorImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MotorTargetVelocity => btHingeConstraint_getMotorTargetVelocity(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SolveLimit => btHingeConstraint_getSolveLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpperLimit => btHingeConstraint_getUpperLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseFrameOffset
		{
			get => btHingeConstraint_getUseFrameOffset(Native);
			set => btHingeConstraint_setUseFrameOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseReferenceFrameA
		{
			get => btHingeConstraint_getUseReferenceFrameA(Native);
			set => btHingeConstraint_setUseReferenceFrameA(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HingeAccumulatedAngleConstraint : HingeConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
		 	global::System.Numerics.Vector3 pivotInA, global::System.Numerics.Vector3 pivotInB, global::System.Numerics.Vector3 axisInA, global::System.Numerics.Vector3 axisInB, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeAccumulatedAngleConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref pivotInA, ref pivotInB, ref axisInA, ref axisInB, useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, global::System.Numerics.Vector3 pivotInA,
		 	global::System.Numerics.Vector3 axisInA, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeAccumulatedAngleConstraint_new2(rigidBodyA.Native, ref pivotInA,
				ref axisInA, useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB,
			Matrix4x4 rigidBodyAFrame, Matrix4x4 rigidBodyBFrame, bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeAccumulatedAngleConstraint_new3(rigidBodyA.Native, rigidBodyB.Native,
				ref rigidBodyAFrame, ref rigidBodyBFrame, useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HingeAccumulatedAngleConstraint(RigidBody rigidBodyA, Matrix4x4 rigidBodyAFrame,
			bool useReferenceFrameA = false)
		{
			IntPtr native = btHingeAccumulatedAngleConstraint_new4(rigidBodyA.Native, ref rigidBodyAFrame,
				useReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AccumulatedHingeAngle
		{
			get => btHingeAccumulatedAngleConstraint_getAccumulatedHingeAngle(Native);
			set => btHingeAccumulatedAngleConstraint_setAccumulatedHingeAngle(Native, value);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct HingeConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AngularOnly;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EnableAngularMotor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MotorTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxMotorImpulse;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BiasFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RelaxationFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(HingeConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct HingeConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AngularOnly;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int EnableAngularMotor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double MotorTargetVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double MaxMotorImpulse;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double UpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LimitSoftness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double BiasFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double RelaxationFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(HingeConstraintDoubleData), fieldName).ToInt32(); }
	}
}
