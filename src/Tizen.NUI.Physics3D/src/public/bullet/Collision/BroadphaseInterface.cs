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
	public abstract class BroadphaseAabbCallback : BulletDisposableObject
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		internal delegate bool ProcessUnmanagedDelegate(IntPtr proxy);

		internal ProcessUnmanagedDelegate _process;

		internal BroadphaseAabbCallback(ConstructionInfo info)
		{
			_process = ProcessUnmanaged;
		}

		protected BroadphaseAabbCallback()
		{
			_process = ProcessUnmanaged;
			IntPtr native = btBroadphaseAabbCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_process));
			InitializeUserOwned(native);
		}

		private bool ProcessUnmanaged(IntPtr proxy)
		{
			return Process(BroadphaseProxy.GetManaged(proxy));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract bool Process(BroadphaseProxy proxy);

		protected override void Dispose(bool disposing)
		{
			btBroadphaseAabbCallback_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class BroadphaseRayCallback : BroadphaseAabbCallback
	{
		private UIntArray _signs;

		protected BroadphaseRayCallback()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btBroadphaseRayCallbackWrapper_new(
				Marshal.GetFunctionPointerForDelegate(_process));
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float LambdaMax
		{
			get => btBroadphaseRayCallback_getLambda_max(Native);
			set => btBroadphaseRayCallback_setLambda_max(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 RayDirectionInverse
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btBroadphaseRayCallback_getRayDirectionInverse(Native, out value);
				return value;
			}
			set => btBroadphaseRayCallback_setRayDirectionInverse(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UIntArray Signs
		{
			get
			{
				if (_signs == null)
				{
					_signs = new UIntArray(btBroadphaseRayCallback_getSigns(Native), 3);
				}
				return _signs;
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract class BroadphaseInterface : BulletDisposableObject
	{
		protected OverlappingPairCache _overlappingPairCache;

		protected internal BroadphaseInterface()
		{
		}

		protected internal void InitializeMembers(OverlappingPairCache overlappingPairCache)
		{
			_overlappingPairCache = overlappingPairCache;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AabbTestRef(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, BroadphaseAabbCallback callback)
		{
			btBroadphaseInterface_aabbTest(Native, ref aabbMin, ref aabbMax, callback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AabbTest(global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax, BroadphaseAabbCallback callback)
		{
			btBroadphaseInterface_aabbTest(Native, ref aabbMin, ref aabbMax, callback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CalculateOverlappingPairs(Dispatcher dispatcher)
		{
			btBroadphaseInterface_calculateOverlappingPairs(Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract BroadphaseProxy CreateProxy(ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax,
			int shapeType, IntPtr userPtr, int collisionFilterGroup, int collisionFilterMask,
			Dispatcher dispatcher);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void DestroyProxy(BroadphaseProxy proxy, Dispatcher dispatcher)
		{
			btBroadphaseInterface_destroyProxy(Native, proxy.Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetAabb(BroadphaseProxy proxy, out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btBroadphaseInterface_getAabb(Native, proxy.Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetBroadphaseAabb(out global::System.Numerics.Vector3 aabbMin, out global::System.Numerics.Vector3 aabbMax)
		{
			btBroadphaseInterface_getBroadphaseAabb(Native, out aabbMin, out aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void PrintStats()
		{
			btBroadphaseInterface_printStats(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTestRef(ref global::System.Numerics.Vector3 rayFrom, ref global::System.Numerics.Vector3 rayTo, BroadphaseRayCallback rayCallback)
		{
			btBroadphaseInterface_rayTest(Native, ref rayFrom, ref rayTo, rayCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTest(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, BroadphaseRayCallback rayCallback)
		{
			btBroadphaseInterface_rayTest(Native, ref rayFrom, ref rayTo, rayCallback.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTestRef(ref global::System.Numerics.Vector3 rayFrom, ref global::System.Numerics.Vector3 rayTo, BroadphaseRayCallback rayCallback, ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax)
		{
			btBroadphaseInterface_rayTest3(Native, ref rayFrom, ref rayTo, rayCallback.Native, ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RayTest(global::System.Numerics.Vector3 rayFrom, global::System.Numerics.Vector3 rayTo, BroadphaseRayCallback rayCallback,
		 global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax)
		{
			btBroadphaseInterface_rayTest3(Native, ref rayFrom, ref rayTo, rayCallback.Native,
				ref aabbMin, ref aabbMax);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ResetPool(Dispatcher dispatcher)
		{
			btBroadphaseInterface_resetPool(Native, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAabbRef(BroadphaseProxy proxy, ref global::System.Numerics.Vector3 aabbMin, ref global::System.Numerics.Vector3 aabbMax, Dispatcher dispatcher)
		{
			btBroadphaseInterface_setAabb(Native, proxy.Native, ref aabbMin, ref aabbMax, dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetAabb(BroadphaseProxy proxy, global::System.Numerics.Vector3 aabbMin, global::System.Numerics.Vector3 aabbMax,
			Dispatcher dispatcher)
		{
			btBroadphaseInterface_setAabb(Native, proxy.Native, ref aabbMin, ref aabbMax,
				dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OverlappingPairCache OverlappingPairCache => _overlappingPairCache;

		protected override void Dispose(bool disposing)
		{
			btBroadphaseInterface_delete(Native);
		}
	}
}
