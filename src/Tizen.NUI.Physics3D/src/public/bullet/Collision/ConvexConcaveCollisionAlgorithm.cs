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
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{/*
	public class ConvexTriangleCallback : TriangleCallback
	{
		internal ConvexTriangleCallback(IntPtr native)
			: base(native)
		{
		}

		public ConvexTriangleCallback(Dispatcher dispatcher, CollisionObjectWrapper body0Wrap,
			CollisionObjectWrapper body1Wrap, bool isSwapped)
			: base(btConvexTriangleCallback_new(dispatcher.Native, body0Wrap.Native,
				body1Wrap.Native, isSwapped))
		{
		}

		public void ClearCache()
		{
			btConvexTriangleCallback_clearCache(_native);
		}

		public void ClearWrapperData()
		{
			btConvexTriangleCallback_clearWrapperData(_native);
		}

		public void SetTimeStepAndCounters(float collisionMarginTriangle, DispatcherInfo dispatchInfo,
			CollisionObjectWrapper convexBodyWrap, CollisionObjectWrapper triBodyWrap,
			ManifoldResult resultOut)
		{
			btConvexTriangleCallback_setTimeStepAndCounters(_native, collisionMarginTriangle,
				dispatchInfo._native, convexBodyWrap.Native, triBodyWrap.Native,
				resultOut._native);
		}

		public global::System.Numerics.Vector3 AabbMax
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexTriangleCallback_getAabbMax(_native, out value);
				return value;
			}
		}

		public global::System.Numerics.Vector3 AabbMin
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btConvexTriangleCallback_getAabbMin(_native, out value);
				return value;
			}
		}

		public PersistentManifold ManifoldPtr
		{
			get => btConvexTriangleCallback_getManifoldPtr(_native);
			set => btConvexTriangleCallback_setManifoldPtr(_native, value._native);
		}

		public int TriangleCount
		{
			get => btConvexTriangleCallback_getTriangleCount(_native);
			set => btConvexTriangleCallback_setTriangleCount(_native, value);
		}

		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConvexTriangleCallback_new(IntPtr dispatcher, IntPtr body0Wrap, IntPtr body1Wrap, bool isSwapped);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_clearCache(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_clearWrapperData(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_getAabbMax(IntPtr obj, out global::System.Numerics.Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_getAabbMin(IntPtr obj, out global::System.Numerics.Vector3 value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern IntPtr btConvexTriangleCallback_getManifoldPtr(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern int btConvexTriangleCallback_getTriangleCount(IntPtr obj);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_setManifoldPtr(IntPtr obj, IntPtr value);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_setTimeStepAndCounters(IntPtr obj, float collisionMarginTriangle, IntPtr dispatchInfo, IntPtr convexBodyWrap, IntPtr triBodyWrap, IntPtr resultOut);
		[DllImport(Native.Dll, CallingConvention = Native.Conv), SuppressUnmanagedCodeSecurity]
		static extern void btConvexTriangleCallback_setTriangleCount(IntPtr obj, int value);
	}
*/
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexConcaveCollisionAlgorithm : ActivatingCollisionAlgorithm
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class CreateFunc : CollisionAlgorithmCreateFunc
		{
			internal CreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
				InitializeSubObject(native, owner);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CreateFunc()
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btConvexConcaveCollisionAlgorithm_CreateFunc_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0,
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new ConvexConcaveCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public class SwappedCreateFunc : CollisionAlgorithmCreateFunc
		{
			internal SwappedCreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
				InitializeSubObject(native, owner);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public SwappedCreateFunc()
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btConvexConcaveCollisionAlgorithm_SwappedCreateFunc_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0,
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new ConvexConcaveCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}
		}

		internal ConvexConcaveCollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexConcaveCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, bool isSwapped)
			: base()
		{
			IntPtr native = btConvexConcaveCollisionAlgorithm_new(ci.Native, body0Wrap.Native,
				body1Wrap.Native, isSwapped);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ClearCache()
		{
			btConvexConcaveCollisionAlgorithm_clearCache(Native);
		}
	}
}
