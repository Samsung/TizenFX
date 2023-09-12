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
using System.Security;
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum ContactPointFlags
	{
		None = 0,
		LateralFrictionInitialized = 1,
		HasContactCfm = 2,
		HasContactErp = 4,
		ContactStiffnessDamping = 8,
		FrictionAnchor = 16
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ContactAddedEventHandler(ManifoldPoint cp, CollisionObjectWrapper colObj0Wrap, int partId0, int index0, CollisionObjectWrapper colObj1Wrap, int partId1, int index1);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ManifoldPoint : BulletDisposableObject
	{
		private static ContactAddedEventHandler _contactAdded;
		private static ContactAddedUnmanagedDelegate _contactAddedUnmanaged;
		private static IntPtr _contactAddedUnmanagedPtr;

		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool ContactAddedUnmanagedDelegate(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1);

		static bool ContactAddedUnmanaged(IntPtr cp, IntPtr colObj0Wrap, int partId0, int index0, IntPtr colObj1Wrap, int partId1, int index1)
		{
			_contactAdded.Invoke(new ManifoldPoint(cp), new CollisionObjectWrapper(colObj0Wrap), partId0, index0, new CollisionObjectWrapper(colObj1Wrap), partId1, index1);
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static event ContactAddedEventHandler ContactAdded
		{
			add
			{
				if (_contactAddedUnmanaged == null)
				{
					_contactAddedUnmanaged = new ContactAddedUnmanagedDelegate(ContactAddedUnmanaged);
					_contactAddedUnmanagedPtr = Marshal.GetFunctionPointerForDelegate(_contactAddedUnmanaged);
				}
				setGContactAddedCallback(_contactAddedUnmanagedPtr);
				_contactAdded += value;
			}
			remove
			{
				_contactAdded -= value;
				if (_contactAdded == null)
				{
					setGContactAddedCallback(IntPtr.Zero);
				}
			}
		}

		internal ManifoldPoint(IntPtr native)
		{
			InitializeSubObject(native, this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldPoint()
		{
			IntPtr native = btManifoldPoint_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldPoint(global::System.Numerics.Vector3 pointA, global::System.Numerics.Vector3 pointB, global::System.Numerics.Vector3 normal, float distance)
		{
			IntPtr native = btManifoldPoint_new2(ref pointA, ref pointB, ref normal, distance);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulse
		{
			get => btManifoldPoint_getAppliedImpulse(Native);
			set => btManifoldPoint_setAppliedImpulse(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulseLateral1
		{
			get => btManifoldPoint_getAppliedImpulseLateral1(Native);
			set => btManifoldPoint_setAppliedImpulseLateral1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float AppliedImpulseLateral2
		{
			get => btManifoldPoint_getAppliedImpulseLateral2(Native);
			set => btManifoldPoint_setAppliedImpulseLateral2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CombinedContactDamping1
		{
			get => btManifoldPoint_getCombinedContactDamping1(Native);
			set => btManifoldPoint_setCombinedContactDamping1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CombinedContactStiffness1
		{
			get => btManifoldPoint_getCombinedContactStiffness1(Native);
			set => btManifoldPoint_setCombinedContactStiffness1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CombinedFriction
		{
			get => btManifoldPoint_getCombinedFriction(Native);
			set => btManifoldPoint_setCombinedFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CombinedRestitution
		{
			get => btManifoldPoint_getCombinedRestitution(Native);
			set => btManifoldPoint_setCombinedRestitution(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CombinedRollingFriction
		{
			get => btManifoldPoint_getCombinedRollingFriction(Native);
			set => btManifoldPoint_setCombinedRollingFriction(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactCfm
		{
			get => btManifoldPoint_getContactCFM(Native);
			set => btManifoldPoint_setContactCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactErp
		{
			get => btManifoldPoint_getContactERP(Native);
			set => btManifoldPoint_setContactERP(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactMotion1
		{
			get => btManifoldPoint_getContactMotion1(Native);
			set => btManifoldPoint_setContactMotion1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactMotion2
		{
			get => btManifoldPoint_getContactMotion2(Native);
			set => btManifoldPoint_setContactMotion2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactPointFlags ContactPointFlags
		{
			get => btManifoldPoint_getContactPointFlags(Native);
			set => btManifoldPoint_setContactPointFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Distance
		{
			get => btManifoldPoint_getDistance(Native);
			set => btManifoldPoint_setDistance(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float Distance1
		{
			get => btManifoldPoint_getDistance1(Native);
			set => btManifoldPoint_setDistance1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float FrictionCfm
		{
			get => btManifoldPoint_getFrictionCFM(Native);
			set => btManifoldPoint_setFrictionCFM(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index0
		{
			get => btManifoldPoint_getIndex0(Native);
			set => btManifoldPoint_setIndex0(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index1
		{
			get => btManifoldPoint_getIndex1(Native);
			set => btManifoldPoint_setIndex1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LateralFrictionDir1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getLateralFrictionDir1(Native, out value);
				return value;
			}
			set => btManifoldPoint_setLateralFrictionDir1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LateralFrictionDir2
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getLateralFrictionDir2(Native, out value);
				return value;
			}
			set => btManifoldPoint_setLateralFrictionDir2(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LifeTime
		{
			get => btManifoldPoint_getLifeTime(Native);
			set => btManifoldPoint_setLifeTime(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalPointA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getLocalPointA(Native, out value);
				return value;
			}
			set => btManifoldPoint_setLocalPointA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LocalPointB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getLocalPointB(Native, out value);
				return value;
			}
			set => btManifoldPoint_setLocalPointB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 NormalWorldOnB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getNormalWorldOnB(Native, out value);
				return value;
			}
			set => btManifoldPoint_setNormalWorldOnB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PartId0
		{
			get => btManifoldPoint_getPartId0(Native);
			set => btManifoldPoint_setPartId0(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PartId1
		{
			get => btManifoldPoint_getPartId1(Native);
			set => btManifoldPoint_setPartId1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PositionWorldOnA
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getPositionWorldOnA(Native, out value);
				return value;
			}
			set => btManifoldPoint_setPositionWorldOnA(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 PositionWorldOnB
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btManifoldPoint_getPositionWorldOnB(Native, out value);
				return value;
			}
			set => btManifoldPoint_setPositionWorldOnB(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public object UserPersistentData
		{
			get
			{
				IntPtr valuePtr = btManifoldPoint_getUserPersistentData(Native);
				return (valuePtr != IntPtr.Zero) ? GCHandle.FromIntPtr(valuePtr).Target : null;
			}
			set
			{
				IntPtr prevPtr = btManifoldPoint_getUserPersistentData(Native);
				if (prevPtr != IntPtr.Zero)
				{
					GCHandle prevHandle = GCHandle.FromIntPtr(prevPtr);
					if (ReferenceEquals(value, prevHandle.Target))
					{
						return;
					}
					prevHandle.Free();
				}
				if (value != null)
				{
					GCHandle handle = GCHandle.Alloc(value);
					btManifoldPoint_setUserPersistentData(Native, GCHandle.ToIntPtr(handle));
				}
				else
				{
					btManifoldPoint_setUserPersistentData(Native, IntPtr.Zero);
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btManifoldPoint_delete(Native);
			}
		}
	}
}
