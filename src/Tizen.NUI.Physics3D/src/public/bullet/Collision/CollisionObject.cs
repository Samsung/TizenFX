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
	public enum ActivationState
	{
		Undefined = 0,
		ActiveTag = 1,
		IslandSleeping = 2,
		WantsDeactivation = 3,
		DisableDeactivation = 4,
		DisableSimulation = 5
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum AnisotropicFrictionFlags
	{
		FrictionDisabled = 0,
		Friction = 1,
		RollingFriction = 2
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CollisionFlags
	{
		None = 0,
		StaticObject = 1,
		KinematicObject = 2,
		NoContactResponse = 4,
		CustomMaterialCallback = 8,
		CharacterObject = 16,
		DisableVisualizeObject = 32,
		DisableSpuCollisionProcessing = 64,
		HasContactStiffnessDamping = 128,
		HasCustomDebugRenderingColor = 256,
		HasFrictionAnchor = 512,
		HasCollisionSoundTrigger = 1024
	}

	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CollisionObjectTypes
	{
		None = 0,
		CollisionObject = 1,
		RigidBody = 2,
		GhostObject = 4,
		SoftBody = 8,
		HFFluid = 16,
		UserType = 32,
		FeatherstoneLink = 64
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CollisionObject : BulletDisposableObject
	{
		private BroadphaseProxy _broadphaseHandle;
		protected CollisionShape _collisionShape;

		internal static CollisionObject GetManaged(IntPtr obj)
		{
			if (obj == IntPtr.Zero)
			{
				return null;
			}

			IntPtr userPtr = btCollisionObject_getUserPointer(obj);
			if (userPtr != IntPtr.Zero)
			{
				return GCHandle.FromIntPtr(userPtr).Target as CollisionObject;
			}

			throw new InvalidOperationException("Unknown collision object!");
		}

		internal CollisionObject(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject()
		{
			IntPtr native = btCollisionObject_new();
			InitializeCollisionObject(native);
		}

		protected internal void InitializeCollisionObject(IntPtr native)
		{
			InitializeUserOwned(native);

			GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
			btCollisionObject_setUserPointer(Native, GCHandle.ToIntPtr(handle));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Activate(bool forceActivation = false)
		{
			btCollisionObject_activate(Native, forceActivation);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btCollisionObject_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckCollideWith(CollisionObject co)
		{
			return btCollisionObject_checkCollideWith(Native, co.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CheckCollideWithOverride(CollisionObject co)
		{
			return btCollisionObject_checkCollideWithOverride(Native, co.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ForceActivationState(ActivationState newState)
		{
			btCollisionObject_forceActivationState(Native, newState);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool GetCustomDebugColor(out global::System.Numerics.Vector3 colorRgb)
		{
			return btCollisionObject_getCustomDebugColor(Native, out colorRgb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetWorldTransform(out Matrix4x4 transform)
		{
			btCollisionObject_getWorldTransform(Native, out transform);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasAnisotropicFriction(AnisotropicFrictionFlags frictionMode = AnisotropicFrictionFlags.Friction)
		{
			return btCollisionObject_hasAnisotropicFriction(Native, frictionMode);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr InternalGetExtensionPointer()
		{
			return btCollisionObject_internalGetExtensionPointer(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void InternalSetExtensionPointer(IntPtr pointer)
		{
			btCollisionObject_internalSetExtensionPointer(Native, pointer);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool MergesSimulationIslands()
		{
			return btCollisionObject_mergesSimulationIslands(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveCustomDebugColor()
		{
			btCollisionObject_removeCustomDebugColor(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAnisotropicFrictionRef(ref global::System.Numerics.Vector3 anisotropicFriction,
			AnisotropicFrictionFlags frictionMode = AnisotropicFrictionFlags.Friction)
		{
			btCollisionObject_setAnisotropicFriction(Native, ref anisotropicFriction, frictionMode);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAnisotropicFriction(global::System.Numerics.Vector3 anisotropicFriction,
			AnisotropicFrictionFlags frictionMode = AnisotropicFrictionFlags.Friction)
		{
			btCollisionObject_setAnisotropicFriction(Native, ref anisotropicFriction,
				frictionMode);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetContactStiffnessAndDamping(float stiffness, float damping)
		{
			btCollisionObject_setContactStiffnessAndDamping(Native, stiffness, damping);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetCustomDebugColor(global::System.Numerics.Vector3 colorRgb)
		{
			btCollisionObject_setCustomDebugColor(Native, ref colorRgb);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetIgnoreCollisionCheck(CollisionObject co, bool ignoreCollisionCheck)
		{
			btCollisionObject_setIgnoreCollisionCheck(Native, co.Native, ignoreCollisionCheck);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ActivationState ActivationState
		{
			get => btCollisionObject_getActivationState(Native);
			set => btCollisionObject_setActivationState(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AnisotropicFriction
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionObject_getAnisotropicFriction(Native, out value);
				return value;
			}
			set => btCollisionObject_setAnisotropicFriction(Native, ref value, AnisotropicFrictionFlags.Friction);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseProxy BroadphaseHandle
		{
			get => _broadphaseHandle;
			set
			{
				btCollisionObject_setBroadphaseHandle(Native, (value != null) ? value.Native : IntPtr.Zero);
				_broadphaseHandle = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CcdMotionThreshold
		{
			get => btCollisionObject_getCcdMotionThreshold(Native);
			set => btCollisionObject_setCcdMotionThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CcdSquareMotionThreshold => btCollisionObject_getCcdSquareMotionThreshold(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CcdSweptSphereRadius
		{
			get => btCollisionObject_getCcdSweptSphereRadius(Native);
			set => btCollisionObject_setCcdSweptSphereRadius(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionFlags CollisionFlags
		{
			get => btCollisionObject_getCollisionFlags(Native);
			set => btCollisionObject_setCollisionFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionShape CollisionShape
		{
			get => _collisionShape;
			set
			{
				btCollisionObject_setCollisionShape(Native, value.Native);
				_collisionShape = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionId
		{
			get => btCollisionObject_getCompanionId(Native);
			set => btCollisionObject_setCompanionId(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactDamping => btCollisionObject_getContactDamping(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactProcessingThreshold
		{
			get => btCollisionObject_getContactProcessingThreshold(Native);
			set => btCollisionObject_setContactProcessingThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactStiffness => btCollisionObject_getContactStiffness(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DeactivationTime
		{
			get => btCollisionObject_getDeactivationTime(Native);
			set => btCollisionObject_setDeactivationTime(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction
		{
			get => btCollisionObject_getFriction(Native);
			set => btCollisionObject_setFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasContactResponse => btCollisionObject_hasContactResponse(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HitFraction
		{
			get => btCollisionObject_getHitFraction(Native);
			set => btCollisionObject_setHitFraction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObjectTypes InternalType => btCollisionObject_getInternalType(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 InterpolationAngularVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionObject_getInterpolationAngularVelocity(Native, out value);
				return value;
			}
			set => btCollisionObject_setInterpolationAngularVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 InterpolationLinearVelocity
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionObject_getInterpolationLinearVelocity(Native, out value);
				return value;
			}
			set => btCollisionObject_setInterpolationLinearVelocity(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 InterpolationWorldTransform
		{
			get
			{
				Matrix4x4 value;
				btCollisionObject_getInterpolationWorldTransform(Native, out value);
				return value;
			}
			set => btCollisionObject_setInterpolationWorldTransform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsActive => btCollisionObject_isActive(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsKinematicObject => btCollisionObject_isKinematicObject(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IslandTag
		{
			get => btCollisionObject_getIslandTag(Native);
			set => btCollisionObject_setIslandTag(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsStaticObject => btCollisionObject_isStaticObject(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsStaticOrKinematicObject => btCollisionObject_isStaticOrKinematicObject(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Restitution
		{
			get => btCollisionObject_getRestitution(Native);
			set => btCollisionObject_setRestitution(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RollingFriction
		{
			get => btCollisionObject_getRollingFriction(Native);
			set => btCollisionObject_setRollingFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float SpinningFriction
		{
			get => btCollisionObject_getSpinningFriction(Native);
			set => btCollisionObject_setSpinningFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object UserObject { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserIndex
		{
			get => btCollisionObject_getUserIndex(Native);
			set => btCollisionObject_setUserIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserIndex2
		{
			get => btCollisionObject_getUserIndex2(Native);
			set => btCollisionObject_setUserIndex2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int WorldArrayIndex
		{
			get => btCollisionObject_getWorldArrayIndex(Native);
			set => btCollisionObject_setWorldArrayIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Matrix4x4 WorldTransform
		{
			get
			{
				Matrix4x4 value;
				btCollisionObject_getWorldTransform(Native, out value);
				return value;
			}
			set => btCollisionObject_setWorldTransform(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			CollisionObject colObj = obj as CollisionObject;
			if (colObj == null)
			{
				return false;
			}
			return Native == colObj.Native;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return Native.GetHashCode();
		}

		protected internal void FreeUnmanagedHandle()
		{
			IntPtr userPtr = btCollisionObject_getUserPointer(Native);
			GCHandle.FromIntPtr(userPtr).Free();
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				// Is the object added to a world?
				if (btCollisionObject_getBroadphaseHandle(Native) != IntPtr.Zero)
				{
					BroadphaseHandle = null;
					return;
				}

				FreeUnmanagedHandle();

				btCollisionObject_delete(Native);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CollisionObjectFloatData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr BroadphaseHandle;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr CollisionShape;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RootCollisionShape;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Name;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData WorldTransform;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformFloatData InterpolationWorldTransform;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData InterpolationLinearVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData InterpolationAngularVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3FloatData AnisotropicFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactProcessingThreshold;	

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float DeactivationTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Friction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float RollingFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Restitution;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float HitFraction; 

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CcdSweptSphereRadius;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CcdMotionThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HasAnisotropicFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFlags;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IslandTag1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ActivationState1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int InternalType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CheckCollideWith;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterGroup;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterMask;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UniqueId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CollisionObjectFloatData), fieldName).ToInt32(); }
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CollisionObjectDoubleData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr BroadphaseHandle;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr CollisionShape;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr RootCollisionShape;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Name;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData WorldTransform;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TransformDoubleData InterpolationWorldTransform;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData InterpolationLinearVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData InterpolationAngularVelocity;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Vector3DoubleData AnisotropicFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double ContactProcessingThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double DeactivationTime;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double Friction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double RollingFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double ContactDamping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double ContactStiffness;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double Restitution;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double HitFraction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double CcdSweptSphereRadius;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public double CcdMotionThreshold;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int HasAnisotropicFriction;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFlags;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int IslandTag1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ActivationState1;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int InternalType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CheckCollideWith;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterGroup;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CollisionFilterMask;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UniqueId;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CollisionObjectDoubleData), fieldName).ToInt32(); }
	}
}
