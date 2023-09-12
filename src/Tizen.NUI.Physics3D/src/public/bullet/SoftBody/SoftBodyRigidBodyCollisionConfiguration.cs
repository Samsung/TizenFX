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
	public sealed class SoftBodyRigidBodyCollisionConfiguration : DefaultCollisionConfiguration
	{
		public SoftBodyRigidBodyCollisionConfiguration()
			: base(ConstructionInfo.Null)
		{
			IntPtr native = btSoftBodyRigidBodyCollisionConfiguration_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SoftBodyRigidBodyCollisionConfiguration(DefaultCollisionConstructionInfo constructionInfo)
			: base(ConstructionInfo.Null)
		{
			if (constructionInfo == null)
			{
				throw new ArgumentNullException(nameof(constructionInfo));
			}

			IntPtr native = btSoftBodyRigidBodyCollisionConfiguration_new2(constructionInfo.Native);
			InitializeUserOwned(Native);

			_collisionAlgorithmPool = constructionInfo.CollisionAlgorithmPool;
			_persistentManifoldPool = constructionInfo.PersistentManifoldPool;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override CollisionAlgorithmCreateFunc GetCollisionAlgorithmCreateFunc(BroadphaseNativeType proxyType0,
			BroadphaseNativeType proxyType1)
		{
			IntPtr createFunc = btCollisionConfiguration_getCollisionAlgorithmCreateFunc(Native, (int)proxyType0, (int)proxyType1);
			if (proxyType0 == BroadphaseNativeType.SoftBodyShape && proxyType1 == BroadphaseNativeType.SoftBodyShape)
			{
				return new SoftSoftCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SoftBodyShape && BroadphaseProxy.IsConvex(proxyType1))
			{
				return new SoftRigidCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConvex(proxyType0) && proxyType1 == BroadphaseNativeType.SoftBodyShape)
			{
				return new SoftRigidCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (proxyType0 == BroadphaseNativeType.SoftBodyShape && BroadphaseProxy.IsConcave(proxyType1))
			{
				return new SoftBodyConcaveCollisionAlgorithm.CreateFunc(createFunc, this);
			}
			if (BroadphaseProxy.IsConcave(proxyType0) && proxyType1 == BroadphaseNativeType.SoftBodyShape)
			{
				return new SoftBodyConcaveCollisionAlgorithm.SwappedCreateFunc(createFunc, this);
			}
			return base.GetCollisionAlgorithmCreateFunc(proxyType0, proxyType1);
		}
	}
}
