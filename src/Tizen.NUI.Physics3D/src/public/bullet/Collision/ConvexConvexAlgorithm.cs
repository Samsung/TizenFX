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
	public class ConvexConvexAlgorithm : ActivatingCollisionAlgorithm
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class CreateFunc : CollisionAlgorithmCreateFunc
		{
			private ConvexPenetrationDepthSolver _pdSolver;

			internal CreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
				InitializeSubObject(native, owner);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CreateFunc(ConvexPenetrationDepthSolver pdSolver)
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btConvexConvexAlgorithm_CreateFunc_new(pdSolver.Native);
				InitializeUserOwned(native);
				_pdSolver = pdSolver;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0, 
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new ConvexConvexAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int MinimumPointsPerturbationThreshold
			{
				get => btConvexConvexAlgorithm_CreateFunc_getMinimumPointsPerturbationThreshold(Native);
				set => btConvexConvexAlgorithm_CreateFunc_setMinimumPointsPerturbationThreshold(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int NumPerturbationIterations
			{
				get => btConvexConvexAlgorithm_CreateFunc_getNumPerturbationIterations(Native);
				set => btConvexConvexAlgorithm_CreateFunc_setNumPerturbationIterations(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public ConvexPenetrationDepthSolver PdSolver
			{
				get => _pdSolver;
				set
				{
					btConvexConvexAlgorithm_CreateFunc_setPdSolver(Native, value.Native);
					_pdSolver = value;
				}
			}
		}

		internal ConvexConvexAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConvexConvexAlgorithm(PersistentManifold mf, CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, VoronoiSimplexSolver simplexSolver,
			ConvexPenetrationDepthSolver pdSolver, int numPerturbationIterations, int minimumPointsPerturbationThreshold)
			: base()
		{
			IntPtr native = btConvexConvexAlgorithm_new(mf.Native, ci.Native, body0Wrap.Native,
				body1Wrap.Native, simplexSolver.Native, pdSolver.Native, numPerturbationIterations,
				minimumPointsPerturbationThreshold);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLowLevelOfDetail(bool useLowLevel)
		{
			btConvexConvexAlgorithm_setLowLevelOfDetail(Native, useLowLevel);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold Manifold => new PersistentManifold(btConvexConvexAlgorithm_getManifold(Native), this);
	}
}
