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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum RigidBodyFlags
	{
		None = 0,
		DisableWorldGravity = 1,
		EnableGyroscopicForceExplicit = 2,
		EnableGyroscopicForceImplicitWorld = 4,
		EnableGyroscopicForceImplicitBody = 8,
		EnableGyroscopicForce = EnableGyroscopicForceImplicitBody
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RigidBody : CollisionObject
	{
		private MotionState _motionState;
		internal List<TypedConstraint> _constraintRefs;

		internal RigidBody(IntPtr native)
			: base(ConstructionInfo.Null)
		{
			InitializeSubObject(native, this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBody(RigidBodyConstructionInfo constructionInfo)
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btRigidBody_new(constructionInfo.Native);
			InitializeCollisionObject(native);

			_collisionShape = constructionInfo.CollisionShape;
			_motionState = constructionInfo.MotionState;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddConstraintRef(TypedConstraint constraint)
		{
			if (_constraintRefs == null)
			{
				_constraintRefs = new List<TypedConstraint>();
			}
			_constraintRefs.Add(constraint);
			btRigidBody_addConstraintRef(Native, constraint.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyCentralForceRef(ref global::System.Numerics.Vector3 force)
		{
			btRigidBody_applyCentralForce(Native, ref force);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyCentralForce(global::System.Numerics.Vector3 force)
		{
			btRigidBody_applyCentralForce(Native, ref force);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyCentralImpulseRef(ref global::System.Numerics.Vector3 impulse)
		{
			btRigidBody_applyCentralImpulse(Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyCentralImpulse(global::System.Numerics.Vector3 impulse)
		{
			btRigidBody_applyCentralImpulse(Native, ref impulse);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyDamping(float timeStep)
		{
			btRigidBody_applyDamping(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyForceRef(ref global::System.Numerics.Vector3 force, ref global::System.Numerics.Vector3 relPos)
		{
			btRigidBody_applyForce(Native, ref force, ref relPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyForce(global::System.Numerics.Vector3 force, global::System.Numerics.Vector3 relPos)
		{
			btRigidBody_applyForce(Native, ref force, ref relPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyGravity()
		{
			btRigidBody_applyGravity(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyImpulseRef(ref global::System.Numerics.Vector3 impulse, ref global::System.Numerics.Vector3 relPos)
		{
			btRigidBody_applyImpulse(Native, ref impulse, ref relPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyImpulse(global::System.Numerics.Vector3 impulse, global::System.Numerics.Vector3 relPos)
		{
			btRigidBody_applyImpulse(Native, ref impulse, ref relPos);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTorqueRef(ref global::System.Numerics.Vector3 torque)
		{
			btRigidBody_applyTorque(Native, ref torque);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTorque(global::System.Numerics.Vector3 torque)
		{
			btRigidBody_applyTorque(Native, ref torque);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTorqueImpulseRef(ref global::System.Numerics.Vector3 torque)
		{
			btRigidBody_applyTorqueImpulse(Native, ref torque);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ApplyTorqueImpulse(global::System.Numerics.Vector3 torque)
		{
			btRigidBody_applyTorqueImpulse(Native, ref torque);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearForces()
		{
			btRigidBody_clearForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearGravity()
		{
			btRigidBody_clearGravity(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ComputeAngularImpulseDenominator(ref global::System.Numerics.Vector3 axis, out float result)
		{
			result = btRigidBody_computeAngularImpulseDenominator(Native, ref axis);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ComputeAngularImpulseDenominator(global::System.Numerics.Vector3 axis)
		{
			return btRigidBody_computeAngularImpulseDenominator(Native, ref axis);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ComputeGyroscopicForceExplicit(float maxGyroscopicForce)
		{
		 	global::System.Numerics.Vector3 value;
			btRigidBody_computeGyroscopicForceExplicit(Native, maxGyroscopicForce,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ComputeGyroscopicImpulseImplicitBody(float step)
		{
		 	global::System.Numerics.Vector3 value;
			btRigidBody_computeGyroscopicImpulseImplicit_Body(Native, step, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ComputeGyroscopicImpulseImplicitWorld(float deltaTime)
		{
		 	global::System.Numerics.Vector3 value;
			btRigidBody_computeGyroscopicImpulseImplicit_World(Native, deltaTime,
				out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ComputeImpulseDenominator(global::System.Numerics.Vector3 pos, global::System.Numerics.Vector3 normal)
		{
			return btRigidBody_computeImpulseDenominator(Native, ref pos, ref normal);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabb(out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btRigidBody_getAabb(Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypedConstraint GetConstraintRef(int index)
		{
			global::System.Diagnostics.Debug.Assert(_constraintRefs != null);
			return _constraintRefs[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetVelocityInLocalPoint(ref global::System.Numerics.Vector3 relPos, out global::System.Numerics.Vector3 value)
		{
			btRigidBody_getVelocityInLocalPoint(Native, ref relPos, out value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetVelocityInLocalPoint(global::System.Numerics.Vector3 relPos)
		{
		 	global::System.Numerics.Vector3 value;
			btRigidBody_getVelocityInLocalPoint(Native, ref relPos, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void IntegrateVelocities(float step)
		{
			btRigidBody_integrateVelocities(Native, step);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictIntegratedTransform(float step, out Matrix4x4 predictedTransform)
		{
			btRigidBody_predictIntegratedTransform(Native, step, out predictedTransform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProceedToTransformRef(ref Matrix4x4 newTrans)
		{
			btRigidBody_proceedToTransform(Native, ref newTrans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProceedToTransform(Matrix4x4 newTrans)
		{
			btRigidBody_proceedToTransform(Native, ref newTrans);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveConstraintRef(TypedConstraint constraint)
		{
			if (_constraintRefs != null)
			{
				_constraintRefs.Remove(constraint);
				btRigidBody_removeConstraintRef(Native, constraint.Native);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SaveKinematicState(float step)
		{
			btRigidBody_saveKinematicState(Native, step);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetDamping(float linDamping, float angDamping)
		{
			btRigidBody_setDamping(Native, linDamping, angDamping);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMassPropsRef(float mass, ref global::System.Numerics.Vector3 inertia)
		{
			btRigidBody_setMassProps(Native, mass, ref inertia);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMassProps(float mass, global::System.Numerics.Vector3 inertia)
		{
			btRigidBody_setMassProps(Native, mass, ref inertia);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetNewBroadphaseProxy(BroadphaseProxy broadphaseProxy)
		{
			btRigidBody_setNewBroadphaseProxy(Native, broadphaseProxy.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetSleepingThresholds(float linear, float angular)
		{
			btRigidBody_setSleepingThresholds(Native, linear, angular);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void TranslateRef(ref global::System.Numerics.Vector3 v)
		{
			btRigidBody_translate(Native, ref v);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Translate(global::System.Numerics.Vector3 v)
		{
			btRigidBody_translate(Native, ref v);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static RigidBody Upcast(CollisionObject colObj)
		{
			return GetManaged(btRigidBody_upcast(colObj.Native)) as RigidBody;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateDeactivation(float timeStep)
		{
			btRigidBody_updateDeactivation(Native, timeStep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateInertiaTensor()
		{
			btRigidBody_updateInertiaTensor(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool WantsSleeping()
		{
			return btRigidBody_wantsSleeping(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDamping => btRigidBody_getAngularDamping(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularFactor
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getAngularFactor(Native, out value);
				return value;
			}
			set => btRigidBody_setAngularFactor(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularSleepingThreshold => btRigidBody_getAngularSleepingThreshold(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AngularVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getAngularVelocity(Native, out value);
				return value;
			}
			set => btRigidBody_setAngularVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseProxy BroadphaseProxy => BroadphaseProxy.GetManaged(btRigidBody_getBroadphaseProxy(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CenterOfMassPosition
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getCenterOfMassPosition(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 CenterOfMassTransform
		{
			get
			{
				Matrix4x4 value;
				btRigidBody_getCenterOfMassTransform(Native, out value);
				return value;
			}
			set => btRigidBody_setCenterOfMassTransform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ContactSolverType
		{
			get => btRigidBody_getContactSolverType(Native);
			set => btRigidBody_setContactSolverType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBodyFlags Flags
		{
			get => btRigidBody_getFlags(Native);
			set => btRigidBody_setFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FrictionSolverType
		{
			get => btRigidBody_getFrictionSolverType(Native);
			set => btRigidBody_setFrictionSolverType(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 Gravity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getGravity(Native, out value);
				return value;
			}
			set => btRigidBody_setGravity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 InvInertiaDiagLocal
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getInvInertiaDiagLocal(Native, out value);
				return value;
			}
			set => btRigidBody_setInvInertiaDiagLocal(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 InvInertiaTensorWorld
		{
			get
			{
				Matrix4x4 value;
				btRigidBody_getInvInertiaTensorWorld(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InvMass => btRigidBody_getInvMass(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsInWorld => btRigidBody_isInWorld(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDamping => btRigidBody_getLinearDamping(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearFactor
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getLinearFactor(Native, out value);
				return value;
			}
			set => btRigidBody_setLinearFactor(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearSleepingThreshold => btRigidBody_getLinearSleepingThreshold(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LinearVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getLinearVelocity(Native, out value);
				return value;
			}
			set => btRigidBody_setLinearVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalInertia
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getLocalInertia(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MotionState MotionState
		{
			get => _motionState;
			set
			{
				btRigidBody_setMotionState(Native, (value != null) ? value.Native : IntPtr.Zero);
				_motionState = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumConstraintRefs => (_constraintRefs != null) ? _constraintRefs.Count : 0;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion Orientation
		{
			get
			{
				Quaternion value;
				btRigidBody_getOrientation(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TotalForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_getTotalForce(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 TotalTorque
		{
			get
			{
				global::System.Numerics.Vector3 value;
				btRigidBody_getTotalTorque(Native, out value);
				return value;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RigidBodyFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectFloatData CollisionObjectData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix3x3FloatData InvInertiaTensorWorld;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AngularFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData LinearFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData Gravity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData GravityAcceleration;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData InvInertiaLocal;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData TotalForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData TotalTorque;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float InverseMass;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalDampingFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalLinearDampingThresholdSqr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalAngularDampingThresholdSqr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalAngularDampingFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearSleepingThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularSleepingThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AdditionalDamping;

		//public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(RigidBodyFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RigidBodyDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectDoubleData CollisionObjectData;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix3x3DoubleData InvInertiaTensorWorld;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AngularFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData LinearFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData Gravity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData GravityAcceleration;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData InvInertiaLocal;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData TotalForce;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData TotalTorque;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double InverseMass;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LinearDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AngularDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AdditionalDampingFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AdditionalLinearDampingThresholdSqr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AdditionalAngularDampingThresholdSqr;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AdditionalAngularDampingFactor;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double LinearSleepingThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double AngularSleepingThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AdditionalDamping;

		//public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(RigidBodyDoubleData), fieldName).ToInt32(); }
	}
}
