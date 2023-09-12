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

using System.Numerics;
using System.ComponentModel;

namespace Tizen.NUI.Physics3D.Bullet
{
	internal class MyCallback : TriangleRaycastCallback
	{
		private readonly int _ignorePart;
		private readonly int _ignoreTriangleIndex;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyCallback(ref global::System.Numerics.Vector3 from, ref global::System.Numerics.Vector3 to, int ignorePart, int ignoreTriangleIndex)
			: base(ref from, ref to)
		{
			_ignorePart = ignorePart;
			_ignoreTriangleIndex = ignoreTriangleIndex;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override float ReportHit(ref global::System.Numerics.Vector3 hitNormalLocal, float hitFraction, int partId, int triangleIndex)
		{
			if (partId != _ignorePart || triangleIndex != _ignoreTriangleIndex)
			{
				if (hitFraction < HitFraction)
					return hitFraction;
			}

			return HitFraction;
		}
	}

	internal class MyInternalTriangleIndexCallback : InternalTriangleIndexCallback
	{
		private readonly CompoundShape _collisionShape;
		private readonly float _depth;
		private readonly GImpactMeshShape _meshShape;
		//private readonly static global::System.Numerics.Vector3 _redColor = new global::System.Numerics.Vector3(1, 0, 0);

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyInternalTriangleIndexCallback(CompoundShape collisionShape, GImpactMeshShape meshShape, float depth)
		{
			_collisionShape = collisionShape;
			_depth = depth;
			_meshShape = meshShape;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void InternalProcessTriangleIndex(ref global::System.Numerics.Vector3 vertex0, ref global::System.Numerics.Vector3 vertex1, ref global::System.Numerics.Vector3 vertex2, int partId, int triangleIndex)
		{
		 global::System.Numerics.Vector3 scale = _meshShape.LocalScaling;
		 global::System.Numerics.Vector3 v0 = vertex0 * scale;
		 global::System.Numerics.Vector3 v1 = vertex1 * scale;
		 global::System.Numerics.Vector3 v2 = vertex2 * scale;

		 global::System.Numerics.Vector3 centroid = (v0 + v1 + v2) / 3;
		 global::System.Numerics.Vector3 normal = global::System.Numerics.Vector3.Cross(v1 - v0, v2 - v0);
			normal = global::System.Numerics.Vector3.Normalize(normal);
		 global::System.Numerics.Vector3 rayFrom = centroid;
		 global::System.Numerics.Vector3 rayTo = centroid - normal * _depth;

			using (var cb = new MyCallback(ref rayFrom, ref rayTo, partId, triangleIndex))
			{
				_meshShape.ProcessAllTrianglesRayRef(cb, ref rayFrom, ref rayTo);
				if (cb.HitFraction < 1)
				{
					rayTo = global::System.Numerics.Vector3.Lerp(cb.From, cb.To, cb.HitFraction);
					//rayTo = cb.From;
					//Vector3 to = centroid + normal;
					//debugDraw.DrawLine(ref centroid, ref to, ref _redColor);
				}
			}

			var triangle = new BuSimplex1To4(v0, v1, v2, rayTo);
			_collisionShape.AddChildShape(Matrix4x4.Identity, triangle);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class CompoundFromGImpact
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static CompoundShape Create(GImpactMeshShape impactMesh, float depth)
		{
			var shape = new CompoundShape();
			using (var callback = new MyInternalTriangleIndexCallback(shape, impactMesh, depth))
			{
			 global::System.Numerics.Vector3 aabbMin, aabbMax;
				impactMesh.GetAabb(Matrix4x4.Identity, out aabbMin, out aabbMax);
				impactMesh.MeshInterface.InternalProcessAllTriangles(callback, aabbMin, aabbMax);
			}
			return shape;
		}
	}
}
