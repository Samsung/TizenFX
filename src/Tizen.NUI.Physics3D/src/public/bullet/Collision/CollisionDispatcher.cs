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
using System.Collections.Generic;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum DispatcherFlags
	{
		None = 0,
		StaticStaticReported = 1,
		UseRelativeContactBreakingThreshold = 2,
		DisableContactPoolDynamicAllocation = 4
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void NearCallback(BroadphasePair collisionPair, CollisionDispatcher dispatcher, DispatcherInfo dispatchInfo);

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CollisionDispatcher : Dispatcher
	{
		[UnmanagedFunctionPointer(Tizen.NUI.Physics3D.Bullet.Native.Conv), SuppressUnmanagedCodeSecurity]
		private delegate void NearCallbackUnmanagedDelegate(IntPtr collisionPair, IntPtr dispatcher, IntPtr dispatchInfo);

		protected CollisionConfiguration _collisionConfiguration;
		private NearCallback _nearCallback;
		private List<CollisionAlgorithmCreateFunc> _collisionCreateFuncs;
		private NearCallbackUnmanagedDelegate _nearCallbackUnmanaged;
		private IntPtr _nearCallbackUnmanagedPtr;

		protected internal CollisionDispatcher()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionDispatcher(CollisionConfiguration collisionConfiguration)
		{
			IntPtr native = btCollisionDispatcher_new(collisionConfiguration.Native);
			InitializeUserOwned(native);

			_collisionConfiguration = collisionConfiguration;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void DefaultNearCallback(BroadphasePair collisionPair, CollisionDispatcher dispatcher,
			DispatcherInfo dispatchInfo)
		{
			btCollisionDispatcher_defaultNearCallback(collisionPair.Native, dispatcher.Native,
				dispatchInfo.Native);
		}

		private void NearCallbackUnmanaged(IntPtr collisionPair, IntPtr dispatcher, IntPtr dispatchInfo)
		{
			 global::System.Diagnostics.Debug.Assert(dispatcher == Native);

			_nearCallback(new BroadphasePair(collisionPair), this, new DispatcherInfo(dispatchInfo));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RegisterCollisionCreateFunc(BroadphaseNativeType proxyType0, BroadphaseNativeType proxyType1, CollisionAlgorithmCreateFunc createFunc)
		{
			if (_collisionCreateFuncs == null)
			{
				_collisionCreateFuncs = new List<CollisionAlgorithmCreateFunc>();
			}
			_collisionCreateFuncs.Add(createFunc);

			btCollisionDispatcher_registerCollisionCreateFunc(Native, proxyType0,
				proxyType1, createFunc.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RegisterClosestPointsCreateFunc(BroadphaseNativeType proxyType0, BroadphaseNativeType proxyType1, CollisionAlgorithmCreateFunc createFunc)
		{
			if (_collisionCreateFuncs == null)
			{
				_collisionCreateFuncs = new List<CollisionAlgorithmCreateFunc>();
			}
			_collisionCreateFuncs.Add(createFunc);

			btCollisionDispatcher_registerClosestPointsCreateFunc(Native, proxyType0,
				proxyType1, createFunc.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollisionConfiguration CollisionConfiguration
		{
			get => _collisionConfiguration;
			set
			{
				btCollisionDispatcher_setCollisionConfiguration(Native, value.Native);
				_collisionConfiguration = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DispatcherFlags DispatcherFlags
		{
			get => btCollisionDispatcher_getDispatcherFlags(Native);
			set => btCollisionDispatcher_setDispatcherFlags(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NearCallback NearCallback
		{
			get => _nearCallback;
			set
			{
				_nearCallback = value;

				if (value == null)
				{
					btCollisionDispatcher_setNearCallback(Native, IntPtr.Zero);
					_nearCallbackUnmanaged = null;
					return;
				}

				if (_nearCallbackUnmanaged == null)
				{
					_nearCallbackUnmanaged = new NearCallbackUnmanagedDelegate(NearCallbackUnmanaged);
					_nearCallbackUnmanagedPtr = Marshal.GetFunctionPointerForDelegate(_nearCallbackUnmanaged);
				}
				btCollisionDispatcher_setNearCallback(Native, _nearCallbackUnmanagedPtr);
			}
		}
	}
}
