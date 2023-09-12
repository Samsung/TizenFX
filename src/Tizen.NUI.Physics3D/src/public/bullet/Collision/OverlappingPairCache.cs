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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class OverlapCallback : BulletDisposableObject
	{
		internal OverlapCallback() // public
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ProcessOverlap(BroadphasePair pair)
		{
			return btOverlapCallback_processOverlap(Native, pair.Native);
		}

		protected override void Dispose(bool disposing)
		{
			btOverlapCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class OverlapFilterCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate bool NeedBroadphaseCollisionUnmanagedDelegate(IntPtr proxy0, IntPtr proxy1);

		private NeedBroadphaseCollisionUnmanagedDelegate _needBroadphaseCollision;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlapFilterCallback()
		{
			_needBroadphaseCollision = NeedBroadphaseCollisionUnmanaged;
			IntPtr native = btOverlapFilterCallbackWrapper_new(Marshal.GetFunctionPointerForDelegate(_needBroadphaseCollision));
			InitializeUserOwned(native);
		}

		private bool NeedBroadphaseCollisionUnmanaged(IntPtr proxy0, IntPtr proxy1)
		{
			return NeedBroadphaseCollision(BroadphaseProxy.GetManaged(proxy0), BroadphaseProxy.GetManaged(proxy1));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract bool NeedBroadphaseCollision(BroadphaseProxy proxy0, BroadphaseProxy proxy1);

		protected override void Dispose(bool disposing)
		{
			btOverlapFilterCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class OverlappingPairCache : OverlappingPairCallback
	{
		private OverlappingPairCallback _ghostPairCallback;
		private AlignedBroadphasePairArray _overlappingPairArray;

		protected internal OverlappingPairCache()
			: base(ConstructionInfo.Null)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CleanOverlappingPair(BroadphasePair pair, Dispatcher dispatcher)
		{
			btOverlappingPairCache_cleanOverlappingPair(Native, pair.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CleanProxyFromPairs(BroadphaseProxy proxy, Dispatcher dispatcher)
		{
			btOverlappingPairCache_cleanProxyFromPairs(Native, proxy.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BroadphasePair FindPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return new BroadphasePair(btOverlappingPairCache_findPair(Native, proxy0.Native, proxy1.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessAllOverlappingPairs(OverlapCallback __unnamed0, Dispatcher dispatcher)
		{
			btOverlappingPairCache_processAllOverlappingPairs(Native, __unnamed0.Native,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ProcessAllOverlappingPairs(OverlapCallback __unnamed0, Dispatcher dispatcher,
			DispatcherInfo dispatcherInfo)
		{
			btOverlappingPairCache_processAllOverlappingPairs2(Native, __unnamed0.Native,
				dispatcher.Native, dispatcherInfo.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetInternalGhostPairCallback(OverlappingPairCallback ghostPairCallback)
		{
			_ghostPairCallback = ghostPairCallback;
			btOverlappingPairCache_setInternalGhostPairCallback(Native, ghostPairCallback?.Native ?? IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetOverlapFilterCallback(OverlapFilterCallback callback)
		{
			btOverlappingPairCache_setOverlapFilterCallback(Native, callback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SortOverlappingPairs(Dispatcher dispatcher)
		{
			btOverlappingPairCache_sortOverlappingPairs(Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HasDeferredRemoval => btOverlappingPairCache_hasDeferredRemoval(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumOverlappingPairs => btOverlappingPairCache_getNumOverlappingPairs(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AlignedBroadphasePairArray OverlappingPairArray
		{
			get
			{
				IntPtr pairArrayPtr = btOverlappingPairCache_getOverlappingPairArray(Native);
				if (_overlappingPairArray == null || _overlappingPairArray.Native != pairArrayPtr)
				{
					_overlappingPairArray = new AlignedBroadphasePairArray(pairArrayPtr);
				}
				return _overlappingPairArray;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HashedOverlappingPairCache : OverlappingPairCache
	{
		private OverlapFilterCallback _overlapFilterCallback;

		internal HashedOverlappingPairCache(IntPtr native, BulletDisposableObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public HashedOverlappingPairCache()
		{
			IntPtr native = btHashedOverlappingPairCache_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return new BroadphasePair(btOverlappingPairCallback_addOverlappingPair(Native, proxy0.Native,
				proxy1.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsBroadphaseCollision(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return btHashedOverlappingPairCache_needsBroadphaseCollision(Native,
				proxy0.Native, proxy1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IntPtr RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1,
			Dispatcher dispatcher)
		{
			return btOverlappingPairCallback_removeOverlappingPair(Native, proxy0.Native,
				proxy1.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,
			Dispatcher dispatcher)
		{
			btOverlappingPairCallback_removeOverlappingPairsContainingProxy(Native,
				proxy0.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Count => btHashedOverlappingPairCache_GetCount(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlapFilterCallback OverlapFilterCallback
		{
			get => _overlapFilterCallback;
			set
			{
				_overlapFilterCallback = value;
				SetOverlapFilterCallback(value);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SortedOverlappingPairCache : OverlappingPairCache
	{
		private OverlapFilterCallback _overlapFilterCallback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SortedOverlappingPairCache()
		{
			IntPtr native = btSortedOverlappingPairCache_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return new BroadphasePair(btOverlappingPairCallback_addOverlappingPair(Native, proxy0.Native,
				proxy1.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsBroadphaseCollision(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return btSortedOverlappingPairCache_needsBroadphaseCollision(Native,
				proxy0.Native, proxy1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IntPtr RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1, 
			Dispatcher dispatcher)
		{
			return btOverlappingPairCallback_removeOverlappingPair(Native, proxy0.Native,
				proxy1.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,
			Dispatcher dispatcher)
		{
			btOverlappingPairCallback_removeOverlappingPairsContainingProxy(Native,
				proxy0.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlapFilterCallback OverlapFilterCallback
		{
			get => _overlapFilterCallback;
			set
			{
				_overlapFilterCallback = value;
				SetOverlapFilterCallback(value);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class NullPairCache : OverlappingPairCache
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public NullPairCache()
		{
			IntPtr native = btNullPairCache_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphasePair AddOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return new BroadphasePair(btOverlappingPairCallback_addOverlappingPair(Native, proxy0.Native,
				proxy1.Native));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override IntPtr RemoveOverlappingPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1,
			Dispatcher dispatcher)
		{
			return btOverlappingPairCallback_removeOverlappingPair(Native, proxy0.Native,
				proxy1.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void RemoveOverlappingPairsContainingProxy(BroadphaseProxy proxy0,
			Dispatcher dispatcher)
		{
			btOverlappingPairCallback_removeOverlappingPairsContainingProxy(Native, proxy0.Native,
				dispatcher.Native);
		}
	}
}
