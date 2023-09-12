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
	public class MultiBody : BulletDisposableObject
	{
		private MultiBodyLink[] _links;

		internal MultiBody(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBody(int nLinks, float mass, global::System.Numerics.Vector3 inertia, bool fixedBase,
			bool canSleep)
		{
			IntPtr native = btMultiBody_new(nLinks, mass, ref inertia, fixedBase, canSleep);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddBaseConstraintForce(global::System.Numerics.Vector3 f)
		{
			btMultiBody_addBaseConstraintForce(Native, ref f);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddBaseConstraintTorque(global::System.Numerics.Vector3 t)
		{
			btMultiBody_addBaseConstraintTorque(Native, ref t);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddBaseForce(global::System.Numerics.Vector3 f)
		{
			btMultiBody_addBaseForce(Native, ref f);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddBaseTorque(global::System.Numerics.Vector3 t)
		{
			btMultiBody_addBaseTorque(Native, ref t);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddJointTorque(int i, float q)
		{
			btMultiBody_addJointTorque(Native, i, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddJointTorqueMultiDof(int i, float[] q)
		{
			btMultiBody_addJointTorqueMultiDof(Native, i, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddJointTorqueMultiDof(int i, int dof, float q)
		{
			btMultiBody_addJointTorqueMultiDof2(Native, i, dof, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddLinkConstraintForce(int i, global::System.Numerics.Vector3 f)
		{
			btMultiBody_addLinkConstraintForce(Native, i, ref f);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddLinkConstraintTorque(int i, global::System.Numerics.Vector3 t)
		{
			btMultiBody_addLinkConstraintTorque(Native, i, ref t);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddLinkForce(int i, global::System.Numerics.Vector3 f)
		{
			btMultiBody_addLinkForce(Native, i, ref f);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddLinkTorque(int i, global::System.Numerics.Vector3 t)
		{
			btMultiBody_addLinkTorque(Native, i, ref t);
		}
		/*

		public void ApplyDeltaVeeMultiDof(float deltaVee, float multiplier)
		{
			btMultiBody_applyDeltaVeeMultiDof(Native, deltaVee.Native, multiplier);
		}

		public void ApplyDeltaVeeMultiDof2(float deltaVee, float multiplier)
		{
			btMultiBody_applyDeltaVeeMultiDof2(Native, deltaVee.Native, multiplier);
		}

		public void CalcAccelerationDeltasMultiDof(float force, float output, AlignedObjectArray<float> scratchR,
			AlignedObjectArray<btVector3> scratchV)
		{
			btMultiBody_calcAccelerationDeltasMultiDof(Native, force.Native, output.Native,
				scratchR.Native, scratchV.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btMultiBody_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CheckMotionAndSleepIfRequired(float timestep)
		{
			btMultiBody_checkMotionAndSleepIfRequired(Native, timestep);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearConstraintForces()
		{
			btMultiBody_clearConstraintForces(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearForcesAndTorques()
		{
			btMultiBody_clearForcesAndTorques(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearVelocities()
		{
			btMultiBody_clearVelocities(Native);
		}
		/*
		public void ComputeAccelerationsArticulatedBodyAlgorithmMultiDof(float deltaTime,
			AlignedObjectArray<float> scratchR, AlignedObjectArray<btVector3> scratchV,
			AlignedObjectArray<btMatrix3x3> scratchM, bool isConstraintPass = false)
		{
			btMultiBody_computeAccelerationsArticulatedBodyAlgorithmMultiDof(Native,
				deltaTime, scratchR.Native, scratchV.Native, scratchM.Native, isConstraintPass);
		}

		public void FillConstraintJacobianMultiDof(int link, global::System.Numerics.Vector3 contactPoint,
		 	global::System.Numerics.Vector3 normalAng, global::System.Numerics.Vector3 normalLin, float jac, AlignedObjectArray<float> scratchR,
			AlignedObjectArray<btVector3> scratchV, AlignedObjectArray<btMatrix3x3> scratchM)
		{
			btMultiBody_fillConstraintJacobianMultiDof(Native, link, ref contactPoint,
				ref normalAng, ref normalLin, jac.Native, scratchR.Native, scratchV.Native,
				scratchM.Native);
		}

		public void FillContactJacobianMultiDof(int link, global::System.Numerics.Vector3 contactPoint, global::System.Numerics.Vector3 normal,
			float jac, AlignedObjectArray<float> scratchR, AlignedObjectArray<btVector3> scratchV,
			AlignedObjectArray<btMatrix3x3> scratchM)
		{
			btMultiBody_fillContactJacobianMultiDof(Native, link, ref contactPoint,
				ref normal, jac.Native, scratchR.Native, scratchV.Native, scratchM.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void FinalizeMultiDof()
		{
			btMultiBody_finalizeMultiDof(Native);
		}
		/*
		public void ForwardKinematics(btAlignedObjectArray<btQuaternion> scratchQ,
			AlignedObjectArray<btVector3> scratchM)
		{
			btMultiBody_forwardKinematics(Native, scratchQ.Native, scratchM.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion GetInterpolateParentToLocalRot(int i)
		{
			Quaternion value;
			btMultiBody_getInterpolateParentToLocalRot(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetInterpolateRVector(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_getInterpolateRVector(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetJointPos(int i)
		{
			return btMultiBody_getJointPos(Native, i);
		}
		/*
		public float GetJointPosMultiDof(int i)
		{
			return btMultiBody_getJointPosMultiDof(Native, i);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetJointTorque(int i)
		{
			return btMultiBody_getJointTorque(Native, i);
		}
		/*
		public float GetJointTorqueMultiDof(int i)
		{
			return btMultiBody_getJointTorqueMultiDof(Native, i);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetJointVel(int i)
		{
			return btMultiBody_getJointVel(Native, i);
		}
		/*
		public float GetJointVelMultiDof(int i)
		{
			return btMultiBody_getJointVelMultiDof(Native, i);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyLink GetLink(int index)
		{
			if (_links == null) {
				_links = new MultiBodyLink[NumLinks];
			}
			if (_links[index] == null) {
				_links[index] = new MultiBodyLink(btMultiBody_getLink(Native, index));
			}
			return _links[index];
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetLinkForce(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_getLinkForce(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetLinkInertia(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_getLinkInertia(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetLinkMass(int i)
		{
			return btMultiBody_getLinkMass(Native, i);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetLinkTorque(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_getLinkTorque(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetParent(int linkNum)
		{
			return btMultiBody_getParent(Native, linkNum);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion GetParentToLocalRot(int i)
		{
			Quaternion value;
			btMultiBody_getParentToLocalRot(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 GetRVector(int i)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_getRVector(Native, i, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GoToSleep()
		{
			btMultiBody_goToSleep(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InternalNeedsJointFeedback()
		{
			return btMultiBody_internalNeedsJointFeedback(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalDirToWorld(int i, global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_localDirToWorld(Native, i, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 LocalFrameToWorld(int i, Matrix4x4 mat)
		{
			Matrix4x4 value;
			btMultiBody_localFrameToWorld(Native, i, ref mat, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalPosToWorld(int i, global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_localPosToWorld(Native, i, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PredictPositionsMultiDof(float deltaTime)
		{
			btMultiBody_predictPositionsMultiDof(deltaTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessDeltaVeeMultiDof2()
		{
			btMultiBody_processDeltaVeeMultiDof2(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetJointPos(int i, float q)
		{
			btMultiBody_setJointPos(Native, i, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetJointPosMultiDof(int i, float[] q)
		{
			btMultiBody_setJointPosMultiDof(Native, i, q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetJointVel(int i, float qdot)
		{
			btMultiBody_setJointVel(Native, i, qdot);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetJointVelMultiDof(int i, float[] qdot)
		{
			btMultiBody_setJointVelMultiDof(Native, i, qdot);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPosUpdated(bool updated)
		{
			btMultiBody_setPosUpdated(Native, updated);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetupFixed(int linkIndex, float mass, global::System.Numerics.Vector3 inertia, int parent,
			Quaternion rotParentToThis, global::System.Numerics.Vector3 parentComToThisPivotOffset, global::System.Numerics.Vector3 thisPivotToThisComOffset,
			bool deprecatedDisableParentCollision = true)
		{
			btMultiBody_setupFixed(Native, linkIndex, mass, ref inertia, parent,
				ref rotParentToThis, ref parentComToThisPivotOffset, ref thisPivotToThisComOffset,
				deprecatedDisableParentCollision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetupPlanar(int i, float mass, global::System.Numerics.Vector3 inertia, int parent, Quaternion rotParentToThis,
		 	global::System.Numerics.Vector3 rotationAxis, global::System.Numerics.Vector3 parentComToThisComOffset, bool disableParentCollision = false)
		{
			btMultiBody_setupPlanar(Native, i, mass, ref inertia, parent, ref rotParentToThis,
				ref rotationAxis, ref parentComToThisComOffset, disableParentCollision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetupPrismatic(int i, float mass, global::System.Numerics.Vector3 inertia, int parent,
			Quaternion rotParentToThis, global::System.Numerics.Vector3 jointAxis, global::System.Numerics.Vector3 parentComToThisPivotOffset,
		 	global::System.Numerics.Vector3 thisPivotToThisComOffset, bool disableParentCollision)
		{
			btMultiBody_setupPrismatic(Native, i, mass, ref inertia, parent, ref rotParentToThis,
				ref jointAxis, ref parentComToThisPivotOffset, ref thisPivotToThisComOffset,
				disableParentCollision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetupRevolute(int linkIndex, float mass, global::System.Numerics.Vector3 inertia, int parentIndex,
			Quaternion rotParentToThis, global::System.Numerics.Vector3 jointAxis, global::System.Numerics.Vector3 parentComToThisPivotOffset,
		 	global::System.Numerics.Vector3 thisPivotToThisComOffset, bool disableParentCollision = false)
		{
			btMultiBody_setupRevolute(Native, linkIndex, mass, ref inertia, parentIndex,
				ref rotParentToThis, ref jointAxis, ref parentComToThisPivotOffset,
				ref thisPivotToThisComOffset, disableParentCollision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetupSpherical(int linkIndex, float mass, global::System.Numerics.Vector3 inertia, int parent,
			Quaternion rotParentToThis, global::System.Numerics.Vector3 parentComToThisPivotOffset, global::System.Numerics.Vector3 thisPivotToThisComOffset,
			bool disableParentCollision = false)
		{
			btMultiBody_setupSpherical(Native, linkIndex, mass, ref inertia, parent,
				ref rotParentToThis, ref parentComToThisPivotOffset, ref thisPivotToThisComOffset,
				disableParentCollision);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void StepPositionsMultiDof(float deltaTime, float[] pq = null, float[] pqd = null)
		{
			btMultiBody_stepPositionsMultiDof(Native, deltaTime, pq, pqd);
		}
		/*
		public void UpdateCollisionObjectWorldTransforms(btAlignedObjectArray<btQuaternion> scratchQ,
			AlignedObjectArray<btVector3> scratchM)
		{
			btMultiBody_updateCollisionObjectWorldTransforms(Native, scratchQ.Native,
				scratchM.Native);
		}

		public void btMultiBody_updateCollisionObjectWorldTransforms(MultiBody obj, btAlignedObjectArray<btQuaternion> worldToLocal,
			AlignedVector3Array localOrigin)
		{
			btMultiBody_updateCollisionObjectWorldTransforms(Native, worldToLocal.Native,
				localOrigin.Native);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void WakeUp()
		{
			btMultiBody_wakeUp(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 WorldDirToLocal(int i, global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_worldDirToLocal(Native, i, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 WorldPosToLocal(int i, global::System.Numerics.Vector3 vec)
		{
		 	global::System.Numerics.Vector3 value;
			btMultiBody_worldPosToLocal(Native, i, ref vec, out value);
			return value;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDamping
		{
			get => btMultiBody_getAngularDamping(Native);
			set => btMultiBody_setAngularDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiBodyLinkCollider BaseCollider
		{
			get => CollisionObject.GetManaged(btMultiBody_getBaseCollider(Native)) as MultiBodyLinkCollider;
			set => btMultiBody_setBaseCollider(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BaseForce
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBaseForce(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BaseInertia
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBaseInertia(Native, out value);
				return value;
			}
			set => btMultiBody_setBaseInertia(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float BaseMass
		{
			get => btMultiBody_getBaseMass(Native);
			set => btMultiBody_setBaseMass(Native, value);
		}
		/*
		public char BaseName
		{
			get { return btMultiBody_getBaseName(Native); }
			set { btMultiBody_setBaseName(Native, value.Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BaseOmega
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBaseOmega(Native, out value);
				return value;
			}
			set => btMultiBody_setBaseOmega(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BasePosition
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBasePos(Native, out value);
				return value;
			}
			set => btMultiBody_setBasePos(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BaseTorque
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBaseTorque(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 BaseVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getBaseVel(Native, out value);
				return value;
			}
			set => btMultiBody_setBaseVel(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 BaseWorldTransform
		{
			get
			{
				Matrix4x4 value;
				btMultiBody_getBaseWorldTransform(Native, out value);
				return value;
			}
			set => btMultiBody_setBaseWorldTransform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CanSleep
		{
			get => btMultiBody_getCanSleep(Native);
			set => btMultiBody_setCanSleep(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionId
		{
			get => btMultiBody_getCompanionId(Native);
			set => btMultiBody_setCompanionId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasFixedBase
		{
			get => btMultiBody_hasFixedBase(Native);
			set => btMultiBody_setFixedBase(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasSelfCollision
		{
			get => btMultiBody_hasSelfCollision(Native);
			set => btMultiBody_setHasSelfCollision(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 InterpolateBasePosition
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btMultiBody_getInterpolateBasePos(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsAwake => btMultiBody_isAwake(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsPosUpdated => btMultiBody_isPosUpdated(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsUsingGlobalVelocities
		{
			get => btMultiBody_isUsingGlobalVelocities(Native);
			set => btMultiBody_useGlobalVelocities(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsUsingRK4Integration
		{
			get => btMultiBody_isUsingRK4Integration(Native);
			set => btMultiBody_useRK4Integration(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDamping
		{
			get => btMultiBody_getLinearDamping(Native);
			set => btMultiBody_setLinearDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxAppliedImpulse
		{
			get => btMultiBody_getMaxAppliedImpulse(Native);
			set => btMultiBody_setMaxAppliedImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxCoordinateVelocity
		{
			get => btMultiBody_getMaxCoordinateVelocity(Native);
			set => btMultiBody_setMaxCoordinateVelocity(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumDofs => btMultiBody_getNumDofs(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumLinks
		{
			get => btMultiBody_getNumLinks(Native);
			set
			{
				btMultiBody_setNumLinks(Native, value);
				if (_links != null)
				{
					Array.Resize(ref _links, value);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumPosVars => btMultiBody_getNumPosVars(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseGyroTerm
		{
			get => btMultiBody_getUseGyroTerm(Native);
			set => btMultiBody_setUseGyroTerm(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserIndex
		{
			get => btMultiBody_getUserIndex(Native);
			set => btMultiBody_setUserIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserIndex2
		{
			get => btMultiBody_getUserIndex2(Native);
			set => btMultiBody_setUserIndex2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr UserPointer
		{
			get => btMultiBody_getUserPointer(Native);
			set => btMultiBody_setUserPointer(Native, value);
		}
		/*
		public float VelocityVector
		{
			get { return btMultiBody_getVelocityVector(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Quaternion WorldToBaseRot
		{
			get
			{
				Quaternion value;
				btMultiBody_getWorldToBaseRot(Native, out value);
				return value;
			}
			set => btMultiBody_setWorldToBaseRot(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btMultiBody_delete(Native);
		}
	}
}
