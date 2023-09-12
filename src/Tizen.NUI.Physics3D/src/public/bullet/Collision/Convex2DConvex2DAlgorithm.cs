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
	public class Convex2DConvex2DAlgorithm : ActivatingCollisionAlgorithm
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public class CreateFunc : CollisionAlgorithmCreateFunc
		{
			private ConvexPenetrationDepthSolver _pdSolver;
			private VoronoiSimplexSolver _simplexSolver;

			internal CreateFunc(IntPtr native, BulletObject owner)
				: base(ConstructionInfo.Null)
			{
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public CreateFunc(VoronoiSimplexSolver simplexSolver, ConvexPenetrationDepthSolver pdSolver)
				: base(ConstructionInfo.Null)
			{
				IntPtr native = btConvex2dConvex2dAlgorithm_CreateFunc_new(simplexSolver.Native,
					pdSolver.Native);
				InitializeUserOwned(native);

				_pdSolver = pdSolver;
				_simplexSolver = simplexSolver;
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0,
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new Convex2DConvex2DAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int MinimumPointsPerturbationThreshold
			{
				get => btConvex2dConvex2dAlgorithm_CreateFunc_getMinimumPointsPerturbationThreshold(Native);
				set => btConvex2dConvex2dAlgorithm_CreateFunc_setMinimumPointsPerturbationThreshold(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public int NumPerturbationIterations
			{
				get => btConvex2dConvex2dAlgorithm_CreateFunc_getNumPerturbationIterations(Native);
				set => btConvex2dConvex2dAlgorithm_CreateFunc_setNumPerturbationIterations(Native, value);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public ConvexPenetrationDepthSolver PdSolver
			{
				get => _pdSolver;
				set
				{
					btConvex2dConvex2dAlgorithm_CreateFunc_setPdSolver(Native, value.Native);
					_pdSolver = value;
				}
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public VoronoiSimplexSolver SimplexSolver
			{
				get => _simplexSolver;
				set
				{
					btConvex2dConvex2dAlgorithm_CreateFunc_setSimplexSolver(Native, value.Native);
					_simplexSolver = value;
				}
			}
		}

		internal Convex2DConvex2DAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Convex2DConvex2DAlgorithm(PersistentManifold mf, CollisionAlgorithmConstructionInfo ci,
			CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap, VoronoiSimplexSolver simplexSolver,
			ConvexPenetrationDepthSolver pdSolver, int numPerturbationIterations, int minimumPointsPerturbationThreshold)
		{
			IntPtr native = btConvex2dConvex2dAlgorithm_new(mf.Native, ci.Native, body0Wrap.Native,
				body1Wrap.Native, simplexSolver.Native, pdSolver.Native, numPerturbationIterations,
				minimumPointsPerturbationThreshold);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLowLevelOfDetail(bool useLowLevel)
		{
			btConvex2dConvex2dAlgorithm_setLowLevelOfDetail(Native, useLowLevel);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PersistentManifold Manifold => new PersistentManifold(btConvex2dConvex2dAlgorithm_getManifold(Native), this);
	}
}
