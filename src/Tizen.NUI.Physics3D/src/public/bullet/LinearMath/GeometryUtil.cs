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

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;

namespace Tizen.NUI.Physics3D.Bullet
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class GeometryUtil
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool AreVerticesBehindPlane(global::System.Numerics.Vector3 planeNormal, float planeConstant, IEnumerable<global::System.Numerics.Vector3> vertices,
			float margin)
		{
			return vertices.All(v => global::System.Numerics.Vector3.Dot(planeNormal, v) + planeConstant <= margin);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static List<global::System.Numerics.Vector4> GetPlaneEquationsFromVertices(ICollection<global::System.Numerics.Vector3> vertices)
		{
			int numVertices = vertices.Count;
			global::System.Numerics.Vector3[] vertexArray = vertices.ToArray();
			var planeEquations = new List<global::System.Numerics.Vector4>();

			for (int i = 0; i < numVertices; i++)
			{
				for (int j = i + 1; j < numVertices; j++)
				{
					for (int k = j + 1; k < numVertices; k++)
					{
					 	global::System.Numerics.Vector3 edge0 = vertexArray[j] - vertexArray[i];
					 	global::System.Numerics.Vector3 edge1 = vertexArray[k] - vertexArray[i];

					 	global::System.Numerics.Vector3 normal = global::System.Numerics.Vector3.Cross(edge0, edge1);
						if (normal.LengthSquared() > 0.0001)
						{
							normal = global::System.Numerics.Vector3.Normalize(normal);
							if (!Vector4EnumerableContainsVector3(planeEquations, normal))
							{
								float constant = -global::System.Numerics.Vector3.Dot(normal, vertexArray[i]);
								if (AreVerticesBehindPlane(normal, constant, vertexArray, 0.01f))
								{
									planeEquations.Add(new global::System.Numerics.Vector4(normal, constant));
								}
							}

							normal = -normal;
							if (!Vector4EnumerableContainsVector3(planeEquations, normal))
							{
								float constant = -global::System.Numerics.Vector3.Dot(normal, vertexArray[i]);
								if (AreVerticesBehindPlane(normal, constant, vertexArray, 0.01f))
								{
									planeEquations.Add(new global::System.Numerics.Vector4(normal, constant));
								}
							}
						}
					}
				}
			}

			return planeEquations;
		}

		private static bool Vector4EnumerableContainsVector3(IEnumerable<global::System.Numerics.Vector4> vertices, global::System.Numerics.Vector3 vertex)
		{
			return vertices.Any(v => {
				var v3 = new global::System.Numerics.Vector3(v.X, v.Y, v.Z);
				return global::System.Numerics.Vector3.Dot(v3, vertex) > 0.999;
			});
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static List< global::System.Numerics.Vector3> GetVerticesFromPlaneEquations(ICollection< global::System.Numerics.Vector4> planeEquations)
		{
			int numPlanes = planeEquations.Count;
		 	global::System.Numerics.Vector3[] planeNormals = new global::System.Numerics.Vector3[numPlanes];
			float[] planeConstants = new float[numPlanes];
			int i = 0;
			foreach (global::System.Numerics.Vector4 plane in planeEquations)
			{
				planeNormals[i] = new global::System.Numerics.Vector3(plane.X, plane.Y, plane.Z);
				planeConstants[i] = plane.W;
				i++;
			}

			var vertices = new List<global::System.Numerics.Vector3>();

			for (i = 0; i < numPlanes; i++)
			{
				for (int j = i + 1; j < numPlanes; j++)
				{
					for (int k = j + 1; k < numPlanes; k++)
					{
						global::System.Numerics.Vector3 n2n3 = global::System.Numerics.Vector3.Cross(planeNormals[j], planeNormals[k]);
						global::System.Numerics.Vector3 n3n1 = global::System.Numerics.Vector3.Cross(planeNormals[k], planeNormals[i]);
						global::System.Numerics.Vector3 n1n2 = global::System.Numerics.Vector3.Cross(planeNormals[i], planeNormals[j]);

						if ((n2n3.LengthSquared() > 0.0001f) &&
							 (n3n1.LengthSquared() > 0.0001f) &&
							 (n1n2.LengthSquared() > 0.0001f))
						{
							//point P out of 3 plane equations:

							//	  d1 ( N2 * N3 ) + d2 ( N3 * N1 ) + d3 ( N1 * N2 )  
							//P = ------------------------------------------------
							//	N1 . ( N2 * N3 )  

							float quotient = global::System.Numerics.Vector3.Dot(planeNormals[i], n2n3);
							if (global::System.Math.Abs(quotient) > 0.000001)
							{
								quotient = -1.0f / quotient;
								n2n3 *= planeConstants[i];
								n3n1 *= planeConstants[j];
								n1n2 *= planeConstants[k];
								global::System.Numerics.Vector3 potentialPoint = quotient * (n2n3 + n3n1 + n1n2);

								//check if inside, and replace supportingVertexOut if needed
								if (IsPointInsidePlanes(planeEquations, potentialPoint, 0.01f))
								{
									vertices.Add(potentialPoint);
								}
							}
						}
					}
				}
			}

			return vertices;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static bool IsPointInsidePlanes(IEnumerable<global::System.Numerics.Vector4> planeEquations, global::System.Numerics.Vector3 point, float margin)
		{
			return planeEquations.All(p => global::System.Numerics.Vector3.Dot(new global::System.Numerics.Vector3(p.X, p.Y, p.Z), point) + p.W <= margin);
		}
	}
}
