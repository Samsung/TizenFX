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
	public class UsageBitfield : BulletObject
	{
		internal UsageBitfield(IntPtr native)
		{
			Initialize(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btUsageBitfield_reset(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Unused1
		{
			get => btUsageBitfield_getUnused1(Native);
			set => btUsageBitfield_setUnused1(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Unused2
		{
			get => btUsageBitfield_getUnused2(Native);
			set => btUsageBitfield_setUnused2(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Unused3
		{
			get => btUsageBitfield_getUnused3(Native);
			set => btUsageBitfield_setUnused3(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Unused4
		{
			get => btUsageBitfield_getUnused4(Native);
			set => btUsageBitfield_setUnused4(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UsedVertexA
		{
			get => btUsageBitfield_getUsedVertexA(Native);
			set => btUsageBitfield_setUsedVertexA(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UsedVertexB
		{
			get => btUsageBitfield_getUsedVertexB(Native);
			set => btUsageBitfield_setUsedVertexB(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UsedVertexC
		{
			get => btUsageBitfield_getUsedVertexC(Native);
			set => btUsageBitfield_setUsedVertexC(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UsedVertexD
		{
			get => btUsageBitfield_getUsedVertexD(Native);
			set => btUsageBitfield_setUsedVertexD(Native, value);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class SubSimplexClosestResult : BulletDisposableObject
	{
		internal SubSimplexClosestResult(IntPtr native, BulletObject owner)
		{
			InitializeSubObject(native, owner);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SubSimplexClosestResult()
		{
			IntPtr native = btSubSimplexClosestResult_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btSubSimplexClosestResult_reset(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBarycentricCoordinates()
		{
			btSubSimplexClosestResult_setBarycentricCoordinates(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBarycentricCoordinates(float a)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates2(Native, a);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBarycentricCoordinates(float a, float b)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates3(Native, a, b);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBarycentricCoordinates(float a, float b, float c)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates4(Native, a, b, c);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetBarycentricCoordinates(float a, float b, float c, float d)
		{
			btSubSimplexClosestResult_setBarycentricCoordinates5(Native, a, b, c,
				d);
		}
		/*
		public FloatArray BarycentricCoords
		{
			get { return btSubSimplexClosestResult_getBarycentricCoords(Native); }
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 ClosestPointOnSimplex
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btSubSimplexClosestResult_getClosestPointOnSimplex(Native, out value);
				return value;
			}
			set => btSubSimplexClosestResult_setClosestPointOnSimplex(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Degenerate
		{
			get => btSubSimplexClosestResult_getDegenerate(Native);
			set => btSubSimplexClosestResult_setDegenerate(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool IsValid => btSubSimplexClosestResult_isValid(Native);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UsageBitfield UsedVertices
		{
			get => new UsageBitfield(btSubSimplexClosestResult_getUsedVertices(Native));
			set => btSubSimplexClosestResult_setUsedVertices(Native, value.Native);
		}

		protected override void Dispose(bool disposing)
		{
			btSubSimplexClosestResult_delete(Native);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public class VoronoiSimplexSolver : BulletDisposableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public VoronoiSimplexSolver()
		{
			IntPtr native = btVoronoiSimplexSolver_new();
			InitializeUserOwned(native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVertexRef(ref global::System.Numerics.Vector3 w, ref global::System.Numerics.Vector3 p, ref global::System.Numerics.Vector3 q)
		{
			btVoronoiSimplexSolver_addVertex(Native, ref w, ref p, ref q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void AddVertex(global::System.Numerics.Vector3 w, global::System.Numerics.Vector3 p, global::System.Numerics.Vector3 q)
		{
			btVoronoiSimplexSolver_addVertex(Native, ref w, ref p, ref q);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void BackupClosest(out global::System.Numerics.Vector3 v)
		{
			btVoronoiSimplexSolver_backup_closest(Native, out v);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool Closest(out global::System.Numerics.Vector3 v)
		{
			return btVoronoiSimplexSolver_closest(Native, out v);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ClosestPtPointTetrahedronRef(ref global::System.Numerics.Vector3 p, ref global::System.Numerics.Vector3 a, ref global::System.Numerics.Vector3 b, ref global::System.Numerics.Vector3 c,
			ref global::System.Numerics.Vector3 d, SubSimplexClosestResult finalResult)
		{
			return btVoronoiSimplexSolver_closestPtPointTetrahedron(Native, ref p,
				ref a, ref b, ref c, ref d, finalResult.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ClosestPtPointTetrahedron(global::System.Numerics.Vector3 p, global::System.Numerics.Vector3 a, global::System.Numerics.Vector3 b, global::System.Numerics.Vector3 c,
		 	global::System.Numerics.Vector3 d, SubSimplexClosestResult finalResult)
		{
			return btVoronoiSimplexSolver_closestPtPointTetrahedron(Native, ref p,
				ref a, ref b, ref c, ref d, finalResult.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ClosestPtPointTriangleRef(ref global::System.Numerics.Vector3 p, ref global::System.Numerics.Vector3 a, ref global::System.Numerics.Vector3 b, ref global::System.Numerics.Vector3 c,
			SubSimplexClosestResult result)
		{
			return btVoronoiSimplexSolver_closestPtPointTriangle(Native, ref p,
				ref a, ref b, ref c, result.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ClosestPtPointTriangle(global::System.Numerics.Vector3 p, global::System.Numerics.Vector3 a, global::System.Numerics.Vector3 b, global::System.Numerics.Vector3 c,
			SubSimplexClosestResult result)
		{
			return btVoronoiSimplexSolver_closestPtPointTriangle(Native, ref p,
				ref a, ref b, ref c, result.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ComputePoints(out global::System.Numerics.Vector3 p1, out global::System.Numerics.Vector3 p2)
		{
			btVoronoiSimplexSolver_compute_points(Native, out p1, out p2);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool EmptySimplex()
		{
			return btVoronoiSimplexSolver_emptySimplex(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool FullSimplex()
		{
			return btVoronoiSimplexSolver_fullSimplex(Native);
		}
		/*
		public int GetSimplex(global::System.Numerics.Vector3[] pBuf, global::System.Numerics.Vector3[] qBuf, global::System.Numerics.Vector3[] yBuf)
		{
			return btVoronoiSimplexSolver_getSimplex(Native, pBuf, qBuf,
				yBuf);
		}
		*/
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool InSimplex(global::System.Numerics.Vector3 w)
		{
			return btVoronoiSimplexSolver_inSimplex(Native, ref w);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float MaxVertex()
		{
			return btVoronoiSimplexSolver_maxVertex(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int PointOutsideOfPlane(global::System.Numerics.Vector3 p, global::System.Numerics.Vector3 a, global::System.Numerics.Vector3 b, global::System.Numerics.Vector3 c,
		 	global::System.Numerics.Vector3 d)
		{
			return btVoronoiSimplexSolver_pointOutsideOfPlane(Native, ref p, ref a,
				ref b, ref c, ref d);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void ReduceVertices(UsageBitfield usedVerts)
		{
			btVoronoiSimplexSolver_reduceVertices(Native, usedVerts.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RemoveVertex(int index)
		{
			btVoronoiSimplexSolver_removeVertex(Native, index);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Reset()
		{
			btVoronoiSimplexSolver_reset(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UpdateClosestVectorAndPoints()
		{
			return btVoronoiSimplexSolver_updateClosestVectorAndPoints(Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SubSimplexClosestResult CachedBC
		{
			get => new SubSimplexClosestResult(btVoronoiSimplexSolver_getCachedBC(Native), this);
			set => btVoronoiSimplexSolver_setCachedBC(Native, value.Native);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedP1
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btVoronoiSimplexSolver_getCachedP1(Native, out value);
				return value;
			}
			set => btVoronoiSimplexSolver_setCachedP1(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedP2
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btVoronoiSimplexSolver_getCachedP2(Native, out value);
				return value;
			}
			set => btVoronoiSimplexSolver_setCachedP2(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 CachedV
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btVoronoiSimplexSolver_getCachedV(Native, out value);
				return value;
			}
			set => btVoronoiSimplexSolver_setCachedV(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool CachedValidClosest
		{
			get => btVoronoiSimplexSolver_getCachedValidClosest(Native);
			set => btVoronoiSimplexSolver_setCachedValidClosest(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public float EqualVertexThreshold
		{
			get => btVoronoiSimplexSolver_getEqualVertexThreshold(Native);
			set => btVoronoiSimplexSolver_setEqualVertexThreshold(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public global::System.Numerics.Vector3 LastW
		{
			get
			{
			 	global::System.Numerics.Vector3 value;
				btVoronoiSimplexSolver_getLastW(Native, out value);
				return value;
			}
			set => btVoronoiSimplexSolver_setLastW(Native, ref value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool NeedsUpdate
		{
			get => btVoronoiSimplexSolver_getNeedsUpdate(Native);
			set => btVoronoiSimplexSolver_setNeedsUpdate(Native, value);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public int NumVertices
		{
			get => btVoronoiSimplexSolver_getNumVertices(Native);
			set => btVoronoiSimplexSolver_setNumVertices(Native, value);
		}
		/*
		public global::System.Numerics.Vector3[] SimplexPointsP
		{
			get { return btVoronoiSimplexSolver_getSimplexPointsP(Native); }
		}

		public global::System.Numerics.Vector3[] SimplexPointsQ
		{
			get { return btVoronoiSimplexSolver_getSimplexPointsQ(Native); }
		}

		public global::System.Numerics.Vector3[] SimplexVectorW
		{
			get { return btVoronoiSimplexSolver_getSimplexVectorW(Native); }
		}
		*/

		protected override void Dispose(bool disposing)
		{
			btVoronoiSimplexSolver_delete(Native);
		}
	}
}
