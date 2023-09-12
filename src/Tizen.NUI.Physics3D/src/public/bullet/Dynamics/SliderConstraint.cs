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
	public enum SliderFlags
	{
		None = 0,
		CfmDirLinear = 1,
		ErpDirLinear = 2,
		CfmDirAngular = 4,
		ErpDirAngular = 8,
		CfmOrthoLinear = 16,
		ErpOrthoLinear = 32,
		CfmOrthoAngular = 64,
		ErpOrthoAngular = 128,
		CfmLimitLinear = 512,
		ErpLimitLinear = 1024,
		CfmLimitAngular = 2048,
		ErpLimitAngular = 4096
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SliderConstraint : TypedConstraint
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public SliderConstraint(RigidBody rigidBodyA, RigidBody rigidBodyB, Matrix4x4 frameInA,
			Matrix4x4 frameInB, bool useLinearReferenceFrameA)
		{
			IntPtr native = btSliderConstraint_new(rigidBodyA.Native, rigidBodyB.Native,
				ref frameInA, ref frameInB, useLinearReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(rigidBodyA, rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SliderConstraint(RigidBody rigidBodyB, Matrix4x4 frameInB, bool useLinearReferenceFrameA)
		{
			IntPtr native = btSliderConstraint_new2(rigidBodyB.Native, ref frameInB, useLinearReferenceFrameA);
			InitializeUserOwned(native);
			InitializeMembers(GetFixedBody(), rigidBodyB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransformsRef(ref Matrix4x4 transA, ref Matrix4x4 transB)
		{
			btSliderConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTransforms(Matrix4x4 transA, Matrix4x4 transB)
		{
			btSliderConstraint_calculateTransforms(Native, ref transA, ref transB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			btSliderConstraint_getInfo1NonVirtual(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix4x4 transA, Matrix4x4 transB,
		 	global::System.Numerics.Vector3 linVelA, global::System.Numerics.Vector3 linVelB, float rbAinvMass, float rbBinvMass)
		{
			btSliderConstraint_getInfo2NonVirtual(Native, info.Native, ref transA,
				ref transB, ref linVelA, ref linVelB, rbAinvMass, rbBinvMass);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFramesRef(ref Matrix4x4 frameA, ref Matrix4x4 frameB)
		{
			btSliderConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetFrames(Matrix4x4 frameA, Matrix4x4 frameB)
		{
			btSliderConstraint_setFrames(Native, ref frameA, ref frameB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestAngularLimits()
		{
			btSliderConstraint_testAngLimits(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TestLinearLimits()
		{
			btSliderConstraint_testLinLimits(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AncorInA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSliderConstraint_getAncorInA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AncorInB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSliderConstraint_getAncorInB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDepth => btSliderConstraint_getAngDepth(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularPosition => btSliderConstraint_getAngularPos(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformA
		{
			get
			{
				Matrix4x4 value;
				btSliderConstraint_getCalculatedTransformA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CalculatedTransformB
		{
			get
			{
				Matrix4x4 value;
				btSliderConstraint_getCalculatedTransformB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingDirAngular
		{
			get => btSliderConstraint_getDampingDirAng(Native);
			set => btSliderConstraint_setDampingDirAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingDirLinear
		{
			get => btSliderConstraint_getDampingDirLin(Native);
			set => btSliderConstraint_setDampingDirLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingLimAngular
		{
			get => btSliderConstraint_getDampingLimAng(Native);
			set => btSliderConstraint_setDampingLimAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingLimLinear
		{
			get => btSliderConstraint_getDampingLimLin(Native);
			set => btSliderConstraint_setDampingLimLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingOrthoAngular
		{
			get => btSliderConstraint_getDampingOrthoAng(Native);
			set => btSliderConstraint_setDampingOrthoAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DampingOrthoLinear
		{
			get => btSliderConstraint_getDampingOrthoLin(Native);
			set => btSliderConstraint_setDampingOrthoLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SliderFlags Flags => btSliderConstraint_getFlags(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetA
		{
			get
			{
				Matrix4x4 value;
				btSliderConstraint_getFrameOffsetA(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 FrameOffsetB
		{
			get
			{
				Matrix4x4 value;
				btSliderConstraint_getFrameOffsetB(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDepth => btSliderConstraint_getLinDepth(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearPosition => btSliderConstraint_getLinearPos(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LowerAngularLimit
		{
			get => btSliderConstraint_getLowerAngLimit(Native);
			set => btSliderConstraint_setLowerAngLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LowerLinearLimit
		{
			get => btSliderConstraint_getLowerLinLimit(Native);
			set => btSliderConstraint_setLowerLinLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxAngMotorForce
		{
			get => btSliderConstraint_getMaxAngMotorForce(Native);
			set => btSliderConstraint_setMaxAngMotorForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxLinearMotorForce
		{
			get => btSliderConstraint_getMaxLinMotorForce(Native);
			set => btSliderConstraint_setMaxLinMotorForce(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool PoweredAngularMotor
		{
			get => btSliderConstraint_getPoweredAngMotor(Native);
			set => btSliderConstraint_setPoweredAngMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool PoweredLinearMotor
		{
			get => btSliderConstraint_getPoweredLinMotor(Native);
			set => btSliderConstraint_setPoweredLinMotor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionDirAngular
		{
			get => btSliderConstraint_getRestitutionDirAng(Native);
			set => btSliderConstraint_setRestitutionDirAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionDirLinear
		{
			get => btSliderConstraint_getRestitutionDirLin(Native);
			set => btSliderConstraint_setRestitutionDirLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionLimAngular
		{
			get => btSliderConstraint_getRestitutionLimAng(Native);
			set => btSliderConstraint_setRestitutionLimAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionLimLinear
		{
			get => btSliderConstraint_getRestitutionLimLin(Native);
			set => btSliderConstraint_setRestitutionLimLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionOrthoAngular
		{
			get => btSliderConstraint_getRestitutionOrthoAng(Native);
			set => btSliderConstraint_setRestitutionOrthoAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RestitutionOrthoLinear
		{
			get => btSliderConstraint_getRestitutionOrthoLin(Native);
			set => btSliderConstraint_setRestitutionOrthoLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessDirAngular
		{
			get => btSliderConstraint_getSoftnessDirAng(Native);
			set => btSliderConstraint_setSoftnessDirAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessDirLinear
		{
			get => btSliderConstraint_getSoftnessDirLin(Native);
			set => btSliderConstraint_setSoftnessDirLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessLimAngular
		{
			get => btSliderConstraint_getSoftnessLimAng(Native);
			set => btSliderConstraint_setSoftnessLimAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessLimLinear
		{
			get => btSliderConstraint_getSoftnessLimLin(Native);
			set => btSliderConstraint_setSoftnessLimLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessOrthoAngular
		{
			get => btSliderConstraint_getSoftnessOrthoAng(Native);
			set => btSliderConstraint_setSoftnessOrthoAng(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SoftnessOrthoLinear
		{
			get => btSliderConstraint_getSoftnessOrthoLin(Native);
			set => btSliderConstraint_setSoftnessOrthoLin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SolveAngularLimit => btSliderConstraint_getSolveAngLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SolveLinearLimit => btSliderConstraint_getSolveLinLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TargetAngularMotorVelocity
		{
			get => btSliderConstraint_getTargetAngMotorVelocity(Native);
			set => btSliderConstraint_setTargetAngMotorVelocity(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float TargetLinearMotorVelocity
		{
			get => btSliderConstraint_getTargetLinMotorVelocity(Native);
			set => btSliderConstraint_setTargetLinMotorVelocity(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpperAngularLimit
		{
			get => btSliderConstraint_getUpperAngLimit(Native);
			set => btSliderConstraint_setUpperAngLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float UpperLinearLimit
		{
			get => btSliderConstraint_getUpperLinLimit(Native);
			set => btSliderConstraint_setUpperLinLimit(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseFrameOffset
		{
			get => btSliderConstraint_getUseFrameOffset(Native);
			set => btSliderConstraint_setUseFrameOffset(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseLinearReferenceFrameA => btSliderConstraint_getUseLinearReferenceFrameA(Native);
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SliderConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintFloatData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseLinearReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseOffsetForConstraintFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(SliderConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SliderConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintDoubleData TypedConstraintData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyAFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData RigidBodyBFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LinearUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LinearLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AngularUpperLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AngularLowerLimit;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseLinearReferenceFrameA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseOffsetForConstraintFrame;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(SliderConstraintDoubleData), fieldName).ToInt32(); }
	}
}
