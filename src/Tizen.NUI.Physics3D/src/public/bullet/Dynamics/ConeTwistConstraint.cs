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
	public enum ConeTwistFlags
	{
		None = 0,
		LinearCfm = 1,
		LinearErp = 2,
		AngularCfm = 4
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConeTwistConstraint : TypedConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeTwistConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix4x4 rigidBodyAFrame,
			Matrix4x4 rigidBodyBFrame)
		{
			IntPtr native = btConeTwistConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref rigidBodyAFrame, ref rigidBodyBFrame);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeTwistConstraint(RigidBody rigidBodyA, Matrix4x4 rigidBodyAFrame)
		{
			IntPtr native = btConeTwistConstraint_new2(rigidBodyA.Native, ref rigidBodyAFrame);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, GetFixedBody());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalcAngleInfo()
		{
			btConeTwistConstraint_calcAngleInfo(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalcAngleInfo2Ref(ref Matrix4x4 transA, ref Matrix4x4 transB, ref Matrix4x4 invInertiaWorldA,
			Matrix4x4 invInertiaWorldB)
		{
			btConeTwistConstraint_calcAngleInfo2(Native, ref transA, ref transB,
				ref invInertiaWorldA, ref invInertiaWorldB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalcAngleInfo2(Matrix4x4 transA, Matrix4x4 transB, Matrix4x4 invInertiaWorldA,
			Matrix4x4 invInertiaWorldB)
		{
			btConeTwistConstraint_calcAngleInfo2(Native, ref transA, ref transB,
				ref invInertiaWorldA, ref invInertiaWorldB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableMotor(bool b)
		{
			btConeTwistConstraint_enableMotor(Native, b);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtualRef(ConstraintInfo2 info, ref Matrix4x4 transA, ref Matrix4x4 transB,
			Matrix4x4 invInertiaWorldA, Matrix4x4 invInertiaWorldB)
		{
			btConeTwistConstraint_getInfo2NonVirtual(Native, info.Native, ref transA,
				ref transB, ref invInertiaWorldA, ref invInertiaWorldB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix4x4 transA, Matrix4x4 transB,
			Matrix4x4 invInertiaWorldA, Matrix4x4 invInertiaWorldB)
		{
			btConeTwistConstraint_getInfo2NonVirtual(Native, info.Native, ref transA,
				ref transB, ref invInertiaWorldA, ref invInertiaWorldB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetLimit(int limitIndex)
		{
			return btConeTwistConstraint_getLimit(Native, limitIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetPointForAngle(float fAngleInRadians, float fLength)
		{
		 	global::System.Numerics.Vector3 value;
			btConeTwistConstraint_GetPointForAngle(Native, fAngleInRadians, fLength,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFramesRef(ref Matrix4x4 frameA, ref Matrix4x4 frameB)
		{
			btConeTwistConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFrames(Matrix4x4 frameA, Matrix4x4 frameB)
		{
			btConeTwistConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(int limitIndex, float limitValue)
		{
			btConeTwistConstraint_setLimit(Native, limitIndex, limitValue);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLimit(float swingSpan1, float swingSpan2, float twistSpan,
			float softness = 1.0f, float biasFactor = 0.3f, float relaxationFactor = 1.0f)
		{
			btConeTwistConstraint_setLimit2(Native, swingSpan1, swingSpan2, twistSpan,
				softness, biasFactor, relaxationFactor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMaxMotorImpulseNormalized(float maxMotorImpulse)
		{
			btConeTwistConstraint_setMaxMotorImpulseNormalized(Native, maxMotorImpulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMotorTargetInConstraintSpace(Quaternion q)
		{
			btConeTwistConstraint_setMotorTargetInConstraintSpace(Native, ref q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateRhs(float timeStep)
		{
			btConeTwistConstraint_updateRHS(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 AFrame
		{
			get
			{
				Matrix4x4 value;
				btConeTwistConstraint_getAFrame(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AngularOnly
		{
			get => btConeTwistConstraint_getAngularOnly(Native);
			set => btConeTwistConstraint_setAngularOnly(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 BFrame
		{
			get
			{
				Matrix4x4 value;
				btConeTwistConstraint_getBFrame(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BiasFactor => btConeTwistConstraint_getBiasFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping
		{
			get => btConeTwistConstraint_getDamping(Native);
			set => btConeTwistConstraint_setDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float FixThresh
		{
			get => btConeTwistConstraint_getFixThresh(Native);
			set => btConeTwistConstraint_setFixThresh(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConeTwistFlags Flags => btConeTwistConstraint_getFlags(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetA
		{
			get
			{
				Matrix4x4 value;
				btConeTwistConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetB
		{
			get
			{
				Matrix4x4 value;
				btConeTwistConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsMaxMotorImpulseNormalized => btConeTwistConstraint_isMaxMotorImpulseNormalized(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsMotorEnabled => btConeTwistConstraint_isMotorEnabled(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsPastSwingLimit => btConeTwistConstraint_isPastSwingLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness => btConeTwistConstraint_getLimitSoftness(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxMotorImpulse
		{
			get => btConeTwistConstraint_getMaxMotorImpulse(Native);
			set => btConeTwistConstraint_setMaxMotorImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion MotorTarget
		{
			get
			{
				Quaternion value;
				btConeTwistConstraint_getMotorTarget(Native, out value);
				return value;
			}
			set => btConeTwistConstraint_setMotorTarget(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RelaxationFactor => btConeTwistConstraint_getRelaxationFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SolveSwingLimit => btConeTwistConstraint_getSolveSwingLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int SolveTwistLimit => btConeTwistConstraint_getSolveTwistLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SwingSpan1 => btConeTwistConstraint_getSwingSpan1(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SwingSpan2 => btConeTwistConstraint_getSwingSpan2(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TwistAngle => btConeTwistConstraint_getTwistAngle(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TwistLimitSign => btConeTwistConstraint_getTwistLimitSign(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TwistSpan => btConeTwistConstraint_getTwistSpan(Native);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConeTwistConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SwingSpan1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SwingSpan2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TwistSpan;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LimitSoftness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BiasFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RelaxationFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Damping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Pad;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConeTwistConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct ConeTwistConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double SwingSpan1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double SwingSpan2;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double TwistSpan;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LimitSoftness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double BiasFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double RelaxationFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double Damping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Pad;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(ConeTwistConstraintDoubleData), fieldName).ToInt32(); }
	}
}
