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
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DefaultCollisionConstructionInfo : BulletDisposableObject
	{
		private PoolAllocator _collisionAlgorithmPool;
		private PoolAllocator _persistentManifoldPool;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultCollisionConstructionInfo()
		{
			IntPtr native = btDefaultCollisionConstructionInfo_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PoolAllocator CollisionAlgorithmPool
		{
			get => _collisionAlgorithmPool;
			set
			{
				btDefaultCollisionConstructionInfo_setCollisionAlgorithmPool(Native, value.Native);
				_collisionAlgorithmPool = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CustomCollisionAlgorithmMaxElementSize
		{
			get => btDefaultCollisionConstructionInfo_getCustomCollisionAlgorithmMaxElementSize(Native);
			set => btDefaultCollisionConstructionInfo_setCustomCollisionAlgorithmMaxElementSize(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DefaultMaxCollisionAlgorithmPoolSize
		{
			get => btDefaultCollisionConstructionInfo_getDefaultMaxCollisionAlgorithmPoolSize(Native);
			set => btDefaultCollisionConstructionInfo_setDefaultMaxCollisionAlgorithmPoolSize(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DefaultMaxPersistentManifoldPoolSize
		{
			get => btDefaultCollisionConstructionInfo_getDefaultMaxPersistentManifoldPoolSize(Native);
			set => btDefaultCollisionConstructionInfo_setDefaultMaxPersistentManifoldPoolSize(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PoolAllocator PersistentManifoldPool
		{
			get => _persistentManifoldPool;
			set
			{
				btDefaultCollisionConstructionInfo_setPersistentManifoldPool(Native, value.Native);
				_persistentManifoldPool = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int UseEpaPenetrationAlgorithm
		{
			get => btDefaultCollisionConstructionInfo_getUseEpaPenetrationAlgorithm(Native);
			set => btDefaultCollisionConstructionInfo_setUseEpaPenetrationAlgorithm(Native, value);
		}

		protected override void Dispose(bool disposing)
		{
			if (IsDisposed == false)
			{
				btDefaultCollisionConstructionInfo_delete(Native);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class DefaultCollisionConfiguration : CollisionConfiguration
	{
		protected PoolAllocator _collisionAlgorithmPool;
		protected PoolAllocator _persistentManifoldPool;

		internal DefaultCollisionConfiguration(ConstructionInfo info)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultCollisionConfiguration()
		{
			IntPtr native = btDefaultCollisionConfiguration_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DefaultCollisionConfiguration(DefaultCollisionConstructionInfo constructionInfo) 
		{
			if (constructionInfo == null)
			{
				throw new ArgumentNullException(nameof(constructionInfo));
			}

			_collisionAlgorithmPool = constructionInfo.CollisionAlgorithmPool;
			_persistentManifoldPool = constructionInfo.PersistentManifoldPool;

			IntPtr native = btDefaultCollisionConfiguration_new2(constructionInfo.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionAlgorithmCreateFunc GetClosestPointsAlgorithmCreateFunc(BroadphaseNativeType proxyType0, BroadphaseNativeType proxyType1)
		{
			IntPtr createFunc = btCollisionConfiguration_getClosestPointsAlgorithmCreateFunc(Native, (int)proxyType0, (int)proxyType1);
			if (proxyType0 == BroadphaseNativeType.BoxShape && proxyType1 == BroadphaseNativeType.BoxShape)
			{
				return new BoxBoxCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SphereShape && proxyType1 == BroadphaseNativeType.SphereShape)
			{
				return new SphereSphereCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SphereShape && proxyType1 == BroadphaseNativeType.TriangleShape)
			{
				return new SphereTriangleCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.TriangleShape && proxyType1 == BroadphaseNativeType.SphereShape)
			{
				return new SphereTriangleCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.StaticPlaneShape && BroadphaseProxy.IsConvex(proxyType1))
			{
				return new ConvexPlaneCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType1 == BroadphaseNativeType.StaticPlaneShape && BroadphaseProxy.IsConvex(proxyType0))
			{
				return new ConvexPlaneCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType0) && BroadphaseProxy.IsConvex(proxyType1))
			{
				return new ConvexConvexAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType0) && BroadphaseProxy.IsConcave(proxyType1))
			{
				return new ConvexConcaveCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType1) && BroadphaseProxy.IsConcave(proxyType0))
			{
				return new ConvexConcaveCollisionAlgorithm.SwappedCreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsCompound(proxyType0))
			{
				return new CompoundCompoundCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsCompound(proxyType1))
			{
				return new CompoundCompoundCollisionAlgorithm.SwappedCreateFunc(createFunc, this);
			}
			return new EmptyAlgorithm.CreateFunc(createFunc, this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionAlgorithmCreateFunc GetCollisionAlgorithmCreateFunc(BroadphaseNativeType proxyType0, BroadphaseNativeType proxyType1)
		{
			IntPtr createFunc = btCollisionConfiguration_getCollisionAlgorithmCreateFunc(Native, (int)proxyType0, (int)proxyType1);
			if (proxyType0 == BroadphaseNativeType.BoxShape && proxyType1 == BroadphaseNativeType.BoxShape)
			{
				return new BoxBoxCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SphereShape && proxyType1 == BroadphaseNativeType.SphereShape)
			{
				return new SphereSphereCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SphereShape && proxyType1 == BroadphaseNativeType.TriangleShape)
			{
				return new SphereTriangleCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.TriangleShape && proxyType1 == BroadphaseNativeType.SphereShape)
			{
				return new SphereTriangleCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.StaticPlaneShape && BroadphaseProxy.IsConvex(proxyType1))
			{
				return new ConvexPlaneCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType1 == BroadphaseNativeType.StaticPlaneShape && BroadphaseProxy.IsConvex(proxyType0))
			{
				return new ConvexPlaneCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType0) && BroadphaseProxy.IsConvex(proxyType1))
			{
				return new ConvexConvexAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType0) && BroadphaseProxy.IsConcave(proxyType1))
			{
				return new ConvexConcaveCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType1) && BroadphaseProxy.IsConcave(proxyType0))
			{
				return new ConvexConcaveCollisionAlgorithm.SwappedCreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsCompound(proxyType0))
			{
				return new CompoundCompoundCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsCompound(proxyType1))
			{
				return new CompoundCompoundCollisionAlgorithm.SwappedCreateFunc(createFunc, this);
			}
			return new EmptyAlgorithm.CreateFunc(createFunc, this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetConvexConvexMultipointIterations(int numPerturbationIterations = 3,
			int minimumPointsPerturbationThreshold = 3)
		{
			btDefaultCollisionConfiguration_setConvexConvexMultipointIterations(
				Native, numPerturbationIterations, minimumPointsPerturbationThreshold);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPlaneConvexMultipointIterations(int numPerturbationIterations = 3,
			int minimumPointsPerturbationThreshold = 3)
		{
			btDefaultCollisionConfiguration_setPlaneConvexMultipointIterations(Native,
				numPerturbationIterations, minimumPointsPerturbationThreshold);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override PoolAllocator CollisionAlgorithmPool
		{
			get
			{
				if (_collisionAlgorithmPool == null)
				{
					_collisionAlgorithmPool = new PoolAllocator(btCollisionConfiguration_getCollisionAlgorithmPool(Native), this);
				}
				return _collisionAlgorithmPool;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override PoolAllocator PersistentManifoldPool
		{
			get
			{
				if (_persistentManifoldPool == null)
				{
					_persistentManifoldPool = new PoolAllocator(btCollisionConfiguration_getPersistentManifoldPool(Native), this);
				}
				return _persistentManifoldPool;
			}
		}
	}
}
