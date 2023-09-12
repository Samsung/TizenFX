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
	public enum ConstraintParam
	{
		Erp = 1,
		StopErp,
		Cfm,
		StopCfm
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum TypedConstraintType
	{
		Point2Point = 3,
		Hinge,
		ConeTwist,
		D6,
		Slider,
		Contact,
		D6Spring,
		Gear,
		Fixed,
		D6Spring2,
		Max
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class JointFeedback : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public JointFeedback()
		{
			IntPtr native = btJointFeedback_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedForceBodyA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btJointFeedback_getAppliedForceBodyA(Native, out value);
				return value;
			}
			set => btJointFeedback_setAppliedForceBodyA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedForceBodyB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btJointFeedback_getAppliedForceBodyB(Native, out value);
				return value;
			}
			set => btJointFeedback_setAppliedForceBodyB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedTorqueBodyA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btJointFeedback_getAppliedTorqueBodyA(Native, out value);
				return value;
			}
			set => btJointFeedback_setAppliedTorqueBodyA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AppliedTorqueBodyB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btJointFeedback_getAppliedTorqueBodyB(Native, out value);
				return value;
			}
			set => btJointFeedback_setAppliedTorqueBodyB(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btJointFeedback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class TypedConstraint : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class ConstraintInfo1 : BulletDisposableObject
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ConstraintInfo1()
			{
				IntPtr native = btTypedConstraint_btConstraintInfo1_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int Nub
			{
				get => btTypedConstraint_btConstraintInfo1_getNub(Native);
				set => btTypedConstraint_btConstraintInfo1_setNub(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int NumConstraintRows
			{
				get => btTypedConstraint_btConstraintInfo1_getNumConstraintRows(Native);
				set => btTypedConstraint_btConstraintInfo1_setNumConstraintRows(Native, value);
			}

			protected override void Dispose(bool disposing)
			{
				btTypedConstraint_btConstraintInfo1_delete(Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public class ConstraintInfo2 : BulletDisposableObject
		{
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ConstraintInfo2()
			{
				IntPtr native = btTypedConstraint_btConstraintInfo2_new();
				InitializeUserOwned(native);
			}
			/*
			public float Cfm
			{
				get { return btTypedConstraint_btConstraintInfo2_getCfm(Native); }
				set { btTypedConstraint_btConstraintInfo2_setCfm(Native, value.Native); }
			}

			public float ConstraintError
			{
				get { return btTypedConstraint_btConstraintInfo2_getConstraintError(Native); }
				set { btTypedConstraint_btConstraintInfo2_setConstraintError(Native, value.Native); }
			}
			*/
			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Damping
			{
				get => btTypedConstraint_btConstraintInfo2_getDamping(Native);
				set => btTypedConstraint_btConstraintInfo2_setDamping(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Erp
			{
				get => btTypedConstraint_btConstraintInfo2_getErp(Native);
				set => btTypedConstraint_btConstraintInfo2_setErp(Native, value);
			}
			/*
			public int Findex
			{
				get { return btTypedConstraint_btConstraintInfo2_getFindex(Native); }
				set { btTypedConstraint_btConstraintInfo2_setFindex(Native, value.Native); }
			}
			*/
			[EditorBrowsable(EditorBrowsableState.Never)]
			public float Fps
			{
				get => btTypedConstraint_btConstraintInfo2_getFps(Native);
				set => btTypedConstraint_btConstraintInfo2_setFps(Native, value);
			}
			/*
			public float J1angularAxis
			{
				get { return btTypedConstraint_btConstraintInfo2_getJ1angularAxis(Native); }
				set { btTypedConstraint_btConstraintInfo2_setJ1angularAxis(Native, value.Native); }
			}

			public float J1linearAxis
			{
				get { return btTypedConstraint_btConstraintInfo2_getJ1linearAxis(Native); }
				set { btTypedConstraint_btConstraintInfo2_setJ1linearAxis(Native, value.Native); }
			}

			public float J2angularAxis
			{
				get { return btTypedConstraint_btConstraintInfo2_getJ2angularAxis(Native); }
				set { btTypedConstraint_btConstraintInfo2_setJ2angularAxis(Native, value.Native); }
			}

			public float J2linearAxis
			{
				get { return btTypedConstraint_btConstraintInfo2_getJ2linearAxis(Native); }
				set { btTypedConstraint_btConstraintInfo2_setJ2linearAxis(Native, value.Native); }
			}

			public float LowerLimit
			{
				get { return btTypedConstraint_btConstraintInfo2_getLowerLimit(Native); }
				set { btTypedConstraint_btConstraintInfo2_setLowerLimit(Native, value.Native); }
			}
			*/
			[EditorBrowsable(EditorBrowsableState.Never)]
			public int NumIterations
			{
				get => btTypedConstraint_btConstraintInfo2_getNumIterations(Native);
				set => btTypedConstraint_btConstraintInfo2_setNumIterations(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int Rowskip
			{
				get => btTypedConstraint_btConstraintInfo2_getRowskip(Native);
				set => btTypedConstraint_btConstraintInfo2_setRowskip(Native, value);
			}
			/*
			public float UpperLimit
			{
				get { return btTypedConstraint_btConstraintInfo2_getUpperLimit(Native); }
				set { btTypedConstraint_btConstraintInfo2_setUpperLimit(Native, value.Native); }
			}
			*/
			protected override void Dispose(bool disposing)
			{
				btTypedConstraint_btConstraintInfo2_delete(Native);
			}
		}

		private JointFeedback _jointFeedback;

		private static RigidBody _fixedBody;

		protected internal TypedConstraint()
		{
		}

		protected internal void InitializeMembers(RigidBody rigidBodyA, RigidBody rigidBodyB)
		{
			RigidBodyA = rigidBodyA;
			RigidBodyB = rigidBodyB;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BuildJacobian()
		{
			btTypedConstraint_buildJacobian(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btTypedConstraint_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void EnableFeedback(bool needsFeedback)
		{
			btTypedConstraint_enableFeedback(Native, needsFeedback);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static RigidBody GetFixedBody()
		{
			if (_fixedBody == null)
			{
				_fixedBody = new RigidBody(btTypedConstraint_getFixedBody());
			}
			return _fixedBody;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo1(ConstraintInfo1 info)
		{
			btTypedConstraint_getInfo1(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetInfo2(ConstraintInfo2 info)
		{
			btTypedConstraint_getInfo2(Native, info.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetParam(ConstraintParam num)
		{
			return btTypedConstraint_getParam(Native, num);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetParam(ConstraintParam num, int axis)
		{
			return btTypedConstraint_getParam2(Native, num, axis);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InternalGetAppliedImpulse()
		{
			return btTypedConstraint_internalGetAppliedImpulse(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InternalSetAppliedImpulse(float appliedImpulse)
		{
			btTypedConstraint_internalSetAppliedImpulse(Native, appliedImpulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetParam(ConstraintParam num, float value)
		{
			btTypedConstraint_setParam(Native, num, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetParam(ConstraintParam num, float value, int axis)
		{
			btTypedConstraint_setParam2(Native, num, value, axis);
		}
		/*
		public void SetupSolverConstraint(btAlignedObjectArray<btSolverConstraint> ca,
			int solverBodyA, int solverBodyB, float timeStep)
		{
			btTypedConstraint_setupSolverConstraint(_native, ca._native, solverBodyA,
				solverBodyB, timeStep);
		}

		public void SolveConstraintObsolete(SolverBody __unnamed0, SolverBody __unnamed1,
			float __unnamed2)
		{
			btTypedConstraint_solveConstraintObsolete(_native, __unnamed0._native,
				__unnamed1._native, __unnamed2);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulse => btTypedConstraint_getAppliedImpulse(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BreakingImpulseThreshold
		{
			get => btTypedConstraint_getBreakingImpulseThreshold(Native);
			set => btTypedConstraint_setBreakingImpulseThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraintType ConstraintType => btTypedConstraint_getConstraintType(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DebugDrawSize
		{
			get => btTypedConstraint_getDbgDrawSize(Native);
			set => btTypedConstraint_setDbgDrawSize(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsEnabled
		{
			get => btTypedConstraint_isEnabled(Native);
			set => btTypedConstraint_setEnabled(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public JointFeedback JointFeedback
		{
			get => _jointFeedback;
			set
			{
				btTypedConstraint_setJointFeedback(Native, value != null ? value.Native : IntPtr.Zero);
				_jointFeedback = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsFeedback => btTypedConstraint_needsFeedback(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int OverrideNumSolverIterations
		{
			get => btTypedConstraint_getOverrideNumSolverIterations(Native);
			set => btTypedConstraint_setOverrideNumSolverIterations(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBody RigidBodyA { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBody RigidBodyB { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Uid => btTypedConstraint_getUid(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintId
		{
			get => btTypedConstraint_getUserConstraintId(Native);
			set => btTypedConstraint_setUserConstraintId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object Userobject { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintType
		{
			get => btTypedConstraint_getUserConstraintType(Native);
			set => btTypedConstraint_setUserConstraintType(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			btTypedConstraint_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AngularLimit : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public AngularLimit()
		{
			IntPtr native = btAngularLimit_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fit(ref float angle)
		{
			btAngularLimit_fit(Native, ref angle);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Set(float low, float high, float softness = 0.9f, float biasFactor = 0.3f,
			float relaxationFactor = 1.0f)
		{
			btAngularLimit_set(Native, low, high, softness, biasFactor, relaxationFactor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Test(float angle)
		{
			btAngularLimit_test(Native, angle);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BiasFactor => btAngularLimit_getBiasFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Correction => btAngularLimit_getCorrection(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Error => btAngularLimit_getError(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HalfRange => btAngularLimit_getHalfRange(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float High => btAngularLimit_getHigh(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsLimit => btAngularLimit_isLimit(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Low => btAngularLimit_getLow(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RelaxationFactor => btAngularLimit_getRelaxationFactor(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Sign => btAngularLimit_getSign(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Softness => btAngularLimit_getSoftness(Native);

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btAngularLimit_delete(Native);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct TypedConstraintFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RigidBodyA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RigidBodyB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Name;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ObjectType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NeedsFeedback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulse;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DebugDrawSize;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DisableCollisionsBetweenLinkedBodies;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int OverrideNumSolverIterations;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BreakingImpulseThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IsEnabled;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(TypedConstraintFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct TypedConstraintDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RigidBodyA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RigidBodyB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Name;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ObjectType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserConstraintId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NeedsFeedback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AppliedImpulse;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double DebugDrawSize;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DisableCollisionsBetweenLinkedBodies;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int OverrideNumSolverIterations;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double BreakingImpulseThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IsEnabled;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(TypedConstraintDoubleData), fieldName).ToInt32(); }
	}
}
