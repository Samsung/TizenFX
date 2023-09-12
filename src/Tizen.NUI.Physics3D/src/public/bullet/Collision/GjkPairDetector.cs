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
	public class GjkPairDetector : DiscreteCollisionDetectorInterface
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public GjkPairDetector(ConvexShape objectA, ConvexShape objectB, VoronoiSimplexSolver simplexSolver,
			ConvexPenetrationDepthSolver penetrationDepthSolver)
		{
			IntPtr native = btGjkPairDetector_new(objectA.Native, objectB.Native, simplexSolver.Native,
				(penetrationDepthSolver != null) ? penetrationDepthSolver.Native : IntPtr.Zero);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GjkPairDetector(ConvexShape objectA, ConvexShape objectB, int shapeTypeA,
			int shapeTypeB, float marginA, float marginB, VoronoiSimplexSolver simplexSolver,
			ConvexPenetrationDepthSolver penetrationDepthSolver)
		{
			IntPtr native = btGjkPairDetector_new2(objectA.Native, objectB.Native, shapeTypeA,
				shapeTypeB, marginA, marginB, simplexSolver.Native,
				(penetrationDepthSolver != null) ? penetrationDepthSolver.Native : IntPtr.Zero);
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void GetClosestPointsNonVirtual(ClosestPointInput input, Result output,
			DebugDraw debugDraw)
		{
			btGjkPairDetector_getClosestPointsNonVirtual(Native, input.Native,
				output.Native, debugDraw != null ? debugDraw.Native : IntPtr.Zero);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetIgnoreMargin(bool ignoreMargin)
		{
			btGjkPairDetector_setIgnoreMargin(Native, ignoreMargin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMinkowskiA(ConvexShape minkA)
		{
			btGjkPairDetector_setMinkowskiA(Native, minkA.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetMinkowskiB(ConvexShape minkB)
		{
			btGjkPairDetector_setMinkowskiB(Native, minkB.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetPenetrationDepthSolver(ConvexPenetrationDepthSolver penetrationDepthSolver)
		{
			btGjkPairDetector_setPenetrationDepthSolver(Native, penetrationDepthSolver.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedSeparatingAxis
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btGjkPairDetector_getCachedSeparatingAxis(Native, out value);
				return value;
			}
			set => btGjkPairDetector_setCachedSeparatingAxis(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float CachedSeparatingDistance => btGjkPairDetector_getCachedSeparatingDistance(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CatchDegeneracies
		{
			get => btGjkPairDetector_getCatchDegeneracies(Native);
			set => btGjkPairDetector_setCatchDegeneracies(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int CurIter
		{
			get => btGjkPairDetector_getCurIter(Native);
			set => btGjkPairDetector_setCurIter(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int DegenerateSimplex
		{
			get => btGjkPairDetector_getDegenerateSimplex(Native);
			set => btGjkPairDetector_setDegenerateSimplex(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int FixContactNormalDirection
		{
			get => btGjkPairDetector_getFixContactNormalDirection(Native);
			set => btGjkPairDetector_setFixContactNormalDirection(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int LastUsedMethod
		{
			get => btGjkPairDetector_getLastUsedMethod(Native);
			set => btGjkPairDetector_setLastUsedMethod(Native, value);
		}
	}
}
