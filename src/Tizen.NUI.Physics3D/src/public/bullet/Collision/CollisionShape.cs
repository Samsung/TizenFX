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
	public abstract class CollisionShape : BulletDisposableObject
	{
		protected internal CollisionShape()
		{
		}

		protected internal void InitializeCollisionShape(IntPtr native, BulletObject owner = null)
		{
			if (owner != null)
			{
				InitializeSubObject(native, owner);
			}
			else
			{
				InitializeUserOwned(native);

				AllocateUnmanagedHandle();
			}
		}

		internal static CollisionShape GetManaged(IntPtr obj)
		{
			if (obj == IntPtr.Zero)
			{
				return null;
			}

			IntPtr userPtr = btCollisionShape_getUserPointer(obj);
			if (userPtr != IntPtr.Zero)
			{
				return GCHandle.FromIntPtr(userPtr).Target as CollisionShape;
			}

			throw new InvalidOperationException("Unknown collision object!");
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CalculateLocalInertia(float mass)
		{
		 	global::System.Numerics.Vector3 inertia;
			btCollisionShape_calculateLocalInertia(Native, mass, out inertia);
			return inertia;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateLocalInertia(float mass, out global::System.Numerics.Vector3 inertia)
		{
			btCollisionShape_calculateLocalInertia(Native, mass, out inertia);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CalculateSerializeBufferSize()
		{
			return btCollisionShape_calculateSerializeBufferSize(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTemporalAabbRef(ref Matrix4x4 curTrans, ref global::System.Numerics.Vector3 linvel, ref global::System.Numerics.Vector3 angvel,
			float timeStep, out global::System.Numerics.Vector3 temporalAabbMin, out global::System.Numerics.Vector3 temporalAabbMax)
		{
			btCollisionShape_calculateTemporalAabb(Native, ref curTrans, ref linvel, ref angvel, timeStep, out temporalAabbMin, out temporalAabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateTemporalAabb(Matrix4x4 curTrans, global::System.Numerics.Vector3 linvel, global::System.Numerics.Vector3 angvel,
			float timeStep, out global::System.Numerics.Vector3 temporalAabbMin, out global::System.Numerics.Vector3 temporalAabbMax)
		{
			btCollisionShape_calculateTemporalAabb(Native, ref curTrans, ref linvel,
				ref angvel, timeStep, out temporalAabbMin, out temporalAabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabbRef(ref Matrix4x4 transformation, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btCollisionShape_getAabb(Native, ref transformation, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabb(Matrix4x4 transformation, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btCollisionShape_getAabb(Native, ref transformation, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetBoundingSphere(out global::System.Numerics.Vector3 center, out float radius)
		{
			btCollisionShape_getBoundingSphere(Native, out center, out radius);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetContactBreakingThreshold(float defaultContactThresholdFactor)
		{
			return btCollisionShape_getContactBreakingThreshold(Native, defaultContactThresholdFactor);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AngularMotionDisc => btCollisionShape_getAngularMotionDisc(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 AnisotropicRollingFrictionDirection
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionShape_getAnisotropicRollingFrictionDirection(Native, out value);
				return value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsCompound => btCollisionShape_isCompound(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsConcave => btCollisionShape_isConcave(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsConvex => btCollisionShape_isConvex(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsConvex2D => btCollisionShape_isConvex2d(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsInfinite => btCollisionShape_isInfinite(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsNonMoving => btCollisionShape_isNonMoving(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsPolyhedral => btCollisionShape_isPolyhedral(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsSoftBody => btCollisionShape_isSoftBody(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalScaling
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btCollisionShape_getLocalScaling(Native, out value);
				return value;
			}
			set => btCollisionShape_setLocalScaling(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Margin
		{
			get => btCollisionShape_getMargin(Native);
			set => btCollisionShape_setMargin(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Name => Marshal.PtrToStringAnsi(btCollisionShape_getName(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphaseNativeType ShapeType => btCollisionShape_getShapeType(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object UserObject { get; set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UserIndex
		{
			get => btCollisionShape_getUserIndex(Native);
			set => btCollisionShape_setUserIndex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return Native.GetHashCode();
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				FreeUnmanagedHandle();

				btCollisionShape_delete(Native);
			}
		}

		internal void AllocateUnmanagedHandle()
		{
			GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
			btCollisionShape_setUserPointer(Native, GCHandle.ToIntPtr(handle));
		}

		internal void FreeUnmanagedHandle()
		{
			IntPtr userPtr = btCollisionShape_getUserPointer(Native);
			GCHandle.FromIntPtr(userPtr).Free();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CollisionShapeData
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IntPtr Name;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int ShapeType;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Padding;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static int Offset(string fieldName) { return Marshal.OffsetOf(typeof(CollisionShapeData), fieldName).ToInt32(); }
	}
}
