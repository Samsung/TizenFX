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
	public class GImpactCollisionAlgorithm : ActivatingCollisionAlgorithm
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
				IntPtr native = btGImpactCollisionAlgorithm_CreateFunc_new();
				InitializeUserOwned(native);
			}

			[EditorBrowsable(EditorBrowsableState.Never)]
			public override CollisionAlgorithm CreateCollisionAlgorithm(CollisionAlgorithmConstructionInfo __unnamed0,
				CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap)
			{
				return new GImpactCollisionAlgorithm(btCollisionAlgorithmCreateFunc_CreateCollisionAlgorithm(
					Native, __unnamed0.Native, body0Wrap.Native, body1Wrap.Native), __unnamed0.Dispatcher);
			}
		}

		internal GImpactCollisionAlgorithm(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GImpactCollisionAlgorithm(CollisionAlgorithmConstructionInfo constructionInfo, CollisionObjectWrapper body0Wrap,
			CollisionObjectWrapper body1Wrap)
		{
			IntPtr native = btGImpactCollisionAlgorithm_new(constructionInfo.Native, body0Wrap.Native,
				body1Wrap.Native);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GImpactVsCompoundShape(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap,
			GImpactShapeInterface shape0, CompoundShape shape1, bool swapped)
		{
			btGImpactCollisionAlgorithm_gimpact_vs_compoundshape(Native, body0Wrap.Native,
				body1Wrap.Native, shape0.Native, shape1.Native, swapped);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GImpactVsConcave(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap,
			GImpactShapeInterface shape0, ConcaveShape shape1, bool swapped)
		{
			btGImpactCollisionAlgorithm_gimpact_vs_concave(Native, body0Wrap.Native,
				body1Wrap.Native, shape0.Native, shape1.Native, swapped);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GImpactVsGImpact(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap,
			GImpactShapeInterface shape0, GImpactShapeInterface shape1)
		{
			btGImpactCollisionAlgorithm_gimpact_vs_gimpact(Native, body0Wrap.Native,
				body1Wrap.Native, shape0.Native, shape1.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GImpactVsShape(CollisionObjectWrapper body0Wrap, CollisionObjectWrapper body1Wrap,
			GImpactShapeInterface shape0, CollisionShape shape1, bool swapped)
		{
			btGImpactCollisionAlgorithm_gimpact_vs_shape(Native, body0Wrap.Native,
				body1Wrap.Native, shape0.Native, shape1.Native, swapped);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ManifoldResult InternalGetResultOut()
		{
			return new ManifoldResult(btGImpactCollisionAlgorithm_internalGetResultOut(Native), this);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void RegisterAlgorithm(CollisionDispatcher dispatcher)
		{
			btGImpactCollisionAlgorithm_registerAlgorithm(dispatcher.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Face0
		{
			get => btGImpactCollisionAlgorithm_getFace0(Native);
			set => btGImpactCollisionAlgorithm_setFace0(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Face1
		{
			get => btGImpactCollisionAlgorithm_getFace1(Native);
			set => btGImpactCollisionAlgorithm_setFace1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Part0
		{
			get => btGImpactCollisionAlgorithm_getPart0(Native);
			set => btGImpactCollisionAlgorithm_setPart0(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int Part1
		{
			get => btGImpactCollisionAlgorithm_getPart1(Native);
			set => btGImpactCollisionAlgorithm_setPart1(Native, value);
		}
	}
}
