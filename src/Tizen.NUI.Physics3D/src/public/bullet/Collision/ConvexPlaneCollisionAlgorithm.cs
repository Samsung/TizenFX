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
using System.Numerics;
using static Tizen.NUI.Physics3D.Bullet.UnsafeNativeMethods;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ConvexPlaneCollisionAlgorithm : CollisionAlgorithm
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
				IntPtr native = btConvexPlaneCollisionAlgorithm_CreateFunc_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0,
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new ConvexPlaneCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int MinimumPointsPerturbationThreshold
			{
				get => btConvexPlaneCollisionAlgorithm_CreateFunc_getMinimumPointsPerturbationThreshold(Native);
				set => btConvexPlaneCollisionAlgorithm_CreateFunc_setMinimumPointsPerturbationThreshold(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int NumPerturbationIterations
			{
				get => btConvexPlaneCollisionAlgorithm_CreateFunc_getNumPerturbationIterations(Native);
				set => btConvexPlaneCollisionAlgorithm_CreateFunc_setNumPerturbationIterations(Native, value);
			}
		}

		internal ConvexPlaneCollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexPlaneCollisionAlgorithm(PersistentManifold mf, CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, bool isSwapped,
			int numPerturbationIterations, int minimumPointsPerturbationThreshold)
		{
			IntPtr native = btConvexPlaneCollisionAlgorithm_new(mf.Native, ci.Native, body0Wrap.Native,
				body1Wrap.Native, isSwapped, numPerturbationIterations, minimumPointsPerturbationThreshold);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void CollideSingleContact(Quaternion perturbeRot, CollisionObjectWrapper body0Wrap,
			CollisionObjectWrapper body1Wrap, DispatcherInfo dispatchInfo, ManifoldResult resultOut)
		{
			btConvexPlaneCollisionAlgorithm_collideSingleContact(Native, ref perturbeRot,
				body0Wrap.Native, body1Wrap.Native, dispatchInfo.Native, resultOut.Native);
		}
	}
}
