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
using System.Numerics;
using System.ComponentModel;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AxisSweep3 : BroadphaseInterface
	{
		private OverlappingPairCallback _overlappingPairUserCallback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AxisSweep3(global::System.Numerics.Vector3 worldAabbMin, global::System.Numerics.Vector3 worldAabbMax, ushort maxHandles = 16384,
			OverlappingPairCache pairCache = null, bool disableRaycastAccelerator = false)
		{
			IntPtr native = btAxisSweep3_new(ref worldAabbMin, ref worldAabbMax, maxHandles,
				pairCache?.Native ?? IntPtr.Zero, disableRaycastAccelerator);
			InitializeUserOwned(native);

			InitializeMembers(pairCache ?? new HashedOverlappingPairCache(
				btBroadphaseInterface_getOverlappingPairCache(Native), this));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ushort AddHandle(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax, IntPtr pOwner,
			int collisionFilterGroup, int collisionFilterMask, Dispatcher dispatcher,
			IntPtr multiSapProxy)
		{
			return btAxisSweep3_addHandle(Native, ref aabbMin, ref aabbMax, pOwner,
				collisionFilterGroup, collisionFilterMask, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ushort AddHandleRef(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, IntPtr pOwner,
			int collisionFilterGroup, int collisionFilterMask,
			Dispatcher dispatcher, IntPtr multiSapProxy)
		{
			return btAxisSweep3_addHandle(Native, ref aabbMin, ref aabbMax, pOwner,
				collisionFilterGroup, collisionFilterMask, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphaseProxy CreateProxy(ref global::System.Numerics.Vector3 aabbMin,
			ref global::System.Numerics.Vector3 aabbMax, int shapeType, IntPtr userPtr, int collisionFilterGroup,
			int collisionFilterMask, Dispatcher dispatcher)
		{
			//throw new NotImplementedException();
			return new BroadphaseProxy(btBroadphaseInterface_createProxy(Native, ref aabbMin, ref aabbMax, shapeType, userPtr, collisionFilterGroup, collisionFilterMask, dispatcher.Native));
		}
		/*
		public Handle GetHandle(ushort index)
		{
			return new Handle(btAxisSweep3_getHandle(Native, index), true);
		}

		public void Quantize(ushort o, global::System.Numerics.Vector3 point, int isMax)
		{
			btAxisSweep3_quantize(Native, out o, ref point, isMax);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveHandle(ushort handle, Dispatcher dispatcher)
		{
			btAxisSweep3_removeHandle(Native, handle, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestAabbOverlap(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return btAxisSweep3_testAabbOverlap(Native, proxy0.Native, proxy1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UnQuantize(BroadphaseProxy proxy, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btAxisSweep3_unQuantize(Native, proxy.Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateHandle(ushort handle, global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax,
			Dispatcher dispatcher)
		{
			btAxisSweep3_updateHandle(Native, handle, ref aabbMin, ref aabbMax,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ushort NumHandles => btAxisSweep3_getNumHandles(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlappingPairCallback OverlappingPairUserCallback
		{
			get => _overlappingPairUserCallback;
			set
			{
				btAxisSweep3_setOverlappingPairUserCallback(Native, (value != null) ? value.Native : IntPtr.Zero);
				_overlappingPairUserCallback = value;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AxisSweep3_32Bit : BroadphaseInterface
	{
		private OverlappingPairCallback _overlappingPairUserCallback;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AxisSweep3_32Bit(global::System.Numerics.Vector3 worldAabbMin, global::System.Numerics.Vector3 worldAabbMax, uint maxHandles = 1500000,
			OverlappingPairCache pairCache = null, bool disableRaycastAccelerator = false)
		{
			IntPtr native = bt32BitAxisSweep3_new(ref worldAabbMin, ref worldAabbMax, maxHandles,
				pairCache?.Native ?? IntPtr.Zero, disableRaycastAccelerator);
			InitializeUserOwned(native);

			InitializeMembers(pairCache ?? new HashedOverlappingPairCache(
				btBroadphaseInterface_getOverlappingPairCache(Native), this));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint AddHandle(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax, IntPtr pOwner, int collisionFilterGroup,
			int collisionFilterMask, Dispatcher dispatcher, IntPtr multiSapProxy)
		{
			return bt32BitAxisSweep3_addHandle(Native, ref aabbMin, ref aabbMax,
				pOwner, collisionFilterGroup, collisionFilterMask, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint AddHandleRef(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, IntPtr pOwner,
			int collisionFilterGroup, int collisionFilterMask,
			Dispatcher dispatcher, IntPtr multiSapProxy)
		{
			return bt32BitAxisSweep3_addHandle(Native, ref aabbMin, ref aabbMax,
				pOwner, collisionFilterGroup, collisionFilterMask, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override BroadphaseProxy CreateProxy(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, int shapeType, IntPtr userPtr, int collisionFilterGroup, int collisionFilterMask, Dispatcher dispatcher)
		{
			//throw new NotImplementedException();
			return new BroadphaseProxy(btBroadphaseInterface_createProxy(Native, ref aabbMin, ref aabbMax, shapeType, userPtr, collisionFilterGroup, collisionFilterMask, dispatcher.Native));
		}
		/*
		public Handle GetHandle(uint index)
		{
			return new Handle(bt32BitAxisSweep3_getHandle(Native, index), true);
		}

		public void Quantize(uint o, global::System.Numerics.Vector3 point, int isMax)
		{
			bt32BitAxisSweep3_quantize(Native, out o, ref point, isMax);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveHandle(uint handle, Dispatcher dispatcher)
		{
			bt32BitAxisSweep3_removeHandle(Native, handle, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool TestAabbOverlap(BroadphaseProxy proxy0, BroadphaseProxy proxy1)
		{
			return bt32BitAxisSweep3_testAabbOverlap(Native, proxy0.Native, proxy1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UnQuantize(BroadphaseProxy proxy, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			bt32BitAxisSweep3_unQuantize(Native, proxy.Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void UpdateHandle(uint handle, global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax, Dispatcher dispatcher)
		{
			bt32BitAxisSweep3_updateHandle(Native, handle, ref aabbMin, ref aabbMax,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public uint NumHandles => bt32BitAxisSweep3_getNumHandles(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlappingPairCallback OverlappingPairUserCallback
		{
			get => _overlappingPairUserCallback;
			set
			{
				bt32BitAxisSweep3_setOverlappingPairUserCallback(Native, (value != null) ? value.Native : IntPtr.Zero);
				_overlappingPairUserCallback = value;
			}
		}
	}
}
