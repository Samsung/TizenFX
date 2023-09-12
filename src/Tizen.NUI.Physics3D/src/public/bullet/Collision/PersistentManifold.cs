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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ContactDestroyedEventHandler(object userPersistantData);
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void ContactProcessedEventHandler(ManifoldPoint cp, CollisionObject body0, CollisionObject body1);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PersistentManifold : BulletDisposableObject //: TypedObject
	{
		private static ContactDestroyedEventHandler _contactDestroyed;
		private static ContactProcessedEventHandler _contactProcessed;
		private static ContactDestroyedUnmanagedDelegate _contactDestroyedUnmanaged;
		private static ContactProcessedUnmanagedDelegate _contactProcessedUnmanaged;
		private static IntPtr _contactDestroyedUnmanagedPtr;
		private static IntPtr _contactProcessedUnmanagedPtr;

		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool ContactDestroyedUnmanagedDelegate(IntPtr userPersistantData);
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool ContactProcessedUnmanagedDelegate(IntPtr cp, IntPtr body0, IntPtr body1);

		private static bool ContactDestroyedUnmanaged(IntPtr userPersistentData)
		{
			_contactDestroyed.Invoke(GCHandle.FromIntPtr(userPersistentData).Target);
			return false;
		}

		private static bool ContactProcessedUnmanaged(IntPtr cp, IntPtr body0, IntPtr body1)
		{
			_contactProcessed.Invoke(new ManifoldPoint(cp), CollisionObject.GetManaged(body0), CollisionObject.GetManaged(body1));
			return false;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static event ContactDestroyedEventHandler ContactDestroyed
		{
			add
			{
				if (_contactDestroyedUnmanaged == null)
				{
					_contactDestroyedUnmanaged = new ContactDestroyedUnmanagedDelegate(ContactDestroyedUnmanaged);
					_contactDestroyedUnmanagedPtr = Marshal.GetFunctionPointerForDelegate(_contactDestroyedUnmanaged);
				}
				setGContactDestroyedCallback(_contactDestroyedUnmanagedPtr);
				_contactDestroyed += value;
			}
			remove
			{
				_contactDestroyed -= value;
				if (_contactDestroyed == null)
				{
					setGContactDestroyedCallback(IntPtr.Zero);
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static event ContactProcessedEventHandler ContactProcessed
		{
			add
			{
				if (_contactProcessedUnmanaged == null)
				{
					_contactProcessedUnmanaged = new ContactProcessedUnmanagedDelegate(ContactProcessedUnmanaged);
					_contactProcessedUnmanagedPtr = Marshal.GetFunctionPointerForDelegate(_contactProcessedUnmanaged);
				}
				setGContactProcessedCallback(_contactProcessedUnmanagedPtr);
				_contactProcessed += value;
			}
			remove
			{
				_contactProcessed -= value;
				if (_contactProcessed == null)
				{
					setGContactProcessedCallback(IntPtr.Zero);
				}
			}
		}

		internal PersistentManifold(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold()
		{
			IntPtr native = btPersistentManifold_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold(CollisionObject body0, CollisionObject body1, int __unnamed2,
			float contactBreakingThreshold, float contactProcessingThreshold)
		{
			IntPtr native = btPersistentManifold_new2(body0.Native, body1.Native, __unnamed2,
				contactBreakingThreshold, contactProcessingThreshold);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int AddManifoldPoint(ManifoldPoint newPoint, bool isPredictive = false)
		{
			return btPersistentManifold_addManifoldPoint(Native, newPoint.Native,
				isPredictive);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearManifold()
		{
			btPersistentManifold_clearManifold(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearUserCache(ManifoldPoint pt)
		{
			btPersistentManifold_clearUserCache(Native, pt.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int GetCacheEntry(ManifoldPoint newPoint)
		{
			return btPersistentManifold_getCacheEntry(Native, newPoint.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldPoint GetContactPoint(int index)
		{
			return new ManifoldPoint(btPersistentManifold_getContactPoint(Native, index));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefreshContactPointsRef(ref Matrix4x4 trA, ref Matrix4x4 trB)
		{
			btPersistentManifold_refreshContactPoints(Native, ref trA, ref trB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RefreshContactPoints(Matrix4x4 trA, Matrix4x4 trB)
		{
			btPersistentManifold_refreshContactPoints(Native, ref trA, ref trB);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveContactPoint(int index)
		{
			btPersistentManifold_removeContactPoint(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReplaceContactPoint(ManifoldPoint newPoint, int insertIndex)
		{
			btPersistentManifold_replaceContactPoint(Native, newPoint.Native, insertIndex);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBodies(CollisionObject body0, CollisionObject body1)
		{
			btPersistentManifold_setBodies(Native, body0.Native, body1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ValidContactDistance(ManifoldPoint pt)
		{
			return btPersistentManifold_validContactDistance(Native, pt.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject Body0 => CollisionObject.GetManaged(btPersistentManifold_getBody0(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionObject Body1 => CollisionObject.GetManaged(btPersistentManifold_getBody1(Native));

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionIdA
		{
			get => btPersistentManifold_getCompanionIdA(Native);
			set => btPersistentManifold_setCompanionIdA(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CompanionIdB
		{
			get => btPersistentManifold_getCompanionIdB(Native);
			set => btPersistentManifold_setCompanionIdB(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactBreakingThreshold
		{
			get => btPersistentManifold_getContactBreakingThreshold(Native);
			set => btPersistentManifold_setContactBreakingThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float ContactProcessingThreshold
		{
			get => btPersistentManifold_getContactProcessingThreshold(Native);
			set => btPersistentManifold_setContactProcessingThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Index1A
		{
			get => btPersistentManifold_getIndex1a(Native);
			set => btPersistentManifold_setIndex1a(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumContacts
		{
			get => btPersistentManifold_getNumContacts(Native);
			set => btPersistentManifold_setNumContacts(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsUserOwned)
			{
				btPersistentManifold_delete(Native);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct PersistentManifoldDoubleData
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCacheLocalPointA;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCacheLocalPointB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCachePositionWorldOnA;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCachePositionWorldOnB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCacheNormalWorldOnB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCacheLateralFrictionDir1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3DoubleData[] PointCacheLateralFrictionDir2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheDistance;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheAppliedImpulse;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedRollingFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedSpinningFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedRestitution;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCachePartId0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCachePartId1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheIndex0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheIndex1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheContactPointFlags;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheAppliedImpulseLateral1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheAppliedImpulseLateral2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheContactMotion1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheContactMotion2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheContactCfm;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedContactStiffness1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheContactErp;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheCombinedContactDamping1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		double[] PointCacheFrictionCfm;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheLifeTime;
		int NumCachedPoints;
		int CompanionIdA;
		int CompanionIdB;
		int Index1a;
		int ObjectType;
		double ContactBreakingThreshold;
		double ContactProcessingThreshold;
		int Padding;
		IntPtr Body0;
		IntPtr Body1;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct PersistentManifoldFloatData
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCacheLocalPointA;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCacheLocalPointB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCachePositionWorldOnA;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCachePositionWorldOnB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCacheNormalWorldOnB;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCacheLateralFrictionDir1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		 Vector3FloatData[] PointCacheLateralFrictionDir2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheDistance;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheAppliedImpulse;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedRollingFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedSpinningFriction;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedRestitution;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCachePartId0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCachePartId1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheIndex0;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheIndex1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheContactPointFlags;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheAppliedImpulseLateral1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheAppliedImpulseLateral2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheContactMotion1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheContactMotion2;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheContactCfm;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedContactStiffness1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheContactErp;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheCombinedContactDamping1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		float[] PointCacheFrictionCfm;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		int[] PointCacheLifeTime;
		int NumCachedPoints;
		int CompanionIdA;
		int CompanionIdB;
		int Index1a;
		int ObjectType;
		float ContactBreakingThreshold;
		float ContactProcessingThreshold;
		int Padding;
		IntPtr Body0;
		IntPtr Body1;
	}
}
