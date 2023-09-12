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
	public class RigidBodyConstructionInfo : BulletDisposableObject
	{
		private CollisionShape _collisionShape;
		private MotionState _motionState;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBodyConstructionInfo(float mass, MotionState motionState,
			CollisionShape collisionShape)
		{
			IntPtr native = btRigidBody_btRigidBodyConstructionInfo_new(mass, motionState != null ? motionState.Native : IntPtr.Zero,
				collisionShape != null ? collisionShape.Native : IntPtr.Zero);
			InitializeUserOwned(native);

			_collisionShape = collisionShape;
			_motionState = motionState;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RigidBodyConstructionInfo(float mass, MotionState motionState,
			CollisionShape collisionShape, global::System.Numerics.Vector3 localInertia)
		{
			IntPtr native = btRigidBody_btRigidBodyConstructionInfo_new2(mass, motionState != null ? motionState.Native : IntPtr.Zero,
				collisionShape != null ? collisionShape.Native : IntPtr.Zero, ref localInertia);
			InitializeUserOwned(native);

			_collisionShape = collisionShape;
			_motionState = motionState;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalAngularDampingFactor
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingFactor(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingFactor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalAngularDampingThresholdSqr
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalAngularDampingThresholdSqr(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalAngularDampingThresholdSqr(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AdditionalDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalDampingFactor
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalDampingFactor(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalDampingFactor(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AdditionalLinearDampingThresholdSqr
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAdditionalLinearDampingThresholdSqr(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAdditionalLinearDampingThresholdSqr(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAngularDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAngularDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularSleepingThreshold
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getAngularSleepingThreshold(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setAngularSleepingThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShape CollisionShape
		{
			get => _collisionShape;
			set
			{
				btRigidBody_btRigidBodyConstructionInfo_setCollisionShape(Native, value != null ? value.Native : IntPtr.Zero);
				_collisionShape = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getFriction(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearDamping
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getLinearDamping(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setLinearDamping(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LinearSleepingThreshold
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getLinearSleepingThreshold(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setLinearSleepingThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalInertia
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btRigidBody_btRigidBodyConstructionInfo_getLocalInertia(Native, out value);
				return value;
			}
			set => btRigidBody_btRigidBodyConstructionInfo_setLocalInertia(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Mass
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getMass(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setMass(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MotionState MotionState
		{
			get => _motionState;
			set
			{
				btRigidBody_btRigidBodyConstructionInfo_setMotionState(Native, value != null ? value.Native : IntPtr.Zero);
				_motionState = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Restitution
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getRestitution(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setRestitution(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RollingFriction
		{
			get => btRigidBody_btRigidBodyConstructionInfo_getRollingFriction(Native);
			set => btRigidBody_btRigidBodyConstructionInfo_setRollingFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 StartWorldTransform
		{
			get
			{
				Matrix4x4 value;
				btRigidBody_btRigidBodyConstructionInfo_getStartWorldTransform(Native, out value);
				return value;
			}
			set => btRigidBody_btRigidBodyConstructionInfo_setStartWorldTransform(Native, ref value);
		}

		protected override void Dispose(bool disposing)
		{
			btRigidBody_btRigidBodyConstructionInfo_delete(Native);
		}
	}
}
